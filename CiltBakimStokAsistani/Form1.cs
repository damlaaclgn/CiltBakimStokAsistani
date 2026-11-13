using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; 
using System.Data.SQLite;  // ARTIK SUNUCU GEREKTIRMEYEN GÖMÜLÜ VERİTABANI

namespace CiltBakimStokAsistani
{
    public partial class Form1 : Form
    {
        // Global Kullanıcı Adı Değişkeni
        string kullaniciAdi = "Kullanıcı";

        // Veritabanı dosyası DAİMA çalışan .exe'nin yanında durur.
        // Böylece program bambaşka bir bilgisayara kopyalansa bile,
        // SQL Server / LocalDB kurulumuna gerek kalmadan sorunsuz açılır.
        readonly string dbDosyaYolu = Path.Combine(Application.StartupPath, "CiltBakimDb.db");
        readonly string baglantiCumlesi;
        SQLiteConnection baglanti;

        public Form1()
        {
            InitializeComponent();
            baglantiCumlesi = "Data Source=" + dbDosyaYolu + ";Version=3;";
            baglanti = new SQLiteConnection(baglantiCumlesi);

            // Veritabanı yoksa oluştur, tabloyu kur, boşsa örnek verileri yükle
            VeritabaniHazirla();
        }

        // ============================================================
        //  GÖMÜLÜ VERİTABANI KURULUMU (ilk açılışta otomatik çalışır)
        // ============================================================
        void VeritabaniHazirla()
        {
            try
            {
                if (!File.Exists(dbDosyaYolu))
                    SQLiteConnection.CreateFile(dbDosyaYolu);

                using (var conn = new SQLiteConnection(baglantiCumlesi))
                {
                    conn.Open();

                    string olusturSql = @"
                        CREATE TABLE IF NOT EXISTS Urunler (
                            Id                INTEGER PRIMARY KEY AUTOINCREMENT,
                            Marka             TEXT,
                            UrunAdi           TEXT,
                            UrunTipi          TEXT,
                            StokAdedi         INTEGER,
                            PhDegeri          REAL,
                            SonKullanmaTarihi DATETIME,
                            KullanimRutini    TEXT
                        );";
                    using (var cmd = new SQLiteCommand(olusturSql, conn))
                        cmd.ExecuteNonQuery();

                    // Tablo boşsa, demoda boş ekran kalmasın diye örnek ürünleri yükle
                    long adet;
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Urunler", conn))
                        adet = Convert.ToInt64(cmd.ExecuteScalar());

                    if (adet == 0)
                        OrnekVerileriYukle(conn);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Veritabanı hazırlanırken hata oluştu: " + hata.Message);
            }
        }

        // İlk kurulumda yüklenen başlangıç verileri.
        // (Eski SQL Server .mdf dosyasından kurtarılan ürünlerdir; istenirse
        //  uygulama içinden silinip kendi verilerinizle değiştirilebilir.)
        void OrnekVerileriYukle(SQLiteConnection conn)
        {
            var ornekler = new[]
            {
                // --- Damla hesabi (giriste "Damla" yazarak gorebilirsiniz) ---
                new object[] { "Damla - CeraVe",              "Foaming Cleanser Temizleyici",    "Temizleyici", 2, 5.5,  "Gündüz Rutini"   },
                new object[] { "Damla - Anua",                "BHA Siyah Nokta Karşıtı Jel",     "Temizleyici", 1, 5.0,  "Gündüz Rutini"   },
                new object[] { "Damla - The Ordinary",        "Glycolic Acid %7 Tonik",          "Tonik",       1, 3.6,  "Gece Rutini"     },
                new object[] { "Damla - The Ordinary",        "Niacinamide %10 + Zinc %1 Serum", "Serum",       3, null, "Gece Rutini"     },
                new object[] { "Damla - The Purest Solutions","Azelaic Acid %10 Aydınlatıcı",    "Serum",       1, null, "Gece Rutini"     },
                new object[] { "Damla - Maruderm",            "Arbutin %2 Leke Karşıtı Serum",   "Serum",       2, null, "Gece Rutini"     },
                new object[] { "Damla - CeraVe",              "Moisturising Cream Nemlendirici", "Nemlendirici",4, null, "İhtiyaç Halinde" },
                new object[] { "Damla - La Roche-Posay",      "Anthelios Güneş Kremi SPF50+",    "Güneş Kremi", 2, null, "Gündüz Rutini"   },
                new object[] { "Damla - Maruderm",            "AHA %10 + BHA %2 Peeling",        "Peeling",     1, null, "Gece Rutini"     },
                new object[] { "Damla - The Ordinary",        "AHA %30 + BHA %2 Peeling Maske",  "Maske",       1, 3.6,  "İhtiyaç Halinde" },
                new object[] { "Damla - Bioderma",            "Sensibio Nemlendirici",           "Nemlendirici",2, null, "Gündüz Rutini"   },

                // --- hira hesabi (giriste "hira" yazarak gorebilirsiniz) ---
                new object[] { "hira - Cosrx",                "AHA/BHA Tonik",                   "Tonik",       1, 4.5,  "Gündüz Rutini"   },
                new object[] { "hira - The Ordinary",         "Niacinamide %10 Serum",           "Serum",       2, null, "Gece Rutini"     },
                new object[] { "hira - The Purest Solutions", "Hyaluronic Acid Nemlendirici",    "Nemlendirici",1, null, "İhtiyaç Halinde" },
                new object[] { "hira - Bioderma",             "Photoderm Güneş Kremi SPF50",     "Güneş Kremi", 1, null, "Gündüz Rutini"   },
            };

            using (var tx = conn.BeginTransaction())
            {
                foreach (var u in ornekler)
                {
                    using (var cmd = new SQLiteCommand(
                        "INSERT INTO Urunler (Marka, UrunAdi, UrunTipi, StokAdedi, PhDegeri, SonKullanmaTarihi, KullanimRutini) " +
                        "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@p1", u[0]);
                        cmd.Parameters.AddWithValue("@p2", u[1]);
                        cmd.Parameters.AddWithValue("@p3", u[2]);
                        cmd.Parameters.AddWithValue("@p4", u[3]);
                        cmd.Parameters.AddWithValue("@p5", u[4] ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@p6", DateTime.Now.AddYears(1).Date);
                        cmd.Parameters.AddWithValue("@p7", u[5]);
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
            }
        }

        // SADECE AKTİF OTURUMU AÇAN KİŞİNİN VERİLERİNİ LİSTELEYEN FONKSİYON
        void VerileriListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
                baglanti.Open();

                // Mevcut tablonun şemasını bozmamak için tüm verileri çekip,
                // Listeleme aşamasında C# tarafında kullanıcıya göre filtreleme yapıyoruz.
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Urunler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataTable filtrelenmisDt = dt.Clone();

                foreach (DataRow satir in dt.Rows)
                {
                    string markaDegeri = satir["Marka"].ToString();
                    // Eğer marka bilgisi giriş yapan kullanıcının ismiyle başlıyorsa listeye ekle
                    if (markaDegeri.StartsWith(kullaniciAdi + " - "))
                    {
                        DataRow yeniSatir = filtrelenmisDt.NewRow();
                        yeniSatir.ItemArray = satir.ItemArray;
                        // Ekranda "Damla - Maruderm" yerine sadece temiz bir şekilde "Maruderm" gözüksün
                        yeniSatir["Marka"] = markaDegeri.Replace(kullaniciAdi + " - ", "");
                        filtrelenmisDt.Rows.Add(yeniSatir);
                    }
                }

                dgwUrunler.DataSource = filtrelenmisDt;
                baglanti.Close();

                // Tablo kozmetini kodla mühürlüyoruz
                dgwUrunler.DefaultCellStyle.ForeColor = Color.White;
                dgwUrunler.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                dgwUrunler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 182, 193);
                dgwUrunler.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Veri listeleme hatası: " + hata.Message);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Şık Koyu Tema Giriş Paneli
            Form isimFormu = new Form()
            {
                Width = 350,
                Height = 180,
                Text = "Asistan Giriş Paneli",
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(32, 33, 36)
            };

            Label lblYazi = new Label() { Left = 25, Top = 20, Width = 300, Height = 40, ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), Text = "Cilt Bakım Asistanına Hoş Geldiniz!\nLütfen adınızı giriniz:" };
            TextBox txtGiris = new TextBox() { Left = 25, Top = 65, Width = 285, Font = new Font("Segoe UI", 11, FontStyle.Regular) };
            Button btnOnay = new Button() { Text = "Giriş Yap", Left = 210, Top = 100, Width = 100, Height = 30, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(255, 182, 193), ForeColor = Color.Black, Font = new Font("Segoe UI", 9, FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btnOnay.FlatAppearance.BorderSize = 0;

            isimFormu.Controls.Add(lblYazi); isimFormu.Controls.Add(txtGiris); isimFormu.Controls.Add(btnOnay);
            isimFormu.AcceptButton = btnOnay;

            if (isimFormu.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(txtGiris.Text.Trim()))
            {
                kullaniciAdi = txtGiris.Text.Trim();
            }

            this.Text = $"Cilt Bakımı Rutin ve Stok Asistanı - Oturum: {kullaniciAdi}";

            VerileriListele();

            // Siyah yazının inatla kalmasını önleyen mutlak beyaz komutları
            dgwUrunler.RowsDefaultCellStyle.ForeColor = Color.White;
            dgwUrunler.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgwUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        // AKILLI SÜZGEÇLİ ÜRÜN EKLEME
        private void btnEkle_Click(object sender, EventArgs e)
        {
            string secilenKullaniciCilt = cmbKullaniciCiltTipi.SelectedItem?.ToString();
            string secilenUrunCilt = cmbUrunCiltTipi.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(secilenKullaniciCilt) || string.IsNullOrEmpty(secilenUrunCilt))
            {
                MessageBox.Show("Lütfen analiz için hem Kullanıcı Cilt Tipini hem de Ürün Cilt Tipini seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Algoritmik Cilt Tipi Uyumluluk Denetimi
            if (secilenUrunCilt != "Tüm Ciltler" && secilenKullaniciCilt != secilenUrunCilt)
            {
                MessageBox.Show($"⚠️ UYUMSUZLUK TESPİT EDİLDİ!\n\nSizin Cilt Tipiniz: {secilenKullaniciCilt}\nÜrünün Uygun Olduğu Cilt: {secilenUrunCilt}\n\nBu ürün cildinizde iritasyon veya reaksiyona sebep olabileceği için sisteme eklenmesi engellendi.", "Akıllı Bariyer Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                baglanti.Open();
                // Verileri karıştırmamak için markanın başına kullanıcı etiketini saklıyoruz
                string saklanacakMarka = kullaniciAdi + " - " + txtMarka.Text;

                SQLiteCommand komut = new SQLiteCommand("INSERT INTO Urunler (Marka, UrunAdi, UrunTipi, StokAdedi, PhDegeri, SonKullanmaTarihi, KullanimRutini) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", baglanti);

                komut.Parameters.AddWithValue("@p1", saklanacakMarka);
                komut.Parameters.AddWithValue("@p2", txtUrunAdi.Text);
                komut.Parameters.AddWithValue("@p3", cmbUrunTipi.SelectedItem?.ToString() ?? "");
                komut.Parameters.AddWithValue("@p4", Convert.ToInt32(numStok.Value));

                if (string.IsNullOrEmpty(txtPh.Text))
                    komut.Parameters.AddWithValue("@p5", DBNull.Value);
                else
                    komut.Parameters.AddWithValue("@p5", Convert.ToDecimal(txtPh.Text.Replace('.', ',')));

                komut.Parameters.AddWithValue("@p6", dtpSkt.Value.Date);
                komut.Parameters.AddWithValue("@p7", cmbRutin.SelectedItem?.ToString() ?? "");

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show($"✅ Cilt tipinizle %100 uyumlu ürün {kullaniciAdi} hesabına başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işlemi sırasında hata oluştu: " + hata.Message);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgwUrunler.SelectedRows.Count > 0)
            {
                DialogResult onay = MessageBox.Show("Seçili ürünü stoktan tamamen silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (onay == DialogResult.Yes)
                {
                    try
                    {
                        int secilenId = Convert.ToInt32(dgwUrunler.SelectedRows[0].Cells["Id"].Value);
                        baglanti.Open();
                        SQLiteCommand komut = new SQLiteCommand("DELETE FROM Urunler WHERE Id=@id", baglanti);
                        komut.Parameters.AddWithValue("@id", secilenId);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Ürün stoktan silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VerileriListele();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Silme hatası: " + hata.Message);
                        if (baglanti.State == ConnectionState.Open) baglanti.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı tablonun en solundaki gri kutucuğa tıklayarak seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
                baglanti.Open();

                // Arama yaparken de sadece kişinin kendi adına kayıtlı ürünleri getiriyoruz
                SQLiteCommand komut = new SQLiteCommand("SELECT * FROM Urunler WHERE UrunAdi LIKE @ara AND Marka LIKE @kullanici", baglanti);
                komut.Parameters.AddWithValue("@ara", "%" + txtAra.Text + "%");
                komut.Parameters.AddWithValue("@kullanici", kullaniciAdi + " - %");

                SQLiteDataAdapter da = new SQLiteDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow satir in dt.Rows)
                {
                    satir["Marka"] = satir["Marka"].ToString().Replace(kullaniciAdi + " - ", "");
                }

                dgwUrunler.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception)
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        // KİŞİYE ÖZEL AKILLI RUTIN MOTORU
        private void btnRaporla_Click(object sender, EventArgs e)
        {
            if (dgwUrunler.Rows.Count > 0)
            {
                string sabahRutini = $"☀️ {kullaniciAdi.ToUpper()} - SABAH CİLT BAKIM SIRALAMANIZ:\n-------------------------------------\n";
                string aksamRutini = $"🌙 {kullaniciAdi.ToUpper()} - AKŞAM CİLT BAKIM SIRALAMANIZ:\n-------------------------------------\n";
                int sabahSira = 1, aksamSira = 1;

                string[] uygulamaSirasi = { "Temizleyici", "Tonik", "Serum", "Nemlendirici", "Güneş Kremi", "Maske", "Peeling" };

                foreach (var tip in uygulamaSirasi)
                {
                    foreach (DataGridViewRow satir in dgwUrunler.Rows)
                    {
                        if (satir.Cells["UrunTipi"].Value?.ToString() == tip)
                        {
                            string marka = satir.Cells["Marka"].Value?.ToString();
                            string ad = satir.Cells["UrunAdi"].Value?.ToString();
                            string rutin = satir.Cells["KullanimRutini"].Value?.ToString();

                            if (rutin == "Gündüz Rutini" || rutin == "İhtiyaç Halinde")
                            {
                                sabahRutini += $"{sabahSira}. Adım: [{tip}] {marka} - {ad}\n";
                                sabahSira++;
                            }
                            if (rutin == "Gece Rutini" || rutin == "İhtiyaç Halinde")
                            {
                                aksamRutini += $"{aksamSira}. Adım: [{tip}] {marka} - {ad}\n";
                                aksamSira++;
                            }
                        }
                    }
                }
                MessageBox.Show(sabahRutini + "\n\n" + aksamRutini, "Yazılım Asistanı - Kişiselleştirilmiş Akıllı Rutin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Sistemde {kullaniciAdi} adına kayıtlı rutin ürünü bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgwUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgwUrunler.Rows[e.RowIndex];
                txtMarka.Text = satir.Cells["Marka"].Value?.ToString();
                txtUrunAdi.Text = satir.Cells["UrunAdi"].Value?.ToString();
                cmbUrunTipi.SelectedItem = satir.Cells["UrunTipi"].Value?.ToString();
                numStok.Value = Convert.ToInt32(satir.Cells["StokAdedi"].Value);
                txtPh.Text = satir.Cells["PhDegeri"].Value?.ToString();

                if (satir.Cells["SonKullanmaTarihi"].Value != DBNull.Value && satir.Cells["SonKullanmaTarihi"].Value != null)
                    dtpSkt.Value = Convert.ToDateTime(satir.Cells["SonKullanmaTarihi"].Value);

                cmbRutin.SelectedItem = satir.Cells["KullanimRutini"].Value?.ToString();
            }
        }

        // TEK VE STABİL ÇALIŞAN GÜNCELLEME METODU
        private void DeğisiklikleriKaydet()
        {
            if (dgwUrunler.SelectedRows.Count > 0)
            {
                try
                {
                    int secilenId = Convert.ToInt32(dgwUrunler.SelectedRows[0].Cells["Id"].Value);
                    if (baglanti.State == ConnectionState.Open) baglanti.Close();

                    baglanti.Open();
                    SQLiteCommand komut = new SQLiteCommand("UPDATE Urunler SET Marka=@p1, UrunAdi=@p2, UrunTipi=@p3, StokAdedi=@p4, PhDegeri=@p5, SonKullanmaTarihi=@p6, KullanimRutini=@p7 WHERE Id=@id", baglanti);

                    komut.Parameters.AddWithValue("@p1", kullaniciAdi + " - " + txtMarka.Text);
                    komut.Parameters.AddWithValue("@p2", txtUrunAdi.Text);
                    komut.Parameters.AddWithValue("@p3", cmbUrunTipi.SelectedItem?.ToString() ?? "");
                    komut.Parameters.AddWithValue("@p4", Convert.ToInt32(numStok.Value));

                    if (string.IsNullOrEmpty(txtPh.Text))
                        komut.Parameters.AddWithValue("@p5", DBNull.Value);
                    else
                        komut.Parameters.AddWithValue("@p5", Convert.ToDecimal(txtPh.Text.Replace('.', ',')));

                    komut.Parameters.AddWithValue("@p6", dtpSkt.Value.Date);
                    komut.Parameters.AddWithValue("@p7", cmbRutin.SelectedItem?.ToString() ?? "");
                    komut.Parameters.AddWithValue("@id", secilenId);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Ürün bilgileri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VerileriListele();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Güncelleme hatası: " + hata.Message);
                    if (baglanti.State == ConnectionState.Open) baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz satırı tablonun en solundaki kutucuğa basarak komple seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string suAnkiSaat = DateTime.Now.ToString("HH:mm");
            if (suAnkiSaat == "09:00")
            {
                timer1.Stop();
                MessageBox.Show($"☀️ Günaydın {kullaniciAdi}! Sabah cilt bakımı rutini zamanı geldi.", "Cilt Bakım Hatırlatıcısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Start();
            }
            else if (suAnkiSaat == "21:30")
            {
                timer1.Stop();
                MessageBox.Show($"🌙 İyi akşamlar {kullaniciAdi}! Gece cilt bakımı rutini zamanı geldi.", "Cilt Bakım Hatırlatıcısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Start();
            }
        }

        // Çakışan buton olaylarını tek çatı altında güvenliğe alıyoruz
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DeğisiklikleriKaydet();
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            DeğisiklikleriKaydet();
        }
    }
}
