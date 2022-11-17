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
    public partial class FormPhong : Form
    {
        public FormPhong()
        {
            InitializeComponent();
        }
        clsQLPK obj = new clsQLPK();
        DataSet dsPhong = new DataSet();
        private void GanDuLieuVaoRow(DataSet ds)
        {
            DataRow drw;
            drw = ds.Tables["Phong"].NewRow();
            drw["MaPK"] = txtMaPK.Text;
            drw["TenPK"] = txtTenPK.Text;
            drw["MaNV"] = txtMaNV.Text;
            drw["MaBS"] = txtMaBS.Text;
            ds.Tables["Phong"].Rows.Add(drw);
        }

        private void FormPhong_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataSet ds = new DataSet();
            ds = obj.getDataSet("PHONG");
            dataGridView1.DataSource = ds.Tables["PHONG"];
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
                drw = obj.TimRow(dsPhong.Tables["Phong"], "MaPK", txtMaPK.Text);
                if (drw != null)
                    MessageBox.Show("Trung khoa");
                else
                {
                    GanDuLieuVaoRow(dsPhong);
                    if (dsPhong.HasChanges())
                    {
                        obj.CapnhatBang(dsPhong, "Phong");
                        dsPhong.AcceptChanges();
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
                hoixoa = MessageBox.Show(this, "Bạn có muốn xóa Phòng: " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), " Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (hoixoa == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(Vitrichon);
                }

                if (dsPhong.HasChanges())
                {
                    obj.CapnhatBang(dsPhong, "Phong");
                    dsPhong.AcceptChanges();
                }
            }
            else
            {
                MessageBox.Show(this, "Moi ban chọn Phòng cần xóa", "Xóa Phòng", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPK.Text = dataGridView1.CurrentRow.Cells["MaPK"].Value.ToString();
            txtTenPK.Text = dataGridView1.CurrentRow.Cells["TenPK"].Value.ToString();
            txtMaNV.Text = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
            txtMaBS.Text = dataGridView1.CurrentRow.Cells["MaBS"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri;
            vitri = dataGridView1.CurrentRow.Index;
            DataRow drw;
            drw = dsPhong.Tables["Phong"].Rows[vitri];
            drw["TenPK"] = txtTenPK.Text;
            drw["MaNV"] = txtMaNV.Text;
            drw["MaBS"] = txtMaBS.Text;
            if (dsPhong.HasChanges())
            {
                obj.CapnhatBang(dsPhong, "BACSI");
                dsPhong.AcceptChanges();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaBS.Clear();
            txtTenPK.Clear();
            txtMaPK.Clear();
            txtMaNV.Clear();
        }
    }
}
