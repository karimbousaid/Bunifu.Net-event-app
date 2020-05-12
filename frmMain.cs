using ProjectTest;
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




namespace Save_Image_to_Sql_Server
{
    public partial class frmMain : Form
    {

        #region Variables
        int ImageID = 0;
        String strFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "dbtraiteur.mdf";
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True");
        #endregion

        #region Methods
        public frmMain()
        {
            InitializeComponent();
            DefaultImage = pbxImage.Image;
            RefreshImageGrid();
        }
        void RefreshImageGrid()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ImageViewAll", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtblImages = new DataTable();
            sqlda.Fill(dtblImages);
            dgvImages.DataSource = dtblImages;
            dgvImages.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvImages.Columns[2].Visible = false;
        }
        void Clear()
        {
            ImageID = 0;
            txtTitle.Clear();
            pbxImage.Image = DefaultImage;
            strFilePath = "";
            btnSave.Text = "Save";
        }
        #endregion

        #region Events
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                pbxImage.Image = new Bitmap(strFilePath);
                if (txtTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
                    txtTitle.Text = System.IO.Path.GetFileName(strFilePath);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() != "")
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
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("ImageAddOrEdit", sqlcon) { CommandType = CommandType.StoredProcedure };
                sqlCmd.Parameters.Add("@ImageID", ImageID);
                sqlCmd.Parameters.Add("@Title", txtTitle.Text.Trim());
                sqlCmd.Parameters.Add("@Image", ImageByteArray);
                sqlCmd.ExecuteNonQuery();
                sqlcon.Close();
                SuccessDialog f = new SuccessDialog();
                Clear();
                RefreshImageGrid();
            }
            //else
            //{
            //    MessageBox.Show("Please enter image title");
            //}

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void dgvImages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTitle.Text = dgvImages.CurrentRow.Cells[1].Value.ToString();
            byte[] ImageArray = (byte[])dgvImages.CurrentRow.Cells[2].Value;
            if (ImageArray.Length == 0)
                pbxImage.Image = DefaultImage;
            else
            {
                ImageByteArray = ImageArray;
                pbxImage.Image = Image.FromStream(new MemoryStream(ImageArray));
            }
            ImageID = Convert.ToInt32(dgvImages.CurrentRow.Cells[0].Value);
            btnSave.Text = "Update";
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvImages.BorderStyle = BorderStyle.None;
            dgvImages.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvImages.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvImages.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvImages.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvImages.BackgroundColor = Color.White;

            dgvImages.EnableHeadersVisualStyles = false;
            dgvImages.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvImages.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgvImages.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void dgvImages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
