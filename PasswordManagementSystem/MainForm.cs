using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManagementSystem.Classes;
using PasswordManagementSystem.Repositories;
using System.IO;
using System.Security.Cryptography;
using Aes = PasswordManagementSystem.Classes.Aes;

namespace PasswordManagementSystem
{
    public partial class MainForm : Form
    {
        User user;
        UserRepository userRepository;
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
            userRepository = new UserRepository();
            user.FileName = @"C:\ProgramData\" + user.FileName;
            string encryptedFile = user.FileName + ".aes";
            if (user.FileName != null) 
            {
                if (Aes.IsFileEncrypted(encryptedFile))
                {
                    string correctFile = encryptedFile.Substring(0, encryptedFile.Length - 4);
                    CryptographicException ex = Aes.DecryptFile(encryptedFile, correctFile, "fw5$]dN]cn3dVRG/");
                    if(ex is CryptographicException)
                    {
                        FileManager.Delete(correctFile);
                    }
                    FileManager.Delete(encryptedFile);
                }

            }           
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            
                switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        
                        break;
                    default:
                    if (!Aes.IsFileEncrypted(user.FileName))
                    {
                        Aes.EncryptFile(user.FileName, user.FileName + ".aes", "fw5$]dN]cn3dVRG/");
                        FileManager.Delete(user.FileName);
                    }
                    break;
                }
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_AddNewPassword_Click(object sender, EventArgs e)
        {
            AddNewPassword add = new AddNewPassword(user);
            add.ShowDialog();
        }
    }
}
