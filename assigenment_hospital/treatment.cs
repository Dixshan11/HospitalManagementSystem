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
    public partial class treatment : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security = True");
        string user;
        public treatment(string usertype)
        {
            InitializeComponent();
            user = usertype;
            autoid();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

        private void tab1_Click(object sender, EventArgs e)
        {

        }

        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (treatment_id)+1 FROM TREATMENT", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txttid.Text = sdr[0].ToString();
                    if (txttid.Text == "")
                    {
                        txttid.Text = "1";
                    }
                }
            }
            else
            {
                txttid.Text = "1";
                return;
            }
            con.Close();
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (txtdid.Text == "" || txtpid.Text == "" || txtdi.Text == "" || txtth.Text == "" || txtpre.Text == "" )
            {
                MessageBox.Show("plese fill the blank page");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TREATMENT( treatment_id,d_id,p_id,disease,treatment_histroy,prescription)VALUES('" + txttid.Text + "','" + txtdid.Text + "','" + txtpid.Text + "','" + txtdi.Text + "','" + txtth.Text + "','" + txtpre.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtdid.Clear();
                txtpid.Clear();

                txtdi.Clear();
                txtth.Clear();
                txtpre.Clear();
            }
        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM TREATMENT WHERE treatment_id='" + txtsearchu.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TREATMENT WHERE treatment_id='" + txtsearchu.Text + "'", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    txttid.Text = sdr[1].ToString();
                    txtdid.Text = sdr[2].ToString();
                    txtdi.Text = sdr[3].ToString();
                    txtth.Text = sdr[4].ToString();
                    txtpre.Text = sdr[5].ToString();
                    


                }
                con.Close();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TREATMENT SET d_id='" + txtdid.Text + "',p_id='" + txtpid.Text + "',disease='" +txtdi.Text + "',treatment_histroy='" + txtth.Text + "',prescription='" + txtpre.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txttid.Clear();
            txtpre.Clear();
            txtpid.Clear();
            txtdi.Clear();
            txtth.Clear();
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DOCTOR myform = new DOCTOR(user);
            myform.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            DOCTOR_VISIT myform = new DOCTOR_VISIT(user);
            myform.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            DOCTOR_TYPE myform = new DOCTOR_TYPE(user);
            myform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            APPONITMENT myform = new APPONITMENT(user);
            myform.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {
            INTERFACE myform = new INTERFACE();
            myform.Show();
            this.Hide();
        }
    }
}
