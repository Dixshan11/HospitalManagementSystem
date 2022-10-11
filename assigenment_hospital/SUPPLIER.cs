using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace assigenment_hospital
{
    public partial class SUPPLIER : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        string user;
        public SUPPLIER(string usertype)
        {
            InitializeComponent();
            user = usertype;
            autoid();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SUPPLIER_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet13.SUPPLIER' table. You can move, or remove it, as needed.
            this.sUPPLIERTableAdapter.Fill(this.hospitalDataSet13.SUPPLIER);
           
           

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO SUPPLIER(type,name,quendity,price,discount,exp_date,manu_date,company,usage_instrucation)VALUES('" + txttype.Text + "','" + txtname.Text + "','" + txtquendity.Text + "','" + txtprice.Text + "','" + txtdiscount.Text + "','" + txtexpdate.Text + "','"
                + txtmanudate.Text + "','" + txtcompany.Text + "','" + txtusage.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            txttype.Clear();
            txtname.Clear();
            txtquendity.Clear();
            txtprice.Clear();
            txtdiscount.Clear();
            txtdiscount.Clear();
            txtexpdate.Clear();
            txtmanudate.Clear();
            txtcompany.Clear();
            txtusage.Clear();
        }

        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (supplier_id)+1 FROM SUPPLIER", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtsupplierid.Text = sdr[0].ToString();
                    if (txtsupplierid.Text == "")
                    {
                        txtsupplierid.Text = "1";
                    }
                }
            }
            else
            {
                txtsupplierid.Text = "1";
                return;
            }
            con.Close();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnsearchu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM SUPPLIER WHERE supplier_id='" + txtsearchu.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SUPPLIER WHERE supplier_id='" + txtsearchu.Text + "'", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    txtsupplieridu.Text = sdr[0].ToString();
                    txttypeu.Text = sdr[1].ToString();
                    txtnameu.Text = sdr[2].ToString();
                    txtquendityu.Text = sdr[3].ToString();
                    txtpriceu.Text = sdr[4].ToString();
                    txtdiscountu.Text = sdr[5].ToString();
                    txtexpdateu.Text = sdr[6].ToString();
                    txtmanudateu.Text = sdr[7].ToString();
                    txtcompanyu.Text = sdr[8].ToString();
                    txtusageu.Text = sdr[9].ToString();

                }
                con.Close();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE SUPPLIER SET type='" + txttypeu.Text + "',name='" + txtnameu.Text + "',quendity='" + txtquendityu.Text + "',price='" + txtpriceu.Text + "',discount='" + txtdiscountu.Text + "',exp_date='" + txtexpdateu.Text + "',manu_date='" + txtmanudateu.Text + "',company='" + txtcompanyu.Text + "',usage_instrucation='" + txtusageu.Text + "' WHERE supplier_id='" + txtsearchu.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txttypeu.Clear();
            txtnameu.Clear();
            txtquendityu.Clear();
            txtpriceu.Clear();
            txtdiscountu.Clear();
            txtexpdateu.Clear();
            txtmanudateu.Clear();
            txtcompanyu.Clear();
            txtusageu.Clear();

            
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user == "admin")
            {
                admindash myform = new admindash(user);
                myform.Show();
                this.Hide();
            }
            else if (user == "doctor")
            {
                doctordash myform = new doctordash(user);
                myform.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DOCTOR myform = new DOCTOR(user);
            myform.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           DOCTOR_TYPE myform = new DOCTOR_TYPE(user);
            myform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DOCTOR_VISIT myform = new DOCTOR_VISIT(user);
            myform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PATINET myform = new PATINET(user);
            myform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PAYMENT myform = new PAYMENT(user);
            myform.Show();
            this.Hide();
        }

        private void btnappoinment_Click(object sender, EventArgs e)
        {
            APPONITMENT myform = new APPONITMENT(user);
            myform.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NURSE myform = new NURSE(user);
            myform.Show();
            this.Hide();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            INTERFACE myform = new INTERFACE();
            myform.Show();
            this.Hide();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
           treatment myform = new treatment(user);
            myform.Show();
            this.Hide();
        }

      
    }
}