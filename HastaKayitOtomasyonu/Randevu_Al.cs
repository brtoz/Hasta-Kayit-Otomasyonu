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
using System.Windows.Forms.VisualStyles;



namespace HastaKayitOtomasyonu
{


    public partial class Randevu_Al : Form
    {

        OleDbConnection connection;

        string connectionString = "provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb";
        string selectedTime = "";


        public Randevu_Al()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
            connection = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb");
        }

        private void Randevu_Al_Load(object sender, EventArgs e)
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
                    comboBox2.Items.Add(reader["KlinikAdi"].ToString());
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKlinik = comboBox2.SelectedItem.ToString();

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Doktorlar WHERE BagliKlinik = (SELECT KlinikID FROM Klinikler WHERE KlinikAdi = @klinik)", connection);
                command.Parameters.AddWithValue("@klinik", selectedKlinik);

                OleDbDataReader reader = command.ExecuteReader();

                comboBox3.Items.Clear();

                while (reader.Read())
                {
                    comboBox3.Items.Add(reader["DoktorAdi"].ToString());
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
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Red;
            selectedTime = clickedButton.Text;
            foreach (Control control in panel1.Controls)
            {
                if (control is Button && control != clickedButton)
                {
                    control.Enabled = false;
                }
            }
            
        }

        private bool RandevuVarMi(string selectedTime)
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM randevular WHERE Klinik=@Klinik AND Doktor=@Doktor AND Tarih=@Tarih AND Saat=@Saat";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@Klinik", comboBox2.SelectedItem);
                command.Parameters.AddWithValue("@Doktor", comboBox3.SelectedItem);
                command.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.ToShortDateString());
                command.Parameters.AddWithValue("@Saat", selectedTime);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return true;
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTime))
            {
                MessageBox.Show("Lütfen bir saat seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection.Open();
                string query = "INSERT INTO randevular (Hasta_Id, Klinik, Doktor, Tarih, Saat) VALUES (@Hasta_Id, @Klinik, @Doktor, @Tarih, @Saat)";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@Hasta_Id", comboBox1.SelectedItem);
                command.Parameters.AddWithValue("@Klinik", comboBox2.SelectedItem);
                command.Parameters.AddWithValue("@Doktor", comboBox3.SelectedItem);
                command.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.ToShortDateString());
                command.Parameters.AddWithValue("@Saat", selectedTime);
                command.ExecuteNonQuery();

                MessageBox.Show(comboBox2.SelectedItem + " Kliniğine " + dateTimePicker1.Value.ToShortDateString() + " Tarihine " + selectedTime + "'Saatine randevunuz alınmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    string buttonText = button.Text;

                    if (RandevuVarMi(buttonText))
                    {
                        button.BackColor = Color.Red; 
                        button.Enabled = false; 
                    }
                    else
                    {
                        button.BackColor = Color.Lime; 
                        button.Enabled = true; 
                    }
                }
            }
        }
    }
}


