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
    public partial class FormThongKe : Form
    {
        private Dashboard model;
        private Button currentButton;
        public FormThongKe()
        {
            InitializeComponent();
            dtp1.Value = DateTime.Today.AddDays(-7);
            dtp2.Value = DateTime.Now;
            btnTuan.Select();
            SetDateMenuButtonUI(btnTuan);
            model = new Dashboard();
            LoadData();
        }
        private void LoadData()
        {
            var refreshData = model.LoadData(dtp1.Value, dtp2.Value);
            if (refreshData == true)
            {
                lbThuocBan.Text = model.ThuocBan.ToString();
                lbThuNhap.Text = model.ThuNhap.ToString() + "VNĐ";
                lbLoiNhuan.Text = model.LoiNhuan.ToString() + "VNĐ";
                lbSoBenhNhan.Text = model.SoBenhNhan.ToString();
                lbThuocTon.Text = model.ThuocTon.ToString();
                chart1.DataSource = model.TongDoanhThu;
                chart1.Series[0].XValueMember = "Date";
                chart1.Series[0].YValueMembers = "TotalAmount";
                chart1.DataBind();
                chart2.DataSource = model.ThuocBanChay;
                chart2.Series[0].XValueMember = "Key";
                chart2.Series[0].YValueMembers = "Value";
                chart2.DataBind();
                dgv.DataSource = model.ThuocThieuHang;
                dgv.Columns[0].HeaderText = "Tên thuốc";
                dgv.Columns[1].HeaderText = "Số lượng";
                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded, same query");
        }
        private void SetDateMenuButtonUI(object button)
        {
            var btn = (Button)button;
            btn.BackColor = btnThang.FlatAppearance.BorderColor;
            btn.ForeColor = Color.White;
            if (currentButton != null & currentButton != btn)
            {
                currentButton.BackColor = this.BackColor;
                currentButton.ForeColor = Color.FromArgb(124, 141, 181);
            }
            currentButton = btn;
            if (btn == btnTuyChinh)
            {
                dtp1.Enabled = true;
                dtp2.Enabled = true;
                btnOK.Visible = true;
                lbDate1.Cursor = Cursors.Hand;
                lbDate2.Cursor = Cursors.Hand;
            }
            else
            {
                {
                    dtp1.Enabled = false;
                    dtp2.Enabled = false;
                    btnOK.Visible = false;
                    lbDate1.Cursor = Cursors.Default;
                    lbDate2.Cursor = Cursors.Default;
                }
            }
        }
        private void FormThongKe_Load(object sender, EventArgs e)
        {
            lbDate1.Text = dtp1.Text;
            lbDate2.Text = dtp2.Text;
            LoadTheme();
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
        }

        private void btnQuy_Click(object sender, EventArgs e)
        {
            dtp1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtp2.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Today.AddDays(-30);
            dtp2.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnTuan_Click(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Today.AddDays(-7);
            dtp2.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Today;
            dtp2.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnTuyChinh_Click(object sender, EventArgs e)
        {
                 SetDateMenuButtonUI(sender);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lbDate1_Click(object sender, EventArgs e)
        {
            if (currentButton == btnTuyChinh)
            {
                dtp1.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void lbDate2_Click(object sender, EventArgs e)
        {
            if (currentButton == btnTuyChinh)
            {
                dtp2.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            lbDate1.Text = dtp1.Text;
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            lbDate2.Text = dtp2.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}