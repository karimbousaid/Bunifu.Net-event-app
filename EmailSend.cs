using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTest
{
    public partial class EmailSend : Form
    {
        public EmailSend()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Emailtxt.Text == string.Empty || Passwordtxt.Text == string.Empty || EmailSendtxt.Text == string.Empty || Objecttxt.Text == string.Empty || bodytxt.Text == string.Empty)
                {
                    MessageBox.Show("Tu doit Remlir tout les champs", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(Emailtxt.Text);
                    message.To.Add(EmailSendtxt.Text);
                    message.Body = bodytxt.Text;
                    message.Subject = Objecttxt.Text;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    if (Filettxt.Text != "")
                    {
                        message.Attachments.Add(new Attachment(Filettxt.Text));
                    }
                    client.Credentials = new System.Net.NetworkCredential(Emailtxt.Text, Passwordtxt.Text);
                    client.Send(message);
                    MessageBox.Show("Email Envoyer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    message = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You have Erreur" + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Emailtxt.Clear();
            Passwordtxt.Clear();
            EmailSendtxt.Clear();
            Objecttxt.Clear();
            bodytxt.Clear();
            Filettxt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Filettxt.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
