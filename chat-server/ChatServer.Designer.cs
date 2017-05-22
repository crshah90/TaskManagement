namespace ChatServer
{
    partial class ChatServer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatServer));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gvCalendar = new System.Windows.Forms.DataGridView();
            this.lblChintan = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMohit = new System.Windows.Forms.Label();
            this.lblReshma = new System.Windows.Forms.Label();
            this.lblLoukik = new System.Windows.Forms.Label();
            this.lblRupali = new System.Windows.Forms.Label();
            this.lblNilesh = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.grpServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCalendar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "&Start server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(119, 19);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "&Stop server";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // grpServer
            // 
            this.grpServer.Controls.Add(this.lblMessage);
            this.grpServer.Controls.Add(this.btnStart);
            this.grpServer.Controls.Add(this.btnStop);
            this.grpServer.Location = new System.Drawing.Point(2, 220);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(200, 75);
            this.grpServer.TabIndex = 1;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "Server Operations";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(6, 51);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 1;
            // 
            // gvCalendar
            // 
            this.gvCalendar.AllowUserToAddRows = false;
            this.gvCalendar.AllowUserToDeleteRows = false;
            this.gvCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gvCalendar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvCalendar.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gvCalendar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCalendar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCalendar.EnableHeadersVisualStyles = false;
            this.gvCalendar.GridColor = System.Drawing.Color.White;
            this.gvCalendar.Location = new System.Drawing.Point(8, 61);
            this.gvCalendar.MultiSelect = false;
            this.gvCalendar.Name = "gvCalendar";
            this.gvCalendar.ReadOnly = true;
            this.gvCalendar.RowHeadersVisible = false;
            this.gvCalendar.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gvCalendar.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.OldLace;
            this.gvCalendar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvCalendar.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Teal;
            this.gvCalendar.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
            this.gvCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvCalendar.Size = new System.Drawing.Size(243, 150);
            this.gvCalendar.TabIndex = 9;
            this.gvCalendar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCalendar_CellClick);
            this.gvCalendar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCalendar_CellDoubleClick);
            this.gvCalendar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCalendar_CellEnter);
            this.gvCalendar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvCalendar_CellFormatting);
            // 
            // lblChintan
            // 
            this.lblChintan.AutoSize = true;
            this.lblChintan.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblChintan.Location = new System.Drawing.Point(26, 53);
            this.lblChintan.Name = "lblChintan";
            this.lblChintan.Size = new System.Drawing.Size(43, 13);
            this.lblChintan.TabIndex = 7;
            this.lblChintan.Text = "Chintan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChintan);
            this.groupBox1.Controls.Add(this.lblMohit);
            this.groupBox1.Controls.Add(this.lblReshma);
            this.groupBox1.Controls.Add(this.lblLoukik);
            this.groupBox1.Controls.Add(this.lblRupali);
            this.groupBox1.Controls.Add(this.lblNilesh);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(253, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 209);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leave Legends";
            // 
            // lblMohit
            // 
            this.lblMohit.AutoSize = true;
            this.lblMohit.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblMohit.Location = new System.Drawing.Point(26, 102);
            this.lblMohit.Name = "lblMohit";
            this.lblMohit.Size = new System.Drawing.Size(33, 13);
            this.lblMohit.TabIndex = 5;
            this.lblMohit.Text = "Mohit";
            // 
            // lblReshma
            // 
            this.lblReshma.AutoSize = true;
            this.lblReshma.ForeColor = System.Drawing.Color.Coral;
            this.lblReshma.Location = new System.Drawing.Point(26, 85);
            this.lblReshma.Name = "lblReshma";
            this.lblReshma.Size = new System.Drawing.Size(46, 13);
            this.lblReshma.TabIndex = 4;
            this.lblReshma.Text = "Reshma";
            // 
            // lblLoukik
            // 
            this.lblLoukik.AutoSize = true;
            this.lblLoukik.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblLoukik.Location = new System.Drawing.Point(26, 69);
            this.lblLoukik.Name = "lblLoukik";
            this.lblLoukik.Size = new System.Drawing.Size(39, 13);
            this.lblLoukik.TabIndex = 3;
            this.lblLoukik.Text = "Loukik";
            // 
            // lblRupali
            // 
            this.lblRupali.AutoSize = true;
            this.lblRupali.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblRupali.Location = new System.Drawing.Point(26, 36);
            this.lblRupali.Name = "lblRupali";
            this.lblRupali.Size = new System.Drawing.Size(37, 13);
            this.lblRupali.TabIndex = 1;
            this.lblRupali.Text = "Rupali";
            // 
            // lblNilesh
            // 
            this.lblNilesh.AutoSize = true;
            this.lblNilesh.ForeColor = System.Drawing.Color.Blue;
            this.lblNilesh.Location = new System.Drawing.Point(26, 19);
            this.lblNilesh.Name = "lblNilesh";
            this.lblNilesh.Size = new System.Drawing.Size(36, 13);
            this.lblNilesh.TabIndex = 0;
            this.lblNilesh.Text = "Nilesh";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(8, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(52, 21);
            this.cmbYear.TabIndex = 10;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged_1);
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousMonth.Location = new System.Drawing.Point(66, 34);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(26, 21);
            this.btnPreviousMonth.TabIndex = 13;
            this.btnPreviousMonth.Text = "<";
            this.btnPreviousMonth.UseVisualStyleBackColor = true;
            this.btnPreviousMonth.Click += new System.EventHandler(this.btnPreviousMonth_Click);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(66, 12);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 11;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged_1);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextMonth.Location = new System.Drawing.Point(161, 34);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(26, 21);
            this.btnNextMonth.TabIndex = 12;
            this.btnNextMonth.Text = ">";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "You have a notification from the application";
            this.notifyIcon1.BalloonTipTitle = "DailyRoutine Message";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DailyRoutine Message";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 307);
            this.Controls.Add(this.gvCalendar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnPreviousMonth);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.grpServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChatServer";
            this.Text = "ChatServer";
            this.Load += new System.EventHandler(this.ChatServer_Load);
            this.Resize += new System.EventHandler(this.ChatServer_Resize);
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCalendar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox grpServer;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridView gvCalendar;
        private System.Windows.Forms.Label lblChintan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMohit;
        private System.Windows.Forms.Label lblReshma;
        private System.Windows.Forms.Label lblLoukik;
        private System.Windows.Forms.Label lblRupali;
        private System.Windows.Forms.Label lblNilesh;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnPreviousMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

