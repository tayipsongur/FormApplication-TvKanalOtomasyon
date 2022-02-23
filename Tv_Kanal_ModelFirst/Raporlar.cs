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
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }

        TvKanalModelContainer baglanti = new TvKanalModelContainer();
        private void button1_Click(object sender, EventArgs e)
        {
            var sonuc = from kanal in baglanti.KanalSet
                        orderby kanal.KanalAdi descending
                        select kanal;

            dataGridView1.DataSource = sonuc.ToList();
                      

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sonuc = from kanal in baglanti.KanalSet
                        group kanal by kanal.KanalAdi into grup
                        select new
                        {
                            ToplamCiro = grup.Sum(x => x.Ciro),
                            KanalAdı = grup.Key
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sonuc = from sorumlu in baglanti.SorumluSet
                        group sorumlu by sorumlu.AdSoyad into grup
                        select new
                        {
                          toplammaas=grup.Sum(x=> x.Maas),
                          SorumluAdSoyad=grup.Key
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sonuc = from reyting in baglanti.YayinSet
                        group reyting by reyting.YayinAdi into grup
                        select new
                        {
                            Enyüksekreyting=grup.Max(x=> x.Reyting),
                            YayınAdı=grup.Key
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sonuc = from yayin in baglanti.YayinSet
                        join sorumlu in baglanti.SorumluSet on
                        yayin.YayinID equals sorumlu.YayinID
                        select new
                        {
                            yayin.YayinAdi,
                            yayin.Reyting,
                            sorumlu.AdSoyad,
                            sorumlu.Maas

                        };

            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var sonuc = from yayin in baglanti.YayinSet
                        join sorumlu in baglanti.SorumluSet on
                        yayin.YayinID equals sorumlu.YayinID
                        join kanal in baglanti.KanalSet on yayin.KanalID equals
                        kanal.KanalID
                        select new
                        {
                            yayin.YayinAdi,
                            yayin.Reyting,
                            sorumlu.AdSoyad,
                            sorumlu.Maas,
                            kanal.KanalAdi,
                            

                        };
            dataGridView1.DataSource = sonuc.ToList();


        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            
        }
    }
}
