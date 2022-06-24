using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DataKaryawan
{
    public partial class Formss : Form
    {
        /*string conectionstring = "Server=localhost;Database=pbo;username=root;Pwd=;";
        MySqlConnection kon;*/
        public Formss()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Formss_Load(object sender, EventArgs e)
        {

        }
        Koneksi koneksi = new Koneksi();

        private void button1_Click_1(object sender, EventArgs e)
        {
            koneksi.OpenConnection();
            try
            {
                /*string stm = "select name,password from log WHERE name =@Name AND password =@Password";
                var cmd = new MySqlCommand(stm, koneksi.kon);

                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.ExecuteReader();*/

                string query = "SELECT COUNT(*) FROM karyawan WHERE email = '" + textBox1.Text + "' AND nohp = '" + textBox2.Text + "' ";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, koneksi.kon);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Form1 halamanNext = new Form1();
                    halamanNext.Show();
                }
                else
                {
                    MessageBox.Show("Email dan No Telepon Tidak Sesuai !", "Terjadi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                koneksi.CloseConnection();
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "login failed");
            }
}
    }
}
