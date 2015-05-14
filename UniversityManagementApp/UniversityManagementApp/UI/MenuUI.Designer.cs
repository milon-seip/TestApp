namespace UniversityManagementApp.UI
{
    partial class MenuUI
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
            this.studentButton = new System.Windows.Forms.Button();
            this.departmentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentButton
            // 
            this.studentButton.Location = new System.Drawing.Point(59, 57);
            this.studentButton.Name = "studentButton";
            this.studentButton.Size = new System.Drawing.Size(95, 51);
            this.studentButton.TabIndex = 0;
            this.studentButton.Text = "Student";
            this.studentButton.UseVisualStyleBackColor = true;
            this.studentButton.Click += new System.EventHandler(this.studentButton_Click);
            // 
            // departmentButton
            // 
            this.departmentButton.Location = new System.Drawing.Point(206, 57);
            this.departmentButton.Name = "departmentButton";
            this.departmentButton.Size = new System.Drawing.Size(92, 51);
            this.departmentButton.TabIndex = 0;
            this.departmentButton.Text = "Department";
            this.departmentButton.UseVisualStyleBackColor = true;
            this.departmentButton.Click += new System.EventHandler(this.departmentButton_Click);
            // 
            // MenuUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 185);
            this.Controls.Add(this.departmentButton);
            this.Controls.Add(this.studentButton);
            this.Name = "MenuUI";
            this.Text = "MenuUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button studentButton;
        private System.Windows.Forms.Button departmentButton;
    }
}