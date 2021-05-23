using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManagementSystem.Classes;
using PasswordManagementSystem.Repositories;
namespace PasswordManagementSystem
{
    public partial class Form1 : Form
    {
        UserRepository userRepository;
        public Form1()
        {
            InitializeComponent();
            userRepository = new UserRepository();
        }

        private const string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arme\source\repos\PasswordManagementSystem\PasswordManagementSystem\Database.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection con = new SqlConnection(ConnectionString);

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (tb_Username.Text != null && tb_Username.Text != "" && tb_Password.Text != null && tb_Password.Text != "")
            {
                User user = userRepository.LoginUser(tb_Username.Text, tb_Password.Text);

                if (user.Name != null && user.Name != "")
                {
                    MainForm main = new(user);
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Neteisingas vartotojo vardas arba slaptažodis");
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            Register__From register__From = new Register__From();
            register__From.Show();
        }
    }
}
