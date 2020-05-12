using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTest
{

    public partial class Utilisateur : Form
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "dbtraiteur.mdf";
        public static SqlConnection cn = new SqlConnection(@"Data Source=.;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True");
        private string strFilePath;
        Byte[] ImageByteArray;
        public Utilisateur()
        {
            InitializeComponent();           
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login n = new Login();
            n.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Name.Text == "Entrer votre Name" || txt_Password.Text == "" || txt_Password.Text == "Entrer  Mode pass" || txt_Email.Text == "" || txt_Email.Text == "Entré votre Email")
            {
                MessageBox.Show("Vérifier les information saisir", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {               
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("insert into Admin values('" + txt_Name.Text + "','" + txt_Password.Text + "','" + txt_Email.Text + "')", cn);
                int n = cmd3.ExecuteNonQuery();
                if (n == 1)
                {
                    MessageBox.Show("l'ajoutement bien réussite", "Password Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Vérifier les information saisir", "Ereur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cn.Close();
            }
        }

        private void txt_Name_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_Name_Enter(object sender, EventArgs e)
        {
            if (txt_Name.Text == "Entrer votre Name")
            {
                txt_Name.Text = "";
            }
        }

        private void txt_Name_Leave(object sender, EventArgs e)
        {
            if (txt_Name.Text == "")
            {
                txt_Name.Text = "Entrer votre Name";
            }
        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {
            if (txt_Password.Text == "Entrer  Mot de pass")
            {
                txt_Password.Text = "";
                txt_Password.isPassword = true;
            }
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            if (txt_Password.Text == "")
            {
                txt_Password.Text = "Entrer  Mot de pass";
                txt_Password.isPassword = false;
            }
        }

        private void txt_Email_Enter(object sender, EventArgs e)
        {
            if (txt_Email.Text == "Entré votre Email")
            {
                txt_Email.Text = "";
            }
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            if (txt_Email.Text == "")
            {
                txt_Email.Text = "Entré votre Email";
            }
        }

        private void Utilisateur_Load(object sender, EventArgs e)
        {
         
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_Password_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pbxImage_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
