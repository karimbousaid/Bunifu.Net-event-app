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
using System.IO;

namespace ProjectTest
{
    public partial class Material : Form
    {
       
       
        public Material()
        {
            InitializeComponent();
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            dataGridView2.Columns.Add(btn2);
            btn2.HeaderText = "Supprimé";
            btn2.Text = "Supprimé";
            btn2.Name = "btn";
            btn2.UseColumnTextForButtonValue = true;
        }
        SqlDataReader dr1;
        private string strFilePath;

        private void Material_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns[2].Visible = false;
            string req = "SELECT * FROM Material";
            SqlDataReader dr = ClassConnection.FillDataReader(req);
            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }
            dr.Close();
            string req1 = "SELECT * FROM Client ORDER BY IdClient DESC";
            SqlDataReader dr1 = ClassConnection.FillDataReader(req1);
            while (dr1.Read())
            {
                bunifuDropdown1.AddItem(dr1["Prenom"] + " " + dr1["Nom"]);
            }
            dr1.Close();
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                pictureBox2.Image = new Bitmap(strFilePath);
            }
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }
        int Id_Client;


        private void bunifuDropdown1_onItemSelected_1(object sender, EventArgs e)
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
            string req3 = @"SELECT        dbo.Material.Nom_Mt, dbo.Material.Nombre, dbo.Material.image, dbo.Material.Id_C, dbo.Material.Prix
FROM            dbo.Client INNER JOIN
                         dbo.Commande ON dbo.Client.IdClient = dbo.Commande.IdClient INNER JOIN
                         dbo.Material ON dbo.Commande.Id_C = dbo.Material.Id_C where dbo.Client.IdClient =" + Id_Client + "";
            ClassConnection.OpenCnx();
            SqlDataReader d2 = ClassConnection.FillDataReader(req3);
            dataGridView2.Rows.Clear();
            while (d2.Read())
            {
                dataGridView2.Rows.Add(d2[0], d2[1], d2[2], d2[3], d2[4]);
            }
            d2.Close();
        }

        private void bunifuCustomLabel4_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DialogResult dialogResult = MessageBox.Show("Voulez-Vous Supprimé ce type de Material !!", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = e.RowIndex;
                    string NomP = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

                    string req1 = "delete from Material where Nom_Mt='" + NomP + "'";
                    ClassConnection.Excute(req1);
                    dataGridView2.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("la Supprision effectué", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                pictureBox2.Image = new Bitmap(strFilePath);
            }
        }
        Byte[] ImageByteArray;
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Selected == true)
                {
                    textBox6.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    textBox5.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    textBox4.Text = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    textBox6.ForeColor = Color.Red;
                    textBox5.ForeColor = Color.Red;
                    textBox4.ForeColor = Color.Red;
                }
            }
        }
    
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
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
            string req4 = "update Material set Nombre=" + textBox5.Text + ", image='" + ImageByteArray + "',Prix=" + textBox4.Text + " where Nom_Mt='" + textBox6.Text + "'";
            ClassConnection.Excute(req4);
            dataGridView2.Rows.Clear();
            dataGridView2.Columns[2].Visible = false;
            string req = "SELECT * FROM Material";
            SqlDataReader dr = ClassConnection.FillDataReader(req);
            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);
            }
            dr.Close();
            ClassConnection.CloseCnx();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
