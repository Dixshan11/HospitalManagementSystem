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
    
    public partial class creat_password : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        string user;

        public creat_password(string usertype)
        {
            InitializeComponent();
            user = usertype;
        }

        private void creat_password_Load(object sender, EventArgs e)
        {

            txtnewpassword.PasswordChar = '*';
            txtnewpassword.MaxLength = 10;

            txtrepassword.PasswordChar = '*';
            txtrepassword.MaxLength = 10;
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM login WHERE username='" + txtusername.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("This user name is already teaken.please try again");
                txtusername.Text = "";
                txtrepassword.Text = "";
                txtnewpassword.Text = "";
            }
            else
            {
                if ((txtusername.Text == "") ||(txtnewpassword.Text=="")||(txtrepassword.Text=="")||(comuserype1.SelectedIndex==0) )
                {
                    MessageBox.Show("plese fill all the fields");
                    txtusername.Text = "";
                    txtrepassword.Text = "";
                    txtnewpassword.Text = "";
                    
                }
                else
                {
                    
                        if (txtnewpassword.Text == txtrepassword.Text)
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO login(username,password,usertype)VALUES('" + txtusername.Text + "','" + txtnewpassword.Text + "','" + comuserype1.Text + "')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtusername.Text = "";
                            txtrepassword.Text = "";
                            txtnewpassword.Text = "";
                            
                        }
                        else
                        {
                            MessageBox.Show("re-entered password is not macth..");
                        }
                    
                   
                }
                
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
