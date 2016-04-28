namespace CustomerManager
{
    partial class frmAdd
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
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.TabIndex = 4;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFirstName.TabIndex = 1;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLastName.TabIndex = 2;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbxEmail.TabIndex = 3;
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 190);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAdd";
            this.Text = "Add Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}