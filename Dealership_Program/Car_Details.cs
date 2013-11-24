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
    public partial class Car_Details : Form
    {
        private string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
        private MySqlConnection myConn = null;
        private MySqlDataAdapter MySQLDA = null;
        private MySqlCommandBuilder MySQLCB = null;
        private DataTable dt = null;
        private BindingSource BS = null;


        int f_car_ID = 0;
        string f_year = null;
        string f_maker = null;
        string f_model = null;
        string f_trim = null;
        string f_color = null;
        int f_MSRP = 0;

        public Car_Details()
        {
            InitializeComponent();
        }

        private void Car_Details_Load(object sender, EventArgs e)
        {
            
        }

        private void Clear()
        {
            tb_CarID.Text = "";
            tb_color.Text = "";
            tb_Maker.Text = "";
            tb_Model.Text = "";
            tb_MSRP.Text = "";
            tb_Trim.Text = "";
            tb_Year.Text = "";
        }

        private void btn_add_car_save_Click(object sender, EventArgs e)
        {
            try
            {
                f_car_ID = Int32.Parse(tb_CarID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            f_year = tb_Year.Text;
            f_maker = tb_Maker.Text;

            f_model = tb_Model.Text;
            f_color = tb_color.Text;
            f_trim = tb_Trim.Text;
            try
            {
                f_MSRP = Int32.Parse(tb_MSRP.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            myConn = new MySqlConnection(connStr);
            MySqlCommand myComm = myConn.CreateCommand();
            MySqlDataReader Reader;
            myComm.CommandText = "INSERT INTO `khnz786`.`Inventory` (`Car_ID`, `Maker`, `Model`, `Trim`, `Color`, `Engine`, `MSRP`)" + 
                                 "VALUES ("+ f_car_ID +", '"+f_maker+"', '"+f_model+"', '"+f_trim+"', '"+f_color+"', '"+f_year+"', '"+f_MSRP+"');";
            myConn.Open();

            MySQLDA = new MySqlDataAdapter(myComm.CommandText, myConn);
            MySQLCB = new MySqlCommandBuilder(MySQLDA);

            dt = new DataTable();
            try
            {
                MySQLDA.Fill(dt);
                MessageBox.Show("Car added successfully!");
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

        private void btn_add_car_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
