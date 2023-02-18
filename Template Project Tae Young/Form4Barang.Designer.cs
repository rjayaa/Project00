namespace Template_Project_Tae_Young
{
    partial class Form4Barang
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
            this.txtNamaBarang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtUpdate = new System.Windows.Forms.Button();
            this.txtInsert = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIDBarang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDelete = new System.Windows.Forms.Button();
            this.txtNamaBarang2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.DataGridBarang = new System.Windows.Forms.DataGridView();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(205, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "PT Tae Young Abadi Jaya   -   Barang";
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.Location = new System.Drawing.Point(84, 34);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.Size = new System.Drawing.Size(212, 20);
            this.txtNamaBarang.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nama Barang";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtNamaBarang);
            this.groupBox1.Controls.Add(this.txtUpdate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInsert);
            this.groupBox1.Location = new System.Drawing.Point(16, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 115);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CRUD";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(9, 77);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtUpdate
            // 
            this.txtUpdate.Location = new System.Drawing.Point(207, 75);
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(75, 23);
            this.txtUpdate.TabIndex = 35;
            this.txtUpdate.Text = "Update";
            this.txtUpdate.UseVisualStyleBackColor = true;
            this.txtUpdate.Click += new System.EventHandler(this.txtUpdate_Click);
            // 
            // txtInsert
            // 
            this.txtInsert.Location = new System.Drawing.Point(288, 75);
            this.txtInsert.Name = "txtInsert";
            this.txtInsert.Size = new System.Drawing.Size(75, 23);
            this.txtInsert.TabIndex = 34;
            this.txtInsert.Text = "Insert";
            this.txtInsert.UseVisualStyleBackColor = true;
            this.txtInsert.Click += new System.EventHandler(this.txtInsert_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIDBarang);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDelete);
            this.groupBox2.Controls.Add(this.txtNamaBarang2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(398, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 115);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // txtIDBarang
            // 
            this.txtIDBarang.Location = new System.Drawing.Point(285, 37);
            this.txtIDBarang.Name = "txtIDBarang";
            this.txtIDBarang.Size = new System.Drawing.Size(99, 20);
            this.txtIDBarang.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "ID Barang";
            // 
            // txtDelete
            // 
            this.txtDelete.Location = new System.Drawing.Point(285, 77);
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.Size = new System.Drawing.Size(99, 23);
            this.txtDelete.TabIndex = 36;
            this.txtDelete.Text = "Delete";
            this.txtDelete.UseVisualStyleBackColor = true;
            this.txtDelete.Click += new System.EventHandler(this.txtDelete_Click);
            // 
            // txtNamaBarang2
            // 
            this.txtNamaBarang2.Location = new System.Drawing.Point(84, 38);
            this.txtNamaBarang2.Name = "txtNamaBarang2";
            this.txtNamaBarang2.Size = new System.Drawing.Size(195, 20);
            this.txtNamaBarang2.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nama Barang";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(204, 77);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 38;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // DataGridBarang
            // 
            this.DataGridBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridBarang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridBarang.Location = new System.Drawing.Point(12, 242);
            this.DataGridBarang.Name = "DataGridBarang";
            this.DataGridBarang.Size = new System.Drawing.Size(776, 154);
            this.DataGridBarang.TabIndex = 22;
            this.DataGridBarang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridBarang_CellClick);
            
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Nama Barang"});
            this.comboBox.Location = new System.Drawing.Point(451, 197);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(101, 21);
            this.comboBox.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(404, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(558, 197);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 20);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Form4Barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 408);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.DataGridBarang);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form4Barang";
            this.Text = "Barang";
            this.Load += new System.EventHandler(this.Form4Barang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamaBarang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIDBarang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaBarang2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button txtUpdate;
        private System.Windows.Forms.Button txtInsert;
        private System.Windows.Forms.Button txtDelete;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView DataGridBarang;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearch;
    }
}