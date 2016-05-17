namespace MySerialPort
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BIN,
            this.OCT,
            this.HEX,
            this.CHAR,
            this.discrip});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(648, 495);
            this.dataGridView1.TabIndex = 0;
            // 
            // BIN
            // 
            this.BIN.HeaderText = "二进制";
            this.BIN.Name = "BIN";
            this.BIN.ReadOnly = true;
            // 
            // OCT
            // 
            this.OCT.HeaderText = "十进制";
            this.OCT.Name = "OCT";
            this.OCT.ReadOnly = true;
            // 
            // HEX
            // 
            this.HEX.HeaderText = "十六进制";
            this.HEX.Name = "HEX";
            this.HEX.ReadOnly = true;
            // 
            // CHAR
            // 
            this.CHAR.HeaderText = "显示字符";
            this.CHAR.Name = "CHAR";
            this.CHAR.ReadOnly = true;
            // 
            // discrip
            // 
            this.discrip.HeaderText = "描述";
            this.discrip.Name = "discrip";
            this.discrip.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 495);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "ASCII表";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn discrip;
    }
}