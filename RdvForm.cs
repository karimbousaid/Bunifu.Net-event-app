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
namespace ProjectTest
{
    public partial class RdvForm : Form
    {
        SqlDataReader dr;
        string req;
        public RdvForm()
        {
            InitializeComponent();
            req = "select * from RDV";
            dr = ClassConnection.FillDataReader(req);
            while(dr.Read())
            {
               DateTime d =(DateTime)dr[1];
               monthCalendar1.AddBoldedDate(DateTime.Parse(d.ToString()));               
            }
            dr.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RdvForm_Load(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void monthCalendar1_MouseHover(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DragLeave(object sender, EventArgs e)
        {

        }
    }
}
