using System.Data.SqlClient;
using System.Data;

namespace Perpustakaan_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-0NKUDBER\SQLEXPRESS;Initial Catalog=perpus;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            //  

            String username, password;

            username = tb_username.Text;
            password = tb_password.Text;

            try
            {

                String querry = "SELECT * FROM table_login WHERE username = '" + tb_username.Text + "' AND password = '" + tb_password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = tb_username.Text;
                    password = tb_password.Text;

                    //
                    Form2 form = new Form2();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_username.Clear();
                    tb_password.Clear();

                    //
                    tb_username.Focus();

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void tb_username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}