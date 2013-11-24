using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Dealership_Program
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string UserName = tb_Username.Text;
            string Password = tb_Password.Text;

            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            MySqlConnection myConn = new MySqlConnection(connStr);
            MySqlCommand login_Command = myConn.CreateCommand();
            MySqlDataReader login_reader;
            login_Command.CommandText = "SELECT Password, Level FROM Users WHERE UserName = '" + UserName +"'";

            myConn.Open();

            MySqlDataAdapter Login_Adapter = new MySqlDataAdapter(login_Command.CommandText, myConn);

            DataTable login_DT = new DataTable();
            Login_Adapter.Fill(login_DT);

            try
            {
                string db_password = login_DT.Rows[0][0].ToString();
                if (db_password == Password)
                {
                    this.Hide();
                    Main_Window Program = new Main_Window();
                    Program.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Password, Try again");
                    tb_Password.Clear();
                    tb_Username.Clear();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Username or Password");
            }

        }
    }
}
