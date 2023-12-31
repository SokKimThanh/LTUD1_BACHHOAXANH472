﻿using LTUD1_BACHHOAXANH472.Model;
using LTUD1_BACHHOAXANH472.ScreenDetail;
using LTUD1_BACHHOAXANH472.ScreenMenu.Nhap;
using LTUD1_BACHHOAXANH472.ScreenMenu.Nhap.DanhMuc;
using LTUD1_BACHHOAXANH472.ScreenMenu.Nhap.PhongBan;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LTUD1_BACHHOAXANH472
{

    public partial class FormMain : Form
    {
        private bool sidebarExpand;
        readonly private int speed = 80;//chia het tang toc do dong mmở navigation
        readonly private int maxWidthMenu = 320;
        readonly private int minWidthMenu = 86;
        private Button currentButton = new Button();
        private Form currentChildForm = new Form();
        public SettingImageList navigationBar;
        public ErrForm errform;
        private Session session;
        public Session Session { get; set; }

        public bool btn_out = false;

        // Khởi tạo ReportManager ở đây
        private ReportManager reportManager;


        /// <summary>
        /// CHẠY TỪ FILE PROGRAM.CS 
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            navigationBar = new SettingImageList(listIcon_navigation_bar);
            errform = new ErrForm(this);
            //lblAccountName = new Label();
            // dành cho test lỗi chạy từ file program.cs
            //lblAccountName.Text = "ADMIN TEST";


            //==============================================================================
            //--..........................................................................--
            //---------------.     Cài đặt lazy load report management       .--------------
            //--..........................................................................--
            //==============================================================================
            // Tạo một ReportManager mới với đường dẫn đến thư mục chứa các báo cáo
            reportManager = new ReportManager(Utils.ReportsString);//lazyloading
        }
        /// <summary>
        /// CHẠY TỪ FILE FORMDANGNHAP.CS
        /// </summary>
        /// <param name="session"></param>
        public FormMain(Session session)
        {

            InitializeComponent();
            navigationBar = new SettingImageList(listIcon_navigation_bar);
            errform = new ErrForm(this);
            this.session = session;
            // dành cho chạy từ đăng nhập sẽ có tên đăng nhập đầy đủ và cấp quyền
            lblAccountName.Text = this.session.Username.ToUpper();

            //==============================================================================
            //--..........................................................................--
            //---------------.     Cài đặt lazy load report management       .--------------
            //--..........................................................................--
            //==============================================================================
            // Tạo một ReportManager mới với đường dẫn đến thư mục chứa các báo cáo
            reportManager = new ReportManager(Utils.ReportsString);//lazyloading
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            //// Thiết lập kích thước cho cột đầu tiên  
            tlpBHX.ColumnStyles[0].Width = minWidthMenu;
            //panelSidebar.Width = minWidthMenu;
            this.Text = string.Empty;// xóa tiêu đề
            this.ControlBox = false;// tắt nút thoát 
            this.DoubleBuffered = true;// giảm nháy màn hình 


            this.IsMdiContainer = true; // Đặt form này là MdiContainer 
        }

        /**
         * Thay đổi panel mỗi khi nhấp vào 1 text (Kích hoạt panel đó)
         */
        public void ActiveButton(object currentButtonSender, Color ActiveColorText, Color ActiveColorBack)
        {
            if (currentButtonSender != null)
            {
                DisableButton();
                currentButton = (Button)currentButtonSender;
                currentButton.ForeColor = ActiveColorText;
                currentButton.BackColor = ActiveColorBack;
                // active current icon title
                currentChangeButton.Image = currentButton.Image;
                currentChangeTitle.Text = currentButton.Text;
                if (currentButton.Name == "btnSetting")
                {
                    currentChangeTitle.Text = "Setting".ToUpper();
                }
            }
        }
        /**
         * Trả về panel khác như cũ sau khi active panel mới
         */
        public void DisableButton()
        {
            // BUTTON
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.ForeColor = Color.White;
                currentChangeButton.Image = navigationBar.getIcon("icon_home", "png");
                currentChangeTitle.Text = "TRANG CHỦ";
            }
        }



        private void NavigationButton_MouseClick(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
        }

        private void NavigationButton_MouseEnter(object sender, EventArgs e)
        {
            Button currentPanel = (Button)sender;
            if (currentPanel != null)
            {
                currentPanel.BackColor = RGB_COLORS.PrimaryPink; // Màu button khi di chuột vào
            }
        }

        private void NavigationButton_MouseLeave(object sender, EventArgs e)
        {
            Button currentPanel = (Button)sender;
            if (currentPanel != null)
            {
                currentPanel.BackColor = Color.Transparent; // Màu button khi di chuột ra
            }
        }

        //drag form
        [DllImport("user32.dll", EntryPoint = "Releasecapture")]
        private static extern void Releasecapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public void OpenChildForm(Form childForm)
        {
            //open only form
            currentChildForm?.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /**
         * Active click 7 button
         */
        //1
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormNhanVien(reportManager));
        }
        //2
        private void btnDiaDiem_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormChiNhanh(reportManager));

        }
        //3
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormSanPham(reportManager));
        }
        //4
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormHoaDon(reportManager));
        }
        //5
        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormKhuyenMai(reportManager));
        }
        //6
        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormNhaCungCap(reportManager));

        }
        //7
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormKhachHang(reportManager));
        }
        //8
        private void btnChiTietHD_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormChiTietHoaDon(reportManager));
        }
        //9
        private void btnDanhMucSP_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormLoaiSP(reportManager));
        }
        //10
        private void btnHinhThucKM_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormHinhThucKhuyenMai(reportManager));
        }
        //11
        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormPhongBan(reportManager));
        }
        //12
        private void btnNhaCCCT_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormChiTietNhaCungCap(reportManager));
        }
        //13
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormBanHang(reportManager));
        }
        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormChiNhanh(reportManager));
        }

        /**
       * reset click all button
       */
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm == null)
            {
                return;
            }
            currentChildForm.Close();
            Reset();
        }
        /**
           * offset navbar
           */
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            // tự động thu gọn navigation khi mở app
            if (!sidebarExpand)
            {
                //panelSidebar.Width -= chiahetcho;
                tlpBHX.ColumnStyles[0].Width += speed;
                if (tlpBHX.ColumnStyles[0].Width >= maxWidthMenu)
                //if (panelSidebar.Width == panelSidebar.MinimumSize.Width)
                {
                    // đặt lại chữ
                    this.btnChiNhanh.Text = "địa điểm".ToUpper();
                    this.btnNhanVien.Text = "nhân viên".ToUpper();
                    this.btnNhaCungCap.Text = "nhà cung cấp".ToUpper();
                    this.btnSanPham.Text = "sản phẩm".ToUpper();
                    this.btnHoaDon.Text = "hóa đơn".ToUpper();
                    this.btnKhuyenMai.Text = "khuyến mãi".ToUpper();
                    this.btnKhachHang.Text = "khách hàng".ToUpper();
                    // khong mo rong nua
                    sidebarExpand = true;
                    sidebarTimer.Stop();

                }
            }
            //th nguoc lai sidebar mở ra do nhấn vào nút navigationbar 
            else
            {
                //panelSidebar.Height += chiahetcho;
                tlpBHX.ColumnStyles[0].Width -= speed;
                if (tlpBHX.ColumnStyles[0].Width <= minWidthMenu)
                //if (panelSidebar.Width == panelSidebar.MaximumSize.Width)
                {
                    // khong thu hep nua
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        private void Reset()
        {
            DisableButton();
        }
        /**
       * Exit form đóng file hỏi lưu file trước khi đóng
       */
        private void MF_BHX_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Application.Exit(); //"Thoát luôn"
                btn_out = true;
            }
        }

        private void currentChangeTitle_MouseDown(object sender, MouseEventArgs e)
        {
            //Releasecapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SetWindowText(int hWnd, String text);

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormTaiKhoan(reportManager));
        }

        private void tsmDangXuat_Click(object sender, EventArgs e)
        {
            // Thực hiện các tác vụ đăng xuất ở đây
            try
            {
                //Đăng xuất
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBHX_Shown(object sender, EventArgs e)
        {
            // Kiểm tra xem Đăng nhập còn không?
            Form formDangNhap = Application.OpenForms["FormDangNhap"];
            // Nếu rồi, xóa nó
            formDangNhap?.Hide();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGB_COLORS.PrimaryGreen, RGB_COLORS.PrimaryPink);
            OpenChildForm(new FormDangNhap());
        }

        private void btnReportManagement_Click(object sender, EventArgs e)
        {
            if (!ErrForm.DialogConfirm("Bạn muốn tải lại các báo cáo không?"))
            {
                reportManager.RefreshAllReports();
            }
        }
    }
}