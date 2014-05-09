namespace SecuritySystemTest
{
    using System;
    using System.ComponentModel;

    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKeepAliveStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPartitionOneStatus = new System.Windows.Forms.Label();
            this.lblPartitionTwoStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDisarm = new System.Windows.Forms.Button();
            this.btnArmAway = new System.Windows.Forms.Button();
            this.btnArmStay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lstZoneList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(44, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login status:";
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.ForeColor = System.Drawing.Color.Red;
            this.lblLoginStatus.Location = new System.Drawing.Point(130, 119);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(79, 13);
            this.lblLoginStatus.TabIndex = 1;
            this.lblLoginStatus.Text = "Not Connected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keep-Alive Status:";
            // 
            // lblKeepAliveStatus
            // 
            this.lblKeepAliveStatus.AutoSize = true;
            this.lblKeepAliveStatus.Location = new System.Drawing.Point(130, 132);
            this.lblKeepAliveStatus.Name = "lblKeepAliveStatus";
            this.lblKeepAliveStatus.Size = new System.Drawing.Size(79, 13);
            this.lblKeepAliveStatus.TabIndex = 3;
            this.lblKeepAliveStatus.Text = "Not Connected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Partition 1 Status:";
            // 
            // lblPartitionOneStatus
            // 
            this.lblPartitionOneStatus.AutoSize = true;
            this.lblPartitionOneStatus.Location = new System.Drawing.Point(130, 159);
            this.lblPartitionOneStatus.Name = "lblPartitionOneStatus";
            this.lblPartitionOneStatus.Size = new System.Drawing.Size(79, 13);
            this.lblPartitionOneStatus.TabIndex = 5;
            this.lblPartitionOneStatus.Text = "Not Connected";
            // 
            // lblPartitionTwoStatus
            // 
            this.lblPartitionTwoStatus.AutoSize = true;
            this.lblPartitionTwoStatus.Location = new System.Drawing.Point(130, 172);
            this.lblPartitionTwoStatus.Name = "lblPartitionTwoStatus";
            this.lblPartitionTwoStatus.Size = new System.Drawing.Size(79, 13);
            this.lblPartitionTwoStatus.TabIndex = 7;
            this.lblPartitionTwoStatus.Text = "Not Connected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Partition 2 Status:";
            // 
            // btnDisarm
            // 
            this.btnDisarm.Location = new System.Drawing.Point(368, 27);
            this.btnDisarm.Name = "btnDisarm";
            this.btnDisarm.Size = new System.Drawing.Size(75, 23);
            this.btnDisarm.TabIndex = 8;
            this.btnDisarm.Text = "Disarm";
            this.btnDisarm.UseVisualStyleBackColor = true;
            this.btnDisarm.Click += new System.EventHandler(this.btnDisarm_Click);
            // 
            // btnArmAway
            // 
            this.btnArmAway.Location = new System.Drawing.Point(368, 57);
            this.btnArmAway.Name = "btnArmAway";
            this.btnArmAway.Size = new System.Drawing.Size(75, 23);
            this.btnArmAway.TabIndex = 9;
            this.btnArmAway.Text = "Arm (Away)";
            this.btnArmAway.UseVisualStyleBackColor = true;
            this.btnArmAway.Click += new System.EventHandler(this.btnArmAway_Click);
            // 
            // btnArmStay
            // 
            this.btnArmStay.Location = new System.Drawing.Point(368, 89);
            this.btnArmStay.Name = "btnArmStay";
            this.btnArmStay.Size = new System.Drawing.Size(75, 23);
            this.btnArmStay.TabIndex = 10;
            this.btnArmStay.Text = "Arm (Stay)";
            this.btnArmStay.UseVisualStyleBackColor = true;
            this.btnArmStay.Click += new System.EventHandler(this.btnArmStay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(259, 71);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(246, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(88, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '*';
            this.txtUsername.Size = new System.Drawing.Size(246, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(15, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Username:";
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(12, 189);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(507, 251);
            this.lstLog.TabIndex = 12;
            // 
            // lstZoneList
            // 
            this.lstZoneList.FormattingEnabled = true;
            this.lstZoneList.Location = new System.Drawing.Point(525, 189);
            this.lstZoneList.Name = "lstZoneList";
            this.lstZoneList.Size = new System.Drawing.Size(279, 251);
            this.lstZoneList.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(522, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Zones With Issues:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 449);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstZoneList);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnArmStay);
            this.Controls.Add(this.btnArmAway);
            this.Controls.Add(this.btnDisarm);
            this.Controls.Add(this.lblPartitionTwoStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPartitionOneStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblKeepAliveStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLoginStatus);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "TotalConnect 2.0 - Windows Version [by atom0s]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKeepAliveStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPartitionOneStatus;
        private System.Windows.Forms.Label lblPartitionTwoStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDisarm;
        private System.Windows.Forms.Button btnArmAway;
        private System.Windows.Forms.Button btnArmStay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.ListBox lstZoneList;
        private System.Windows.Forms.Label label7;
    }


    /// <summary>
    /// InvokerExtensions Class Implementation
    /// </summary>
    public static class InvokerExtensions
    {
        /// <summary>
        /// Extends Invoke to allow cross-thread invoking safely.
        /// 
        /// Credits: http://stackoverflow.com/a/711419/1080150
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            try
            {
                if (@this.InvokeRequired)
                    @this.Invoke(action, new object[] { @this });
                else
                    action(@this);
            }
            catch { /* Swallow exceptions from this.. */ }
        }
    }
}

