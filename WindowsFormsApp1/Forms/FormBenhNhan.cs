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
    public partial class FormBenhNhan : Form
    {
        public FormBenhNhan()
        {
            InitializeComponent();
        }
        clsQLPK obj = new clsQLPK();
        DataSet dsBenhNhan = new DataSet();
        private void GanDuLieuVaoRow(DataSet ds)
        {
            DataRow drw;
            drw = ds.Tables["BenhNhan"].NewRow();
            drw["MaBS"] = txtMaBN.Text;
            drw["TenBS"] = txtTenBN.Text;
            drw["DiaChi"] = txtDiaChi.Text;
            drw["SDT"] = txtSDT.Text;
            drw["NgaySinh"] = dateTimePicker1.Text;
            ds.Tables["BenhNhan"].Rows.Add(drw);
        }

        private void FormBenhNhan_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DataSet ds = new DataSet();
            ds = obj.getDataSet("BENHNHAN");
            dataGridView1.DataSource = ds.Tables["BENHNHAN"];
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
                drw = obj.TimRow(dsBenhNhan.Tables["BenhNhan"], "MaBN", txtMaBN.Text);
                if (drw != null)
                    MessageBox.Show("Trung khoa");
                else
                {
                    GanDuLieuVaoRow(dsBenhNhan);
                    if (dsBenhNhan.HasChanges())
                    {
                        obj.CapnhatBang(dsBenhNhan, "BenhNhan");
                        dsBenhNhan.AcceptChanges();
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
                hoixoa = MessageBox.Show(this, "Bạn có muốn xóa Bệnh nhân: " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), " Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (hoixoa == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(Vitrichon);
                }

                if (dsBenhNhan.HasChanges())
                {
                    obj.CapnhatBang(dsBenhNhan, "BenhNhan");
                    dsBenhNhan.AcceptChanges();
                }
            }
            else
            {
                MessageBox.Show(this, "Mời bạn chọn Bệnh nhân cần xóa", "Xóa Bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBN.Text = dataGridView1.CurrentRow.Cells["MaBN"].Value.ToString();
            txtTenBN.Text = dataGridView1.CurrentRow.Cells["TenBN"].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["NgaySinh"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri;
            vitri = dataGridView1.CurrentRow.Index;
            DataRow drw;
            drw = dsBenhNhan.Tables["BenhNhan"].Rows[vitri];
            drw["TenBN"] = txtTenBN.Text;
            drw["DiaChi"] = txtDiaChi.Text;
            drw["SDT"] = txtSDT.Text;
            drw["NgaySinh"] = dateTimePicker1.Text;
            if (dsBenhNhan.HasChanges())
            {
                obj.CapnhatBang(dsBenhNhan, "BENHNHAN");
                dsBenhNhan.AcceptChanges();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaBN.Clear();
            txtTenBN.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            
        }
    }
}
