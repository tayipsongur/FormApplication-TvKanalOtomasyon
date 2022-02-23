using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tv_Kanal_ModelFirst
{
    public partial class Kanal_ : Form
    {
        public Kanal_()
        {
            InitializeComponent();
        }

        TvKanalModelContainer baglanti = new TvKanalModelContainer();
        public void VeriGoruntule()
        {
            dataGridView1.DataSource = baglanti.KanalSet.ToList();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = baglanti.KanalSet.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kanal ekle = new Kanal();

            ekle.KanalAdi = txtKanalAd.Text;
            ekle.Ciro = Convert.ToDecimal(txtCiro.Text);
            ekle.Adres = txtAdres.Text;
            ekle.Reyting = Convert.ToDecimal(txtReyting.Text);

            baglanti.KanalSet.Add(ekle);
            baglanti.SaveChanges();
            VeriGoruntule();

            MessageBox.Show("Ekleme İşlemi Başarılı");

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int kanalıd = Convert.ToInt32(txtKanalNo.Text);

            var guncelle = baglanti.KanalSet.Where(x => x.KanalID == kanalıd).FirstOrDefault();

            guncelle.KanalAdi = txtKanalAd.Text;
            guncelle.Ciro = Convert.ToDecimal(txtCiro.Text);
            guncelle.Adres = txtAdres.Text;
            guncelle.Reyting = Convert.ToDecimal(txtReyting.Text);

            baglanti.SaveChanges();
            VeriGoruntule();

            MessageBox.Show("Güncelleme İşlemi Başarılı");

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int kanalıd = Convert.ToInt32(txtKanalNo.Text);

            var sil = baglanti.KanalSet.Where(x => x.KanalID == kanalıd).FirstOrDefault();
            baglanti.KanalSet.Remove(sil);
            baglanti.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı..");

           

        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.KanalSet.Where(x => x.KanalAdi.ToLower().Contains(txtKanalAd.Text) || x.KanalAdi.ToUpper().Contains(txtKanalAd.Text)).ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;

            txtKanalNo.Text = satir.Cells["KanalID"].Value.ToString();
            txtKanalAd.Text = satir.Cells["KanalAdi"].Value.ToString();
            txtCiro.Text = satir.Cells["Ciro"].Value.ToString();
            txtAdres.Text = satir.Cells["Adres"].Value.ToString();
            txtReyting.Text = satir.Cells["Reyting"].Value.ToString();
          
        }
    }
}
