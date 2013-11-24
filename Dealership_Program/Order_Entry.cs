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
    public partial class Order_Entry : Form
    {
        bool customer_OK = false;
        bool car_OK = false;
        bool fee_OK = false;
        bool MSRP_OK = false;
        bool downpayment_OK = false;
        bool finance_term_OK = false;
        bool finance_interest_OK = false;
        bool Order_ID_OK = false;
        bool Order_Date_Ok = false;
        bool payment_type_OK = false;
        bool payment_information_OK = false;

        int Order_ID = 0;
        string Order_Date = null;
        int Car_ID = 0;
        int Customer_ID = 0;
        double downpayment = 0;
        int term = 0;
        double financing_interest = 0;
        double tax = 0;
        double payments = 0;
        double fees = 0;
        double due_today = 0;
        double remaining = 0;
        double MSRP = 0;

        Image check = Image.FromFile("C:\\Users\\Zia Khan\\Pictures\\check.png");

        public Order_Entry()
        {
            InitializeComponent();
        }

        private void Clear_Customer()
        {
            pictureBox1.Image = null;
            tb_LastName.Text = "";
            tb_FirstName.Text = "";
            tb_Address.Text = "";
            tb_City.Text = "";
            tb_State.Text = "";
            tb_Zip.Text = "";
            tb_DOB.Text = "";
            tb_phone.Text = "";
        }

        private void Clear_Car()
        {
            pictureBox2.Image = null;
            tb_Maker.Text = "";
            tb_Model.Text = "";
            tb_Trim.Text = "";
            tb_Year.Text = "";
            tb_MSRP.Text = "";
            tb_color.Text = "";
        }

        private void btn_Check_Customer_Click(object sender, EventArgs e)
        {


            
        }

        private void btn_Check_Car_Click(object sender, EventArgs e)
        {
            Clear_Car();
            int f_car_ID = 0;

            try
            {
                f_car_ID = Int32.Parse(tb_CarID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }

            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            MySqlConnection myConn = new MySqlConnection(connStr);
            MySqlCommand myComm = myConn.CreateCommand();
            if (tb_CarID.Text == "")
            {
                MessageBox.Show("Please enter a value into the search box.");
                return;
            }
            else
            {
                myComm.CommandText = "SELECT Maker, Model, Trim, Color, Engine, MSRP FROM Inventory WHERE Car_ID = '" + f_car_ID + "'";
            }
            try
            {
                myConn.Open();

                using (MySqlDataAdapter MySQLDA = new MySqlDataAdapter(myComm.CommandText, myConn))
                {
                    using (MySqlDataReader reader = myComm.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            tb_Maker.Text = reader["Maker"].ToString();
                            tb_Model.Text = reader["Model"].ToString();
                            tb_Trim.Text = reader["Trim"].ToString();
                            tb_color.Text = reader["Color"].ToString();
                            tb_Year.Text = reader["Engine"].ToString();
                            tb_MSRP.Text = reader["MSRP"].ToString();
                        }
                        reader.Close();
                        if (tb_MSRP.Text != "")
                        {
                            car_OK = true;
                            pictureBox2.Image = check;
                            Car_ID = f_car_ID;
                        }
                        else
                        {
                            tb_CarID.Text = "";
                            MessageBox.Show("Car does not exist, please search again");
                        }
                        if ((car_OK == true) && (customer_OK == true))
                        {
                            Order_Entry.ActiveForm.Width = 1183;
                            Order_Entry.ActiveForm.Height = 448;
                            gb_Order_Information.Visible = true;
                            Initialize_Order();
                        }

                    }
                }
            }
            finally
            {
                if (myConn.State != ConnectionState.Closed)
                {
                    myConn.Close();
                    
                }
            }
        }

        private void Order_Entry_Load(object sender, EventArgs e)
        {
            // Validate ORDER_ID textbox
            string Order_ID_string = tb_Order_ID.Text;
            bool isInt = false;
            Order_ID_OK = int.TryParse(Order_ID_string, out Order_ID);
            if (Order_ID > 10000 && Order_ID < 99999)
            {
                isInt = true;
            }
            if (Order_ID_OK == false || isInt == false)
            {
                errorProvider1.SetError(tb_Order_ID, "Not a valid order ID, must be 5 digit int");
            }
            else
            {
                errorProvider1.Clear();
            } 
            // Validate Date Textbox
            string date = tb_order_date.Text;
            if (date.Length != 10)
            {
                Order_Date_Ok = true;
            }
            if (Order_ID_OK == false)
            {
                errorProvider2.SetError(tb_order_date, "Not a valid date.");
            }
            else
            {
                errorProvider2.Clear();
            } 
            // Validate Payment Type textbox
            string payment_type = tb_Payment_Type.Text;
            if (payment_type.Length != 0)
            {
                payment_type_OK = true;
            }
            if (payment_type_OK == false)
            {
                errorProvider3.SetError(tb_Payment_Type, "Not a payment type.");
            }
            else
            {
                errorProvider3.Clear();
            } 
            //Validate Payment Information textbox.
            string payment_information = tb_Payment_Information.Text;
            if (payment_information.Length != 0)
            {
                payment_information_OK = true;
            }
            if (payment_information_OK == false)
            {
                errorProvider4.SetError(tb_Payment_Information, "Payment information needed.");
            }
            else
            {
                errorProvider4.Clear();
            } 
        }

        private void btn_Check_Customer_Click_1(object sender, EventArgs e)
        {
            Clear_Customer();
            int f_Customer_ID = 0;

            try
            {
                f_Customer_ID = Int32.Parse(tb_CustomerID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }

            string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
            MySqlConnection myConn = new MySqlConnection(connStr);
            MySqlCommand myComm = myConn.CreateCommand();
            if (tb_CustomerID.Text == "")
            {
                MessageBox.Show("Please enter a value into the search box.");
                return;
            }
            else
            {
                myComm.CommandText = "SELECT Last_Name, First_Name, Address, City, State, Zip, DOB, Phone FROM Customers WHERE Customer_ID = '" + f_Customer_ID + "'";
            }
            try
            {
                myConn.Open();

                using (MySqlDataAdapter MySQLDA = new MySqlDataAdapter(myComm.CommandText, myConn))
                {
                    using (MySqlDataReader reader = myComm.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            tb_LastName.Text = reader["Last_Name"].ToString();
                            tb_FirstName.Text = reader["First_Name"].ToString();
                            tb_Address.Text = reader["Address"].ToString();
                            tb_City.Text = reader["City"].ToString();
                            tb_State.Text = reader["State"].ToString();
                            tb_Zip.Text = reader["Zip"].ToString();
                            tb_DOB.Text = reader["DOB"].ToString();
                            tb_phone.Text = reader["Phone"].ToString();
                        }
                        reader.Close();
                        if (tb_LastName.Text != "")
                        {
                            customer_OK = true;
                            pictureBox1.Image = check;
                            Customer_ID = f_Customer_ID;
                        }
                        else
                        {
                            tb_CustomerID.Text = "";
                            MessageBox.Show("Customer does not exist, please search again");
                        }
                        if ((car_OK == true) && (customer_OK == true))
                        {
                            Order_Entry.ActiveForm.Width = 1183;
                            Order_Entry.ActiveForm.Height = 448;
                            gb_Order_Information.Visible = true;
                            Initialize_Order();
                           
                        }

                    }
                }
            }
            finally
            {
                if (myConn.State != ConnectionState.Closed)
                {
                    myConn.Close();
                }
            }
        }

        private void chb_Financing_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Financing.Checked == true)
            {
                label26.Visible = true;
                label27.Visible = true;
                label28.Visible = true;
                label30.Visible = true;
                label31.Visible = true;
                label32.Visible = true;
                tb_finance_interest.Visible = true;
                tb_finance_payments.Visible = true;
                tb_finance_term.Visible = true;

            }
            else
            {
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                tb_finance_interest.Visible = false;
                tb_finance_payments.Visible = false;
                tb_finance_term.Visible = false;
            }
        }

        private void Initialize_Order()
        {
            tb_finance_payments.Text = "0";
            tb_Order_ID.Text = "";
            tb_Payment_Information.Text = "";
            tb_Downpayment.Text = "0";
            tb_Fees.Text = "0";
            tb_Tax.Text = "0";
            tb_finance_term.Text = "0";
            tb_finance_interest.Text = "0";
            tb_finance_payments.Text = "0";
            tb_Notes.Text = "Enter Notes Here";
            tb_Total_Today.Text = "0";
            tb_Total_Due_On_Car.Text = "0";

        }

        private void Order_Entry_SizeChanged(object sender, EventArgs e)
        {

        }

        private void tb_Downpayment_TextChanged(object sender, EventArgs e)
        {

            MSRP_OK = double.TryParse(tb_MSRP.Text, out MSRP);
            fee_OK = double.TryParse(tb_Fees.Text, out fees);
            tax = (downpayment + fees) * 0.07;
            tb_Tax.Text = tax.ToString("c");

            downpayment_OK = double.TryParse(tb_Downpayment.Text, out downpayment);

            due_today = downpayment + fees + tax;
            remaining = MSRP - due_today;
            tb_Total_Due_On_Car.Text = remaining.ToString("c");
            tb_Total_Today.Text = due_today.ToString("c");

            
        }

        private void tb_Downpayment_Leave(object sender, EventArgs e)
        {
            //tb_Downpayment.Text = downpayment.ToString("c");
        }

        private void tb_Fees_TextChanged(object sender, EventArgs e)
        {
            MSRP_OK = double.TryParse(tb_MSRP.Text, out MSRP);
            fee_OK = double.TryParse(tb_Fees.Text, out fees);
            tax = (downpayment+fees) * 0.07;
            tb_Tax.Text = tax.ToString("c");

            downpayment_OK = double.TryParse(tb_Downpayment.Text, out downpayment);

            due_today = downpayment + fees + tax;
            remaining = MSRP - due_today;
            tb_Total_Due_On_Car.Text = remaining.ToString("c");
            tb_Total_Today.Text = due_today.ToString("c");
        }

        private void tb_finance_term_TextChanged(object sender, EventArgs e)
        {
            finance_term_OK = Int32.TryParse(tb_finance_term.Text, out term);
            finance_interest_OK = double.TryParse(tb_finance_interest.Text, out financing_interest);

            payments = (remaining / term)*((financing_interest/100)+1);

            tb_finance_payments.Text = payments.ToString("c");

        }

        private void tb_finance_interest_TextChanged(object sender, EventArgs e)
        {
            finance_term_OK = Int32.TryParse(tb_finance_term.Text, out term);
            finance_interest_OK = double.TryParse(tb_finance_interest.Text, out financing_interest);

            payments = (remaining / term) * ((financing_interest / 100) + 1);

            tb_finance_payments.Text = payments.ToString("c");
        }

        private void tb_Order_ID_TextChanged(object sender, EventArgs e)
        {
            string Order_ID_string = tb_Order_ID.Text;
            bool isInt = false;
            Order_ID_OK = int.TryParse(Order_ID_string, out Order_ID);
            if (Order_ID > 10000 && Order_ID < 99999)
            {
                isInt = true;
            }
            if (Order_ID_OK == false || isInt == false)
            {
                errorProvider1.SetError(tb_Order_ID, "Not a valid order ID, must be 5 digit int");
            }
            else
            {
                errorProvider1.Clear();
            } 
        }

        private void tb_order_date_TextChanged(object sender, EventArgs e)
        {
            string date = tb_order_date.Text;
            if (date.Length != 10)
            {
                Order_Date_Ok = true;
            }
            if (Order_ID_OK == false)
            {
                errorProvider2.SetError(tb_order_date, "Not a valid date.");
            }
            else
            {
                errorProvider2.Clear();
            } 
        }

        private void tb_Payment_Type_Leave(object sender, EventArgs e)
        {
            string payment_type = tb_Payment_Type.Text;
            if (payment_type.Length != 0)
            {
                payment_type_OK = true;
            }
            if (payment_type_OK == false)
            {
                errorProvider3.SetError(tb_Payment_Type, "Not a payment type.");
            }
            else
            {
                errorProvider3.Clear();
            } 
        }

        private void tb_Payment_Information_Leave(object sender, EventArgs e)
        {
            string payment_information = tb_Payment_Information.Text;
            if (payment_information.Length != 0)
            {
                payment_information_OK = true;
            }
            if (payment_information_OK == false)
            {
                errorProvider4.SetError(tb_Payment_Information, "Payment information needed.");
            }
            else
            {
                errorProvider4.Clear();
            } 
        }

        private void btn_Submit_Order_Click(object sender, EventArgs e)
        {
            double tax = Convert.ToDouble(Double.Parse(tb_Tax.Text, System.Globalization.NumberStyles.Currency));
            double payments = Convert.ToDouble(Double.Parse(tb_finance_payments.Text, System.Globalization.NumberStyles.Currency)); ;
            double total_today = Convert.ToDouble(Double.Parse(tb_Total_Today.Text, System.Globalization.NumberStyles.Currency)); ;
            double total_remaining = Convert.ToDouble(Double.Parse(tb_Total_Due_On_Car.Text, System.Globalization.NumberStyles.Currency)); ;


            if (Order_Date_Ok == true && payment_type_OK == true && payment_information_OK == true)
            {

                string connStr = "SERVER=www.freesql.org;DATABASE=khnz786;UID=khnz786;PASSWORD=ziakhan";
                MySqlConnection myConn = new MySqlConnection(connStr);
                MySqlCommand myComm = myConn.CreateCommand();
                myComm.CommandText = "INSERT INTO `khnz786`.`Order_ID` (`Order_ID`, `Customer_ID`, `Car_ID`, `Order_Date`, `Payment Type`, `Payment Information`, `Down_Payment`, `Tax`, `Fees`, `Financing_Term`, `Financing_Interest`, `Financing_Payments`, `Total_Today`, `Total_Due_on_Car`, `Notes`)" +
                                     " VALUES ("
                                     +Order_ID+", "
                                     + Customer_ID +", "
                                     +Car_ID+", '" 
                                     + tb_order_date.Text + "', '"
                                     +tb_Payment_Type.Text+"', '"
                                     +tb_Payment_Information.Text+"', "
                                     +tb_Downpayment.Text+", '"
                                     +tax+"', '"
                                     +tb_Fees.Text+"', "
                                     +tb_finance_term.Text+", '"
                                     +tb_finance_interest.Text+"', "
                                     +payments+", '"
                                     +total_today+"', '"
                                     +total_remaining+"', '"
                                     +tb_Notes.Text+"' )";
                MessageBox.Show(myComm.CommandText);

                try
                {
                    myConn.Open();

                    MySqlDataAdapter MySQLDA = new MySqlDataAdapter(myComm.CommandText, myConn);
                    MySqlCommandBuilder MySQLCB = new MySqlCommandBuilder(MySQLDA);

                    DataTable dt = new DataTable();
                    try
                    {
                        MySQLDA.Fill(dt);
                        MessageBox.Show("Order added successfully!");
                        //Clear();
                        //this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    BindingSource BS = new BindingSource();
                    BS.DataSource = dt;
                }
                finally
                {
                    if (myConn.State != ConnectionState.Closed)
                    {
                        myConn.Close();

                    }
                }
            }
        }
    }
}
