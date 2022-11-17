using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        clsQLPK obj = new clsQLPK();
        DataSet dsNhanVien = new DataSet();
        private void GanDuLieuVaoRow(DataSet ds)
        {
            DataRow drw;
            drw = ds.Tables["NhanVien"].NewRow();
            drw["MaNV"] = txtMaNV.Text;
            drw["TenNV"] = txtTenNV.Text;
            drw["DiaChi"] = txtDiaChi.Text;
            drw["SDT"] = txtSDT.Text;
            drw["CongViec"] = txtCongViec.Text;
            ds.Tables["NhanVien"].Rows.Add(drw);
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataTable NhanVien = new DataTable();
            dsNhanVien = obj.GetDataSetTable("NhanVien");
            // lay Ds de phuc vu sau 
            //đưa dữ liệu lên dataGridView.
            dataGridView1.DataSource = dsNhanVien.Tables[0];
            // dua len cbo Lop 3 buoc 
            NhanVien = obj.getDataTable("NhanVien");
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label6.ForeColor = ThemeColor.SecondaryColor;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow drw;
                drw = obj.TimRow(dsNhanVien.Tables["NhanVien"], "MaNV", txtMaNV.Text);
                if (drw != null)
                    MessageBox.Show("Trung khoa");
                else
                {
                    GanDuLieuVaoRow(dsNhanVien);
                    if (dsNhanVien.HasChanges())
                    {
                        obj.CapnhatBang(dsNhanVien, "NhanVien");
                        dsNhanVien.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int Vitrichon;
            DialogResult hoixoa;
            if (dataGridView1.CurrentRow != null)
            {
                Vitrichon = dataGridView1.CurrentRow.Index;
                hoixoa = MessageBox.Show(this, "Bạn có muốn xóa Nhân viên: " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), " Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (hoixoa == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(Vitrichon);
                }

                if (dsNhanVien.HasChanges())
                {
                    obj.CapnhatBang(dsNhanVien, "NhanVien");
                    dsNhanVien.AcceptChanges();
                }
            }
            else
            {
                MessageBox.Show(this, "Moi ban chọn Nhân viên cần xóa", "Xóa Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri;
            vitri = dataGridView1.CurrentRow.Index;
            DataRow drw;
            drw = dsNhanVien.Tables["NhanVien"].Rows[vitri];
            drw["TenNV"] = txtTenNV.Text;
            drw["DiaChi"] = txtDiaChi.Text;
            drw["SDT"] = txtSDT.Text;
            drw["CongViec"] = txtCongViec.Text;
            if (dsNhanVien.HasChanges())
            {
                obj.CapnhatBang(dsNhanVien, "NhanVien");
                dsNhanVien.AcceptChanges();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtCongViec.Clear();
            dataGridView1.DataSource = dsNhanVien.Tables["NhanVien"];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dataGridView1.CurrentRow.Cells["TenNV"].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txtCongViec.Text = dataGridView1.CurrentRow.Cells["CongViec"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strGiaTriTim;
            DataTable tbl = new DataTable();
            strGiaTriTim = txtMaTimKiem.Text;
            tbl = obj.Get1NV(strGiaTriTim);
            dataGridView1.DataSource = tbl;
        }
    }
}
