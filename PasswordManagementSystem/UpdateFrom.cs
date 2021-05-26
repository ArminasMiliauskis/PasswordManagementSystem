using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManagementSystem.Classes;
namespace PasswordManagementSystem
{
    public partial class UpdateFrom : Form
    {
        User user;
        Des des = new Des();
        public UpdateFrom(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            FindALine(tb_Text.Text);
        }

        void FindALine(string text)
        {
            foreach (var line in File.ReadLines(user.FileName))
            {
                foreach (var word in line.Split(','))
                {
                    if (word == text)
                    {
                        string[] values;
                        values = line.ToString().Split(",");
                        tb_Password.Text = values[2];
                        label1.Text = values[2];
                    }
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            
            File.WriteAllText(user.FileName, File.ReadAllText(user.FileName).Replace(label1.Text, des.EncryptData(tb_Password.Text, Convert.ToString(32165468), true)));
            MessageBox.Show("Succes");
            this.Close();
            
        }

        private void UpdateFrom_Load(object sender, EventArgs e)
        {

        }
    }
}
