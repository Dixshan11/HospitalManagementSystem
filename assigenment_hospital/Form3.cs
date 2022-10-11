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
    public partial class DOCTOR : Form
    {
        string user;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        public DOCTOR(string usertype)
        {
            InitializeComponent();
            autoid();
            user = usertype;
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DOCTOR(f_name,l_name,doctortype,doctor_charge,gender,telephone_no,nic,address,email)VALUES('" + txtfname.Text + "','" + txtlname.Text + "','" + txtdoctortype.Text + "','"+txtdoctorcharge.Text+"','" + txtgender.Text + "','" + txttelephone.Text + "','" + txtnic.Text + "','"
                + txtaddress.Text + "','" + txtemail.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            txtfname.Clear();
            txtlname.Clear();
            txtdoctortype.SelectedIndex = 0;
            txtdoctorcharge.Clear();
            txtgender.Clear();
            txttelephone.Clear();
            txtnic.Clear();
            txtaddress.Clear();
            txtemail.Clear();
            
        }

        private void btnserachup_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM DOCTOR WHERE f_name='" + txtsearch.Text + "' OR l_name= '" + txtsearch.Text + "' OR  gender= '" + txtsearch.Text + "' OR doctor_charge='"+txtsearch.Text+"'OR telephone_no= '" + txtsearch.Text + "'OR nic= '" + txtsearch.Text + "' OR address= '" + txtsearch.Text + "'OR email= '" + txtsearch.Text + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            sda.Fill(dt);
            con.Close();
            dataGridView2.DataSource = dt;



        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM DOCTOR WHERE d_id='" + txtsearchup.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM DOCTOR WHERE d_id='" + txtsearchup.Text + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtdoctoridu.Text = sdr[0].ToString();
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtdoctortypeu.Text = sdr[3].ToString();
                       
                       txtgenderu.Text = sdr[4].ToString();
                        txttelephonenou.Text = sdr[5].ToString();
                        txtnicu.Text = sdr[6].ToString();
                        txtaddressu.Text = sdr[7].ToString();
                        txtemailu.Text= sdr[8].ToString();
                        txtdoctorchargeu.Text = sdr[9].ToString();

                    }
                    con.Close();
                }
            }
            else if (comboBox1.Text == "Name")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM DOCTOR WHERE  f_name='" + txtsearchup.Text + "'OR l_name='" + txtsearchup.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM DOCTOR WHERE f_name='" + txtsearchup.Text + "'OR l_name='" + txtsearchup.Text + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {


                        txtdoctoridu.Text = sdr[0].ToString();
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtdoctortypeu.Text = sdr[3].ToString();

                        txtgenderu.Text = sdr[4].ToString();
                        txttelephonenou.Text = sdr[5].ToString();
                        txtnicu.Text = sdr[6].ToString();
                        txtaddressu.Text = sdr[7].ToString();
                        txtemailu.Text = sdr[8].ToString();
                        txtdoctorchargeu.Text = sdr[9].ToString();
                    }

                    con.Close();

                }
            }
            else if (comboBox1.Text == "nic")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM DOCTOR WHERE  nic='" + txtsearchup.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM DOCTOR WHERE nic='" + txtsearchup.Text + "' ", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {

                        txtdoctoridu.Text = sdr[0].ToString();
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtdoctortypeu.Text = sdr[3].ToString();

                        txtgenderu.Text = sdr[4].ToString();
                        txttelephonenou.Text = sdr[5].ToString();
                        txtnicu.Text = sdr[6].ToString();
                        txtaddressu.Text = sdr[7].ToString();
                        txtemailu.Text = sdr[8].ToString();
                        txtdoctorchargeu.Text = sdr[9].ToString();

                    }

                    con.Close();
                }
            }
        }
            private void btnupdate_Click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("UPDATE DOCTOR SET f_name='" + txtfnameu.Text + "',l_name='" + txtlnameu.Text + "',doctortype='" + txtdoctortypeu.Text + "',doctor_charge='"+txtdoctorchargeu.Text+"',gender='" + txtgenderu.Text + "',telephone_no='" + txttelephonenou.Text + "',nic='" + txtnicu.Text + "',address='"+txtaddressu.Text+"',email='"+txtemailu.Text+"' WHERE d_id='"+txtsearchup.Text+"' ",  con);
                con.Open();
            
                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtfnameu.Clear();
                txtlnameu.Clear();
                txtdoctortypeu.SelectedIndex=0;
                 txtdoctorchargeu.Clear();
                txtgenderu.Clear();
                txttelephonenou.Clear();
                txtnicu.Clear();
                txtaddressu.Clear();
             txtemailu.Clear();
                
                txtdoctorid.Clear();
            con.Close();
            }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (d_id)+1 FROM DOCTOR", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtdoctorid.Text = sdr[0].ToString();
                    if (txtdoctorid.Text == "")
                    {
                        txtdoctorid.Text = "1000";
                    }
                }
            }
            else
            {
                txtdoctorid.Text = "1000";
                return;
            }
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DOCTOR_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet7.DOCTOR' table. You can move, or remove it, as needed.
            this.dOCTORTableAdapter1.Fill(this.hospitalDataSet7.DOCTOR);
            // TODO: This line of code loads data into the 'hospitalDataSet4.DOCTOR' table. You can move, or remove it, as needed.
            this.dOCTORTableAdapter.Fill(this.hospitalDataSet4.DOCTOR);
            if (user == "doctor")
            {
                this.tabPage1.Hide();
                tabControl1.TabPages.Remove(tabPage1);
                this.tabPage2.Hide();
                tabControl1.TabPages.Remove(tabPage2);
                button5.Visible = false;
                button6.Visible = false;
             
                button10.Visible = false;
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            DOCTOR_VISIT myform = new DOCTOR_VISIT(user);
            myform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DOCTOR_TYPE myform = new DOCTOR_TYPE(user);
            myform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PATINET myform = new PATINET(user);
            myform.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NURSE myform = new NURSE(user);
            myform.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
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

        private void txtdoctorcharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txttelephone_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txttelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtdoctorid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdoctorid_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 )
            {
                e.Handled = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            treatment myform = new treatment(user);
            myform.Show();
            this.Hide();
        }
    }
    }
