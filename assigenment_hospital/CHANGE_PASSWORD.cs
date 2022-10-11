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
    public partial class CHANGE_PASSWORD : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        string user;
        public CHANGE_PASSWORD(string usertype)
        {
            InitializeComponent();
            user = usertype;
        }

        private void CHANGE_PASSWORD_Load(object sender, EventArgs e)
        {
            txtoldpassword.PasswordChar = '*';
            txtnewpassword.PasswordChar = '*';
            txtnewpassword.MaxLength = 10;
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM login WHERE username='" + txtusername.Text + "' AND password='" + txtoldpassword.Text + "'AND usertype='" + user + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand("UPDATE login SET password='" + txtnewpassword.Text + "' WHERE username='" + txtusername.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtusername.Clear();
                txtnewpassword.Clear();
                txtoldpassword.Clear();


            }
            else
            {
                MessageBox.Show("Invalid user name or password");
                txtusername.Text = "";
                txtoldpassword.Text = "";
                txtnewpassword.Text = "";
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            PASSWORD_SETTING frm = new PASSWORD_SETTING(user);
            frm.Show();
            this.Hide();
        }

        private void txtnewpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
