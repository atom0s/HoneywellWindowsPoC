/**
 * Honeywell Total Connect 2.0 Windows Remake
 * Proof of Concept
 * 
 * (c) 2012-2014 atom0s [atom0s@live.com]
 */
namespace SecuritySystemTest
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public partial class frmMain : Form
    {
        /// <summary>
        /// Internal Total Control service client.
        /// </summary>
        private readonly TotalControlService.svcTC2APISoapClient m_Client;

        /// <summary>
        /// Internal Total Control service session info.
        /// </summary>
        private TotalControlService.SessionDetailResults m_SessionInfo;

        /// <summary>
        /// Internal Total Control session key.
        /// </summary>
        private string m_SessionKey;

        /// <summary>
        /// Internal state to check if a poll response is required.
        /// </summary>
        private bool m_PollForResult;

        /// <summary>
        /// Internal thread to keep login session valid.
        /// </summary>
        private Thread m_KeepAliveThread;

        /// <summary>
        /// Internal exit flag for keep alive thread.
        /// </summary>
        private bool m_IsExiting;

        /// <summary>
        /// NOTE: 
        /// 
        /// This may be required for some calls, I did not thoroughly test.
        /// If it is, set it to the 4 digit pin code you use to access your alarm system.
        /// </summary>
        private int m_PinCode = 0;

        /// <summary>
        /// Internal enumeration of the alarm state.
        /// </summary>
        private enum AlarmState
        {
            ALARM_CANCEL_STATUS_CODE = 10213,
            ALARM_SILENCED_STATUS_CODE = 10216,
            ALARM_STATUS_CODE = 10207,
            ARMED_AWAY_BYPASS_STATUS_CODE = 10202,
            ARMED_AWAY_INSTANT_BYPASS_STATUS_CODE = 10206,
            ARMED_AWAY_INSTANT_STATUS_CODE = 10205,
            ARMED_AWAY_STATUS_CODE = 10201,
            ARMED_STAY_BYPASS_STATUS_CODE = 10204,
            ARMED_STAY_INSTANT_BYPASS_STATUS_CODE = 10210,
            ARMED_STAY_INSTANT_STATUS_CODE = 10209,
            ARMED_STAY_STATUS_CODE = 10203,
            ARMING_STATUS_CODE = 10307,
            BEGIN_SECURITY_STATUS_POLLING_RESULT_CODE = 4500,
            BYPASS_CLEARED_STATUS_CODE = 10107,
            COMMAND_FAIL_LAUNCH_KEYPAD_RESULT_CODE = -4502,
            CO_STATUS_CODE = 10215,
            DISARMED_BYPASS_STATUS_CODE = 10211,
            DISARMED_NOT_READY_STATUS_CODE = 0,
            DISARMED_STATUS_CODE = 10200,
            DISARMING_STATUS_CODE = 10308,
            FIRE_STATUS_CODE = 10212,
            META_UPDATE_REQUIRED_RESULT_CODE = 4002,
            NOTHING_CHANGED_RESULT_CODE = 4001,
            STATUS_IS_ARMED = 0,
            STATUS_IS_ARMING = 2,
            STATUS_IS_DISARMED = 1,
            STATUS_IS_DISARMING = 3,
            STATUS_IS_NOT_AVAILABLE = 4,
        }

        /// <summary>
        /// Internal enumeration of the alarm arm type.
        /// </summary>
        private enum ArmType
        {
            ARM_TYPE_NONE = -100,
            ARM_TYPE_DISARM = -1,
            ARM_TYPE_ARM_AWAY = 0,
            ARM_TYPE_ARM_STAY = 1,
            ARM_TYPE_ARM_INSTANT = 2,
            ARM_TYPE_ARM_MAX = 3,
            ARM_TYPE_NIGHT_STAY = 4,
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            // Prepare variables..
            this.m_Client = new TotalControlService.svcTC2APISoapClient("svcTC2APISoap");
            this.m_SessionKey = string.Empty;
            this.m_KeepAliveThread = null;
            this.m_IsExiting = false;
        }

        /// <summary>
        /// Form load event used to login to the Total Control service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Form unload event to logout of the Total Control service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kill the keep-alive thread..
            if (this.m_KeepAliveThread != null)
            {
                this.m_IsExiting = true;
                while (this.m_KeepAliveThread.IsAlive)
                {
                    this.m_KeepAliveThread.Abort();
                    this.m_KeepAliveThread.Join(1000);
                }
            }

            // Logout of our session..
            if (!string.IsNullOrEmpty(this.m_SessionKey))
                this.m_Client.Logout(this.m_SessionKey);
        }

        /// <summary>
        /// Thread handler to keep login session alive.
        /// </summary>
        private void DoKeepAlive()
        {
            var tickKeepAlive = 1000;
            var tickPanelSync = 1000;

            while (!this.m_IsExiting)
            {
                Thread.Sleep(1000);

                // Tick the markers..
                tickKeepAlive++;
                tickPanelSync++;

                // Obtain last result if required..
                if (this.m_PollForResult)
                {
                    var panelResult = this.m_Client.CheckSecurityPanelLastCommandState(this.m_SessionKey, this.m_SessionInfo.Locations[0].LocationID, this.m_SessionInfo.Locations[0].DeviceList[0].DeviceID, -1);
                    this.InvokeEx(f => f.lstLog.Items.Add(string.Format("Panel Result: {0} - {1}", panelResult.ResultCode, panelResult.ResultData)));
                    this.m_PollForResult = false;
                }

                // Determine if we should pulse a keep alive..
                if (tickKeepAlive >= 30)
                {
                    // Pulse keep alive to service..
                    var keepAlive = this.m_Client.KeepAlive(this.m_SessionKey);
                    if (keepAlive.ResultCode != 0)
                    {
                        this.InvokeEx(f =>
                            {
                                f.lblLoginStatus.Text = "Not Connected";
                                f.lblLoginStatus.ForeColor = Color.Red;
                                f.lblKeepAliveStatus.Text = "Session died at: " + DateTime.Now;
                            });
                        break;
                    }

                    this.InvokeEx(f => f.lblKeepAliveStatus.Text = "Last Ping: " + DateTime.Now);
                    tickKeepAlive = 0;
                }

                // Determine if we should pulse a panel sync..
                if (tickPanelSync >= 5)
                {
                    // Obtain the main panel information..
                    var partOneStatus = this.m_Client.GetPanelMetaDataAndFullStatusByDeviceID(
                        this.m_SessionKey,
                        this.m_SessionInfo.Locations[0].DeviceList[0].DeviceID,
                        0, 0, 1
                        );

                    if (partOneStatus.ResultCode == 0)
                        this.InvokeEx(f => f.lblPartitionOneStatus.Text = ((AlarmState)partOneStatus.PanelMetadataAndStatus.Partitions[0].ArmingState).ToString());
                    else
                        this.InvokeEx(f => f.lblPartitionOneStatus.Text = "Not Connected");

                    var zoneInfo = this.m_Client.GetZonesListInState(
                        this.m_SessionKey,
                        this.m_SessionInfo.Locations[0].LocationID, 1, 0);
                    if (zoneInfo.ResultCode == 0)
                    {
                        this.InvokeEx(f =>
                            {
                                f.lstZoneList.Items.Clear();
                                foreach (var zone in zoneInfo.ZoneStatus.Zones)
                                {
                                    if (zone.ZoneStatus == 0)
                                        continue;

                                    f.lstZoneList.Items.Add(string.Format("Zone: {0} -- Status: {1}",
                                        GetZoneName(partOneStatus, zone.ZoneID), 
                                        DetermineZoneStatus(zone.ZoneStatus)));
                                }
                            });
                    }

                    tickPanelSync = 0;
                }
            }
        }
        
        /// <summary>
        /// Attempts to login to the Total Control service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate the username and password..
            if (string.IsNullOrEmpty(this.txtUsername.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Please ensure both the username and password are filled in!");
                return;
            }

            // Attempt to login..
            var result = this.m_Client.AuthenticateUserLogin(this.txtUsername.Text, this.txtPassword.Text, 34857971, "2.2.0");
            if (result.ResultCode != 0 || string.IsNullOrEmpty(result.SessionID))
            {
                MessageBox.Show("Failed to login to account. Result was: " + result.ResultCode);
                return;
            }

            // Obtain the session details..
            var sessionDetails = this.m_Client.GetSessionDetails(result.SessionID, 34857971, "2.2.0");
            if (sessionDetails == null || sessionDetails.ResultCode != 0)
            {
                MessageBox.Show("Failed to obtain session details. Result was: " + result.ResultCode);
                return;
            }

            // Login successful..
            this.m_SessionInfo = sessionDetails;
            this.m_SessionKey = result.SessionID;
            this.btnLogin.Enabled = false;
            this.lblLoginStatus.Text = "Connected!";
            this.lblLoginStatus.ForeColor = Color.Green;

            // Create keep-alive thread..
            this.m_KeepAliveThread = new Thread(DoKeepAlive)
                {
                    IsBackground = true
                };
            this.m_KeepAliveThread.Start();
        }

        /// <summary>
        /// Button handler to disarm the alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisarm_Click(object sender, EventArgs e)
        {
            // Validation checks..
            if (this.m_SessionInfo == null || string.IsNullOrEmpty(this.m_SessionKey))
                return;

            var result = this.m_Client.DisarmSecuritySystem(
                this.m_SessionKey,
                this.m_SessionInfo.Locations[0].LocationID,
                this.m_SessionInfo.Locations[0].DeviceList[0].DeviceID,
                -1);

            if (result.ResultCode != 0)
            {
                if (result.ResultCode == 4500)
                    this.m_PollForResult = true;
                this.lstLog.Items.Add(string.Format("[DISARM] Failed with error code: {0} - {1}", result.ResultCode, result.ResultData));
            }
        }

        /// <summary>
        /// Button handler to arm (away) the alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArmAway_Click(object sender, EventArgs e)
        {
            // Validation checks..
            if (this.m_SessionInfo == null || string.IsNullOrEmpty(this.m_SessionKey))
                return;

            var result = this.m_Client.ArmSecuritySystem(
                this.m_SessionKey,
                this.m_SessionInfo.Locations[0].LocationID,
                this.m_SessionInfo.Locations[0].DeviceList[0].DeviceID,
                (int)ArmType.ARM_TYPE_ARM_AWAY, this.m_PinCode);

            if (result.ResultCode != 0)
            {
                if (result.ResultCode == 4500)
                    this.m_PollForResult = true;
                this.lstLog.Items.Add(string.Format("[ARMAWAY] Failed with error code: {0} - {1}", result.ResultCode, result.ResultData));
            }
        }

        /// <summary>
        /// Button handler to arm (stay) the alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArmStay_Click(object sender, EventArgs e)
        {
            // Validation checks..
            if (this.m_SessionInfo == null || string.IsNullOrEmpty(this.m_SessionKey))
                return;

            var result = this.m_Client.ArmSecuritySystem(
                this.m_SessionKey,
                this.m_SessionInfo.Locations[0].LocationID,
                this.m_SessionInfo.Locations[0].DeviceList[0].DeviceID,
                (int)ArmType.ARM_TYPE_ARM_STAY, this.m_PinCode);

            if (result.ResultCode != 0)
            {
                if (result.ResultCode == 4500)
                    this.m_PollForResult = true;
                this.lstLog.Items.Add(string.Format("[ARMSTAY] Failed with error code: {0} - {1}", result.ResultCode, result.ResultData));
            }
        }

        /// <summary>
        /// Obtains the zone name of the given zone id.
        /// </summary>
        /// <param name="panelInfo"></param>
        /// <param name="nZoneId"></param>
        /// <returns></returns>
        private string GetZoneName(TotalControlService.PanelMetadataAndStatusResults panelInfo, int nZoneId)
        {
            if (this.m_SessionInfo == null)
                return string.Format("UNKNOWN ZONE ({0})", nZoneId);

            foreach (var zone in panelInfo.PanelMetadataAndStatus.Zones)
            {
                if (zone.ZoneID == nZoneId)
                    return zone.ZoneDescription;
            }

            return string.Format("UNKNOWN ZONE ({0})", nZoneId);
        }

        /// <summary>
        /// Converts a zone status id to its string representation.
        /// </summary>
        /// <param name="nZoneStatus"></param>
        /// <returns></returns>
        private string DetermineZoneStatus(int nZoneStatus)
        {
            var flags = new List<string>();

            if (nZoneStatus == 0)
                flags.Add("Normal");
            if ((nZoneStatus & 1) > 0)
                flags.Add("Bypassed");
            if ((nZoneStatus & 2) > 0)
                flags.Add("Faulted");
            if ((nZoneStatus & 8) > 0)
                flags.Add("Trouble");
            if ((nZoneStatus & 16) > 0)
                flags.Add("Tampered");
            if ((nZoneStatus & 32) > 0)
                flags.Add("Supervision Failed");

            return string.Join(" | ", flags);
        }
    }
}
