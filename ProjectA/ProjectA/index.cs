using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            evl s = new evl();
            this.Hide();
            s.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void std_Click(object sender, EventArgs e)
        {
            std s = new std();
            this.Hide();
            s.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            adv a = new adv();
            this.Hide();
            a.Show();
        }

        private void proj_Click(object sender, EventArgs e)
        {
            Manage_Project p = new Manage_Project();
            this.Hide();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grp g = new grp();
            this.Hide();
            g.Show();
        }
    }
}
