using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagementSystem.Classes;
namespace PasswordManagementSystem.Repositories
{
    class UserRepository
    {
        private const string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arme\source\repos\PasswordManagementSystem\PasswordManagementSystem\Database.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection con = new SqlConnection(ConnectionString);
        
        public User LoginUser(string username, string password)
        {
            User user = new User();
            try
            {
                con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("Select Username,Password FROM Users where Username=@Username AND Password=@Password", con);
                //parametrised Sql Command, have to provide values that we wrote
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string Name = reader["Username"].ToString();
                    string FileName = reader["FileName"].ToString();

                    user.Name = Name;
                    user.FileName = FileName;
                }
                con.Close();
                return user;
            }catch (Exception ex) { Console.WriteLine(ex); return null; }
        }
    }
}
