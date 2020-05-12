using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ProjectTest
{
    public partial class CommandeForm : Form
    {

        
        public CommandeForm()
        {
            InitializeComponent();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Supprimé";
            btn.Text = "Supprimé";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.ClearSelection();

        }
        DataTable dt = new DataTable();
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private string strFilePath;
        Byte[] ImageByteArray;

        private void CommandeForm_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns[2].Visible = false;
            string req = "SELECT * FROM Plats";
            SqlDataReader dr = ClassConnection.FillDataReader(req);
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3],dr[4]);
            }
            dr.Close();
            string req1 = "SELECT * FROM Client ORDER BY IdClient DESC";
            SqlDataReader dr1 = ClassConnection.FillDataReader(req1);
            while (dr1.Read())
            {
                bunifuDropdown1.AddItem(dr1["Prenom"] + " " + dr1["Nom"]);
            }
            dr1.Close();
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                pictureBox1.Image = new Bitmap(strFilePath);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        SqlDataReader dr2;
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }
        SqlCommand cmd;
        DataTable t = new DataTable();
        SqlDataAdapter d = new SqlDataAdapter();
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {



            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();                  
                    textBox1.ForeColor = Color.Red;
                    textBox2.ForeColor = Color.Red;
                    textBox3.ForeColor = Color.Red;               
                    //byte[] MyData = null;
                    //MyData = (byte[])dataGridView1.Rows[i].Cells[2].Value;
                    //MemoryStream stream = new MemoryStream(MyData);
                    //stream.Position = 0;
                    //pictureBox1.Image = Image.FromStream(stream);
                }
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }




        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
            {

            }
            static int Id_Client;

            private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
            {

                string delimiteur = " ";
                char[] limite = delimiteur.ToCharArray();
                string value = bunifuDropdown1.selectedValue;
                string[] split = value.Split(limite);
                string req1 = "select IdClient from Client where Nom='" + split[1] + "'";
                SqlDataReader d1 = ClassConnection.FillDataReader(req1);
                if (d1.Read())
                {
                    Id_Client = (int)d1["IdClient"];
                    d1.Close();
                }
                string req3 = @"SELECT  dbo.Plats.Nom_Plat,  dbo.Plats.Nombre_Plat, dbo.Plats.image, dbo.Plats.Id_C, dbo.Plats.Prix FROM dbo.Client INNER JOIN dbo.Commande ON dbo.Client.IdClient = dbo.Commande.IdClient INNER JOIN dbo.Plats ON dbo.Commande.Id_C = dbo.Plats.Id_C where dbo.Client.IdClient =" + Id_Client + "";
                ClassConnection.OpenCnx();
                SqlDataReader d2 = ClassConnection.FillDataReader(req3);
                dataGridView1.Rows.Clear();
                while (d2.Read())
                {
                    dataGridView1.Rows.Add(d2[0], d2[1], d2[2], d2[3], d2[4]);
                }
                d2.Close();
            }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 5)
                {
                    DialogResult dialogResult = MessageBox.Show("Voulez-Vous Supprimé ce client !!", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int row = e.RowIndex;
                        string NomP = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                        string req1 = "delete from Plats where Nom_Plat='" + NomP + "'";
                        ClassConnection.Excute(req1);
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("la Supprision effectué", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            static int Id_C;
            private void bunifuFlatButton2_Click(object sender, EventArgs e)
            {

                if (strFilePath == "")
                {
                    if (ImageByteArray.Length != 0)
                        ImageByteArray = new byte[] { };
                }
                else
                {
                    Image temp = new Bitmap(strFilePath);
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageByteArray = strm.ToArray();
                }
                string req4 = "update Plats set Nombre_Plat=" + textBox2.Text + ", image='" + ImageByteArray + "',Prix=" + textBox3.Text + " where Nom_Plat='" + textBox1.Text + "'";
                ClassConnection.Excute(req4);
                dataGridView1.Rows.Clear();
                dataGridView1.Columns[2].Visible = false;
                string req = "SELECT * FROM Plats";
                SqlDataReader dr = ClassConnection.FillDataReader(req);
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
                dr.Close();
                ClassConnection.CloseCnx();
            }

            private void bunifuImageButton3_Click_1(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }


