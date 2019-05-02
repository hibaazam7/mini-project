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
    public partial class adv : Form
    {
        public adv()
        {
            InitializeComponent();
        }

        private void addlist_Click(object sender, EventArgs e)
        {
            advisors s = new advisors();
            this.Hide();
            s.Show();
        }

        private void create_Click(object sender, EventArgs e)
        {
            addadvics a = new addadvics();
            this.Hide();
            a.Show();

        }
        
        private void ind_Click(object sender, EventArgs e)
        {
            index a = new index();
            this.Hide();
            a.Show();
        }
    }
}
