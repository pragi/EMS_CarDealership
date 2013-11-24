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
    public partial class Main_Window : Form
    {
        
        private string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
        private MySqlConnection myConn = null;
        private MySqlConnection myConn2 = null;
        private MySqlDataAdapter MySQLDA = null;
        private MySqlCommandBuilder MySQLCB = null;
        private MySqlDataAdapter MySQLDA2 = null;
        private MySqlCommandBuilder MySQLCB2 = null;
        private DataTable dt = null;
        private DataTable inventory_dt = null;
        private BindingSource BS = null;
        private BindingSource BS2 = null;


        public Main_Window()
        {
            InitializeComponent();           
        }

        private void Main_Window_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'khnz786DataSet2.Order_ID' table. You can move, or remove it, as needed.
            this.order_IDTableAdapter.Fill(this.khnz786DataSet2.Order_ID);
            // TODO: This line of code loads data into the 'khnz786DataSet1.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.khnz786DataSet1.Inventory);
            // TODO: This line of code loads data into the 'khnz786DataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.khnz786DataSet.Customers);
            // TODO: This line of code loads data into the 'khnz786DataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.khnz786DataSet.Customers);
            ddlSearch_Column.SelectedIndex = 0;

            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            myConn = new MySqlConnection(connStr);
            MySqlCommand myComm = myConn.CreateCommand();
            MySqlDataReader Reader;
            myComm.CommandText = "SELECT * FROM Customers";
            myConn.Open();

            MySQLDA = new MySqlDataAdapter(myComm.CommandText, myConn);
            MySQLCB = new MySqlCommandBuilder(MySQLDA);

            dt = new DataTable();
            MySQLDA.Fill(dt);
            BS = new BindingSource();
            BS.DataSource = dt;

            dg_Search.DataSource = BS;

            Reader = myComm.ExecuteReader();
            myConn.Close();

            myConn2 = new MySqlConnection(connStr);
            MySqlCommand inventory_Comm = myConn.CreateCommand();
            MySqlDataReader Reader2;
            inventory_Comm.CommandText = "SELECT * FROM Inventory";
            myConn2.Open();
            MySQLDA2 = new MySqlDataAdapter(inventory_Comm.CommandText, myConn2);
            MySQLCB2 = new MySqlCommandBuilder(MySQLDA2);
            inventory_dt = new DataTable();
            MySQLDA2.Fill(inventory_dt);
            BS2 = new BindingSource();
            BS2.DataSource = inventory_dt;
            dg_inventory.DataSource = BS2;

            Reader2 = inventory_Comm.ExecuteReader();


            myConn2.Close();


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String search_value;
            String column_value = "";
            int caseswitch = 0;
            caseswitch = ddlSearch_Column.SelectedIndex;
            switch (caseswitch)
            {
                case 0: 
                    column_value = "Last_Name";
                    break;
                case 1:
                    column_value = "Phone";
                    break;
                case 2:
                    column_value = "Customer_ID";
                    break;                
            }
            search_value = tb_Search.Text;
            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            MySqlConnection myConn = new MySqlConnection(connStr);
            MySqlCommand myComm = myConn.CreateCommand();
            MySqlDataReader Reader;
            if (search_value == "")
            {
                MessageBox.Show("Please enter a value into the search box.");
                return;
            }
            else
            {
                myComm.CommandText = "SELECT * FROM Customers WHERE " + column_value + "= '" + search_value + "'";
            }
            myConn.Open();

            MySqlDataAdapter MySQLDA = new MySqlDataAdapter(myComm.CommandText, myConn);
            MySqlCommandBuilder MySQLCB = new MySqlCommandBuilder(MySQLDA);
            
            DataTable dt = new DataTable();
            MySQLDA.Fill(dt);
            BindingSource BS = new BindingSource();
            BS.DataSource = dt;

            dg_Search.DataSource = BS;

            Reader = myComm.ExecuteReader();
            //while (Reader.Read())
            //{
            //    MessageBox.Show(column_value);
            //}
            myConn.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            MySqlConnection myConn8 = new MySqlConnection(connStr);
            MySqlCommand myComm8 = myConn8.CreateCommand();
            MySqlDataReader Reader8;
            myComm8.CommandText = "SELECT * FROM Customers";
            myConn8.Open();

            MySqlDataAdapter MySQLDA8 = new MySqlDataAdapter(myComm8.CommandText, myConn8);
            MySqlCommandBuilder MySQLCB8 = new MySqlCommandBuilder(MySQLDA8);

            DataTable dt8 = new DataTable();
            MySQLDA.Fill(dt8);
            BindingSource BS8 = new BindingSource();
            BS8.DataSource = dt8;

            dg_Search.DataSource = BS;

            Reader8 = myComm8.ExecuteReader();
            myConn8.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                MySQLDA.Update(dt);
                MessageBox.Show("Update Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                dg_Search.Rows.RemoveAt(dg_Search.CurrentRow.Index);
                MySQLDA.Update(dt);
                MessageBox.Show("Delete Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            Add_Customer Customer = new Add_Customer();

            Customer.Show();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.inventoryTableAdapter.FillBy(this.khnz786DataSet1.Inventory);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection myConn3 = new MySqlConnection(connStr);
            MySqlDataReader Reader3;
            MySqlCommand inventory_Comm = myConn3.CreateCommand();
            inventory_Comm.CommandText = "SELECT * FROM Inventory WHERE " + cb_search_inventory.Text + "= '" + tb_search_inventory.Text + "'";
            if (cb_search_inventory.Text == "")
            {
                MessageBox.Show("Please select a category");
                return;
            }
            myConn3.Open();
            MySqlDataAdapter MySQLDA3 = new MySqlDataAdapter(inventory_Comm.CommandText, myConn3);
            MySqlCommandBuilder MySQLCB3 = new MySqlCommandBuilder(MySQLDA3);
            DataTable inventory_dt = new DataTable();
            MySQLDA3.Fill(inventory_dt);
            BindingSource BS3 = new BindingSource();
            BS3.DataSource = inventory_dt;
            dg_inventory.DataSource = BS3;

            Reader3 = inventory_Comm.ExecuteReader();
            myConn3.Close();
        }

        private void btn_search_year_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn4 = new MySqlConnection(connStr);
            MySqlDataReader Reader4;
            MySqlCommand inventory_Comm = myConn4.CreateCommand();
            inventory_Comm.CommandText = "SELECT * FROM Inventory WHERE Engine BETWEEN '" + tb_year_min.Text + "' AND '" + tb_year_max.Text + "'";
            myConn4.Open();
            MySqlDataAdapter MySQLDA4 = new MySqlDataAdapter(inventory_Comm.CommandText, myConn4);
            MySqlCommandBuilder MySQLCB4 = new MySqlCommandBuilder(MySQLDA4);
            DataTable inventory_dt = new DataTable();
            MySQLDA4.Fill(inventory_dt);
            BindingSource BS4 = new BindingSource();
            BS4.DataSource = inventory_dt;
            dg_inventory.DataSource = BS4;

            Reader4 = inventory_Comm.ExecuteReader();
            myConn4.Close();
        }

        private void btn_Search_Price_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn5 = new MySqlConnection(connStr);
            MySqlDataReader Reader5;
            MySqlCommand inventory_Comm = myConn5.CreateCommand();
            inventory_Comm.CommandText = "SELECT * FROM Inventory WHERE MSRP BETWEEN '" + tb_price_min.Text + "' AND '" + tb_price_max.Text + "'";
            myConn5.Open();
            MySqlDataAdapter MySQLDA5 = new MySqlDataAdapter(inventory_Comm.CommandText, myConn5);
            MySqlCommandBuilder MySQLCB5 = new MySqlCommandBuilder(MySQLDA5);
            DataTable inventory_dt = new DataTable();
            MySQLDA5.Fill(inventory_dt);
            BindingSource BS5 = new BindingSource();
            BS5.DataSource = inventory_dt;
            dg_inventory.DataSource = BS5;

            Reader5 = inventory_Comm.ExecuteReader();
            myConn5.Close();

        }

        private void btn_update_inventory_Click(object sender, EventArgs e)
        {
            try
            {
                MySQLDA2.Update(inventory_dt);
                MessageBox.Show("Update Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_delete_inventory_Click(object sender, EventArgs e)
        {
            try
            {
                dg_inventory.Rows.RemoveAt(dg_inventory.CurrentRow.Index);
                MySQLDA2.Update(inventory_dt);
                MessageBox.Show("Delete Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_add_car_Click(object sender, EventArgs e)
        {
            Car_Details Car_Details = new Car_Details();

            Car_Details.Show();
        }

        private void btn_inventory_show_all_Click(object sender, EventArgs e)
        {
            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            MySqlConnection myConn7 = new MySqlConnection(connStr);
            MySqlCommand inventory_showall_myComm = myConn7.CreateCommand();
            MySqlDataReader inventory_showall_Reader;
            inventory_showall_myComm.CommandText = "SELECT * FROM Inventory";
            myConn7.Open();

            MySqlDataAdapter inventory_showall_MySQLDA = new MySqlDataAdapter(inventory_showall_myComm.CommandText, myConn7);
            MySqlCommandBuilder inventory_showall_MySQLCB = new MySqlCommandBuilder(inventory_showall_MySQLDA);

            DataTable inventory_showall_dt = new DataTable();
            inventory_showall_MySQLDA.Fill(inventory_showall_dt);
            BindingSource inventory_showall_BS = new BindingSource();
            inventory_showall_BS.DataSource = inventory_showall_dt;

            dg_inventory.DataSource = inventory_showall_BS;

            inventory_showall_Reader = inventory_showall_myComm.ExecuteReader();
            myConn7.Close();
        }

        private void btn_new_Order_Click(object sender, EventArgs e)
        {
            Order_Entry Order = new Order_Entry();

            Order.Show();
        }

        private void dg_Orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Order_ID = this.dg_Orders.CurrentRow.Cells[0].Value.ToString();
            string Customer_ID = this.dg_Orders.CurrentRow.Cells[1].Value.ToString();
            string Car_ID = this.dg_Orders.CurrentRow.Cells[2].Value.ToString();

            if (Order_ID.Length == 0 || Customer_ID.Length == 0 || Car_ID.Length == 0)
            {
                return;
            }
            
            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            MySqlConnection myConn8 = new MySqlConnection(connStr);
            MySqlCommand orders_Order_ID = myConn8.CreateCommand();
            MySqlCommand orders_Customer_ID = myConn8.CreateCommand();
            MySqlCommand orders_Car_ID = myConn8.CreateCommand();

            MySqlDataReader order_reader;
            orders_Order_ID.CommandText = "SELECT * FROM Order_ID WHERE Order_ID ="+Order_ID;
            orders_Customer_ID.CommandText = "SELECT * FROM Customers WHERE Customer_ID="+Customer_ID;
            orders_Car_ID.CommandText = "SELECT * FROM Inventory WHERE Car_ID= "+Car_ID;
            
            myConn8.Open();

            MySqlDataAdapter orders_Customer_ID_MySQLDA = new MySqlDataAdapter(orders_Customer_ID.CommandText, myConn8);
            MySqlCommandBuilder orders_Customer_ID_MySQLCB = new MySqlCommandBuilder(orders_Customer_ID_MySQLDA);

            DataTable orders_Customer_ID_dt = new DataTable();
            orders_Customer_ID_MySQLDA.Fill(orders_Customer_ID_dt);
            BindingSource orders_Customer_ID_BS = new BindingSource();
            orders_Customer_ID_BS.DataSource = orders_Customer_ID_dt;

            tb_CustomerID_Orders.Text = orders_Customer_ID_dt.Rows[0][0].ToString();
            tb_LastName_Orders.Text = orders_Customer_ID_dt.Rows[0][1].ToString();
            tb_FirstName_Orders.Text = orders_Customer_ID_dt.Rows[0][2].ToString();
            tb_DOB_Orders.Text = orders_Customer_ID_dt.Rows[0][4].ToString();
            tb_Address_Orders.Text = orders_Customer_ID_dt.Rows[0][5].ToString();
            tb_City_Orders.Text = orders_Customer_ID_dt.Rows[0][6].ToString();
            tb_State_Orders.Text = orders_Customer_ID_dt.Rows[0][7].ToString();
            tb_Zip_Orders.Text = orders_Customer_ID_dt.Rows[0][8].ToString();
            tb_phone_Orders.Text = orders_Customer_ID_dt.Rows[0][9].ToString();

            MySqlDataAdapter orders_Car_ID_MySQLDA = new MySqlDataAdapter(orders_Car_ID.CommandText, myConn8);
            MySqlCommandBuilder orders_Car_ID_MySQLCB = new MySqlCommandBuilder(orders_Car_ID_MySQLDA);

            DataTable orders_Car_ID_dt = new DataTable();
            orders_Car_ID_MySQLDA.Fill(orders_Car_ID_dt);
            BindingSource orders_Car_ID_BS = new BindingSource();
            orders_Car_ID_BS.DataSource = orders_Car_ID_dt;

            tb_CarID.Text = orders_Car_ID_dt.Rows[0][0].ToString();
            tb_Maker.Text = orders_Car_ID_dt.Rows[0][1].ToString();
            tb_Model.Text = orders_Car_ID_dt.Rows[0][2].ToString();
            tb_Trim.Text = orders_Car_ID_dt.Rows[0][3].ToString();
            tb_color.Text = orders_Car_ID_dt.Rows[0][4].ToString();
            tb_Year.Text = orders_Car_ID_dt.Rows[0][5].ToString();
            tb_MSRP.Text = orders_Car_ID_dt.Rows[0][6].ToString();

            MySqlDataAdapter orders_Order_ID_MySQLDA = new MySqlDataAdapter(orders_Order_ID.CommandText, myConn8);
            MySqlCommandBuilder orders_Order_ID_MySQLCB = new MySqlCommandBuilder(orders_Order_ID_MySQLDA);

            DataTable orders_Order_ID_dt = new DataTable();
            orders_Order_ID_MySQLDA.Fill(orders_Order_ID_dt);
            BindingSource orders_Order_ID_BS = new BindingSource();
            orders_Order_ID_BS.DataSource = orders_Order_ID_dt;

            tb_Order_Date_Orders.Text = orders_Order_ID_dt.Rows[0][3].ToString();
            tb_Order_ID_orders.Text = orders_Order_ID_dt.Rows[0][0].ToString();
            tb_Payment_Type_orders.Text = orders_Order_ID_dt.Rows[0][4].ToString();
            tb_Payment_Information_Orders.Text = orders_Order_ID_dt.Rows[0][5].ToString();
            tb_Downpayment_Orders.Text = orders_Order_ID_dt.Rows[0][6].ToString();
            tb_Tax_Orders.Text = orders_Order_ID_dt.Rows[0][7].ToString();
            tb_Fees_Orders.Text = orders_Order_ID_dt.Rows[0][8].ToString();
            tb_Finance_Term_Orders.Text = orders_Order_ID_dt.Rows[0][9].ToString();
            tb_Interest_Rate_Orders.Text = orders_Order_ID_dt.Rows[0][10].ToString();
            tb_Finance_Payments_Orders.Text = orders_Order_ID_dt.Rows[0][11].ToString();
            tb_Total_Paid_Orders.Text = orders_Order_ID_dt.Rows[0][12].ToString();
            tb_Total_Remaining_Orders.Text = orders_Order_ID_dt.Rows[0][13].ToString();
            tb_Notes_Orders.Text = orders_Order_ID_dt.Rows[0][14].ToString();

            order_reader = orders_Order_ID.ExecuteReader();
            myConn8.Close();

        }
    }
}
