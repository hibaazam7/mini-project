using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
namespace ProjectA
{
    public partial class Manage_Project : Form
    {
        public Manage_Project()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addproject p = new addproject();
            this.Hide();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            asad p = new asad();
            this.Hide();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Advisos a = new Advisos();
            this.Hide();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("C:/Users/HIBA/Desktop/ProjectA/ProjectA/Projectreport.pdf", FileMode.Create));
            document.Open();

            PdfPTable table = new PdfPTable(2);

            //actual width of table in points

            table.TotalWidth = 216f;

            //fix the absolute width of the table

            table.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 150f, 150f };

            table.SetWidths(widths);

            table.HorizontalAlignment = 0;

            //leave a gap before and after the table

            table.SpacingBefore = 20f;

            table.SpacingAfter = 30f;



            PdfPCell cell = new PdfPCell(new Phrase("GROUP REPORT"));
           
            cell.Colspan = 2;

            cell.Border = 0;

            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            PdfPCell cell1 = new PdfPCell(new Phrase("List of Advisors"));
            cell1.Colspan = 2;
            cell1.Border = 0;

            cell1.HorizontalAlignment = 1;
            table.AddCell(cell1);
            table.AddCell("Project Name");
            table.AddCell("Advisor Name");



            using (DatabaseConnection.getInstance().getConnection())

            {

                string query = "SELECT Title as [Project Name],Person.FirstName+ ' ' + Person.LastName as [Advisor Name] FROM Person Join Advisor On person.Id = Advisor.Id Join ProjectAdvisor On ProjectAdvisor.AdvisorId = Advisor.Id  Join GroupProject on GroupProject.ProjectId = ProjectAdvisor.AdvisorId Join Project on Project.Id = PRojectAdvisor.ProjectId";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.getInstance().getConnection());



                using (SqlDataReader rdr = cmd.ExecuteReader())

                {

                    while (rdr.Read())

                    {

                        table.AddCell(rdr[0].ToString());

                        table.AddCell(rdr[1].ToString());

                    }

                }
                document.Add(table);
            }

            PdfPTable table1 = new PdfPTable(2);
            //actual width of table in points

            table1.TotalWidth = 216f;

            //fix the absolute width of the table

            table1.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            
            table1.SetWidths(widths);

            table1.HorizontalAlignment = 0;

            //leave a gap before and after the table

            table1.SpacingBefore = 20f;

            table1.SpacingAfter = 30f;

            
            PdfPCell cell2 = new PdfPCell(new Phrase("List Of Student"));

            cell2.Colspan = 4;

            cell2.Border = 0;

            cell2.HorizontalAlignment = 1;
            table1.AddCell(cell2);
            table1.AddCell("Project Name");
            table1.AddCell("Student Name");



            using (DatabaseConnection.getInstance().getConnection())

            {

                string query = "SELECT Title as [Project Name],Person.FirstName+ ' ' + Person.LastName as [Student Name] FROM Person Join Student On person.Id = Student.Id Join GroupStudent On GroupStudent.StudentId = Student.Id  Join GroupProject on GroupProject.GroupId = GroupStudent.GroupId Join Project on Project.Id = GroupProject.ProjectId";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.getInstance().getConnection());



                using (SqlDataReader rdr = cmd.ExecuteReader())

                {

                    while (rdr.Read())

                    {

                        table1.AddCell(rdr[0].ToString());

                        table1.AddCell(rdr[1].ToString());
                       
                    }

                }

                document.Add(table1);

            }

            document.Close();
        
    }

        private void button5_Click(object sender, EventArgs e)
        {
            index n = new index();
            this.Hide();
            n.Show();
        }
    }
}
