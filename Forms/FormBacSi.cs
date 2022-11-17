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
    public partial class FormBacSi : Form
    {
        public FormBacSi()
        {
            InitializeComponent();
        }
        clsQLPK obj = new clsQLPK();
        DataSet dsBacSi = new DataSet();
        private void GanDuLieuVaoRow(DataSet ds)
        {
            DataRow drw;
            drw = ds.Tables["BacSi"].NewRow(); //buoc 1  tao row moi 
            drw["MaBS"] = txtMaBS.Text; // buoc 2 gan du lieu vao field
            drw["TenBS"] = txtTenBS.Text;// buoc 2 gan du lieu vao field
            drw["DiaChi"] = txtDiaChi.Text;// buoc 2 gan du lieu vao field
            drw["SDT"] = txtSDT.Text;// buoc 2 gan du lieu vao field
            drw["ChuyenMon"] = txtChuyenMon.Text;// buoc 2 gan du lieu vao field
            ds.Tables["BacSi"].Rows.Add(drw);// buoc 3 gan Row vao tbl

        }

        private void FormBacSi_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataTable BacSi = new DataTable();
            dsBacSi = obj.GetDataSetTable("BacSi");
            // lay Ds de phuc vu sau 
            //đưa dữ liệu lên dataGridView.
            dataGridView1.DataSource = dsBacSi.Tables[0];
            // dua len cbo Lop 3 buoc 
            BacSi = obj.getDataTable("BacSi");

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
                // sinh vien kiem tra du lieu dung du nhu trung khoa chinh,kieu so, chuoi rong 
                DataRow drw;
                drw = obj.TimRow(dsBacSi.Tables["BacSi"], "MaBS", txtMaBS.Text);
                if (drw != null)
                    MessageBox.Show("Trung khoa");
                else
                {
                    GanDuLieuVaoRow(dsBacSi);
                    if (dsBacSi.HasChanges())
                    {
                        obj.CapnhatBang(dsBacSi, "BacSi");
                        dsBacSi.AcceptChanges();
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
                hoixoa = MessageBox.Show(this, "Bạn có muốn xóa bác sĩ: " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), " Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (hoixoa == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(Vitrichon);
                }

                if (dsBacSi.HasChanges())
                {
                    obj.CapnhatBang(dsBacSi, "BacSi");
                    dsBacSi.AcceptChanges();
                }
            }
            else
            {
                MessageBox.Show(this, "Moi ban chọn sinh viên cần xóa", "Xóa sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBS.Text = dataGridView1.CurrentRow.Cells["MaBS"].Value.ToString();
            txtTenBS.Text = dataGridView1.CurrentRow.Cells["TenBS"].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txtChuyenMon.Text = dataGridView1.CurrentRow.Cells["ChuyenMon"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri;
            vitri = dataGridView1.CurrentRow.Index;
            DataRow drw;
            drw = dsBacSi.Tables["BacSi"].Rows[vitri];
            //Lưu ý: drw["MaBS"] =txtMaBS.Text  khong sua
            drw["TenBS"] = txtTenBS.Text;
            drw["DiaChi"] = txtDiaChi.Text;
            drw["SDT"] = txtSDT.Text;
            drw["ChuyenMon"] = txtChuyenMon.Text;
            if (dsBacSi.HasChanges())
            {
                obj.CapnhatBang(dsBacSi, "BacSi");
                dsBacSi.AcceptChanges();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Làm trắng các ô textbox 
            txtMaBS.Clear();
            txtTenBS.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtChuyenMon.Clear();
            //cập nhật lại bảng dataGridView1 sau khi tìm kiếm bác sĩ theo mã bác sĩ bằng cách lấy toàn bộ danh sách bác sĩ
            dataGridView1.DataSource = dsBacSi.Tables["BacSi"];
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string strGiaTriTim;
            DataTable tbl = new DataTable();
            strGiaTriTim = txtMaTimKiem.Text;
            tbl = obj.Get1BS(strGiaTriTim);
            dataGridView1.DataSource = tbl;
        }
    }
}
