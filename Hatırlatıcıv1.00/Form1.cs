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
    public partial class Form1 : Form
    {
        public Form1(bool yenile)
        {
            InitializeComponent();
            gYenile = yenile;
        }

        bool gYenile = false;

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hatirlat.accdb");
        OleDbCommand komut = new OleDbCommand();

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy  dddd   |   HH:mm:ss";
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Başlık");
            listView1.Columns.Add("Not", 800);
            listView1.Columns.Add("Tarih");
            DateTime tarih = dateTimePicker1.Value;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM hatirlat";
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            { 
                if (DateTime.Parse(okuyucu["tarih"].ToString()) == tarih)
                {
                    int count = listView1.Items.Count;
                    listView1.Items.Add(okuyucu["id"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                }
            }
            baglanti.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                listView1.Items.Clear();
                DateTime tarih = dateTimePicker1.Value;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM hatirlat";
                OleDbDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    if (DateTime.Parse(okuyucu["tarih"].ToString()) == tarih)
                    {
                        int count = listView1.Items.Count;
                        listView1.Items.Add(okuyucu["id"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                    }
                }
                baglanti.Close();
            }
            else
            { 
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dateTimePicker1.Value, "Ekle", "", "", 0);
            form2.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                listView1.Items.Clear();
                DateTime tarih = dateTimePicker1.Value;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM hatirlat";
                OleDbDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    int count = listView1.Items.Count;
                    listView1.Items.Add(okuyucu["id"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                    listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                }
                baglanti.Close();
            }
            else if (checkBox1.Checked == false)
            {
                dateTimePicker1.Enabled = true;
                listView1.Items.Clear();
                DateTime tarih = dateTimePicker1.Value;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM hatirlat";
                OleDbDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    if (DateTime.Parse(okuyucu["tarih"].ToString()) == tarih)
                    {
                        int count = listView1.Items.Count;
                        listView1.Items.Add(okuyucu["id"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                    }
                }
                baglanti.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gYenile == true)
            {
                if (checkBox1.Checked == true)
                {
                    listView1.Items.Clear();
                    DateTime tarih = dateTimePicker1.Value;
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "SELECT * FROM hatirlat";
                    OleDbDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        int count = listView1.Items.Count;
                        listView1.Items.Add(okuyucu["id"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                    }
                    baglanti.Close();
                }
                else if (checkBox1.Checked == false)
                {
                    listView1.Items.Clear();
                    DateTime tarih = dateTimePicker1.Value;
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "SELECT * FROM hatirlat";
                    OleDbDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        if (DateTime.Parse(okuyucu["tarih"].ToString()) == tarih)
                        {
                            int count = listView1.Items.Count;
                            listView1.Items.Add(okuyucu["id"].ToString());
                            listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                            listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                            listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                        }
                    }
                    baglanti.Close();
                }
                gYenile = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                baglanti.Open();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    int id = int.Parse(item.Text);
                    komut.Connection = baglanti;
                    komut.CommandText = "DELETE FROM hatirlat WHERE id=@id";
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
                baglanti.Close();
                MessageBox.Show("Silme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (checkBox1.Checked == true)
                {
                    listView1.Items.Clear();
                    DateTime tarih = dateTimePicker1.Value;
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "SELECT * FROM hatirlat";
                    OleDbDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        int count = listView1.Items.Count;
                        listView1.Items.Add(okuyucu["id"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                        listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                    }
                    baglanti.Close();
                    
                }
                else if (checkBox1.Checked == false)
                {
                    listView1.Items.Clear();
                    DateTime tarih = dateTimePicker1.Value;
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "SELECT * FROM hatirlat";
                    OleDbDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        if (DateTime.Parse(okuyucu["tarih"].ToString()) == tarih)
                        {
                            int count = listView1.Items.Count;
                            listView1.Items.Add(okuyucu["id"].ToString());
                            listView1.Items[count].SubItems.Add(okuyucu["baslik"].ToString());
                            listView1.Items[count].SubItems.Add(okuyucu["aciklama"].ToString());
                            listView1.Items[count].SubItems.Add(okuyucu["tarih"].ToString());
                        }
                    }
                    baglanti.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int nID = int.Parse(listView1.SelectedItems[0].Text);
                DateTime nTarih = DateTime.Parse(listView1.SelectedItems[0].SubItems[3].Text);
                string nBaslik = listView1.SelectedItems[0].SubItems[1].Text;
                string nNot = listView1.SelectedItems[0].SubItems[2].Text;
                Form2 form2 = new Form2(nTarih, "Düzenle", nBaslik, nNot, nID);
                form2.ShowDialog();
            }
        }
    }
}
