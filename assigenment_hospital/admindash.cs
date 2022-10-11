using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assigenment_hospital
{
    public partial class admindash : Form
    {
        String user;
        public admindash(String usertype)
        {
            InitializeComponent();
             user = usertype;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NURSE frm = new NURSE(user);
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PATINET frm = new PATINET(user);
            frm.Show();
           this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DOCTOR frm = new DOCTOR(user);
            frm.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DOCTOR_VISIT frm = new DOCTOR_VISIT(user);
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PAYMENT frm = new PAYMENT(user);
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SUPPLIER frm = new SUPPLIER(user);
            frm.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            APPONITMENT frm = new APPONITMENT(user);
            frm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SUPPLIER frm = new SUPPLIER(user);
            frm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PASSWORD_SETTING frm = new PASSWORD_SETTING(user);
            frm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            treatment myform = new treatment(user);
            myform.Show();
            this.Hide();
        }

        /*private void button13_Click(object sender, EventArgs e)
        {
            creat_password frm = new creat_password(user);
            frm.Show();
            this.Hide();
        }*/
    }
}
