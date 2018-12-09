namespace BaleBotWin
{
    partial class MainForm
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
            this.logData = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtRec = new System.Windows.Forms.TextBox();
            this.txtPayam = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logData
            // 
            this.logData.BackColor = System.Drawing.SystemColors.ControlText;
            this.logData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logData.Location = new System.Drawing.Point(475, 41);
            this.logData.Multiline = true;
            this.logData.Name = "logData";
            this.logData.ReadOnly = true;
            this.logData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logData.Size = new System.Drawing.Size(565, 359);
            this.logData.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(177, 162);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(124, 41);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtRec
            // 
            this.txtRec.Location = new System.Drawing.Point(12, 12);
            this.txtRec.Multiline = true;
            this.txtRec.Name = "txtRec";
            this.txtRec.ReadOnly = true;
            this.txtRec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRec.Size = new System.Drawing.Size(457, 144);
            this.txtRec.TabIndex = 2;
            // 
            // txtPayam
            // 
            this.txtPayam.Location = new System.Drawing.Point(12, 209);
            this.txtPayam.Multiline = true;
            this.txtPayam.Name = "txtPayam";
            this.txtPayam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPayam.Size = new System.Drawing.Size(457, 144);
            this.txtPayam.TabIndex = 2;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(132, 359);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(209, 41);
            this.btnSendMsg.TabIndex = 1;
            this.btnSendMsg.Text = "Send message to last user";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(558, 12);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(482, 23);
            this.txtToken.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Token";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 409);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtPayam);
            this.Controls.Add(this.txtRec);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.logData);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Bale Bot Messenger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logData;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtRec;
        private System.Windows.Forms.TextBox txtPayam;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label1;
    }
}

