
namespace PasswordManagementSystem
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
            this.btn_AddNewPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_AddNewPassword
            // 
            this.btn_AddNewPassword.Location = new System.Drawing.Point(12, 12);
            this.btn_AddNewPassword.Name = "btn_AddNewPassword";
            this.btn_AddNewPassword.Size = new System.Drawing.Size(113, 23);
            this.btn_AddNewPassword.TabIndex = 0;
            this.btn_AddNewPassword.Text = "Naujas Slaptažodis";
            this.btn_AddNewPassword.UseVisualStyleBackColor = true;
            this.btn_AddNewPassword.Click += new System.EventHandler(this.btn_AddNewPassword_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_AddNewPassword);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_AddNewPassword;
    }
}