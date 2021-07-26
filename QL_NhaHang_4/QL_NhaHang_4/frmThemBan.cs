using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace QL_NhaHang_4
{
    public partial class frmThemBan : Form
    {
        DAO_Ban ban;
        public frmThemBan()
        {
            InitializeComponent();
            ban = new DAO_Ban();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            if(txtTenBan.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên bàn", "Thông báo");
                return;
            }
            if (ban.themBanMoi(txtTenBan.Text.Trim()))
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo");
            }
        }
    }
}
