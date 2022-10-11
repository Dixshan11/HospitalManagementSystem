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
    public partial class NURSE : Form

    { //  connection for database(sql)
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security = True");
        string user;
        public NURSE(string usertype)
        {
            InitializeComponent();
            user = usertype;
            autoid();
        }

        private void NURSE_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet9.NURSE' table. You can move, or remove it, as needed.
            this.nURSETableAdapter4.Fill(this.hospitalDataSet9.NURSE);
            // TODO: This line of code loads data into the 'hospitalDataSet8.NURSE' table. You can move, or remove it, as needed.
            this.nURSETableAdapter3.Fill(this.hospitalDataSet8.NURSE);
            // TODO: This line of code loads data into the 'hospitalDataSet6.NURSE' table. You can move, or remove it, as needed.
            this.nURSETableAdapter2.Fill(this.hospitalDataSet6.NURSE);
            // TODO: This line of code loads data into the 'hospitalDataSet5.NURSE' table. You can move, or remove it, as needed.
            this.nURSETableAdapter1.Fill(this.hospitalDataSet5.NURSE);
            // TODO: This line of code loads data into the 'hospitalDataSet.NURSE' table. You can move, or remove it, as needed.

            if (user == "docor")
            {
                this.tabPag1.Hide();
                tabcontrol1.TabPages.Remove(tabPag1);
                this.tabPage2.Hide();
                tabcontrol1.TabPages.Remove(tabPage2);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
            // add coding to data base
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO NURSE(f_name,l_name,gender,telephone_no,nic,address,email)VALUES('" + txtfnameu.Text + "','" + txtlnameu.Text + "','" + txtgenderu.Text + "','" + txttelephonenou.Text + "','" + txtnicu.Text + "','" + txtaddressu.Text + "','" + txtemailu.Text
                + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            txtfnameu.Clear();
            txtlnameu.Clear();
            txtgenderu.Clear();
            txttelephonenou.Clear();
            txtnicu.Clear();
            txtaddressu.Clear();
            txtemailu.Clear();
            txtnurseid.Clear();

        }

        private void btnserach_Click(object sender, EventArgs e)
        {//search by id
            if (comboBox1.Text == "ID")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM NURSE WHERE n_id='" + txtsearchup.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM NURSE WHERE n_id='" + txtsearchup.Text + "' ", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtnurseidu.Text = sdr[0].ToString();
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtgenderu.Text = sdr[3].ToString();
                        txttelephonenou.Text = sdr[4].ToString();
                        txtnicu.Text = sdr[5].ToString();
                        txtaddressu.Text = sdr[6].ToString();
                        txtemailu.Text = sdr[7].ToString();

                    }
                }
                con.Close();
            }
            else if (comboBox1.Text == "NAME")

            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM NURSE WHERE f_name='" + txtsearchup.Text + "'OR l_name= '" + txtsearchup.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM NURSE WHERE f_name='" + txtsearchup.Text + "'OR l_name='"+txtsearchup.Text+"' ", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtnurseidu.Text = sdr[0].ToString();
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtgenderu.Text = sdr[3].ToString();
                        txttelephonenou.Text = sdr[4].ToString();
                        txtnicu.Text = sdr[5].ToString();
                        txtaddressu.Text = sdr[6].ToString();
                        txtemailu.Text = sdr[7].ToString();

                    }
                }
                con.Close();
            }

            else if (comboBox1.Text == "NIC")
            {

                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM NURSE WHERE nic='" + txtsearchup.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM NURSE WHERE nic='" + txtsearchup.Text + "' ", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtnurseidu.Text = sdr[0].ToString();
                        txtfnameu.Text = sdr[1].ToString();
                        txtlnameu.Text = sdr[2].ToString();
                        txtgenderu.Text = sdr[3].ToString();
                        txttelephonenou.Text = sdr[4].ToString();
                        txtnicu.Text = sdr[5].ToString();
                        txtaddressu.Text = sdr[6].ToString();
                        txtemailu.Text = sdr[7].ToString();

                    }
                }
                con.Close();
            }
        }


        private void btnupdate_Click(object sender, EventArgs e)
        {// update in to database
            SqlCommand cmd = new SqlCommand("UPDATE NURSE SET f_name='" + txtfnameu.Text + "',l_name='" + txtlnameu.Text + "',gender='" + txtgenderu.Text + "',telephone_no='" + txttelephonenou.Text + "',nic='" + txtnicu.Text + "',address='" + txtaddressu.Text + "',email='" + txtemailu.Text + "' WHERE n_id='"+txtsearchup.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtfnameu.Clear();
            txtlnameu.Clear();
            txtgenderu.Clear();
            txttelephonenou.Clear();
            txtnicu.Clear();
            txtaddressu.Clear();
            txtemailu.Clear();
            con.Close();
        }

        void autoid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (n_id)+1 FROM NURSE", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtnurseid.Text = sdr[0].ToString();
                    if (txtnurseid.Text == "")
                    {
                        txtnurseid.Text = "1";
                    }
                }
            }
            else
            {
                txtnurseid.Text = "1";
                return;
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(user == "ADMIN")
            {
                admindash frm = new admindash(user);
                frm.Show();
                this.Hide();

            }
            else if(user == "DOCTOR")
            {
                doctordash frm = new doctordash(user);
                frm.Show();
                this.Hide();
            }
            else
            {
                INTERFACE frm = new INTERFACE();
                frm.Show();
                this.Hide();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO NURSE(f_name,l_name,gender,telephone_no,nic,address,email)VALUES('" + txtfname.Text + "','" + txtlname.Text + "','" + txtgender.Text + "','" + txttelephoneno.Text + "','" + txtnic.Text + "','" + txtaddress.Text + "','"+txtemail.Text+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            txtfname.Clear();
            txtlname.Clear();
            txtgender.Clear();
            txttelephoneno.Clear();
            txtnic.Clear();
            txtaddress.Clear();
            txtemail.Clear();
            con.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {


        }
        private void label17_Click(object sender, EventArgs e)
        {

        }

       
        

        private void button9_Click_1(object sender, EventArgs e)
        {
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PATINET myform = new PATINET(user);
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

        private void button8_Click(object sender, EventArgs e)
        {
            DOCTOR_VISIT myform = new DOCTOR_VISIT(user);
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

        

        private void button13_Click(object sender, EventArgs e)
        {
            APPONITMENT myform = new APPONITMENT(user);
            myform.Show();
            this.Hide();
        }

        private void txtnurseid_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            INTERFACE myform = new INTERFACE();
            myform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user == "admin")
            {
                admindash myform = new admindash(user);
                myform.Show();
                this.Hide();
            }
            else if(user=="doctor")
            {
                doctordash myform = new doctordash(user);
                myform.Show();
                this.Hide();
            }

        }

        private void tabPag1_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_2(object sender, EventArgs e)
        {

            treatment myform = new treatment(user);
            myform.Show();
            this.Hide();
        }
    }
}



        


        
        
    
