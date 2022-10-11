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
    public partial class APPONITMENT : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security = True");
        string user;
        public APPONITMENT(string usertype)
        {
            InitializeComponent();
            user = usertype;
            autoid();
            
        }
      

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtdate.Text=="" || txttime.Text=="" || txtbookeddate.Text=="" || txtdoctorname.Text=="" || txtpatientname.Text=="" || txtreason.Text=="")
            {
                MessageBox.Show("plese fill the blank page");
            }
            else {
                SqlCommand cmd = new SqlCommand("INSERT INTO appointment(appointment_date,appointment_time,book_date,doctor_name,patient_name,reason)VALUES('" + txtdate.Text + "','" + txttime.Text + "','" + txtbookeddate.Text + "','" + txtdoctorname.Text + "','" + txtpatientname.Text + "','" + txtreason.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txtdate.CustomFormat="";
                txttime.Clear();
                txtbookeddate.CustomFormat="";
                txtdoctorname.Clear();
                txtpatientname.Clear();
                txtreason.Clear();
            }
            
        }
       
        private void APPONITMENT_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'hospitalDataSet10.appointment' table. You can move, or remove it, as needed.
           // this.appointmentTableAdapter.Fill(this.hospitalDataSet10.appointment);
            // TODO: This line of code loads data into the 'hospitalDataSet1.DOCTOR' table. You can move, or remove it, as needed.
            this.dOCTORTableAdapter.Fill(this.hospitalDataSet1.DOCTOR);
            if (user == "doctor")
            {
                this.tab1.Hide();
                tabControl1.TabPages.Remove(tab1);
                this.tabPage2.Hide();
                tabControl1.TabPages.Remove(tabPage2);
                button5.Visible = false;

                button7.Visible = false;
                button6.Visible = false;

            }
        }
        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (appointment_id)+1 FROM appointment", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtappoinmentid.Text = sdr[0].ToString();
                    if (txtappoinmentid.Text == "")
                    {
                        txtappoinmentid.Text = "1";
                    }
                }
            }
            else
            {
                txtappoinmentid.Text = "1";
                return;
            }
            con.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE appointment SET appointment_date='" + txtappdateu.Text + "',appointment_time='" + txtapptimeu.Text + "',book_date='" + txtbookeddateu.Text + "',doctor_name='" + txtdnameu.Text + "',patient_name='" + txtpnameu.Text + "',reason='" + txtreasonu.Text + "'WHERE appointment_id='"+txtsearchu.Text+"' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtdate.CustomFormat="";
            txttime.Clear();
            txtbookeddate.CustomFormat = "";
            txtdoctorname.Clear();
            txtpatientname.Clear();
            txtreason.Clear();
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NURSE myform = new NURSE(user);
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM appointment WHERE appointment_id='" + txtsearchu.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM appointment WHERE appointment_id='" + txtsearchu.Text + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    { 
                        txtappdateu.Text = sdr[1].ToString();
                        txtapptimeu.Text = sdr[2].ToString();
                       txtbookeddateu.Text = sdr[3].ToString();
                        txtdnameu.Text = sdr[4].ToString();
                        txtpnameu.Text = sdr[5].ToString();
                        txtreasonu.Text = sdr[6].ToString();
                       
                       
                    }
                    con.Close();
                }
            }
            else if (comboBox1.Text == "PATIENT_NAME")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM appointment WHERE  patient_name='" + txtsearchu.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM appointment WHERE patient_name='" + txtsearchu.Text + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        
                        txtappdateu.Text = sdr[1].ToString();
                        txtapptimeu.Text = sdr[2].ToString();
                        txtbookeddateu.Text = sdr[3].ToString();
                        txtdnameu.Text = sdr[4].ToString();
                        txtpnameu.Text = sdr[5].ToString();
                        txtreasonu.Text = sdr[6].ToString();
                    }

                    con.Close();

                }
            }
           
        }

            private void button1_Click(object sender, EventArgs e)
        {
            DOCTOR myform = new DOCTOR(user);
            myform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DOCTOR_TYPE myform = new DOCTOR_TYPE(user);
            myform.Show();
            this.Hide();
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

        private void SEARCH_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DOCTOR_TYPE myform = new DOCTOR_TYPE("user");
            myform.Show();
            this.Hide();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            treatment myform = new treatment("user");
            myform.Show();
            this.Hide();

        }

        
    }
}
