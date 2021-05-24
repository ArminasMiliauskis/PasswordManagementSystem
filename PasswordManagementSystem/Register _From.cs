using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PasswordManagementSystem
{
    public partial class Register__From : Form
    {
        private const string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arme\source\repos\PasswordManagementSystem\PasswordManagementSystem\Database.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection con = new SqlConnection(ConnectionString);
        public Register__From()
        {
            InitializeComponent();
            tb_Password.Text = RandomPasswordGenerator();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // nenaudojamas
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            InstertIntoDB(tb_Username.Text, tb_Password.Text);
            MessageBox.Show("Succes!");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        public void InstertIntoDB(string username, string password)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Users (Username,Password,FileName) VALUES(@Username,@Password,@FileName)", con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@FileName", username + ".txt");
            cmd.ExecuteNonQuery();
            con.Close();
        }
       
        public string RandomPasswordGenerator()
        {
            string possiblechr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            char[] possibleChars = possiblechr.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {              
                int randInt32 = GetRandomInt();
               
                Random r = new Random(randInt32);

                int nextInt = r.Next(possibleChars.Length);
                char c = possibleChars[nextInt];
                builder.Append(c);
            }
            return builder.ToString();
        }
        static public Int32 GetRandomInt()
        {
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            Int32 randomInt = BitConverter.ToInt32(randomBytes, 0);
            return randomInt;
        }
    }
}
