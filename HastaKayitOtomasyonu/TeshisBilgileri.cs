using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaKayitOtomasyonu
{
    public partial class TeshisBilgileri : Form
    {

        OleDbConnection connection;
        string connectionString = @"provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";
        public TeshisBilgileri()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
        }

        private void TeshisBilgileri_Load(object sender, EventArgs e)
        {
            string connectionString = @"provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();

                string query = "SELECT Id FROM Hastalar";
                OleDbCommand command = new OleDbCommand(query, connection);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        comboBox1.Items.Add(id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO teshis (Hasta_Id, Teshis, Belirti, Ilac, Dozu, Sıklıgı) VALUES (@Hasta_Id, @Teshis, @Belirti, @Ilac, @Dozu, @Sıklıgı)";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@Hasta_Id", comboBox1.SelectedItem);
                command.Parameters.AddWithValue("@Teshis", textBox2.Text);
                command.Parameters.AddWithValue("@Belirti", textBox3.Text);
                command.Parameters.AddWithValue("@Ilac", textBox1.Text);
                command.Parameters.AddWithValue("@Dozu", comboBox2.SelectedItem);
                command.Parameters.AddWithValue("@Sıklıgı", comboBox3.SelectedItem);

                command.ExecuteNonQuery();

                MessageBox.Show("Teşhis bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}