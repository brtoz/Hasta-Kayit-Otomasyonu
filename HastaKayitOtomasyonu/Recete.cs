using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace HastaKayitOtomasyonu
{
    public partial class Recete : Form
    {
        OleDbConnection connection;
        string connectionString = "provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";

        public Recete()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
        }

        private void Recete_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Doktor, Teshis, Ilac FROM recete", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // DataGridView'in veri kaynağını belirliyoruz.
            dataGridView1.DataSource = dataTable;

            LoadHastalar();
            LoadDoktorlar();
            LoadTeshisler();
            LoadIlaclar();
            ClearTextBoxes();
        }

        private void LoadHastaBilgileri(int hastaId)
        {
            try
            {
                connection.Open();

                string doktorAdiQuery = "SELECT Doktor FROM randevular WHERE Hasta_Id = @HastaId";
                OleDbCommand doktorAdiCommand = new OleDbCommand(doktorAdiQuery, connection);
                doktorAdiCommand.Parameters.AddWithValue("@HastaId", hastaId);
                string doktorAdi = (string)doktorAdiCommand.ExecuteScalar();
                comboBox2.Text = doktorAdi;

                string teshisQuery = "SELECT Teshis FROM teshis WHERE Hasta_Id = @HastaId";
                OleDbCommand teshisCommand = new OleDbCommand(teshisQuery, connection);
                teshisCommand.Parameters.AddWithValue("@HastaId", hastaId);
                OleDbDataReader teshisReader = teshisCommand.ExecuteReader();
                while (teshisReader.Read())
                {
                    textBox1.Text += teshisReader["Teshis"].ToString() + Environment.NewLine;
                }
                teshisReader.Close();

                string ilacQuery = "SELECT Ilac FROM teshis WHERE Hasta_Id = @HastaId";
                OleDbCommand ilacCommand = new OleDbCommand(ilacQuery, connection);
                ilacCommand.Parameters.AddWithValue("@HastaId", hastaId);
                OleDbDataReader ilacReader = ilacCommand.ExecuteReader();
                while (ilacReader.Read())
                {
                    textBox2.Text += ilacReader["Ilac"].ToString() + Environment.NewLine;
                }
                ilacReader.Close();
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

        private void LoadHastalar()
        {
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

        private void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void LoadDoktorlar()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT DoktorAdi FROM doktorlar", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["DoktorAdi"].ToString());
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
        private void LoadTeshisler()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT Teshis FROM teshis", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    textBox1.Text += reader["Teshis"].ToString() + Environment.NewLine;
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
        private void LoadIlaclar()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT Ilac FROM teshis", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    textBox2.Text += reader["Ilac"].ToString() + Environment.NewLine;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO recete (Doktor, Teshis, Ilac) VALUES (@Doktor, @Teshis, @Ilac)";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@Doktor", comboBox2.SelectedItem);
                command.Parameters.AddWithValue("@Teshis", textBox1.Text);
                command.Parameters.AddWithValue("@Ilac", textBox2.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Reçete bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearTextBoxes();


            if (comboBox1.SelectedItem != null)
            {
                int hastaId = (int)comboBox1.SelectedItem;
                LoadHastaBilgileri(hastaId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Dosyası|*.pdf";
                saveDialog.Title = "PDF Olarak Kaydet";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveDialog.FileName, FileMode.Create));

                    doc.Open();

                    PdfPTable pdfTable = new PdfPTable(selectedRow.Cells.Count);

                    for (int j = 0; j < selectedRow.Cells.Count; j++)
                    {
                        pdfTable.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                    }

                    pdfTable.HeaderRows = 1;

                    for (int k = 0; k < selectedRow.Cells.Count; k++)
                    {
                        if (selectedRow.Cells[k].Value != null)
                        {
                            pdfTable.AddCell(new Phrase(selectedRow.Cells[k].Value.ToString()));
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();

                    MessageBox.Show("PDF başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
