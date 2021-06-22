using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace QL_NhaHang_4
{
    public partial class frmDuBaoDoanhThu : Form
    {
        private DTO_NguoiDung nguoiDung;
        private DAO_DoanhThu doanhThu;
        private List<DoanhThu> lst;
        private List<DoanhThu> lst2;
        public static double wa1, wb1, wc1, wd1, wa2, wb2, wc2, wd2, w13, w23;
        public static double A, B, C, D, Z;
        public static double ng1, ng2, ng3;
        public static double n = 1;
        private double max, min;
        public frmDuBaoDoanhThu(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            doanhThu = new DAO_DoanhThu();
            lst = new List<DoanhThu>();
            lst2 = new List<DoanhThu>();
            khoiTao();
            randomTrongSo();
        }
        public void loadDuBao()
        {
            DataTable dt = new DataTable();
            dt = doanhThu.layTop5DuBaoDT();
            List<DoanhThu> doanhThus = new List<DoanhThu>();
            List<DoanhThu> doanhThus2 = new List<DoanhThu>();
            for (int i = lst.Count -5 ; i < lst.Count; i++)
            {
                doanhThus2.Add(lst[i]);
            }
            foreach (DataRow row in dt.Rows)
            {
                DateTime ngayNhap = DateTime.Parse(row["ngayXuat"].ToString());
                double tongTien = double.Parse(row["tongTien"].ToString());
                DoanhThu doanhThu = new DoanhThu(ngayNhap, tongTien);
                doanhThus.Add(doanhThu);
            }
            doanhThus.Reverse();
            DateTime[] x = new DateTime[5];
            double[] y = new double[5];
            double[] z = new double[5];
            for (int i = 0; i < 5; i++)
            {
                x[i] = doanhThus[i].Ngay.Date;
                y[i] = doanhThus[i].TongTien;
                z[i] = doanhThus2[i].TongTien;
            }
            chartDuBao.Series[0].Points.DataBindXY(x, z);
            chartDuBao.Series[1].Points.DataBindXY(x, y);
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (gridcChuanHoa.Rows.Count == 1)
            {
                MessageBox.Show("Bạn phải chuẩn hóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < 27; i++)
            {
                docDauVao(i);
                train();
            }
            docFile();
            double kqdudoan = TraKQ(DuDoan(A, B, C, D), max, min);
            DateTime ngayThem = DateTime.Now;
            doanhThu.themDoanhThuDuBao(ngayThem, decimal.Parse(kqdudoan.ToString()), nguoiDung.IdNguoidung);
            txtKetQua.Text = string.Format("{0:0,0 VNĐ}", kqdudoan);
        }

        public static double ChuanHoaDuLieu(double x, double max, double min)
        {
            double kq = (x - min) / (max - min);
            Math.Round(kq, 6);
            return kq;
        }
        public static double TraKQ(double x, double max, double min)
        {
            double kq = x * (max - min) + min;
            Math.Round(kq, 6);
            return kq;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            loadDataChuanHoa();
        }

        public static double Sigmoid(double value)
        {
            return (float)(1.0 / (1.0 + Math.Pow(Math.E, -value)));
        }


        public static double Timt(double a, double b, double wa1, double wb1, double c, double d, double wc1, double wd1)
        {
            double t = (a * wa1) + (b * wb1) + (c * wc1) + (d * wd1) + n;
            Math.Round(t, 6);
            return t;
        }

        public static double DauRaNoron(double a, double b, double wa1, double wb1, double c, double d, double wc1, double wd1)
        {
            double t = Timt(a, b, wa1, wb1, c, d, wc1, wd1);
            Math.Round(t, 6);
            double Y = Sigmoid(t);
            Math.Round(Y, 6);
            return Y;
        }

        public static double Timt2(double a, double b, double wa1, double wb1)
        {
            double t = (a * wa1) + (b * wb1) + n;
            Math.Round(t, 6);
            return t;
        }

        public static double DauRaNoron2(double a, double b, double wa1, double wb1)
        {
            double t = Timt2(a, b, wa1, wb1);
            Math.Round(t, 6);
            double Y = Sigmoid(t);
            Math.Round(Y, 6);
            return Y;
        }
        public static double derivative_Sigmoid(double value)
        {
            return Math.Round((double)(Math.Pow(Math.E, value) / (Math.Pow(1 + Math.Pow(Math.E, value), 2))), 6);
        }

        public static double TinhTrongSo(double a, double w, double n, double ng, double t)
        {
            return Math.Round((double)(w + n * ng * derivative_Sigmoid(t) * a), 6);
        }

        public static void randomTrongSo()
        {
            Random r = new Random();
            wa1 = r.NextDouble();
            wb1 = r.NextDouble();
            wc1 = r.NextDouble();
            wd1 = r.NextDouble();
            wa2 = r.NextDouble();
            wb2 = r.NextDouble();
            wc2 = r.NextDouble();
            wd2 = r.NextDouble();
            w13 = r.NextDouble();
            w23 = r.NextDouble();
            StreamWriter write = new StreamWriter("randtrongso.txt", false);
            write.WriteLine(Math.Round(wa1, 6).ToString());
            write.WriteLine(Math.Round(wb1, 6).ToString());
            write.WriteLine(Math.Round(wc1, 6).ToString());
            write.WriteLine(Math.Round(wd1, 6).ToString());
            write.WriteLine(Math.Round(wa2, 6).ToString());
            write.WriteLine(Math.Round(wb2, 6).ToString());
            write.WriteLine(Math.Round(wc2, 6).ToString());
            write.WriteLine(Math.Round(wd2, 6).ToString());
            write.WriteLine(Math.Round(w13, 6).ToString());
            write.WriteLine(Math.Round(w23, 6).ToString());
            write.Close();
        }
        public static void XuatModel()
        {
            StreamWriter write = new StreamWriter("ngoc.txt", false);
            write.WriteLine(Math.Round(wa1, 6).ToString());
            write.WriteLine(Math.Round(wb1, 6).ToString());
            write.WriteLine(Math.Round(wc1, 6).ToString());
            write.WriteLine(Math.Round(wd1, 6).ToString());
            write.WriteLine(Math.Round(wa2, 6).ToString());
            write.WriteLine(Math.Round(wb2, 6).ToString());
            write.WriteLine(Math.Round(wc2, 6).ToString());
            write.WriteLine(Math.Round(wd2, 6).ToString());
            write.WriteLine(Math.Round(w13, 6).ToString());
            write.WriteLine(Math.Round(w23, 6).ToString());
            write.Close();
        }

        public static void docFile()
        {
            StreamReader read = new StreamReader("ngoc.txt");
            wa1 = Math.Round(double.Parse(read.ReadLine()), 6);
            wb1 = Math.Round(double.Parse(read.ReadLine()), 6);
            wc1 = Math.Round(double.Parse(read.ReadLine()), 6);
            wd1 = Math.Round(double.Parse(read.ReadLine()), 6);
            wa2 = Math.Round(double.Parse(read.ReadLine()), 6);
            wb2 = Math.Round(double.Parse(read.ReadLine()), 6);
            wc2 = Math.Round(double.Parse(read.ReadLine()), 6);
            wd2 = Math.Round(double.Parse(read.ReadLine()), 6);
            w13 = Math.Round(double.Parse(read.ReadLine()), 6);
            w23 = Math.Round(double.Parse(read.ReadLine()), 6);
            read.Close();
        }
        public void docDauVao(int j)
        {
            for (int i = j; i <= j + 4; i++)
            {
                if (i == j)
                {
                    A = double.Parse(lst2[i].TongTien.ToString());
                }
                if (i == j + 1)
                {
                    B = double.Parse(lst2[i].TongTien.ToString());
                }
                if (i == j + 2)
                {
                    C = double.Parse(lst2[i].TongTien.ToString());
                }
                if (i == j + 3)
                {
                    D = double.Parse(lst2[i].TongTien.ToString());
                }
                if (i == j + 4)
                {
                    Z = double.Parse(lst2[i].TongTien.ToString());
                }
            }
        }
        public static void train()
        {
            double t1 = Timt(A, B, wa1, wb1, C, D, wc1, wd1);
            Math.Round(t1, 6);
            double bien1 = DauRaNoron(A, B, wa1, wb1, C, D, wc1, wd1);
            Math.Round(bien1, 6);
            double t2 = Timt(A, B, wa2, wb2, C, D, wc2, wd2);
            Math.Round(t2, 6);
            double bien2 = DauRaNoron(A, B, wa2, wb2, C, D, wc2, wd2);
            Math.Round(bien2, 6);
            double t3 = Timt2(bien1, bien2, w13, w23);
            Math.Round(t3, 6);
            double bien3 = DauRaNoron2(bien1, bien2, w13, w23);
            Math.Round(bien3, 6);
            ng3 = Z - bien3;
            Math.Round(ng3, 6);
            ng1 = ng3 * w13;
            Math.Round(ng1, 6);
            ng2 = ng3 * w23;
            Math.Round(ng2, 6);
            wa1 = TinhTrongSo(A, wa1, n, ng1, t1);
            Math.Round(wa1, 6);
            wb1 = TinhTrongSo(B, wb1, n, ng1, t1);
            Math.Round(wb1, 6);
            wc1 = TinhTrongSo(C, wc1, n, ng1, t1);
            Math.Round(wc1, 6);
            wd1 = TinhTrongSo(D, wd1, n, ng1, t1);
            Math.Round(wd1, 6);
            wa2 = TinhTrongSo(A, wa2, n, ng2, t2);
            Math.Round(wa2, 6);
            wb2 = TinhTrongSo(B, wb2, n, ng2, t2);
            Math.Round(wb2, 6);
            wc2 = TinhTrongSo(C, wc2, n, ng2, t2);
            Math.Round(wc2, 6);
            wd2 = TinhTrongSo(D, wd2, n, ng2, t2);
            Math.Round(wd2, 6);
            w13 = TinhTrongSo(bien1, w13, n, ng3, t3);
            Math.Round(w13, 6);
            w23 = TinhTrongSo(bien2, w23, n, ng3, t3);
            Math.Round(w23, 6);
            XuatModel();
        }
        public static double DuDoan(double a1, double b1, double c1, double d1)
        {
            double t1 = Timt(a1, b1, wa1, wb1, c1, d1, wc1, wd1);
            Math.Round(t1, 6);
            double bien1 = DauRaNoron(a1, b1, wa1, wb1, c1, d1, wc1, wd1);
            Math.Round(bien1, 6);
            double t2 = Timt(a1, b1, wa2, wb2, c1, d1, wc2, wd2);
            Math.Round(t2, 6);
            double bien2 = DauRaNoron(a1, b1, wa2, wb2, c1, d1, wc2, wd2);
            Math.Round(bien2, 6);
            double t3 = Timt2(bien1, bien2, w13, w23);
            Math.Round(t3, 6);
            double bien3 = DauRaNoron2(bien1, bien2, w13, w23);
            Math.Round(bien3, 6);
            return Math.Round(bien3, 6);
        }
        public void khoiTao()
        {
            lst.Add(new DoanhThu(DateTime.ParseExact("01/05/2021", "dd/MM/yyyy", null), 15000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("02/05/2021", "dd/MM/yyyy", null), 13000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("03/05/2021", "dd/MM/yyyy", null), 7000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("04/05/2021", "dd/MM/yyyy", null), 9000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("05/05/2021", "dd/MM/yyyy", null), 14000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("06/05/2021", "dd/MM/yyyy", null), 15000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("07/05/2021", "dd/MM/yyyy", null), 13000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("08/05/2021", "dd/MM/yyyy", null), 12000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("09/05/2021", "dd/MM/yyyy", null), 11000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("10/05/2021", "dd/MM/yyyy", null), 11400000));
            lst.Add(new DoanhThu(DateTime.ParseExact("11/05/2021", "dd/MM/yyyy", null), 11200000));
            lst.Add(new DoanhThu(DateTime.ParseExact("12/05/2021", "dd/MM/yyyy", null), 12400000));
            lst.Add(new DoanhThu(DateTime.ParseExact("13/05/2021", "dd/MM/yyyy", null), 12500000));
            lst.Add(new DoanhThu(DateTime.ParseExact("14/05/2021", "dd/MM/yyyy", null), 11000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("15/05/2021", "dd/MM/yyyy", null), 9500000));
            lst.Add(new DoanhThu(DateTime.ParseExact("16/05/2021", "dd/MM/yyyy", null), 8700000));
            lst.Add(new DoanhThu(DateTime.ParseExact("17/05/2021", "dd/MM/yyyy", null), 7600000));
            lst.Add(new DoanhThu(DateTime.ParseExact("18/05/2021", "dd/MM/yyyy", null), 8000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("19/05/2021", "dd/MM/yyyy", null), 6700000));
            lst.Add(new DoanhThu(DateTime.ParseExact("20/05/2021", "dd/MM/yyyy", null), 13200000));
            lst.Add(new DoanhThu(DateTime.ParseExact("21/05/2021", "dd/MM/yyyy", null), 12000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("22/05/2021", "dd/MM/yyyy", null), 12200000));
            lst.Add(new DoanhThu(DateTime.ParseExact("23/05/2021", "dd/MM/yyyy", null), 12400000));
            lst.Add(new DoanhThu(DateTime.ParseExact("24/05/2021", "dd/MM/yyyy", null), 11300000));
            lst.Add(new DoanhThu(DateTime.ParseExact("25/05/2021", "dd/MM/yyyy", null), 7800000));
            lst.Add(new DoanhThu(DateTime.ParseExact("26/05/2021", "dd/MM/yyyy", null), 9500000));
            lst.Add(new DoanhThu(DateTime.ParseExact("27/05/2021", "dd/MM/yyyy", null), 13400000));
            lst.Add(new DoanhThu(DateTime.ParseExact("28/05/2021", "dd/MM/yyyy", null), 9300000));
            lst.Add(new DoanhThu(DateTime.ParseExact("29/05/2021", "dd/MM/yyyy", null), 14300000));
            lst.Add(new DoanhThu(DateTime.ParseExact("30/05/2021", "dd/MM/yyyy", null), 13000000));
            lst.Add(new DoanhThu(DateTime.ParseExact("31/05/2021", "dd/MM/yyyy", null), 12100000));
        }

        private void frmDuBaoDoanhThu_Load(object sender, EventArgs e)
        {
            loadDataDuLieu();
            loadDuBao();
        }
        public void loadDataDuLieu()
        {
            max = lst[0].TongTien;
            min = lst[0].TongTien;
            for (int i = 0; i < lst.Count; i++)
            {
                DoanhThu doanhThu = lst[i];
                if (lst[i].TongTien > max)
                {
                    max = lst[i].TongTien;
                }
                if (lst[i].TongTien < min)
                {
                    min = lst[i].TongTien;
                }
                lst2.Add(doanhThu);
                gridDuLieu.Rows.Add();
                gridDuLieu.Rows[i].Cells["STT"].Value = i;
                gridDuLieu.Rows[i].Cells["TongTien"].Value = Math.Round(doanhThu.TongTien, 2);
            }
        }
        public void loadDataChuanHoa()
        {
            gridcChuanHoa.Rows.Clear();
            lst2.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                DoanhThu doanhThu = lst[i];
                doanhThu.TongTien = ChuanHoaDuLieu(double.Parse(doanhThu.TongTien.ToString()), double.Parse(max.ToString()), double.Parse(min.ToString()));
                lst2.Add(doanhThu);
                gridcChuanHoa.Rows.Add();
                gridcChuanHoa.Rows[i].Cells["STT2"].Value = i;
                gridcChuanHoa.Rows[i].Cells["TongTien2"].Value = Math.Round(doanhThu.TongTien, 2);
            }
        }
    }
}
