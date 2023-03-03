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

namespace Perpustakaan_App
{
    public partial class DashboardKehadiran : Form

    {
       int isPengunjung = 0;
       int isPeminjam = 0;


        public DashboardKehadiran()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-0NKUDBER\SQLEXPRESS;Initial Catalog=perpus;Integrated Security=True");
        SqlCommand cmd;


        private void btnkehadiran_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [table_pengunjung] (id,nama_pengunjung,keperluan,pengunjung,peminjam,tanggal) values ('" + txtId.Text + "','" + txtNama.Text + "','" + txtKeperluan.Text + "','" + isPengunjung + "', '" + isPeminjam + "','" + monthCalendar1.SelectionRange.Start.ToString("dd MMM yyyy") + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Berhasil Disimpan");
            txtId.Text = "";
            txtNama.Text = "";
            txtKeperluan.Text = "";
            rbpeminjam.Checked = false;
            rb_pengunjung.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void rb_pengunjung_CheckedChanged(object sender, EventArgs e)
        {
            isPengunjung = 1;
            isPeminjam = 0;
        }

        private void rbpeminjam_CheckedChanged(object sender, EventArgs e)
        {
            isPengunjung = 0;
            isPeminjam = 1;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNama.Text = "";
            txtKeperluan.Text = "";
            rbpeminjam.Checked = false;
            rb_pengunjung.Checked = false;
        }

        private void DashboardKehadiran_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [table_pengunjung] set id = '" + txtId.Text + "', nama_pengunjung = '" + txtNama.Text + "' , keperluan = '" + txtKeperluan.Text + "' , pengunjung = '" + isPengunjung + "' , peminjam = '" + isPeminjam + "' , tanggal = '" + monthCalendar1.SelectionRange.Start.ToString("dd MMM yyyy") + "' where id = '" + txtId.Text + "' ";
            cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("Data berhasil diedit");
            txtId.Text = "";
            txtNama.Text = "";
            txtKeperluan.Text = "";
            rbpeminjam.Checked = false;
            rb_pengunjung.Checked = false;
        }
    }
}
