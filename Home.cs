using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace ProjectTest
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private int imageNumber = 1;
        private void LoadNextImage()
        {        
            ClassConnection.OpenCnx();
            SqlCommand cmd = new SqlCommand("select Image from Image where ImageID="+ imageNumber + "", ClassConnection.cnx);
            string req = "select Image from Image where ImageID=" + imageNumber + "";
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Image", ClassConnection.cnx);          
            SqlDataReader reader = ClassConnection.FillDataReader(req);         
            if (reader.Read())
            {
                byte[] picData = reader["Image"] as byte[] ?? null;
                reader.Close();
                if (picData != null)
                {
                    using (MemoryStream ms = new MemoryStream(picData))
                    {
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);
                        Int32 count = (Int32)cmd2.ExecuteScalar();
                        slidePic.Image = Image.FromStream(ms);
                        if(imageNumber ==count)
                        {
                            imageNumber=1;
                        }
                        else
                        {
                            imageNumber++;
                        }
                        
                    }
                }
            }
            ClassConnection.CloseCnx();
        }


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            bunifuCustomLabel2.Text = DateTime.Now.ToString();
            timer1.Start();          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 40)
            {
                panel1.Width = 174;
                panelAnimator.ShowSync(panel1);
                logoAnimator.ShowSync(logo);            
            }
            else
            {
                logoAnimator.Hide(logo);
                panel1.Visible = false;
                panel1.Width = 40;
                panelAnimator.ShowSync(panel1);           

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_CursorChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuMaterialTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

      

     

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            EmailSend o = new EmailSend();
            o.ShowDialog();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {          
            ClientInfo c = new ClientInfo();
            c.ShowDialog();          
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
   
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            RdvForm r = new RdvForm();
            r.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            PlatAndMaterial c = new PlatAndMaterial();
            c.ShowDialog();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click_2(object sender, EventArgs e)
        {
            Client c = new Client();
            c.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
            bunifuCustomLabel2.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            c.ShowDialog();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomDataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            Parametre p = new Parametre();
            p.ShowDialog();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            AddCommande l = new AddCommande();
            l.ShowDialog();
        }

        private void EmailSendPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
