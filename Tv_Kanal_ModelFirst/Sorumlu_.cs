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
    public partial class Sorumlu_ : Form
    {
        public Sorumlu_()
        {
            InitializeComponent();
        }

        TvKanalModelContainer baglanti = new TvKanalModelContainer();

        public void VeriGoruntule()
        {
            dataGridView1.DataSource = baglanti.SorumluSet.ToList();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.SorumluSet.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Sorumlu ekle = new Sorumlu();
            ekle.AdSoyad = txtSorumluAdSoyad.Text;
            ekle.Görevli = txtGörevli.Text;
            ekle.Maas = Convert.ToDecimal(txtMaas.Text);
            ekle.GörevSayisi = Convert.ToInt32(txtGörevSayisi.Text);
            ekle.YayinID = Convert.ToInt32(comboYayınNo.Text);

            baglanti.SorumluSet.Add(ekle);
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
            int sorumluid = Convert.ToInt32(txtSorumluNo.Text);

            var guncelle = baglanti.SorumluSet.Where(x => x.SorumluID == sorumluid).FirstOrDefault();

            guncelle.AdSoyad = txtSorumluAdSoyad.Text;
            guncelle.Görevli = txtGörevli.Text;
            guncelle.Maas = Convert.ToDecimal(txtMaas.Text);
            guncelle.GörevSayisi = Convert.ToInt32(txtGörevSayisi.Text);
            guncelle.YayinID = Convert.ToInt32(comboYayınNo.Text);


            baglanti.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");

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

        private void btnArama_Click(object sender, EventArgs e)
        {
            baglanti.SorumluSet.Where(x => x.AdSoyad.ToUpper().Contains(txtSorumluAdSoyad.Text) || x.AdSoyad.ToLower().Contains(txtSorumluAdSoyad.Text)).ToList();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int sorumluid = Convert.ToInt32(txtSorumluNo.Text);
            var sil = baglanti.SorumluSet.Where(x => x.SorumluID == sorumluid).FirstOrDefault();

            baglanti.SorumluSet.Remove(sil);
            baglanti.SaveChanges();

            MessageBox.Show("Silme İşlemi Başarılı");

        }

        private void Sorumlu__Load(object sender, EventArgs e)
        {
            comboYayınNo.DataSource = baglanti.YayinSet.ToList();
            comboYayınNo.ValueMember = "YayinID";

            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;

            txtSorumluNo.Text = satir.Cells["SorumluID"].Value.ToString();
            txtSorumluAdSoyad.Text = satir.Cells["AdSoyad"].Value.ToString();
            txtGörevli.Text = satir.Cells["Görevli"].Value.ToString();
            txtMaas.Text = satir.Cells["Maas"].Value.ToString();
            txtGörevSayisi.Text = satir.Cells["GörevSayisi"].Value.ToString();
            comboYayınNo.Text = satir.Cells["YayinID"].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
