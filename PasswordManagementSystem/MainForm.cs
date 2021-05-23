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
namespace PasswordManagementSystem
{
    public partial class MainForm : Form
    {
        User user;
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
