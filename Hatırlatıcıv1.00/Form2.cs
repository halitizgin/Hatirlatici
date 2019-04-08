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

namespace Hatırlatıcıv1._00
{
    public partial class Form2 : Form
    {
        public Form2(DateTime tarih, string button, string nBaslik, string nMetin, int nID)
        {
            InitializeComponent();
            gTarih = tarih;
            gButton = button;
            gBaslik = nBaslik;
            gMetin = nMetin;
            gID = nID;
        }

        int gID = 0;
        string gButton = "Ekle";
        string gBaslik = "";
        string gMetin = "";
        DateTime gTarih = DateTime.Now;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hatirlat.accdb");
        OleDbCommand komut = new OleDbCommand();

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Text = gButton;
            textBox1.Text = gBaslik;
            textBox2.Text = gMetin;
            textBox3.Text = gID.ToString();
            dateTimePicker1.Value = gTarih;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy  dddd - HH:mm:ss";
            dateTimePicker1.Value = gTarih;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Ekle")
            {
                int sonuc = DateTime.Compare(dateTimePicker1.Value, DateTime.Now);
                if (sonuc >= 0)
                {
                    if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
                    {
                        string nBaslik = textBox1.Text.Trim();
                        string nNot = textBox2.Text.Trim();
                        DateTime nTarih = dateTimePicker1.Value;
                        baglanti.Open();
                        komut.Connection = baglanti;
                        komut.CommandText = "INSERT INTO hatirlat (tarih, baslik, aciklama) VALUES ('" + nTarih + "', '" + nBaslik + "', '" + nNot + "')";
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        baglanti.Close();
                        MessageBox.Show("Not başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 form1 = new Form1(true);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen gerekli alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen ileride bir tarih seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (button1.Text == "Düzenle")
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
                {
                    baglanti.Open();
                    string nBaslik = textBox1.Text.Trim();
                    string nMetin = textBox2.Text.Trim();
                    DateTime nTarih = dateTimePicker1.Value;
                    int nID = int.Parse(textBox3.Text);
                    komut.Connection = baglanti;
                    komut.CommandText = "UPDATE hatirlat SET tarih='" + nTarih + "', baslik='" + nBaslik + "', aciklama='" + nMetin + "' WHERE id=@id";
                    komut.Parameters.AddWithValue("@id", nID);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    MessageBox.Show("Düzenleme işlemi başarıyla tamamlanmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                { 
                
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
