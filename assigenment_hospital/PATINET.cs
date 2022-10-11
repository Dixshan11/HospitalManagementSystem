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
    public partial class PATINET : Form
    {
        string user;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        public PATINET( String usertype)
        {
            InitializeComponent();
            autoid();
            user = usertype;
                        

        }

        private void DOB_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PATINET_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet16.PATIENT' table. You can move, or remove it, as needed.
            this.pATIENTTableAdapter4.Fill(this.hospitalDataSet16.PATIENT);
            // TODO: This line of code loads data into the 'hospitalDataSet15.PATIENT' table. You can move, or remove it, as needed.
            this.pATIENTTableAdapter3.Fill(this.hospitalDataSet15.PATIENT);
            // TODO: This line of code loads data into the 'hospitalDataSet14.PATIENT' table. You can move, or remove it, as needed.
            this.pATIENTTableAdapter2.Fill(this.hospitalDataSet14.PATIENT);
            // TODO: This line of code loads data into the 'hospitalDataSet3.PATIENT' table. You can move, or remove it, as needed.
        //    pATIENTTableAdapter1.Fill(this.hospitalDataSet3.PATIENT);
            // TODO: This line of code loads data into the 'hospitalDataSet2.PATIENT' table. You can move, or remove it, as needed.
          //  this.pATIENTTableAdapter.Fill(this.hospitalDataSet2.PATIENT);
            if (user == "doctor")
            {
                this.tabPage1.Hide();
                tabControl1.TabPages.Remove(tabPage1);
                this.tabPage2.Hide();
                tabControl1.TabPages.Remove(tabPage2);
               
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //to insert deatils to SQL 
            SqlCommand cmd = new SqlCommand("INSERT INTO PATIENT(f_name,l_name,dob,gender,telephoneno,address,email,nic)VALUES('" + txtfname.Text + "','" + txtlname.Text + "','" + txtdob.Text + "','" + txtgender.Text + "','" + txttelephoneno.Text + "','" + txtaddress.Text + "','" + txtemail.Text + "','" + txtnic.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            // to show success message
            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            // after clear all the fill the data from textboxes
            
            txtfname.Clear();
            txtlname.Clear();
            txtdob.Clear();
            txtgender.Clear();
            txttelephoneno.Clear();
            txtnic.Clear();
            txtaddress.Clear();
            txtemail.Clear();
            autoid();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnsearchu_Click(object sender, EventArgs e)
        {
            // to view the deatils that entered id
            if (comboBox1.Text == "ID")
            {
                // to check the requested id is true or false
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM PATIENT WHERE p_id='" + txtsearchu.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                // if the data avilable then this command deliver all the deatils of the id
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PATIENT WHERE p_id='" + txtsearchu.Text + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtdobu.Text = sdr[3].ToString();
                       txtgenderu.Text = sdr[4].ToString();
                        txttelephonenou.Text = sdr[5].ToString();
                        txtaddressu.Text = sdr[6].ToString();
                        txtemailu.Text = sdr[7].ToString();
                        txtnicu.Text = sdr[8].ToString();

                    }
                    con.Close();
                }
            }
            // if the data avilable then this command deliver all the deatils of the name
            else if (comboBox1.Text == "Name")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM PATIENT WHERE  f_name='" + txtsearchu.Text + "'OR l_name='" + txtsearchu.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PATIENT WHERE f_name='" + txtsearchu.Text + "'OR l_name='" + txtsearchu.Text + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtdobu.Text = sdr[3].ToString();
                        txtgenderu.Text = sdr[4].ToString();
                        txttelephonenou.Text = sdr[5].ToString();
                        txtnicu.Text = sdr[8].ToString();
                        txtaddressu.Text = sdr[6].ToString();
                        txtemailu.Text = sdr[7].ToString();

                    }

                    con.Close();

                }
            }
            // if the data avilable then this command deliver all the deatils of the nic
            else if (comboBox1.Text == "nic")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM PATIENT WHERE  nic='" + txtsearchu.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PATIENT WHERE nic='" + txtsearchu.Text + "' ", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtdobu.Text = sdr[3].ToString();
                        txtgenderu.Text = sdr[4].ToString();
                        txttelephonenou.Text = sdr[5].ToString();
                        txtnicu.Text = sdr[8].ToString();
                        txtaddressu.Text = sdr[6].ToString();
                        txtemailu.Text = sdr[7].ToString();

                    }

                    con.Close();
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // update the deatils into the database
            SqlCommand cmd = new SqlCommand("UPDATE PATIENT SET f_name='" + txtfnameu.Text + "',l_name='" + txtlnameu.Text + "',dob='" + txtdobu.Text + "',gender='" + txtgenderu.Text + "',telephoneno='" + txttelephonenou.Text + "',address='" + txtaddressu.Text + "',email='"+txtemailu.Text+"',nic='"+txtnicu.Text+"' WHERE p_id='"+txtsearchu.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            //for display success message
            MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // to clear fill the data in the text box
            txtfnameu.Clear();
            txtlnameu.Clear();
            txtdobu.Clear();
            txtgenderu.Clear();
            txttelephonenou.Clear();
            txtnicu.Clear();
            txtaddressu.Clear();
            txtemailu.Clear();
     
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void autoid() // for automatic id
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (p_id)+1 FROM PATIENT",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    txtpatientid.Text = sdr[0].ToString();
                    if(txtpatientid.Text=="")
                    {
                        txtpatientid.Text = "1000";
                    }
                }
            }
            else
            {
                txtpatientid.Text = "1000";
                return;
            }
            con.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

      
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (user == "admin")
            {
                admindash myform = new admindash("user");
                myform.Show();
                this.Hide();
            }
            else if (user == "doctor")
            {
                doctordash myform = new doctordash("user");
                myform.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SUPPLIER myform = new SUPPLIER(user);
            myform.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DOCTOR myform = new DOCTOR(user);
            myform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DOCTOR_VISIT myform = new DOCTOR_VISIT(user);
            myform.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DOCTOR_TYPE myform = new DOCTOR_TYPE(user);
            myform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PAYMENT myform = new PAYMENT(user);
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

       

        private void button11_Click(object sender, EventArgs e)
        {
            INTERFACE myform = new INTERFACE();
            myform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treatment myform = new treatment(user);
            myform.Show();
            this.Hide();

        }

      
    }
}
