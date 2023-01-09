using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_registration
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.ControlBox = false;
        }
        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\CLAB1-30\source\repos\login_registration\login_registration\bin\Debug\mydata.mdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connect.Open();
            String login = "SELECT * FROM tbl_users WHERE username ='"+txtUsername.Text+"' AND password = '"+txtPassword.Text+"'";
            command = new OleDbCommand(login, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if(reader.Read() == true)
            {
                WelcomeForm welcome = new WelcomeForm();
                welcome.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Invalid Username or Password, PLease Try Again");
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
            connect.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void chckPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chckPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            } else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                        DialogResult result = MessageBox.Show("Are you sure you want to close the form?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
