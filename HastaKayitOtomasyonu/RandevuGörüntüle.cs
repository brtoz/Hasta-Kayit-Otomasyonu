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
    public partial class RandevuGörüntüle : Form
    {

        OleDbConnection connection;
        string connectionString = @"provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";

        public RandevuGörüntüle()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
        }

        private void RandevuGörüntüle_Load(object sender, EventArgs e)
        {
            string connectionString = @"provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";
            string query = "SELECT Hasta_Id, Klinik, Doktor, Tarih, Saat FROM randevular";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int selectedPatientID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Hasta_Id"].Value);

                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM randevular WHERE Hasta_Id = @PatientID";
                    OleDbCommand command = new OleDbCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@PatientID", selectedPatientID);
                    command.ExecuteNonQuery();

                    dataGridView1.Rows.RemoveAt(selectedRowIndex);

                    MessageBox.Show("Hasta başarıyla silindi.");
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
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.");
            }
        }
    }
}
