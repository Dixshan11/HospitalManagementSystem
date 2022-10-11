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
    public partial class DOCTOR_VISIT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        string user;
        public DOCTOR_VISIT(string usertype)
        {
            InitializeComponent();
            user = usertype;
            autoid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void DOCTOR_VISIT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet11.DOCTOR_VISIT' table. You can move, or remove it, as needed.
            this.dOCTOR_VISITTableAdapter.Fill(this.hospitalDataSet11.DOCTOR_VISIT);
            if (user == "doctor")
            {
                this.tabPage1.Hide();
                tabControl1.TabPages.Remove(tabPage1);
                button7.Visible = false;
                button5.Visible = false;
               
                button9.Visible = false;
            }

        }

        private void txtdoctorcharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {


        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            String time = txtstime.Text + '-' + txtetime.Text;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM DOCTOR_VISIT WHERE d_id='"+txtdoctorid.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {

                SqlCommand cmd1 = new SqlCommand("UPDATE DOCTOR_VISIT SET comday='"+time+"',max_patient='"+txtmaximumpatient+"' WHERE d_id='" + txtdoctorid.Text + "'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdoctorid.Clear();
                txtmaximumpatient.Clear();
                comday.SelectedIndex =0;
                con.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DOCTOR_VISIT (d_id,"+comday.Text+" ,max_patient)VALUES('" + txtdoctorid.Text + "','" + time + "','" + txtmaximumpatient.Text + "') ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdoctorid.Clear();
                txtmaximumpatient.Clear();
                comday.SelectedIndex = 0;
                con.Close();
            }
           
        }


    /* private void txtupdate_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM DOCTOR_VISIT WHERE d_id='" + txtdoctoridu.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {

                }
            }

        }*/

        private void btnmainmenu_Click(object sender, EventArgs e)
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

        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (d_id)+1 FROM DOCTOR_VISIT", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtdoctorid.Text = sdr[0].ToString();
                    if (txtdoctorid.Text == "")
                    {
                        txtdoctorid.Text = "10";
                    }
                }
            }
            else
            {
                txtdoctorid.Text = "10";
                return;
            }
            con.Close();
        }

        /* private void btnupsearch_Click(object sender, EventArgs e)
         {
             if (comboBox1.Text == "ID")
             {
                 SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM DOCTOR_VISIT WHERE d_id='" + txtsearchup.Text + "' ", con);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 if (dt.Rows[0][0].ToString() == "1")
                 {
                     SqlCommand cmd = new SqlCommand("SELECT * FROM DOCTOR_VISIT WHERE d_id='" + txtsearchup.Text + "' ", con);
                     con.Open();
                     SqlDataReader sdr = cmd.ExecuteReader();
                     while (sdr.Read())
                     {
                         txtdoctoridu.Text = sdr[1].ToString();
                         txtupdactorname.Text = sdr[2].ToString();
                         txtdayu.Text = sdr[3].ToString();
                         txtstimeu.Text = sdr[4].ToString();
                         txtetimeu.Text = sdr[5].ToString();
                         txtmaxmimumpatientu.Text = sdr[6].ToString();


                     }
                 }
                 con.Close();
             }
             else if (comboBox1.Text == "NAME")

             {
                 SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM DOCTOR_VISIT WHERE f_name='" + txtsearchup.Text + "'OR l_name= '" + txtsearchup.Text + "'", con);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 if (dt.Rows[0][0].ToString() == "1")
                 {
                     SqlCommand cmd = new SqlCommand("SELECT * FROM DOCTOR_VISIT WHERE f_name='" + txtsearchup.Text + "'OR l_name='" + txtsearchup.Text + "' ", con);
                     con.Open();
                     SqlDataReader sdr = cmd.ExecuteReader();
                     while (sdr.Read())
                     {

                         txtdoctoridu.Text = sdr[1].ToString();
                         txtupdactorname.Text = sdr[2].ToString();
                         txtdayu.Text = sdr[3].ToString();
                         txtstimeu.Text = sdr[4].ToString();
                         txtetimeu.Text = sdr[5].ToString();
                         txtmaxmimumpatientu.Text = sdr[6].ToString();

                     }
                 }
                 con.Close();
             }
         }*/

        private void txtetimeu_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            INTERFACE myform = new INTERFACE();
            myform.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void btnpatient_Click(object sender, EventArgs e)
        {
            PATINET myform = new PATINET(user);
            myform.Show();
            this.Hide();
        }

        private void btnappoinment_Click(object sender, EventArgs e)
        {
            APPONITMENT myform = new APPONITMENT(user);
            myform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PAYMENT myform = new PAYMENT(user);
            myform.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            treatment myform = new treatment(user);
            myform.Show();
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}