using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Ulasan
{


    public partial class Ulasan : Form
    {
        private Form1.User user;
        public Ulasan(Form1.User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=ternyatabeda;Database=token"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into komentar (komentar,id_user) values (@komentar,@id)";
                    command.CommandType = CommandType.Text;
                    string komentarValue = textBox1.Text;
                    command.Parameters.AddWithValue("@komentar", komentarValue);
                    command.Parameters.AddWithValue("@id", user.id_user);
                    command.ExecuteNonQuery();
                    textBox1.Text = "";
                    connection.Close();
                }

                using (NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=ternyatabeda;Database=token"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into rating (rating, id_user) values (@rating, @id_user)";

                    int id = user.id_user;
                    int ratingValue = 0;

                    if (radioButton1.Checked)
                    {
                        ratingValue = 1;
                        radioButton1.Checked = false;
                    }
                    else if (radioButton2.Checked)
                    {
                        ratingValue = 2;
                        radioButton2.Checked = false;
                    }
                    else if (radioButton3.Checked)
                    {
                        ratingValue = 3;
                        radioButton3.Checked = false;
                    }
                    else if (radioButton4.Checked)
                    {
                        ratingValue = 4;
                        radioButton4.Checked = false;
                    }
                    else if (radioButton5.Checked)
                    {
                        ratingValue = 5;
                        radioButton5.Checked = false;
                    }

                    // Tetapkan nilai rating ke parameter @rating
                    command.Parameters.AddWithValue("@rating", ratingValue);
                    command.Parameters.AddWithValue("@id_user", id);
                    command.ExecuteNonQuery();

                    connection.Close();
                }

                MessageBox.Show("Berhasil memasukkan data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tidak berhasil memasukkan data. Error: " + ex.Message);
            }

        }

        private void Ulasan_Load(object sender, EventArgs e)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=ternyatabeda;Database=token"))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT komentar.komentar, users.username FROM komentar INNER JOIN users ON komentar.id_user = users.id_user ORDER BY komentar.id_komentar DESC";
                NpgsqlDataReader reader = command.ExecuteReader();
                int i = 1;

                while (reader.Read()) // Loop melalui hasil bacaan reader
                {
                    string komentar = reader["komentar"].ToString();
                    string username = reader["username"].ToString(); // Mengambil nilai dari kolom "username"

                    Label label = this.Controls.Find("labelKomentar" + i, true).FirstOrDefault() as Label;
                    if (label != null)
                        label.Text = komentar;
                        label.Visible = true;
                    Label labelusername = this.Controls.Find("labelUsername" + i, true).FirstOrDefault() as Label;
                    if (labelusername != null)
                        labelusername.Text = username;
                        label.Visible = true;

                    i++; // Meningkatkan nilai i untuk mencari label berikutnya
                }

                reader.Close(); // Menutup reader setelah penggunaannya
                connection.Close();
            }

        }
    }
}
