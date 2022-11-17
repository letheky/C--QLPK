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
            drw = ds.Tables["BacSi"].NewRow();
            drw["MaBS"] = txtMaBS.Text;
            drw["TenBS"] = txtTenBS.Text;
            drw["DiaChi"] = txtDiaChi.Text;
            drw["SDT"] = txtSDT.Text;
            drw["ChuyenMon"] = txtChuyenMon.Text;
            ds.Tables["BacSi"].Rows.Add(drw);
        }

        private void FormBacSi_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataSet ds = new DataSet();
            ds = obj.getDataSet("BACSI");
            dataGridView1.DataSource = ds.Tables["BACSI"];

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
                MessageBox.Show(this, "Moi ban chọn bác sĩ cần xóa", "Xóa bác sĩ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
            drw["TenBS"] = txtTenBS.Text;
            drw["DiaChi"] = txtDiaChi.Text;
            drw["SDT"] = txtSDT.Text;
            drw["ChuyenMon"] = txtChuyenMon.Text;
            if (dsBacSi.HasChanges())
            {
                obj.CapnhatBang(dsBacSi, "BACSI");
                dsBacSi.AcceptChanges();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaBS.Clear();
            txtTenBS.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtChuyenMon.Clear();
        }
    }
}
