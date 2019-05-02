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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace ProjectA
{
    public partial class Viewgrp : Form
    {
        public Viewgrp()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT Title FROM Project WHERE ( Project.Id IN(SELECT ProjectId FROM GroupProject))");
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                procombo.Items.Add(reader["Title"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cmd = String.Format("Select GroupProject.GroupId from Project JOIN GroupProject ON Project.Id = GroupProject.ProjectId where title = '{0}'", procombo.Text);
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int ad;
            ad = (Int32)a.ExecuteScalar();
            groups g = new groups(ad);
            this.Hide();
            g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grp g = new grp();
            this.Hide();
            g.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("C:/Users/HIBA/Desktop/ProjectA/ProjectA/groupReport.pdf", FileMode.Create));
            document.Open();
            

            PdfPTable table = new PdfPTable(4);

            //actual width of table in points

            table.TotalWidth = 216f;

            //fix the absolute width of the table

            table.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 150f, 150f ,150f,150f};

            table.SetWidths(widths);

            table.HorizontalAlignment = 0;

            //leave a gap before and after the table

            table.SpacingBefore = 20f;

            table.SpacingAfter = 30f;



            PdfPCell cell = new PdfPCell(new Phrase("GROUP EVALUATION REPORT"));

            cell.Colspan = 4;

            cell.Border = 0;

            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell("Project Name");
            table.AddCell("Student Name");
            table.AddCell("Evaluation Name");
            table.AddCell("Obtained Marks");
            
            

            using (DatabaseConnection.getInstance().getConnection())

            {

                string query = "SELECT Title as [Project Name], Person.FirstName+ ' ' + Person.LastName as [Student Name],Evaluation.Name as [Evaluation], ObtainedMarks FROM Person Join Student On person.Id = Student.Id Join GroupStudent On GroupStudent.StudentId = Student.Id Join GroupEvaluation on GroupEvaluation.GroupId = GroupStudent.GroupId Join Evaluation On GroupEvaluation.EvaluationId = Evaluation.Id Join GroupProject on GroupProject.GroupId = GroupStudent.GroupId Join PRoject on Project.Id = GroupProject.ProjectId ";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.getInstance().getConnection());

               

                    using (SqlDataReader rdr = cmd.ExecuteReader())

                    {

                        while (rdr.Read())

                        {

                            table.AddCell(rdr[0].ToString());

                            table.AddCell(rdr[1].ToString());
                        table.AddCell(rdr[2].ToString());
                        table.AddCell(rdr[3].ToString());

                    }

                    }
                    
                document.Add(table);

            }
           
            document.Close();
        }
    }
}
