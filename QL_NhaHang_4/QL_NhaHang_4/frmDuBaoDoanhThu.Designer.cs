namespace QL_NhaHang_4
{
    partial class frmDuBaoDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chartDuBao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridDuLieu = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.gridcChuanHoa = new System.Windows.Forms.DataGridView();
            this.STT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDuBao)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDuLieu)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcChuanHoa)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.chartDuBao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 766);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(843, 47);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Biểu đồ chênh lệch giữa dự báo và thực tế";
            // 
            // chartDuBao
            // 
            this.chartDuBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartDuBao.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDuBao.Legends.Add(legend1);
            this.chartDuBao.Location = new System.Drawing.Point(0, 50);
            this.chartDuBao.Margin = new System.Windows.Forms.Padding(0);
            this.chartDuBao.Name = "chartDuBao";
            series1.BackSecondaryColor = System.Drawing.SystemColors.ActiveCaptionText;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelBorderColor = System.Drawing.Color.White;
            series1.LabelBorderWidth = 0;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.MarkerSize = 6;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Thực tế";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsValueShownAsLabel = true;
            series2.IsXValueIndexed = true;
            series2.LabelBorderWidth = 0;
            series2.Legend = "Legend1";
            series2.MarkerSize = 6;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series2.Name = "Dự báo";
            this.chartDuBao.Series.Add(series1);
            this.chartDuBao.Series.Add(series2);
            this.chartDuBao.Size = new System.Drawing.Size(803, 716);
            this.chartDuBao.TabIndex = 0;
            this.chartDuBao.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(843, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(458, 766);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridDuLieu);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2.Controls.Add(this.gridcChuanHoa);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Size = new System.Drawing.Size(458, 766);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridDuLieu
            // 
            this.gridDuLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDuLieu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridDuLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDuLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.TongTien});
            this.gridDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDuLieu.Location = new System.Drawing.Point(0, 47);
            this.gridDuLieu.Name = "gridDuLieu";
            this.gridDuLieu.RowTemplate.Height = 24;
            this.gridDuLieu.Size = new System.Drawing.Size(458, 348);
            this.gridDuLieu.TabIndex = 3;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(458, 47);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dữ liệu hóa đơn trong 30 ngày";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtKetQua);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 316);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(458, 51);
            this.panel6.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(212, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kết quả doanh số hôm nay";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKetQua.BackColor = System.Drawing.SystemColors.Info;
            this.txtKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetQua.ForeColor = System.Drawing.Color.Red;
            this.txtKetQua.Location = new System.Drawing.Point(6, 11);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.Size = new System.Drawing.Size(200, 30);
            this.txtKetQua.TabIndex = 0;
            this.txtKetQua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gridcChuanHoa
            // 
            this.gridcChuanHoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridcChuanHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridcChuanHoa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridcChuanHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridcChuanHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT2,
            this.TongTien2});
            this.gridcChuanHoa.Location = new System.Drawing.Point(0, 47);
            this.gridcChuanHoa.Margin = new System.Windows.Forms.Padding(0);
            this.gridcChuanHoa.Name = "gridcChuanHoa";
            this.gridcChuanHoa.RowTemplate.Height = 24;
            this.gridcChuanHoa.Size = new System.Drawing.Size(458, 266);
            this.gridcChuanHoa.TabIndex = 4;
            // 
            // STT2
            // 
            this.STT2.HeaderText = "STT";
            this.STT2.Name = "STT2";
            // 
            // TongTien2
            // 
            this.TongTien2.HeaderText = "Tổng Tiền";
            this.TongTien2.Name = "TongTien2";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.btnTrain);
            this.panel5.Controls.Add(this.btnKiemTra);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(458, 47);
            this.panel5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "Dữ liệu chuẩn hóa";
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrain.BackColor = System.Drawing.Color.Blue;
            this.btnTrain.FlatAppearance.BorderSize = 0;
            this.btnTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrain.ForeColor = System.Drawing.Color.White;
            this.btnTrain.Location = new System.Drawing.Point(239, 7);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(111, 31);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Chuẩn hóa";
            this.btnTrain.UseVisualStyleBackColor = false;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKiemTra.BackColor = System.Drawing.Color.Crimson;
            this.btnKiemTra.FlatAppearance.BorderSize = 0;
            this.btnKiemTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKiemTra.Location = new System.Drawing.Point(365, 7);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(85, 31);
            this.btnKiemTra.TabIndex = 0;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // frmDuBaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1301, 766);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDuBaoDoanhThu";
            this.Text = "Dự báo doanh thu";
            this.Load += new System.EventHandler(this.frmDuBaoDoanhThu_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDuBao)).EndInit();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDuLieu)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcChuanHoa)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDuBao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridDuLieu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gridcChuanHoa;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}