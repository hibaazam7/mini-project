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
namespace ProjectA
{
    public partial class grp : Form
    {
        public grp()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crestegrp crtgrp = new crestegrp();
            this.Hide();
            crtgrp.Show();
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adstud p = new adstud();
            this.Hide();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Viewgrp g = new Viewgrp();
            this.Hide();
            g.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index i = new index();
            this.Hide();
            i.Show();
        }
    }
}
