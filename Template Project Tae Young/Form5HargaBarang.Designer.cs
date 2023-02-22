namespace Template_Project_Tae_Young
{
    partial class Form5HargaBarang
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
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nilaiHargaBarang = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNamaBarang = new System.Windows.Forms.ComboBox();
            this.txtIDNamaBarang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNamaPerusahaan = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtIDPerusahaan = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtNPView = new System.Windows.Forms.TextBox();
            this.txtNBView = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHBView = new System.Windows.Forms.TextBox();
            this.txtIDView2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDView = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DataGridHargaBarang = new System.Windows.Forms.DataGridView();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nilaiHargaBarang)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridHargaBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(237, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "PT Tae Young Abadi Jaya   -   Harga Barang";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nilaiHargaBarang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbNamaBarang);
            this.groupBox1.Controls.Add(this.txtIDNamaBarang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbNamaPerusahaan);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.txtIDPerusahaan);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Location = new System.Drawing.Point(15, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 185);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CRUD";
            // 
            // nilaiHargaBarang
            // 
            this.nilaiHargaBarang.Location = new System.Drawing.Point(103, 110);
            this.nilaiHargaBarang.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nilaiHargaBarang.Name = "nilaiHargaBarang";
            this.nilaiHargaBarang.Size = new System.Drawing.Size(212, 20);
            this.nilaiHargaBarang.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Harga Barang";
            // 
            // cbNamaBarang
            // 
            this.cbNamaBarang.FormattingEnabled = true;
            this.cbNamaBarang.Location = new System.Drawing.Point(103, 71);
            this.cbNamaBarang.Name = "cbNamaBarang";
            this.cbNamaBarang.Size = new System.Drawing.Size(212, 21);
            this.cbNamaBarang.TabIndex = 41;
            this.cbNamaBarang.SelectedIndexChanged += new System.EventHandler(this.cbNamaBarang_SelectedIndexChanged);
            // 
            // txtIDNamaBarang
            // 
            this.txtIDNamaBarang.Location = new System.Drawing.Point(321, 71);
            this.txtIDNamaBarang.Name = "txtIDNamaBarang";
            this.txtIDNamaBarang.Size = new System.Drawing.Size(74, 20);
            this.txtIDNamaBarang.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Nama Barang";
            // 
            // cbNamaPerusahaan
            // 
            this.cbNamaPerusahaan.FormattingEnabled = true;
            this.cbNamaPerusahaan.Location = new System.Drawing.Point(103, 34);
            this.cbNamaPerusahaan.Name = "cbNamaPerusahaan";
            this.cbNamaPerusahaan.Size = new System.Drawing.Size(212, 21);
            this.cbNamaPerusahaan.TabIndex = 38;
            this.cbNamaPerusahaan.SelectedIndexChanged += new System.EventHandler(this.cbNamaPerusahaan_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 37;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtIDPerusahaan
            // 
            this.txtIDPerusahaan.Location = new System.Drawing.Point(321, 34);
            this.txtIDPerusahaan.Name = "txtIDPerusahaan";
            this.txtIDPerusahaan.Size = new System.Drawing.Size(74, 20);
            this.txtIDPerusahaan.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nama Perusahaan";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(340, 146);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 34;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.txtNPView);
            this.groupBox2.Controls.Add(this.txtNBView);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtHBView);
            this.groupBox2.Controls.Add(this.txtIDView2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtIDView);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(460, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 185);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(321, 146);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(74, 23);
            this.button8.TabIndex = 45;
            this.button8.Text = "Delete";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(235, 146);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 46;
            this.button9.Text = "Cancel";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // txtNPView
            // 
            this.txtNPView.Location = new System.Drawing.Point(104, 34);
            this.txtNPView.Name = "txtNPView";
            this.txtNPView.Size = new System.Drawing.Size(212, 20);
            this.txtNPView.TabIndex = 45;
            // 
            // txtNBView
            // 
            this.txtNBView.Location = new System.Drawing.Point(104, 71);
            this.txtNBView.Name = "txtNBView";
            this.txtNBView.Size = new System.Drawing.Size(212, 20);
            this.txtNBView.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Harga Barang";
            // 
            // txtHBView
            // 
            this.txtHBView.Location = new System.Drawing.Point(103, 107);
            this.txtHBView.Name = "txtHBView";
            this.txtHBView.Size = new System.Drawing.Size(212, 20);
            this.txtHBView.TabIndex = 42;
            // 
            // txtIDView2
            // 
            this.txtIDView2.Location = new System.Drawing.Point(321, 71);
            this.txtIDView2.Name = "txtIDView2";
            this.txtIDView2.Size = new System.Drawing.Size(74, 20);
            this.txtIDView2.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Nama Barang";
            // 
            // txtIDView
            // 
            this.txtIDView.Location = new System.Drawing.Point(321, 34);
            this.txtIDView.Name = "txtIDView";
            this.txtIDView.Size = new System.Drawing.Size(74, 20);
            this.txtIDView.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Nama Perusahaan";
            // 
            // DataGridHargaBarang
            // 
            this.DataGridHargaBarang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridHargaBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridHargaBarang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGridHargaBarang.Location = new System.Drawing.Point(0, 300);
            this.DataGridHargaBarang.Name = "DataGridHargaBarang";
            this.DataGridHargaBarang.Size = new System.Drawing.Size(886, 150);
            this.DataGridHargaBarang.TabIndex = 45;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(535, 262);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(101, 21);
            this.comboBox3.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(488, 265);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Search";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(642, 262);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(230, 20);
            this.textBox10.TabIndex = 47;
            // 
            // Form5HargaBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 450);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.DataGridHargaBarang);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Name = "Form5HargaBarang";
            this.Text = "Harga Barang";
            this.Load += new System.EventHandler(this.Form5HargaBarang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nilaiHargaBarang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridHargaBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNamaBarang;
        private System.Windows.Forms.TextBox txtIDNamaBarang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNamaPerusahaan;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtIDPerusahaan;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNPView;
        private System.Windows.Forms.TextBox txtNBView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHBView;
        private System.Windows.Forms.TextBox txtIDView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIDView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView DataGridHargaBarang;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.NumericUpDown nilaiHargaBarang;
    }
}