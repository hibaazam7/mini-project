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
    public partial class evl : Form
    {
        public evl()
        {
            InitializeComponent();
        }

        private void evllist_Click(object sender, EventArgs e)
        {
            evaluations ev = new evaluations();
            this.Hide();
            ev.Show();
        }

        private void create_Click(object sender, EventArgs e)
        {
            addeval s = new addeval();
            this.Hide();
            s.Show();
        }

        private void ind_Click(object sender, EventArgs e)
        {
            index s = new index();
            this.Hide();
            s.Show();
        }
    }
}
