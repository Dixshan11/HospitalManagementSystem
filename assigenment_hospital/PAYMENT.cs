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
    public partial class PAYMENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        string user;

        public PAYMENT(string usertype)
        {
            InitializeComponent();
            user = usertype;
            autoid();
        }

        private void PAYMENT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet12.PAYMENT' table. You can move, or remove it, as needed.
            this.pAYMENTTableAdapter.Fill(this.hospitalDataSet12.PAYMENT);
            if (user == "doctor")
            {
                this.tabPage1.Hide();
                tabControl1.TabPages.Remove(tabPage1);
                this.tabPage2.Hide();
                tabControl1.TabPages.Remove(tabPage2);
                button3.Visible = false;
                
                button7.Visible = false;
                btndoctortype.Visible = false;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PAYMENT(paydate,doctor_charge,medicine_charge,room_charge,totel_amount,status)VALUES('" + txtpaymentdate.Text + "','" + txtdoctorcharge.Text + "','" + txtmedicinecharge.Text + "','" + txtroomcharge.Text + "','"+txttotel.Text+"','" + txtstatus.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            txtpaymentdate.Clear();
            txtdoctorcharge.Clear();
            txtmedicinecharge.Clear();
            txtroomcharge.Clear();
            txttotel.Clear();
            txtstatus.Clear();
           
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PAYMENT SET paydate='" + txtpaymentdateu.Text + "',doctor_charge='" + txtdoctorchargeu.Text + "',medicine_charge='" + txtmedicinechargeu.Text + "',room_charge='" + txtroomchargeu.Text + "',totel_amount='" + txttotelamountu.Text + "',status='" + txtstatusu.Text + "'WHERE payment_id='"+txtsearchup.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtpaymentdateu.Clear();
            txtdoctorchargeu.Clear();
            txtmedicinechargeu.Clear();
            txtroomchargeu.Clear();
            txttotelamountu.Clear();
            txtstatusu.Clear();
            
            con.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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

        private void txtmedicinecharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM PAYMENT WHERE payment_id='" + txtsearchup.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PAYMENT WHERE payment_id='" + txtsearchup.Text + "' ", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                { txtpaymentidu.Text = sdr[0].ToString();
                    txtpaymentdateu.Text = sdr[1].ToString();
                    txtdoctorchargeu.Text = sdr[2].ToString();
                    txtmedicinechargeu.Text = sdr[3].ToString();
                    txtroomchargeu.Text = sdr[4].ToString();
                    txttotelamountu.Text = sdr[5].ToString();
                    txtstatusu.Text = sdr[6].ToString();
                    
                }
            }
            con.Close();
        }

        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (payment_id)+1 FROM PAYMENT", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtpaymentid.Text = sdr[0].ToString();
                    if (txtpaymentid.Text == "")
                    {
                        txtpaymentid.Text = "1";
                    }
                }
            }
            else
            {
                txtpaymentid.Text = "1";
                return;
            }
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {

            DOCTOR myform = new DOCTOR(user);
            myform.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DOCTOR_VISIT myform = new DOCTOR_VISIT(user);
            myform.Show();
            this.Hide();
        }

        private void btndoctortype_Click(object sender, EventArgs e)
        {

            DOCTOR_TYPE myform = new DOCTOR_TYPE(user);
            myform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            PATINET myform = new PATINET(user);
            myform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            APPONITMENT myform = new APPONITMENT(user);
            myform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            NURSE myform = new NURSE(user);
            myform.Show();
            this.Hide();
        }

       

        private void button7_Click(object sender, EventArgs e)
        {

            SUPPLIER myform = new SUPPLIER(user);
            myform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            INTERFACE myform = new INTERFACE();
            myform.Show();
            this.Hide();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            treatment myform = new treatment(user);
            myform.Show();
            this.Hide();
        }

        
    }
}
