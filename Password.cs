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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTest
{
  
    public partial class Password : Form
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "dbtraiteur.mdf";
        public static SqlConnection cn = new SqlConnection(@"Data Source=.;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True");


        public Password()
        {
            
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Login g = new Login();
            g.ShowDialog();
            this.Hide();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txt_Email.Text == "" || txt_Password.Text == "" || txt_Npassword.Text == "" || txt_Password.Text != txt_Npassword.Text || txt_Email.Text== "Entrer votre Email" || txt_Npassword.Text == "Entrer le Nouveau Mot de pass" || txt_Password.Text == "Confirmé le mot de pass")
            {
                MessageBox.Show("Vérifier les information saisir", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
               
              
                SqlCommand cmd = new SqlCommand("update Admin set password='" + txt_Npassword.Text+ "' where Email='" + txt_Email.Text + "'", cn);
                cn.Open();
                int n=cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    MessageBox.Show("la Modification réussite", "Modifier de mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vérifier l'email saisir", "Ereur d'email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                cn.Close();

            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();

        }

        private void Password_Load(object sender, EventArgs e)
        {

        }

        private void txt_Email_Enter(object sender, EventArgs e)
        {
            if (txt_Email.Text == "Entrer votre Email")
            {
                txt_Email.Text = "";
            }
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            if (txt_Email.Text == "")
            {
                txt_Email.Text = "Entrer votre Email";
            }
        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {
            if (txt_Password.Text == "Entrer le Nouveau Mot de pass")
            {
                txt_Password.Text = "";
                txt_Password.isPassword = true;
            }
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            if (txt_Password.Text == "")
            {
                txt_Password.Text = "Entrer le Nouveau Mot de pass";
                txt_Password.isPassword = false;
            }
        }

        private void txt_Npassword_Enter(object sender, EventArgs e)
        {
            if (txt_Npassword.Text == "Confirmé le mot de pass")
            {
                txt_Npassword.Text = "";
                txt_Npassword.isPassword = true;
            }
        }

        private void txt_Npassword_Leave(object sender, EventArgs e)
        {
            if (txt_Npassword.Text == "")
            {
                txt_Npassword.Text = "Confirmé le mot de pass";
                txt_Npassword.isPassword = false;
            }
        }

        private void txt_Password_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_Npassword_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
