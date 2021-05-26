using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        Hash hash = new Hash();
        public Form1()
        {
            InitializeComponent();
            userRepository = new UserRepository();
            tb_Password.Text = "VkiEUP5!AM";
        }

        private const string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arme\source\repos\PasswordManagementSystem\PasswordManagementSystem\Database.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection con = new SqlConnection(ConnectionString);

        private void btn_Login_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (tb_Username.Text != null && tb_Username.Text != "" && tb_Password.Text != null && tb_Password.Text != "")
            {


                if (userRepository.UserLogin(tb_Username.Text, hash.passHash(tb_Password.Text)).Item1 == true)
                {
                    user = userRepository.UserLogin(tb_Username.Text, hash.passHash(tb_Password.Text)).Item2;
                   
                    MainForm main = new MainForm(user);
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
