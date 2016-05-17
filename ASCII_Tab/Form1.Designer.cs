namespace ASCII_Tab
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Discrip});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(635, 482);
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
            this.CHAR.HeaderText = "可见字符";
            this.CHAR.Name = "CHAR";
            this.CHAR.ReadOnly = true;
            // 
            // Discrip
            // 
            this.Discrip.HeaderText = "描述";
            this.Discrip.Name = "Discrip";
            this.Discrip.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 482);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discrip;

    }
}

