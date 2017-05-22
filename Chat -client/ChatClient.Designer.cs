namespace ChatClient
{
    partial class ChatClient
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
            this.grpMessageWindow = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.grpUserCredentials = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.grpUserList = new System.Windows.Forms.GroupBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.grpAddTasks = new System.Windows.Forms.GroupBox();
            this.btnAddnext = new System.Windows.Forms.Button();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkcompleted = new System.Windows.Forms.CheckBox();
            this.lblTasks = new System.Windows.Forms.Label();
            this.txtTasks = new System.Windows.Forms.TextBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.grpConsolidatedTasks = new System.Windows.Forms.GroupBox();
            this.grpReports = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpMessageWindow.SuspendLayout();
            this.grpUserCredentials.SuspendLayout();
            this.grpUserList.SuspendLayout();
            this.grpAddTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.grpConsolidatedTasks.SuspendLayout();
            this.grpReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMessageWindow
            // 
            this.grpMessageWindow.Controls.Add(this.btnSend);
            this.grpMessageWindow.Controls.Add(this.txtSendMessage);
            this.grpMessageWindow.Controls.Add(this.rtbMessages);
            this.grpMessageWindow.Enabled = false;
            this.grpMessageWindow.Location = new System.Drawing.Point(12, 193);
            this.grpMessageWindow.Name = "grpMessageWindow";
            this.grpMessageWindow.Size = new System.Drawing.Size(315, 246);
            this.grpMessageWindow.TabIndex = 0;
            this.grpMessageWindow.TabStop = false;
            this.grpMessageWindow.Text = "Message window";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(265, 186);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(44, 55);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(6, 186);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(253, 55);
            this.txtSendMessage.TabIndex = 9;
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(8, 19);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(251, 161);
            this.rtbMessages.TabIndex = 0;
            this.rtbMessages.Text = "";
            // 
            // grpUserCredentials
            // 
            this.grpUserCredentials.Controls.Add(this.btnLogin);
            this.grpUserCredentials.Controls.Add(this.txtUserName);
            this.grpUserCredentials.Controls.Add(this.lblLoginName);
            this.grpUserCredentials.Location = new System.Drawing.Point(12, 5);
            this.grpUserCredentials.Name = "grpUserCredentials";
            this.grpUserCredentials.Size = new System.Drawing.Size(315, 45);
            this.grpUserCredentials.TabIndex = 1;
            this.grpUserCredentials.TabStop = false;
            this.grpUserCredentials.Text = "User credentials:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(234, 16);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(92, 17);
            this.txtUserName.MaxLength = 10;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(136, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Location = new System.Drawing.Point(21, 20);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(65, 13);
            this.lblLoginName.TabIndex = 0;
            this.lblLoginName.Text = "Login name:";
            this.lblLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpUserList
            // 
            this.grpUserList.Controls.Add(this.lstUsers);
            this.grpUserList.Enabled = false;
            this.grpUserList.Location = new System.Drawing.Point(333, 196);
            this.grpUserList.Name = "grpUserList";
            this.grpUserList.Size = new System.Drawing.Size(154, 147);
            this.grpUserList.TabIndex = 2;
            this.grpUserList.TabStop = false;
            this.grpUserList.Text = "Users online";
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(6, 19);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(140, 121);
            this.lstUsers.TabIndex = 0;
            // 
            // lbldate
            // 
            this.lbldate.Location = new System.Drawing.Point(618, 15);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(114, 23);
            this.lbldate.TabIndex = 7;
            this.lbldate.Text = "Date";
            // 
            // grpAddTasks
            // 
            this.grpAddTasks.Controls.Add(this.btnAddnext);
            this.grpAddTasks.Controls.Add(this.txtDays);
            this.grpAddTasks.Controls.Add(this.label1);
            this.grpAddTasks.Controls.Add(this.chkcompleted);
            this.grpAddTasks.Controls.Add(this.lblTasks);
            this.grpAddTasks.Controls.Add(this.txtTasks);
            this.grpAddTasks.Controls.Add(this.cmbProject);
            this.grpAddTasks.Controls.Add(this.lblProject);
            this.grpAddTasks.Location = new System.Drawing.Point(12, 52);
            this.grpAddTasks.Name = "grpAddTasks";
            this.grpAddTasks.Size = new System.Drawing.Size(315, 138);
            this.grpAddTasks.TabIndex = 10;
            this.grpAddTasks.TabStop = false;
            this.grpAddTasks.Text = "Add Tasks";
            // 
            // btnAddnext
            // 
            this.btnAddnext.Location = new System.Drawing.Point(92, 109);
            this.btnAddnext.Name = "btnAddnext";
            this.btnAddnext.Size = new System.Drawing.Size(75, 23);
            this.btnAddnext.TabIndex = 7;
            this.btnAddnext.Text = "Add New";
            this.btnAddnext.UseVisualStyleBackColor = true;
            this.btnAddnext.Click += new System.EventHandler(this.btnAddnext_Click);
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(268, 91);
            this.txtDays.MaxLength = 10;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(41, 20);
            this.txtDays.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(176, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Estimated Days:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkcompleted
            // 
            this.chkcompleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcompleted.Location = new System.Drawing.Point(9, 91);
            this.chkcompleted.Name = "chkcompleted";
            this.chkcompleted.Size = new System.Drawing.Size(98, 17);
            this.chkcompleted.TabIndex = 5;
            this.chkcompleted.Text = "Is Completed ?";
            this.chkcompleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcompleted.UseVisualStyleBackColor = true;
            this.chkcompleted.CheckedChanged += new System.EventHandler(this.chkcompleted_CheckedChanged);
            // 
            // lblTasks
            // 
            this.lblTasks.Location = new System.Drawing.Point(21, 40);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(65, 13);
            this.lblTasks.TabIndex = 8;
            this.lblTasks.Text = "Tasks:";
            this.lblTasks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTasks
            // 
            this.txtTasks.Location = new System.Drawing.Point(92, 40);
            this.txtTasks.Multiline = true;
            this.txtTasks.Name = "txtTasks";
            this.txtTasks.Size = new System.Drawing.Size(217, 46);
            this.txtTasks.TabIndex = 4;
            // 
            // cmbProject
            // 
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(92, 14);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(121, 21);
            this.cmbProject.TabIndex = 3;
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(21, 19);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(65, 13);
            this.lblProject.TabIndex = 3;
            this.lblProject.Text = "Project:";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Location = new System.Drawing.Point(661, 193);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(71, 21);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseMnemonic = false;
            this.btnSubmit.UseVisualStyleBackColor = true;
            //this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTasks.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTasks.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTasks.Location = new System.Drawing.Point(9, 19);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTasks.Size = new System.Drawing.Size(384, 113);
            this.dgvTasks.TabIndex = 11;
            // 
            // grpConsolidatedTasks
            // 
            this.grpConsolidatedTasks.AutoSize = true;
            this.grpConsolidatedTasks.Controls.Add(this.dgvTasks);
            this.grpConsolidatedTasks.Location = new System.Drawing.Point(333, 52);
            this.grpConsolidatedTasks.Name = "grpConsolidatedTasks";
            this.grpConsolidatedTasks.Size = new System.Drawing.Size(399, 138);
            this.grpConsolidatedTasks.TabIndex = 12;
            this.grpConsolidatedTasks.TabStop = false;
            this.grpConsolidatedTasks.Text = "Consolidated Tasks";
            // 
            // grpReports
            // 
            this.grpReports.Controls.Add(this.button2);
            this.grpReports.Controls.Add(this.button1);
            this.grpReports.Location = new System.Drawing.Point(532, 217);
            this.grpReports.Name = "grpReports";
            this.grpReports.Size = new System.Drawing.Size(200, 81);
            this.grpReports.TabIndex = 13;
            this.grpReports.TabStop = false;
            this.grpReports.Text = "Reports";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Project Wise Status Report";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Daily Status Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 440);
            this.Controls.Add(this.grpReports);
            this.Controls.Add(this.grpConsolidatedTasks);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grpAddTasks);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.grpUserList);
            this.Controls.Add(this.grpUserCredentials);
            this.Controls.Add(this.grpMessageWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "ChatClient";
            this.Text = "User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClient_FormClosing);
            this.grpMessageWindow.ResumeLayout(false);
            this.grpMessageWindow.PerformLayout();
            this.grpUserCredentials.ResumeLayout(false);
            this.grpUserCredentials.PerformLayout();
            this.grpUserList.ResumeLayout(false);
            this.grpAddTasks.ResumeLayout(false);
            this.grpAddTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.grpConsolidatedTasks.ResumeLayout(false);
            this.grpReports.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMessageWindow;
        private System.Windows.Forms.GroupBox grpUserCredentials;
        private System.Windows.Forms.GroupBox grpUserList;
        private System.Windows.Forms.Label lblLoginName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.GroupBox grpAddTasks;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.TextBox txtTasks;
        private System.Windows.Forms.CheckBox chkcompleted;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.GroupBox grpConsolidatedTasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddnext;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.GroupBox grpReports;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

