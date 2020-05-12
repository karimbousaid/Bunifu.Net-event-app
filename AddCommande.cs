using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTest
{
    public partial class AddCommande : Form
    {
        String strFilePath = "";
        Byte[] ImageByteArray;
        public static int Id_C;
        public static int Id_Client;

        public AddCommande()
        {
            InitializeComponent();
        }

        private void AddCommande_Load(object sender, EventArgs e)
        {
            string req = "SELECT * FROM Client ORDER BY IdClient DESC";
            SqlDataReader dr = ClassConnection.FillDataReader(req);
            while (dr.Read())
            {
                bunifuDropdown1.AddItem(dr["Prenom"] + " " + dr["Nom"]);
                //bunifuDropdown1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            dr.Close();
 
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                imageM.Image = new Bitmap(strFilePath);
            }
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                imageM.Image = new Bitmap(strFilePath);
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
                    string delimiteur = " ";
                    char[] limite = delimiteur.ToCharArray();
                    string value = bunifuDropdown1.selectedValue;
                    string[] split = value.Split(limite);
                    string req1 = "select IdClient from Client where Nom='" + split[1] + "'";
                    SqlDataReader dr1 = ClassConnection.FillDataReader(req1);
                    if (dr1.Read())
                    {
                        Id_Client = (int)dr1["IdClient"];
                        string req3 = "SELECT Id_C from Commande where IdClient=" + Id_Client + "";
                        ClassConnection.OpenCnx();
                        dr1.Close();
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
                        dr2.Close();
                        ClassConnection.Excute(req4);
                        ClassConnection.CloseCnx();
                        MessageBox.Show("la Commande effectuer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem d'ajouter la Commande", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Height = 563;
            plabox.Visible = true;
            matrbox.Visible = false;
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            this.Height = 563;
            matrbox.Visible = true;
            plabox.Visible = false;           
        }

        private void bunifuImageButton8_Click_1(object sender, EventArgs e)
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
                    string delimiteur = " ";
                    char[] limite = delimiteur.ToCharArray();
                    string value = bunifuDropdown1.selectedValue;
                    string[] split = value.Split(limite);
                    string req1 = "select IdClient from Client where Nom='" + split[1] + "'";
                    SqlDataReader dr1 = ClassConnection.FillDataReader(req1);
                    if (dr1.Read())
                    {
                        Id_Client = (int)dr1["IdClient"];
                        string req3 = "SELECT Id_C from Commande where IdClient=" + Id_Client + "";
                        ClassConnection.OpenCnx();
                        dr1.Close();
                        SqlDataReader dr2 = ClassConnection.FillDataReader(req3);
                        if (dr2.Read())
                        {
                            Id_C = (int)dr2["Id_C"];
                        }

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
                        dr2.Close();
                        ClassConnection.Excute(req4);
                        ClassConnection.CloseCnx();
                        MessageBox.Show("la Commande effectuer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem d'ajouter la Commande", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bunifuImageButton7_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                imageplat.Image = new Bitmap(strFilePath);
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            string delimiteur = " ";
            char[] limite = delimiteur.ToCharArray();
            string value = bunifuDropdown1.selectedValue;
            string[] split = value.Split(limite);
            string req1 = "select IdClient from Client where Nom='" + split[1] + "'";
            SqlDataReader dr1 = ClassConnection.FillDataReader(req1);
            if (dr1.Read())
            {
                Id_Client = (int)dr1["IdClient"];
                string req3 = "SELECT Id_C from Commande where IdClient=" + Id_Client + "";
                ClassConnection.OpenCnx();
                dr1.Close();
                SqlDataReader dr2 = ClassConnection.FillDataReader(req3);
                if (dr2.Read())
                {
                    Id_C = (int)dr2["Id_C"];
                }
                dr2.Close();
            }
        }
    }
}
