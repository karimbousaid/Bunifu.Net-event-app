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
using System.Drawing.Imaging;

namespace ProjectTest
{
    public partial class Commande : Form
    {

        String strFilePath = "";
        Byte[] ImageByteArray;
         public static int Id_C;
         public static int Id_Client;
        public Commande()
        {
            InitializeComponent();
        }
       
        private void Commande_Load(object sender, EventArgs e)
        {       
            this.Height = 239;
            string req = "SELECT * FROM Client ORDER BY IdClient DESC";
            SqlDataReader dr = ClassConnection.FillDataReader(req);
            while (dr.Read())
            {              
                bunifuDropdown1.AddItem(dr["Prenom"] + " " + dr["Nom"]);              
                //bunifuDropdown1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            dr.Close();
            bunifuImageButton1.Enabled = false;
            bunifuImageButton2.Enabled = false;
            
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {         
            this.Height = 615;
            plabox.Visible = true;
            matrbox.Visible = false;
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            

        }
        
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Height = 615;
            matrbox.Visible = true;       
        }
        private void bunifuCustomLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                imageplat.Image = new Bitmap(strFilePath);
            }
        }

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex == -1 || NomMtxt.selectedIndex == -1 || nbMtxt.Text == string.Empty || prixMtxt.Text == string.Empty)
                {
                    MessageBox.Show("Tu doit Remlir tout les champs", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string req3 = "SELECT Id_C from Commande where IdClient=" + Id_Client + "";
                    ClassConnection.OpenCnx();
                    SqlDataReader dr2 = ClassConnection.FillDataReader(req3);
                    if (dr2.Read())
                    {
                        Id_C = (int)dr2["Id_C"];
                    }
                    dr2.Close();
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
                    string req4 = "insert into Material values('" + NomMtxt.selectedValue + "'," + nbMtxt.Text + ",'" + ImageByteArray + "'," + Id_C.ToString() + "," + prixMtxt.Text + ")";
                    ClassConnection.Excute(req4);
                    ClassConnection.CloseCnx();
                    MessageBox.Show("la Commande effectuer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Problem d'ajouter la Commande", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex == -1 || Plattxt.selectedIndex == -1 || platnbtxt.Text == string.Empty || prixplattxt.Text == string.Empty)
                {
                    MessageBox.Show("Tu doit Remlir tout les champs", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string req3 = "SELECT Id_C from Commande where IdClient=" + Id_Client + "";
                    ClassConnection.OpenCnx();
                    SqlDataReader dr2 = ClassConnection.FillDataReader(req3);
                    if (dr2.Read())
                    {
                        Id_C = (int)dr2["Id_C"];
                    }
                    dr2.Close();
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
                    string req4 = "insert into Plats values('" + Plattxt.selectedValue + "'," + platnbtxt.Text + ",'" + ImageByteArray + "'," + Id_C.ToString() + "," + prixplattxt.Text + ")";
                    ClassConnection.Excute(req4);
                    ClassConnection.CloseCnx();
                    MessageBox.Show("la Commande effectuer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr2.Close();
                }
            }
            catch
            {
                MessageBox.Show("Problem d'ajouter la Commande", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //string req = "SELECT * FROM Client where Prenom like '%" + comboBox1.Text + "%'";
            //SqlCommand cmd = new SqlCommand(req, ClassConnection.cnx);               
            //SqlDataAdapter ds = new SqlDataAdapter(cmd);
            //ds.Fill(dt);
            //comboBox1.DataSource = dt;
            //comboBox1.DisplayMember = "Prenom";
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected_1(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton5_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                imageM.Image = new Bitmap(strFilePath);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if(bunifuDropdown1.selectedIndex==-1)
            {
                MessageBox.Show("Selectioné un client", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    ClassConnection.OpenCnx();
                    string delimiteur = " ";
                    char[] limite = delimiteur.ToCharArray();
                    string value = bunifuDropdown1.selectedValue;
                    string[] split = value.Split(limite);
                    string req1 = "select IdClient from Client where Nom='" + split[1] + "'";
                    SqlDataReader dr1 = ClassConnection.FillDataReader(req1);
                    if (dr1.Read())
                    {
                        Id_Client = (int)dr1["IdClient"];
                        string req2 = "insert into Commande values(" + Id_Client + ")";
                        dr1.Close();
                        ClassConnection.Excute(req2);
                    }
                    bunifuImageButton1.Enabled = true;
                    bunifuImageButton2.Enabled = true;
                }
                else
                {
                    bunifuImageButton1.Enabled = false;
                    bunifuImageButton2.Enabled = false;
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
             
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton3_Click_2(object sender, EventArgs e)
        {
            string req5 = "SELECT Id_C from Commande where IdClient=" + Id_Client + "";
            ClassConnection.OpenCnx();
            SqlDataReader dr1 = ClassConnection.FillDataReader(req5);
            if (dr1.Read())
            {
                Id_C = (int)dr1["Id_C"];
                dr1.Close();
                RDV r = new RDV();
                r.Pass((int)Id_C);            
                r.ShowDialog();               
            }               
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void imageM_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            string req5 = "SELECT Id_C from Commande where IdClient=" + Id_Client + "";
            ClassConnection.OpenCnx();
            SqlDataReader dr1 = ClassConnection.FillDataReader(req5);
            if (dr1.Read())
            {
                Id_C = (int)dr1["Id_C"];
                dr1.Close();           
                RDV r = new RDV();
                r.Pass((int)Id_C);
                r.ShowDialog();
            }
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
           
         
        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

