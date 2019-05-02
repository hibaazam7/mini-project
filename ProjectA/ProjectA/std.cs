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
    public partial class std : Form
    {
        public std()
        {
            InitializeComponent();
        }

        private void studlist_Click(object sender, EventArgs e)
        {
            students s = new students();
            this.Hide();
            s.Show();
        }

        private void create_Click(object sender, EventArgs e)
        {
            addstudent s = new addstudent();
            this.Hide();
            s.Show();
        }

        private void ind_Click(object sender, EventArgs e)
        {
            index s = new index();
            this.Hide();
            s.Show();
        }

        private void std_Load(object sender, EventArgs e)
        {

        }
    }
}
