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

namespace Perpustakaan_App
{
    public partial class pctr_ui : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-0NKUDBER\SQLEXPRESS;Initial Catalog=perpus;Integrated Security=True");
        SqlCommand cmd;
        int isdipinjam = 0;
        int isdikembalikan = 0;
        public pctr_ui()
        {
            InitializeComponent();
        }

        private void btnkehadiran_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DashboardKehadiran form = new DashboardKehadiran();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pctr_ui form = new pctr_ui();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbNamaBuku_SelectedIndexChanged(object sender, EventArgs e)
        {

            pctr_csharp.Visible = false;
            pctr_sikancil.Visible = false;
            pctr_flutter.Visible = false;
            pctr_design.Visible = false;
            pctr_html.Visible = false;

            if (cbbNamaBuku.Text == "Si Kancil")
            {

                pctr_sikancil.Visible = true;
            }
            else if (cbbNamaBuku.Text == "Belajar C#")
            {

                pctr_csharp.Visible = true;
            }
            else if (cbbNamaBuku.Text == "Flutter Foundamental")
            {

                pctr_flutter.Visible = true;
            }
            else if (cbbNamaBuku.Text == "Dasar Dasar HTML")
            {

                pctr_html.Visible = true;
            }
            else if (cbbNamaBuku.Text == "Typography UI/UX")
            {

                pctr_design.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBarcode.Visible = true;
            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBarcode.Image = brCode.Draw(cbbNamaBuku.Text, 40);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [table_peminjam] (id,nama_peminjam,nomer_handphone,alamat,nama_buku,dipinjam,dikembalikan) values ('" + txtIdPeminjam.Text + "','" + txtNamaPeminjam.Text + "','" + txtNomer.Text + "','" + txtAlamat.Text + "', '" + cbbNamaBuku.Text + "','" + isdipinjam + "', '" + isdikembalikan + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Berhasil Disimpan");
            txtIdPeminjam.Text = "";
            txtAlamat.Text = "";
            txtNamaPeminjam.Text = "";
            txtNomer.Text = ""; 
            pctr_csharp.Visible = false;
            pctr_design.Visible = false;
            pctr_flutter.Visible = false;
            pctr_html.Visible = false;
            pctr_sikancil.Visible = false;
            cbbNamaBuku.Items.Clear();
            rb_dikembalikan.Checked = false;
            rb_dipinjam.Checked = false;
        }

        private void rb_dipinjam_CheckedChanged(object sender, EventArgs e)
        {
            isdipinjam = 1;
            isdikembalikan = 0; 
        }

        private void rb_dikembalikan_CheckedChanged(object sender, EventArgs e)
        {
            isdikembalikan = 1;
            isdipinjam = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtIdPeminjam.Text = "";
            txtAlamat.Text = "";
            txtNamaPeminjam.Text = "";
            txtNomer.Text = "";
            pctr_csharp.Visible = false;
            pctr_design.Visible = false;
            pctr_flutter.Visible = false;
            pctr_html.Visible = false;
            pctr_sikancil.Visible = false;
            cbbNamaBuku.Items.Clear();
            rb_dikembalikan.Checked = false;
            rb_dipinjam.Checked = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [table_peminjam] set id = '" + txtIdPeminjam.Text + "', nama_peminjam = '" + txtNamaPeminjam.Text + "' , nomer_handphone = '" + txtNomer.Text + "' , alamat = '" + txtAlamat + "' , nama_buku = '" + cbbNamaBuku.Text + "' , dipinjam = '" + isdipinjam + "', dikembalikan = '" + isdikembalikan + "' where id = '" + txtIdPeminjam.Text + "' ";
            cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("Data berhasil diedit");
            txtIdPeminjam.Text = "";
            txtAlamat.Text = "";
            txtNamaPeminjam.Text = "";
            txtNomer.Text = "";
            pctr_csharp.Visible = false;
            pctr_design.Visible = false;
            pctr_flutter.Visible = false;
            pctr_html.Visible = false;
            pctr_sikancil.Visible = false;
            cbbNamaBuku.Items.Clear();
            rb_dikembalikan.Checked = false;
            rb_dipinjam.Checked = false;

        }
    }
}
