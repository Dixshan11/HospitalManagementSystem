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
    public partial class doctordash : Form
    {
        string user;
        public doctordash(String usertype)
        {
            InitializeComponent();
            user = usertype;
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
            frm.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            APPONITMENT frm = new APPONITMENT(user);
            frm.Show();
            frm.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PATINET frm = new PATINET(user);
            frm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
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

        private void button7_Click_1(object sender, EventArgs e)
        {
            APPONITMENT frm = new APPONITMENT(user);
            frm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CHANGE_PASSWORD frm = new CHANGE_PASSWORD(user);
                frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            treatment frm = new treatment(user);
            frm.Show();
            this.Hide();
        }
    }
}
