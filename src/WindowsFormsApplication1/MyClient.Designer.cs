namespace IntraChat
{
    partial class MyClient
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
            this.clientMessage = new System.Windows.Forms.TextBox();
            this.sentBtn = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // clientMessage
            // 
            this.clientMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientMessage.Location = new System.Drawing.Point(47, 273);
            this.clientMessage.Name = "clientMessage";
            this.clientMessage.Size = new System.Drawing.Size(176, 22);
            this.clientMessage.TabIndex = 0;
            this.clientMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_KeyPress);
            // 
            // sentBtn
            // 
            this.sentBtn.Location = new System.Drawing.Point(292, 267);
            this.sentBtn.Name = "sentBtn";
            this.sentBtn.Size = new System.Drawing.Size(102, 35);
            this.sentBtn.TabIndex = 1;
            this.sentBtn.Text = "Send";
            this.sentBtn.UseVisualStyleBackColor = true;
            this.sentBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(47, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(347, 225);
            this.listBox.TabIndex = 2;
            // 
            // MyClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 326);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.sentBtn);
            this.Controls.Add(this.clientMessage);
            this.Name = "MyClient";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clientMessage;
        private System.Windows.Forms.Button sentBtn;
        private System.Windows.Forms.ListBox listBox;
    }
}

