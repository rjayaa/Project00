namespace Apps_CURD
{
    partial class Form4InsertBarang
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
            this.BtnExit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.txtID1 = new System.Windows.Forms.TextBox();
            this.txtNB1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DataGridBarang1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBarang1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(819, 12);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 65;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(581, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Pt Tae Young Abadi Jaya  |   Tabel Insert Barang";
            // 
            // txtNB
            // 
            this.txtNB.Location = new System.Drawing.Point(137, 57);
            this.txtNB.Name = "txtNB";
            this.txtNB.Size = new System.Drawing.Size(209, 20);
            this.txtNB.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Nama Barang";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "ID Barang";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(137, 26);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(60, 20);
            this.txtID.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnClear);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.txtNB);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(25, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 145);
            this.panel1.TabIndex = 66;
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(157, 106);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 47;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(238, 106);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 46;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(271, 106);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdate.TabIndex = 45;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Insert";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.BtnDelete);
            this.panel2.Controls.Add(this.BtnUpdate);
            this.panel2.Controls.Add(this.txtID1);
            this.panel2.Controls.Add(this.txtNB1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(482, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 145);
            this.panel2.TabIndex = 66;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(109, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(190, 106);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 46;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // txtID1
            // 
            this.txtID1.Location = new System.Drawing.Point(137, 26);
            this.txtID1.Name = "txtID1";
            this.txtID1.Size = new System.Drawing.Size(60, 20);
            this.txtID1.TabIndex = 44;
            // 
            // txtNB1
            // 
            this.txtNB1.Location = new System.Drawing.Point(137, 57);
            this.txtNB1.Name = "txtNB1";
            this.txtNB1.Size = new System.Drawing.Size(209, 20);
            this.txtNB1.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "ID Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Nama Barang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Update";
            // 
            // DataGridBarang1
            // 
            this.DataGridBarang1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridBarang1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridBarang1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGridBarang1.Location = new System.Drawing.Point(0, 241);
            this.DataGridBarang1.Name = "DataGridBarang1";
            this.DataGridBarang1.Size = new System.Drawing.Size(909, 150);
            this.DataGridBarang1.TabIndex = 68;
            // 
            // Form4InsertBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 391);
            this.Controls.Add(this.DataGridBarang1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.label7);
            this.Enabled = false;
            this.Name = "Form4InsertBarang";
            this.Text = "Form4InsertBarang";
            this.Load += new System.EventHandler(this.Form4InsertBarang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBarang1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtID1;
        private System.Windows.Forms.TextBox txtNB1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.DataGridView DataGridBarang1;
        private System.Windows.Forms.Button button1;
    }
}