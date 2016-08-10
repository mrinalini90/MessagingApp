namespace WindowsFormsApplication1
{
    partial class MyServer
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
            this.recievedTextBox = new System.Windows.Forms.RichTextBox();
            this.recieveMessage = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recievedTextBox
            // 
            this.recievedTextBox.Enabled = false;
            this.recievedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recievedTextBox.Location = new System.Drawing.Point(37, 28);
            this.recievedTextBox.Name = "recievedTextBox";
            this.recievedTextBox.Size = new System.Drawing.Size(369, 49);
            this.recievedTextBox.TabIndex = 0;
            this.recievedTextBox.Text = "";
            // 
            // recieveMessage
            // 
            this.recieveMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recieveMessage.Location = new System.Drawing.Point(37, 134);
            this.recieveMessage.Name = "recieveMessage";
            this.recieveMessage.Size = new System.Drawing.Size(369, 171);
            this.recieveMessage.TabIndex = 1;
            this.recieveMessage.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recieve Message From Client:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MyServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 317);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recieveMessage);
            this.Controls.Add(this.recievedTextBox);
            this.Name = "MyServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.MyServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox recievedTextBox;
        private System.Windows.Forms.RichTextBox recieveMessage;
        private System.Windows.Forms.Label label1;
    }
}