using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assigenment_hospital
{
    public partial class INTERFACE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dix\source\repos\assigenment_hospital\assigenment_hospital\hospital.mdf;Integrated Security=True");
        public INTERFACE()
        {
            InitializeComponent();
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnadmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
            txtpassword.MaxLength = 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)FROM login WHERE username='"+txtusername.Text+"' AND password='"+txtpassword.Text+"'AND usertype='"+comusertype.Text+"'",con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
            {
                if (comusertype.Text=="admin")
                {
                    admindash frm = new admindash(comusertype.Text);
                    frm.Show();
                    this.Hide();

                }
                else if(comusertype.Text=="doctor")
                {
                    doctordash frm = new doctordash(comusertype.Text);
                    frm.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Invalid user name or password");
                txtusername.Text = "";
                txtpassword.Text = "";
                comusertype.SelectedIndex = 0;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comusertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
