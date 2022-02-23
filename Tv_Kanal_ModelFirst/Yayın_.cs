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
    public partial class Yayın_ : Form
    {
        public Yayın_()
        {
            InitializeComponent();
        }
        public void VeriGoruntule()
        {
            dataGridView1.DataSource = baglanti.YayinSet.ToList();
        }

        TvKanalModelContainer baglanti = new TvKanalModelContainer();
        private void Yayın__Load(object sender, EventArgs e)
        {
            comboKanal.DataSource = baglanti.KanalSet.ToList();
            comboKanal.ValueMember = "KanalID";
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.YayinSet.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Yayin ekle = new Yayin();

            ekle.YayinAdi = txtYayınAd.Text;
            ekle.YayinTarih = dateTimePicker1.Text;
            ekle.Reyting = Convert.ToDecimal(txtReyting.Text);
            ekle.KanalID = Convert.ToInt32(comboKanal.Text);

            baglanti.YayinSet.Add(ekle);
            baglanti.SaveChanges();
            VeriGoruntule();
            MessageBox.Show("Ekleme İşlemi Başarılı");

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int yayinıd = Convert.ToInt32(txtYayınNo.Text);

            var guncelle = baglanti.YayinSet.Where(x => x.YayinID == yayinıd).FirstOrDefault();

            guncelle.YayinAdi = txtYayınAd.Text;
            guncelle.YayinTarih = dateTimePicker1.Text;
            guncelle.Reyting = Convert.ToDecimal(txtReyting.Text) ;
            guncelle.KanalID = Convert.ToInt32(comboKanal.Text);

            baglanti.SaveChanges();

            MessageBox.Show("Güncelleme İşlemi Başarılı");
            VeriGoruntule();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
               
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;


            txtYayınNo.Text = satir.Cells["YayinID"].Value.ToString();
            txtYayınAd.Text = satir.Cells["YayinAdi"].Value.ToString();
           dateTimePicker1.Text = satir.Cells["YayinTarih"].Value.ToString();
            txtReyting.Text = satir.Cells["Reyting"].Value.ToString();
            comboKanal.Text = satir.Cells["KanalID"].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int yayinno = Convert.ToInt32(txtYayınNo.Text);

            var sil = baglanti.YayinSet.Where(x => x.KanalID == yayinno).FirstOrDefault();

            baglanti.YayinSet.Remove(sil);

            baglanti.SaveChanges();
            VeriGoruntule();

            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.YayinSet.Where(x => x.YayinAdi.ToLower().Contains(txtYayınAd.Text) || x.YayinAdi.ToUpper().Contains(txtYayınAd.Text)).ToList(); 
        }
    }
}
