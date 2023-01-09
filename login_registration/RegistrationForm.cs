using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace login_registration
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.ControlBox = false;
        }

        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\CLAB1-30\source\repos\login_registration\login_registration\bin\Debug\mydata.mdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();

        private void btnRegister_Click(object sender, EventArgs e)
        {

         if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirm.Text))
         {
                MessageBox.Show("All fields must be fill");
         } else
            {
                if (txtPassword.Text == txtConfirm.Text)
                {
                    connect.Open();
                    string Register = "INSERT INTO tbl_users VALUES('" + txtUsername.Text + "', '" + txtPassword.Text + "')";
                    command = new OleDbCommand(Register, connect);
                    
                 
                    bool success = false;

                    if (command.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    } if (success)
                    {
                        MessageBox.Show("Data SAVED");
                    } else
                    {
                        MessageBox.Show("ERROR");
                    }
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtConfirm.Text = "";
                    connect.Close();
                }
                 else
                {
                    MessageBox.Show("Password does not match");
                }
            }
  
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
            } else
            {
                txtPassword.PasswordChar = '•';
                txtConfirm.PasswordChar = '•';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirm.Text = "";
            txtUsername.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new loginForm().Show();
            this.Hide();
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
