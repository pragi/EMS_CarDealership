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
    public partial class Add_Customer : Form
    {
        private string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
        private MySqlConnection myConn = null;
        private MySqlDataAdapter MySQLDA = null;
        private MySqlCommandBuilder MySQLCB = null;
        private DataTable dt = null;
        private BindingSource BS = null;


        int f_customer_ID = 0;
        string f_last_name = null;
        string f_first_name = null;
        string f_DOB = null;
        string f_address = null;
        string f_city = null;
        string f_state = null;
        string f_zip = null;
        string f_phone = null;

        public Add_Customer()
        {
            InitializeComponent();

        }

        private void tb_CustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {

        
        }

        

        private void btn_addCustomer_Click(object sender, EventArgs e)
        {


            try
            {
                f_customer_ID = Int32.Parse(tb_CustomerID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            f_last_name = tb_LastName.Text;
            f_first_name = tb_FirstName.Text;

            f_DOB = tbm_DOB.Text;

            f_address = tb_Address.Text;
            f_city = tb_City.Text;
            f_state = tb_State.Text;
            f_zip = tb_Zip.Text;
            f_phone = tb_phone.Text;

            myConn = new MySqlConnection(connStr);
            MySqlCommand myComm = myConn.CreateCommand();
            MySqlDataReader Reader;
            myComm.CommandText = "INSERT INTO `khnz786`.`Customers` (`Customer_ID`, `Last_Name`, `First_Name`, `DOB`, `Address`, `City`, `State`, `Zip`, `Phone`)" +
                                  "VALUES (" + f_customer_ID + ", '" + f_last_name + "', '" + f_first_name + "', '" + f_DOB +  
                                           "', '"+ f_address +"', '"+ f_city +"', '"+ f_state +"', '"+ f_zip +"', '"+ f_phone +"');";
            myConn.Open();

            MySQLDA = new MySqlDataAdapter(myComm.CommandText, myConn);
            MySQLCB = new MySqlCommandBuilder(MySQLDA);

            dt = new DataTable();
            try
            {
                MySQLDA.Fill(dt);
                MessageBox.Show("Customer added successfully!");
                Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            BS = new BindingSource();
            BS.DataSource = dt;
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void Clear()
        {
            tb_phone.Text = "";
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Address.Text = "";
            tb_City.Text = "";
            tb_CustomerID.Text = "";
            tb_State.Text = "";
            tb_Zip.Text = "";
            tbm_DOB.Text = "0000-00-01";
             
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

    }
}
