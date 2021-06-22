using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QL_NhaHang_4
{
    public partial class frmQuanLiDoanhThu : Form
    {
        int PageSize = 27;
        private DAO_DoanhThu DoanhThu;
        public frmQuanLiDoanhThu()
        {
            InitializeComponent();
            DoanhThu = new DAO_DoanhThu();
        }
        public class BieuDoDoanhThu
        {
            public int thang;
            public decimal giatri;
            public BieuDoDoanhThu(int thang, decimal giatri)
            {
                this.thang = thang;
                this.giatri = giatri;
            }
        }
        public class BieuDo
        {
            public int thang;
            public decimal giatri;
            public BieuDo(int thang, decimal giatri)
            {
                this.thang = thang;
                this.giatri = giatri;
            }
        }
        private void btnLocDoanhThu_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            loadDoanhThuThang(nam);
            loadTongLuongThang(nam);
        }
        public void loadDoanhThuThang(int nam)
        {
            DataTable dt = new DataTable();
            chartDoanThuThang.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartDoanThuThang.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            dt = DoanhThu.loadDoanhThuNam(nam);
            List<BieuDoDoanhThu> list = new List<BieuDoDoanhThu>();
            for (int i = 1; i <= 12; i++)
            {
                int dem = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i == int.Parse(dt.Rows[j][0].ToString()))
                    {
                        int thang = int.Parse(dt.Rows[j][0].ToString());
                        decimal giaTri = decimal.Parse(dt.Rows[j][1].ToString());
                        BieuDoDoanhThu bieuDo = new BieuDoDoanhThu(thang, giaTri);
                        list.Add(bieuDo);
                        dem++;
                    }
                }
                if (dem == 0)
                {
                    BieuDoDoanhThu bieuDo = new BieuDoDoanhThu(i, 0);
                    list.Add(bieuDo);
                }
            }
            int[] x = new int[12];
            decimal[] y = new decimal[12];
            for (int i = 0; i < 12; i++)
            {
                x[i] = list[i].thang;
                y[i] = list[i].giatri;
            }
            chartDoanThuThang.Series[0].Points.DataBindXY(x, y);
        }
        public void loadTongLuongThang(int nam)
        {
            DataTable dt = new DataTable();
            List<BieuDo> list = new List<BieuDo>();
            chartLuongNV.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartLuongNV.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            dt = DoanhThu.layDSTongLuongThang(nam);
            for (int i = 1; i <= 12; i++)
            {
                int dem = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i == int.Parse(dt.Rows[j][0].ToString()))
                    {
                        int thang = int.Parse(dt.Rows[j][0].ToString());
                        decimal giaTri = decimal.Parse(dt.Rows[j][1].ToString());
                        BieuDo bieuDo = new BieuDo(thang, giaTri);
                        list.Add(bieuDo);
                        dem++;
                    }
                }
                if (dem == 0)
                {
                    BieuDo bieuDo = new BieuDo(i, 0);
                    list.Add(bieuDo);
                }
            }
            chartLuongNV.DataSource = list;
            int[] x = new int[12];
            decimal[] y = new decimal[12];
            for (int i = 0; i < 12; i++)
            {
                x[i] = list[i].thang;
                y[i] = list[i].giatri;
            }
            chartLuongNV.Series[0].Points.DataBindXY(x, y);
        }

        private void frmQuanLiDoanhThu_Load(object sender, EventArgs e)
        {
            cboNam.SelectedIndex = 0;
            cboThangDoanhThu.SelectedIndex = 0;
            cboNamDoanhThu.SelectedIndex = 0;
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            loadDoanhThuThang(nam);
            loadTongLuongThang(nam);
            DateTime dt = txtNgay.Value;
            int ngay = dt.Day;
            int thang = dt.Month;
            int nam1 = dt.Year;
            loadData();
        }
        public void loadGridTienBan(int ngay, int thang, int nam)
        {
            DataTable dt = DoanhThu.loadHoaDonTheoNgay(ngay, thang, nam);
            gridHoaDon.DataSource = dt;
            gridHoaDon.Columns[0].HeaderText = "Mã HD";
            gridHoaDon.Columns[1].HeaderText = "Mã bàn";
            gridHoaDon.Columns[2].HeaderText = "Ngày nhập";
            gridHoaDon.Columns[3].HeaderText = "Ngày xuất";
            gridHoaDon.Columns[4].HeaderText = "Tình trạng";
            gridHoaDon.Columns[5].HeaderText = "Tổng tiền";
        }

        private void btnLocNgay_Click(object sender, EventArgs e)
        {
            DateTime dt = txtNgay.Value;
            int ngay = dt.Day;
            int thang = dt.Month;
            int nam1 = dt.Year;
            int thang1 = int.Parse(cboThangDoanhThu.SelectedItem.ToString());
            int nam2 = int.Parse(cboNamDoanhThu.SelectedItem.ToString());
            loadData();
            int tienBan = DoanhThu.layDoanhThuNgay(ngay, thang, nam1);
            int tienBanThang = DoanhThu.layDoanhThuThang(thang1, nam2);
            int tienBanNam = DoanhThu.layDoanhThuNam(nam2);
            txtHDNgay.Text = string.Format("{0:0,0 VNĐ}", tienBan);
            txtHDThang.Text = string.Format("{0:0,0 VNĐ}", tienBanThang);
            txtHDNam.Text = string.Format("{0:0,0 VNĐ}", tienBanNam);
        }
        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            //Sử dụng đối tượng List để chứa danh sách các trang
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;
            int pagerSpan = 3;

            //Tính toán để hiển thị các trang.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1; endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 3;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add nút trang đầu.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "Trang đầu", Value = "1" });
            }

            //Add nút < 1)
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++) { pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage }); } //Add nút >>.
            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add nút Trang cuối.
            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = "Trang cuối", Value = pageCount.ToString() });
            }

            //Xóa các nút trên trang.
            pnlDieuHuong.Controls.Clear();

            //Lặp và add các Buttons cho trang.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(110 * count, 5);
                btnPage.Size = new System.Drawing.Size(100, 30);
                btnPage.FlatStyle = FlatStyle.Flat;
                btnPage.FlatAppearance.BorderSize = 0;
                btnPage.ForeColor = System.Drawing.Color.White;
                btnPage.BackColor = System.Drawing.Color.Indigo;
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                pnlDieuHuong.Controls.Add(btnPage);
                count++;
            }
        }
        //Viết sự kiện khi kích trên nút phân trang
        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            DateTime dt = txtNgay.Value;
            int ngay = dt.Day;
            int thang = dt.Month;
            int nam1 = dt.Year;
            DTO_PhanTrang phanTrang = DoanhThu.loadHoaDonTheoNgayPhanTrang(ngay,thang,nam1,int.Parse(btnPager.Name), PageSize);
            gridHoaDon.DataSource = phanTrang.dt;
            HienThiThanhDieuHuong(phanTrang.rowCount, int.Parse(btnPager.Name));
        }
        public void loadData()
        {
            DateTime dt = txtNgay.Value;
            int ngay = dt.Day;
            int thang = dt.Month;
            int nam1 = dt.Year;
            DTO_PhanTrang phanTrang = DoanhThu.loadHoaDonTheoNgayPhanTrang(ngay,thang,nam1,1, PageSize);
            gridHoaDon.DataSource = phanTrang.dt;
            HienThiThanhDieuHuong(phanTrang.rowCount, 1);
        }
        //Tạo class Page để lưu trữ các thuộc tính của Page
        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }
    }
}
