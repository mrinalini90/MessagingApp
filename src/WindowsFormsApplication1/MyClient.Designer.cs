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
            this.logout_btn = new System.Windows.Forms.Button();
            this.contact_data_table = new System.Windows.Forms.DataGridView();
            this.recieveMessageBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            // recieveMessageBox
            // 
            this.recieveMessageBox.Location = new System.Drawing.Point(35, 12);
            this.recieveMessageBox.Name = "recieveMessageBox";
            this.recieveMessageBox.Size = new System.Drawing.Size(314, 242);
            this.recieveMessageBox.TabIndex = 5;
            this.recieveMessageBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(526, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status: Connected!";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(563, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MyClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 344);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recieveMessageBox);
            this.Controls.Add(this.contact_data_table);
            this.Controls.Add(this.logout_btn);
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
        private System.Windows.Forms.Button logout_btn;
        public System.Windows.Forms.DataGridView contact_data_table;
        private System.Windows.Forms.RichTextBox recieveMessageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

