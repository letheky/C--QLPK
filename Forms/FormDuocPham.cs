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
    public partial class FormDuocPham : Form
    {
        public FormDuocPham()
        {
            InitializeComponent();
        }
        clsQLPK obj = new clsQLPK();
        DataSet dsDuocPham = new DataSet();
        private void GanDuLieuVaoRow(DataSet ds)
        {
            DataRow drw;
            drw = ds.Tables["DuocPham"].NewRow();
            drw["MaDP"] = txtMaDP.Text;
            drw["TenDP"] = txtTenDP.Text;
            drw["SoLuong"] = txtSoLuong.Text;
            drw["DonGia"] = txtDonGia.Text;
            drw["NgayNhap"] = dateTimePicker1.Text;
            ds.Tables["DuocPham"].Rows.Add(drw);
        }

        private void FormDuocPham_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataTable DuocPham = new DataTable();
            dsDuocPham = obj.GetDataSetTable("DuocPham");
            // lay Ds de phuc vu sau 
            //đưa dữ liệu lên dataGridView.
            dataGridView1.DataSource = dsDuocPham.Tables[0];
            // dua len cbo Lop 3 buoc 
            DuocPham = obj.getDataTable("DuocPham");
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
                drw = obj.TimRow(dsDuocPham.Tables["DuocPham"], "MaDP", txtMaDP.Text);
                if (drw != null)
                    MessageBox.Show("Trung khoa");
                else
                {
                    GanDuLieuVaoRow(dsDuocPham);
                    if (dsDuocPham.HasChanges())
                    {
                        obj.CapnhatBang(dsDuocPham, "DuocPham");
                        dsDuocPham.AcceptChanges();
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
                hoixoa = MessageBox.Show(this, "Bạn có muốn xóa Dược phẩm: " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), " Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (hoixoa == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(Vitrichon);
                }

                if (dsDuocPham.HasChanges())
                {
                    obj.CapnhatBang(dsDuocPham, "DuocPham");
                    dsDuocPham.AcceptChanges();
                }
            }
            else
            {
                MessageBox.Show(this, "Mời bạn chọn Dược phẩm cần xóa", "Xóa Dược phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri;
            vitri = dataGridView1.CurrentRow.Index;
            DataRow drw;
            drw = dsDuocPham.Tables["DuocPham"].Rows[vitri];
            drw["TenDP"] = txtTenDP.Text;
            drw["SoLuong"] = Convert.ToInt16(txtSoLuong.Text);
            drw["DonGia"] = Convert.ToInt16(txtDonGia.Text);
            drw["NgayNhap"] = dateTimePicker1.Text;
            if (dsDuocPham.HasChanges())
            {
                obj.CapnhatBang(dsDuocPham, "DuocPham");
                dsDuocPham.AcceptChanges();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaDP.Clear();
            txtTenDP.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            dataGridView1.DataSource = dsDuocPham.Tables["DuocPham"];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDP.Text = dataGridView1.CurrentRow.Cells["MaDP"].Value.ToString();
            txtTenDP.Text = dataGridView1.CurrentRow.Cells["TenDP"].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = dataGridView1.CurrentRow.Cells["DonGia"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["NgayNhap"].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string strGiaTriTim;
            DataTable tbl = new DataTable();
            strGiaTriTim = txtMaTimKiem.Text;
            tbl = obj.Get1DP(strGiaTriTim);
            dataGridView1.DataSource = tbl;
        }
    }
}
