using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PasswordManagementSystem.Classes;
namespace PasswordManagementSystem
{
    public partial class DeleteForm : Form
    {
        User user;
        public DeleteForm(User user)
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
                    }
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteLinesFromFile(tb_Text.Text);
            switch (MessageBox.Show("Ar tikrai norite ištrinti slaptažodį?",
                  "",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    DeleteLinesFromFile(tb_Text.Text);
                    break;

                case DialogResult.No:

                    break;


            }
        }
        public void DeleteLinesFromFile(string strLineToDelete)
        {
            string strFilePath = user.FileName;
            string strSearchText = strLineToDelete;
            string strOldText;
            string n = "";
            StreamReader sr = File.OpenText(strFilePath);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(strSearchText))
                {
                    n += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(strFilePath, n);
        }
    }
}
