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
    public partial class ReceteGörüntüle : Form
    {
        OleDbConnection connection;
        string connectionString = @"provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";

        public ReceteGörüntüle()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
        }

        private void ReceteGörüntüle_Load(object sender, EventArgs e)
        {
            string connectionString = @"provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";
            string query = "SELECT Doktor, Teshis, Ilac FROM recete";

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

                object doktorValue = dataGridView1.Rows[selectedRowIndex].Cells["Doktor"].Value;

                if (doktorValue != null)
                {
                    try
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM recete WHERE Doktor = @PatientID";
                        OleDbCommand command = new OleDbCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@PatientID", doktorValue.ToString());
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
                    MessageBox.Show("Hata: 'Doktor' hücresinde bir değer yok.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.");
            }
        }
    }
}
