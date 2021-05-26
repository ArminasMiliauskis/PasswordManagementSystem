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
    public partial class SearchForm : Form
    {
        Des des = new Des();
        User user;
        public SearchForm(User user)
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

                        //MessageBox.Show(line.ToString());
                    }
                }
            }
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(des.DecryptData(tb_Password.Text, Convert.ToString(32165468), true));
        }
    }
}
