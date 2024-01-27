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
    public partial class Muayene : Form
    {

        private OleDbConnection connection;

        public Muayene()
        {
            InitializeComponent();
            connection = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb");
        }

        private void Muayene_Load(object sender, EventArgs e)
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
            LoadKlinikler();
        }

        private void LoadKlinikler()

        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Klinikler", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox3.Items.Add(reader["KlinikAdi"].ToString());
                }
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKlinik = comboBox3.SelectedItem.ToString();

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Doktorlar WHERE BagliKlinik = (SELECT KlinikID FROM Klinikler WHERE KlinikAdi = @klinik)", connection);
                command.Parameters.AddWithValue("@klinik", selectedKlinik);

                OleDbDataReader reader = command.ExecuteReader();

                comboBox2.Items.Clear();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["DoktorAdi"].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata: " + ex.Message); ;
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

                string query = "INSERT INTO muayene (Hasta_Id, Klinik, Doktor) VALUES (@Hasta_Id, @Klinik, @Doktor)";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@Hasta_Id", comboBox1.SelectedItem);
                command.Parameters.AddWithValue("@Klinik", comboBox3.SelectedItem);
                command.Parameters.AddWithValue("@Doktor", comboBox2.SelectedItem);

                command.ExecuteNonQuery();

                MessageBox.Show("Muayene bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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