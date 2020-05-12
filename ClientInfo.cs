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

namespace ProjectTest
{
    public partial class ClientInfo : Form
    {
        public ClientInfo()
        {
            InitializeComponent();
            dataGridView1.ClearSelection();
        }
        SqlDataReader dr;
        static int idclient;
        static string NomC;
        static string PrenomC;
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();          
        }
       
        private void ClientInfo_Load(object sender, EventArgs e)
        {
            
        }
       
        


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
         
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
         
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }
        DataTable dt = new DataTable();
        private void ClientInfo_Load_1(object sender, EventArgs e)
        {                   
             dt = new DataTable();
            string req = "SELECT * FROM Client";
            SqlCommand cmd = new SqlCommand(req, ClassConnection.cnx);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Supprimé";
            btn.Text = "Supprimé";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn1);
            btn1.HeaderText = "Modifier";
            btn1.Text = "Modifier";
            btn1.Name = "btn";
            btn1.UseColumnTextForButtonValue = true;
            Refresh();
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
        SqlDataReader dr2;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DialogResult dialogResult = MessageBox.Show("Voulez-Vous Supprimé ce client !!", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {            
                    int row = e.RowIndex;                                 
                    int idc = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    string req = "select Id_C from Commande where IdClient='" + idc + "'";
                    dr2 = ClassConnection.FillDataReader(req);
                    if(dr2.Read())
                    {
                        string req1 = "delete from RDV where Id_C='" + dr2["Id_C"] + "'";
                        string req2 = "delete from Plats where Id_C='" + dr2["Id_C"] + "'";
                        string req3 = "delete from Material where Id_C='" + dr2["Id_C"] + "'";
                        string req4 = "delete from Commande where Id_C='" + dr2["Id_C"] + "'";
                        string req5 = "delete from Client where IdClient='" + idc + "'";
                        dr2.Close();
                        ClassConnection.Excute(req1);
                        ClassConnection.Excute(req2);
                        ClassConnection.Excute(req3);
                        ClassConnection.Excute(req4);
                        ClassConnection.Excute(req5);                     
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("la Supprision effectué", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }

            }
            if (e.ColumnIndex == 8)
            {
                DialogResult dialogResult = MessageBox.Show("Voulez-Vous Modifier ce client !!", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = e.RowIndex;
                    int idc =(int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    string Prenom =dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string Nom = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string Adresse = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int Tlf = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                    string Email = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string Type = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    string req = "update client set Prenom='" + Prenom + "',Nom='" + Nom + "',Adresse='" + Adresse + "',telephone='" + Tlf + "', Email='" + Email + "' , TypeEvenement='" + Type + "'where IdClient=" + idc + "";
                    ClassConnection.Excute(req);
                    MessageBox.Show("la Modification effectué", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }

            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dataGridView1.ClearSelection();
                string req = "SELECT * FROM Client where IdClient=" + textBox1.Text + "";
                dr = ClassConnection.FillDataReader(req);
                if (dr.Read())
                {
                    idclient = (int)dr[0];
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();
                    textBox6.Text = dr[3].ToString();
                    dr.Close();
                    int searchstring = idclient;
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                        foreach (DataGridViewCell c in r.Cells)
                            if (c.Value.ToString().Contains(searchstring.ToString()))
                            {
                                r.Selected = true;                               
                                break;
                            }
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Client avec ce Id n'existe pas", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (radioButton2.Checked == true)
            {
                dataGridView1.ClearSelection();
                string req = "SELECT * FROM Client where Nom='" + textBox1.Text + "'";
                dr = ClassConnection.FillDataReader(req);
                if (dr.Read())
                {
                    NomC = dr[2].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();
                    textBox6.Text = dr[3].ToString();
                    dr.Close();
                    string searchstring = NomC;
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                        foreach (DataGridViewCell c in r.Cells)
                            if (c.Value.ToString().Contains(searchstring.ToString()))
                            {
                                r.Selected = true;
                                break;
                            }
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Client avec ce Nom n'existe pas", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (radioButton3.Checked == true)
            {           
                dataGridView1.ClearSelection();
                string req = "SELECT * FROM Client where Prenom='" + textBox1.Text + "'";
                dr = ClassConnection.FillDataReader(req);
                if (dr.Read())
                {
                    PrenomC = dr[1].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();
                    textBox6.Text = dr[3].ToString();
                    dr.Close();
                    string searchstring = PrenomC;
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                        foreach (DataGridViewCell c in r.Cells)
                            if (c.Value.ToString().Contains(searchstring.ToString()))
                            {
                                r.Selected = true;
                                break;
                            }
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Client avec ce Prenom n'existe pas", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void refresh()
        {
            dt.Clear();
            dataGridView1.DataSource = dt;
            string req1 = "SELECT * FROM Client";
            SqlCommand cmd = new SqlCommand(req1, ClassConnection.cnx);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
              if(radioButton1.Checked==true)
                {
                    string req = "update client set Prenom='" + textBox2.Text + "',Nom='" + textBox3.Text + "',Adresse='" + textBox6.Text + "',telephone='" + textBox4.Text + "',Email='" + textBox5.Text + "' where IdClient='" + textBox1.Text + "'";
                    ClassConnection.Excute(req);
                    MessageBox.Show("la Modification effectué", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();      
                }
                if (radioButton2.Checked == true)
                {
                    string req = "update client set Prenom='" + textBox2.Text + "',Nom='" + textBox3.Text + "',Adresse='" + textBox6.Text + "',telephone='" + textBox4.Text + "',Email='" + textBox5.Text + "' where Nom=" + textBox1.Text + "";
                    ClassConnection.Excute(req);
                    MessageBox.Show("la Modification effectué", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                if (radioButton3.Checked == true)
                {
                    string req = "update client set Prenom='" + textBox2.Text + "',Nom='" + textBox3.Text + "',Adresse='" + textBox6.Text + "',telephone='" + textBox4.Text + "',Email='" + textBox5.Text + "' where Prenom='" + textBox1.Text + "'";
                    ClassConnection.Excute(req);
                    MessageBox.Show("la Modification effectué", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {
                    MessageBox.Show("selectioné un radiobutton de modification", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Erreur de modification", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    textBox6.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    textBox2.ForeColor = Color.Red;
                    textBox3.ForeColor = Color.Red;
                    textBox4.ForeColor = Color.Red;
                    textBox5.ForeColor = Color.Red;
                    textBox6.ForeColor = Color.Red;

                }
            }
        }
    }
}
