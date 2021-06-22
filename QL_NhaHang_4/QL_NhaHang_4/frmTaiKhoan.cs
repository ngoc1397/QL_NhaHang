using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;
using System.Security.Cryptography;

namespace QL_NhaHang_4
{
    public partial class frmTaiKhoan : Form
    {
        DTO_NguoiDung nguoiDung;
        public frmTaiKhoan(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Enabled = true;
            txtMatKhau.Enabled = true;
            txtNhapLaiMatKhau.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO_NguoiDung dAO_NguoiDung = new DAO_NguoiDung();
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật tài khoản","Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int kq = dAO_NguoiDung.sp_KiemTraDangNhap(txtTenDN.Text, txtMatKhauCu.Text);
                if (kq == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if(!txtMatKhau.Text.Equals(txtNhapLaiMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu không trùng nhau", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    
                    dAO_NguoiDung.capNhatTaiKhoan(txtTenHienThi.Text,txtTenDN.Text,GetMd5Hash(txtNhapLaiMatKhau.Text.Trim()));
                }
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = nguoiDung.TenDangNhap;
            txtTenHienThi.Text = nguoiDung.TenHienThi;
            txtMatKhauCu.Enabled = false;
            txtMatKhau.Enabled = false;
            txtNhapLaiMatKhau.Enabled = false; 
        }
        public string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
