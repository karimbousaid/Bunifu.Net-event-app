using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTest
{
    public partial class Login : Form
    {
        
        int nbfois = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            bunifuImageButton3.Visible = false;           
            bunifuCircleProgressbar1.Visible = false;
            bunifuCircleProgressbar1.Value = 0;
            bunifuCircleProgressbar1.MaxValue = 99;
          
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            Utilisateur u = new Utilisateur();
            u.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
           
        }

        private void bunifuTextbox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void bunifuTextbox1_Leave(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox2_Leave(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void bunifuTextbox2_MouseHover(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox2_OnTextChange_1(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_KeyUp(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_KeyDown(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_KeyPress(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void bunifuTextbox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void bunifuTextbox1_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_MouseHover(object sender, EventArgs e)
        {

        }
        

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
            int i;
            bunifuCircleProgressbar1.Visible = true;
            for ( i = 0; i <= 99; i++)
            {  
               
                Thread.Sleep(50);               
                bunifuCircleProgressbar1.Value = i;             
                bunifuCircleProgressbar1.Update();             
            }

            if (txt_Name.Text == "" || txt_Password.Text == "")
                {
                    MessageBox.Show("le Nom d'utilisateur ou le Mot De Passe Ne doit pas être vide", "les champs obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }

                else
                {
                    ProjectTest.ClassConnection.OpenCnx();
                    ProjectTest.ClassConnection.cmd = new SqlCommand("select * from Admin where name='" + txt_Name.Text + "' and password='" + txt_Password.Text + "'", ClassConnection.cnx);
                    ProjectTest.ClassConnection.dr = ClassConnection.cmd.ExecuteReader();
                    int count = 0;
                    if (ClassConnection.dr.Read())
                    {
                        count++;
                    }

                    if (count == 1)
                    {

                        Home f = new Home();
                        f.Show();
                        this.Hide();
                        ProjectTest.ClassConnection.CloseCnx();
                        
                        return;
                    }
                    if (count == 0)
                    {
                    ClassConnection.dr.Close();
                    MessageBox.Show("Vérifier les information saisir", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuCircleProgressbar1.Visible = false;
                   
                    nbfois += 1;
                    }
                    if (nbfois == 3)
                    {
                   
                    DialogResult dialogResult = MessageBox.Show("Tu veux le Modifier Mot De Passe !!", "Modification de Mot De Passe", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Password p = new Password();
                            p.Show();
                            this.Hide();
                        }
                    }
                   
                    ProjectTest.ClassConnection.CloseCnx();
                }
            
            
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            
        }
       
        private void Name_OnValueChanged(object sender, EventArgs e)
        {
                     
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            Password p = new Password();
            p.Show();
            this.Hide();
        }

        private void txt_Name_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txt_Name_Enter(object sender, EventArgs e)
        {
             if(txt_Name.Text == "Entrer le Nom utilisateur")
                {
                txt_Name.Text = "";
                }
        }

        private void txt_Name_Leave(object sender, EventArgs e)
        {
            if (txt_Name.Text == "")
            {
                txt_Name.Text = "Entrer le Nom utilisateur";
            }
        }

        private void txt_Password_Move(object sender, EventArgs e)
        {
           
        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {
          
          
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
          if (txt_Password.isPassword == false)
            {
                txt_Password.isPassword = true;
                bunifuImageButton3.Visible = true;
                bunifuImageButton2.Visible = false;
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (txt_Password.isPassword == true)
            {
                txt_Password.isPassword = false;
                bunifuImageButton3.Visible = false;
                bunifuImageButton2.Visible = true;
            }
        }

        private void txt_Password_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
