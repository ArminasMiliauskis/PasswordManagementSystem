using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using PasswordManagementSystem.Classes;
namespace PasswordManagementSystem.Repositories
{
    class UserRepository
    {
        private const string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arme\source\repos\PasswordManagementSystem\PasswordManagementSystem\Database.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection con = new SqlConnection(ConnectionString);  //C:\Users\Arme\source\repos\PasswordManagementSystem\PasswordManagementSystem\Database.mdf

        
        public (bool, User) UserLogin(string username, string password)
        {
            User user = new User();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Users where Username=@Username AND Password=@Password", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while(dataReader.Read() == true)
                {
                    user.Name = dataReader["Username"].ToString();
                    user.FileName = dataReader["FileName"].ToString();
                    return (true,user);
                }
                dataReader.Close();
                con.Close();
                
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);              
            }
            return (false, null);
        }
        public void CreateNewFile(string filename)
        {
            string path = @"c:\ProgramData\" + filename;
            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path));               
            }
        }
    }
}
