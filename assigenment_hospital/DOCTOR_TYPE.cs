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
    public partial class DOCTOR_TYPE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        
        string user;
        public DOCTOR_TYPE(string usertype)
        {
            InitializeComponent();
            user = usertype;
            autoid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (Id)+1 FROM doctor_type", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtdoctorid.Text = sdr[0].ToString();
                    if (txtdoctorid.Text == "")
                    {
                       txtdoctorid.Text = "1";
                    }
                }
            }
            else
            {
               txtdoctorid.Text = "1";
                return;
            }
            con.Close();
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

        private void button1_Click(object sender, EventArgs e)
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

        private void DOCTOR_TYPE_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet17.doctor_type' table. You can move, or remove it, as needed.
            this.doctor_typeTableAdapter.Fill(this.hospitalDataSet17.doctor_type);
            if (user == "docor")
            {
                this.tabPage1.Hide();
                tabControl1.TabPages.Remove(tabPage1);
                this.tabpage2.Hide();
                tabControl1.TabPages.Remove(tabpage2);
               
                button6.Visible = false;
                button7.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          treatment myform = new treatment(user);
            myform.Show();
            this.Hide();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO doctor_type(Id,type)VALUES('" + txtdoctorid.Text+ "','" + txttype.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            txttype.Clear();
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE doctor_type SET type='" + txttypeu.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txttypeu.Clear();
            

        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM doctor_type WHERE Id='" + txtdoctoridu.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM doctor_type WHERE Id='" + txtdoctoridu.Text + "'", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    txttypeu.Text = sdr[1].ToString();
                    

                }
                con.Close();
            }
        }
    }
}
