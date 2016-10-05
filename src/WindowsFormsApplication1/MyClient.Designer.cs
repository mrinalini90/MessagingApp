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
            this.logout_btn = new System.Windows.Forms.Button();
            this.contact_data_table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.contact_data_table)).BeginInit();
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
            this.sentBtn.Location = new System.Drawing.Point(247, 260);
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
            this.listBox.Size = new System.Drawing.Size(302, 225);
            this.listBox.TabIndex = 2;
            // 
            // logout_btn
            // 
            this.logout_btn.Location = new System.Drawing.Point(247, 301);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(102, 28);
            this.logout_btn.TabIndex = 3;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // contact_data_table
            // 
            this.contact_data_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contact_data_table.Location = new System.Drawing.Point(355, 25);
            this.contact_data_table.Name = "contact_data_table";
            this.contact_data_table.Size = new System.Drawing.Size(339, 150);
            this.contact_data_table.TabIndex = 4;
            
            // 
            // MyClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 344);
            this.Controls.Add(this.contact_data_table);
            this.Controls.Add(this.logout_btn);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.sentBtn);
            this.Controls.Add(this.clientMessage);
            this.Name = "MyClient";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.contact_data_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clientMessage;
        private System.Windows.Forms.Button sentBtn;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button logout_btn;
        public System.Windows.Forms.DataGridView contact_data_table;
    }
}

