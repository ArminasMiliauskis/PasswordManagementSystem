using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using PasswordManagementSystem.Classes;
namespace PasswordManagementSystem
{
    public partial class AddNewPassword : Form
    {
        User user;
        Des des = new Des();
        public AddNewPassword(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>();
            data.Add(tb_Name.Text + "," + tb_Url.Text + "," + des.EncryptData(tb_Password.Text, Convert.ToString(32165468), true));
            FileManager.WriteFile(user.FileName, data);
            //File.AppendAllText(user.FileName, data);
            this.Close();
        }
    }
}
