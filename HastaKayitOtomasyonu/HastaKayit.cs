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

namespace HastaKayitOtomasyonu
{
    public partial class HastaKayit : Form
    {

        OleDbConnection con = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source = HastaKayit.mdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;

        void listele()
        {
            da = new OleDbDataAdapter("select * from hastalar", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            temizle();
        }

        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            maskedTextBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            maskedTextBox2.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        public HastaKayit()
        {
            InitializeComponent();
        }

        private void HastaKayit_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("insert into hastalar (TC, AD, SOYAD, C, KAN, DOGUMY, DOGUMT, BABAADI, ANNEADI, CEPTEL, POSTA, GIRIST, CIKIST, ADRES ) values( @tc, @ad, @soyad, @c, @kan, @dogumy, @dogumt, @babaadı, @anneadı, @ceptel, @posta, @girist, @cikist, @adres ) ", con);
            cmd.Parameters.AddWithValue("@tc", textBox2.Text);
            cmd.Parameters.AddWithValue("@ad", textBox3.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox4.Text);
            cmd.Parameters.AddWithValue("@c", comboBox1.Text);
            cmd.Parameters.AddWithValue("@kan", comboBox2.Text);
            cmd.Parameters.AddWithValue("@dogumy", comboBox3.Text);
            cmd.Parameters.AddWithValue("@dogumt", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@babaadı", textBox5.Text);
            cmd.Parameters.AddWithValue("@anneadı", textBox6.Text);
            cmd.Parameters.AddWithValue("@ceptel", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@posta", textBox7.Text);
            cmd.Parameters.AddWithValue("@girist", dateTimePicker1.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@cikist", dateTimePicker2.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@adres", textBox8.Text);
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun");
            }
            else
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt Eklendi");
                listele();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            cmd = new OleDbCommand("delete from hastalar where TC  = @tc ", con);
            cmd.Parameters.AddWithValue("@tc", textBox2.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand(" update hastalar set AD = '" + textBox3.Text + "', SOYAD='" + textBox4.Text + "', C='" + comboBox1.Text + "', KAN='" + comboBox2.Text + "', DOGUMY='" + comboBox3.Text + "', DOGUMT='" + maskedTextBox1.Text + "', BABAADI='" + textBox5.Text + "', ANNEADI='" + textBox6.Text + "', CEPTEL='" + maskedTextBox2.Text + "', POSTA='" + textBox7.Text + "', GIRIST='" + dateTimePicker1.Value.ToShortDateString() + "', CIKIST='" + dateTimePicker2.Value.ToShortDateString() + "', ADRES='" + textBox8.Text + "' where TC ='" + textBox2.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Güncellendi");
            listele();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            da = new OleDbDataAdapter("select * from hastalar where tc like '" + textBox9.Text + "%'", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
