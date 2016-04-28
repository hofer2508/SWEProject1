namespace CustomerManager
{
    partial class frmEdit
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
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Enabled = false;
            this.tbxFirstName.Location = new System.Drawing.Point(83, 6);
            this.tbxFirstName.Margin = new System.Windows.Forms.Padding(2);
            // 
            // tbxLastName
            // 
            this.tbxLastName.Location = new System.Drawing.Point(83, 32);
            this.tbxLastName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxLastName.TabIndex = 0;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(83, 57);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(2);
            this.tbxEmail.TabIndex = 1;
            // 
            // nudAmount
            // 
            this.nudAmount.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAmount.Location = new System.Drawing.Point(83, 81);
            this.nudAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nudAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAmount.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(99, 20);
            this.nudAmount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "New amount";
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 190);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAmount);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEdit";
            this.Text = "Edit Customer";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.tbxFirstName, 0);
            this.Controls.SetChildIndex(this.tbxLastName, 0);
            this.Controls.SetChildIndex(this.tbxEmail, 0);
            this.Controls.SetChildIndex(this.nudAmount, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label1;
    }
}