namespace CiltBakimStokAsistani
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbUrunCiltTipi = new System.Windows.Forms.ComboBox();
            this.cmbKullaniciCiltTipi = new System.Windows.Forms.ComboBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.cmbRutin = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpSkt = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numStok = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUrunTipi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgwUrunler = new System.Windows.Forms.DataGridView();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnRaporla = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStok)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbUrunCiltTipi);
            this.groupBox1.Controls.Add(this.cmbKullaniciCiltTipi);
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.cmbRutin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpSkt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numStok);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbUrunTipi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUrunAdi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMarka);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(339, 627);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yeni Ürün / Güncelleme Paneli";
            // 
            // cmbUrunCiltTipi
            // 
            this.cmbUrunCiltTipi.FormattingEnabled = true;
            this.cmbUrunCiltTipi.Items.AddRange(new object[] {
            "Kuru ",
            "Yağlı",
            "Karma",
            "Hassas",
            "Tüm Ciltler"});
            this.cmbUrunCiltTipi.Location = new System.Drawing.Point(185, 461);
            this.cmbUrunCiltTipi.Name = "cmbUrunCiltTipi";
            this.cmbUrunCiltTipi.Size = new System.Drawing.Size(121, 31);
            this.cmbUrunCiltTipi.TabIndex = 17;
            // 
            // cmbKullaniciCiltTipi
            // 
            this.cmbKullaniciCiltTipi.FormattingEnabled = true;
            this.cmbKullaniciCiltTipi.Items.AddRange(new object[] {
            "Kuru",
            "Yağlı",
            "Karma",
            "Hassas"});
            this.cmbKullaniciCiltTipi.Location = new System.Drawing.Point(185, 412);
            this.cmbKullaniciCiltTipi.Name = "cmbKullaniciCiltTipi";
            this.cmbKullaniciCiltTipi.Size = new System.Drawing.Size(121, 31);
            this.cmbKullaniciCiltTipi.TabIndex = 16;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.LightPink;
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Location = new System.Drawing.Point(9, 552);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(226, 33);
            this.btnGuncelle.TabIndex = 15;
            this.btnGuncelle.Text = "Değişiklikleri Kaydet";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click_1);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.LightPink;
            this.btnEkle.FlatAppearance.BorderSize = 0;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Location = new System.Drawing.Point(12, 511);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(125, 33);
            this.btnEkle.TabIndex = 14;
            this.btnEkle.Text = "Ürünü Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cmbRutin
            // 
            this.cmbRutin.FormattingEnabled = true;
            this.cmbRutin.Items.AddRange(new object[] {
            "Gündüz Rutini",
            "Gece Rutini",
            "Haftalık Bakım",
            "İhtiyaç Halinde"});
            this.cmbRutin.Location = new System.Drawing.Point(156, 288);
            this.cmbRutin.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRutin.Name = "cmbRutin";
            this.cmbRutin.Size = new System.Drawing.Size(150, 31);
            this.cmbRutin.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 288);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Kullanım Rutini:";
            // 
            // dtpSkt
            // 
            this.dtpSkt.Location = new System.Drawing.Point(182, 335);
            this.dtpSkt.Margin = new System.Windows.Forms.Padding(4);
            this.dtpSkt.Name = "dtpSkt";
            this.dtpSkt.Size = new System.Drawing.Size(136, 30);
            this.dtpSkt.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 335);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Son Kullanma Tarihi:";
            // 
            // txtPh
            // 
            this.txtPh.Location = new System.Drawing.Point(114, 231);
            this.txtPh.Margin = new System.Windows.Forms.Padding(4);
            this.txtPh.Name = "txtPh";
            this.txtPh.Size = new System.Drawing.Size(149, 30);
            this.txtPh.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "pH Değeri:";
            // 
            // numStok
            // 
            this.numStok.Location = new System.Drawing.Point(114, 188);
            this.numStok.Margin = new System.Windows.Forms.Padding(4);
            this.numStok.Name = "numStok";
            this.numStok.Size = new System.Drawing.Size(150, 30);
            this.numStok.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stok Adedi:";
            // 
            // cmbUrunTipi
            // 
            this.cmbUrunTipi.FormattingEnabled = true;
            this.cmbUrunTipi.Items.AddRange(new object[] {
            "Temizleyici",
            "Tonik",
            "Serum",
            "Nemlendirici",
            "Güneş Kremi",
            "Maske",
            "Peeling"});
            this.cmbUrunTipi.Location = new System.Drawing.Point(114, 141);
            this.cmbUrunTipi.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUrunTipi.Name = "cmbUrunTipi";
            this.cmbUrunTipi.Size = new System.Drawing.Size(150, 31);
            this.cmbUrunTipi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ürün Tipi:";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.AutoCompleteCustomSource.AddRange(new string[] {
            "Niacinamide %10 Serum",
            "AHA %10 + BHA %2 Peeling Serum",
            "Hyaluronic Acid %2 + B3 Serum",
            "Salicylic Acid %2 Gözenek Sıkılaştırıcı Tonik",
            "Glycolic Acid %7 Tonik",
            "Caffeine Solution %5 + EGCG Göz Altı Serumu",
            "Vitamin C %15 Aydınlatıcı Serum",
            "Centella Asiatica Sakinleştirici Krem",
            "Ceramide Bariyer Onarıcı Nemlendirici",
            "Hydrating Cleanser Hassas Temizleme Jeli",
            "Retinol %0.5 Yaşlanma Karşıtı Serum",
            "Arbutin %2 Leke Karşıtı Serum",
            "Azelaic Acid %10 Aydınlatıcı Jel Krem",
            "Mineral Sunscreen SPF 50+ Güneş Kremi",
            "BHA Siyah Nokta Karşıtı Temizleyici Tonik"});
            this.txtUrunAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUrunAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUrunAdi.Location = new System.Drawing.Point(114, 96);
            this.txtUrunAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(149, 30);
            this.txtUrunAdi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün Adı:";
            // 
            // txtMarka
            // 
            this.txtMarka.AccessibleName = "";
            this.txtMarka.AutoCompleteCustomSource.AddRange(new string[] {
            "The Purest Solutions",
            "Maruderm",
            "La Roche-Posay",
            "The Ordinary",
            "CeraVe",
            "Anua",
            "Beauty of Joseon"});
            this.txtMarka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMarka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMarka.Location = new System.Drawing.Point(114, 55);
            this.txtMarka.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(149, 30);
            this.txtMarka.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marka:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Controls.Add(this.txtAra);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(350, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(635, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ürün Arama ve Filtreleme ";
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(172, 34);
            this.txtAra.Margin = new System.Windows.Forms.Padding(4);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(284, 30);
            this.txtAra.TabIndex = 1;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(21, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ürün Adı ile Ara:";
            // 
            // dgwUrunler
            // 
            this.dgwUrunler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwUrunler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgwUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwUrunler.Location = new System.Drawing.Point(350, 115);
            this.dgwUrunler.Margin = new System.Windows.Forms.Padding(4);
            this.dgwUrunler.Name = "dgwUrunler";
            this.dgwUrunler.RowHeadersWidth = 51;
            this.dgwUrunler.RowTemplate.Height = 24;
            this.dgwUrunler.Size = new System.Drawing.Size(637, 421);
            this.dgwUrunler.TabIndex = 2;
            this.dgwUrunler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwUrunler_CellClick);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.LightPink;
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Location = new System.Drawing.Point(771, 597);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(171, 33);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Seçili Ürünü Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnRaporla
            // 
            this.btnRaporla.BackColor = System.Drawing.Color.LightPink;
            this.btnRaporla.FlatAppearance.BorderSize = 0;
            this.btnRaporla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporla.Location = new System.Drawing.Point(375, 597);
            this.btnRaporla.Margin = new System.Windows.Forms.Padding(4);
            this.btnRaporla.Name = "btnRaporla";
            this.btnRaporla.Size = new System.Drawing.Size(289, 33);
            this.btnRaporla.TabIndex = 4;
            this.btnRaporla.Text = "Günlük Akıllı Rutinimi Hazırla\r\n\r\n";
            this.btnRaporla.UseVisualStyleBackColor = false;
            this.btnRaporla.Click += new System.EventHandler(this.btnRaporla_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.label9.Location = new System.Drawing.Point(15, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "Cilt Tipinizi Seçin";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.label10.Location = new System.Drawing.Point(15, 464);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "Ürün Tipini Seçin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1000, 647);
            this.Controls.Add(this.btnRaporla);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.dgwUrunler);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Cilt Bakımı Rutin ve Stok Asistanı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStok)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUrunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarka;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numStok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUrunTipi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpSkt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPh;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.ComboBox cmbRutin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgwUrunler;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnRaporla;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbUrunCiltTipi;
        private System.Windows.Forms.ComboBox cmbKullaniciCiltTipi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

