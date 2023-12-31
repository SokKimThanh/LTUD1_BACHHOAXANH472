﻿using LTUD1_BACHHOAXANH472.Model;
using System;
using System.Data;
using System.Windows.Forms;
namespace LTUD1_BACHHOAXANH472
{
    public partial class FormNhaCungCap : Form
    {
        NhaCungCapController nccController;
        ButtonStateManager buttonStateManager;
        ReportManager reportManager;// chia se report

        public FormNhaCungCap(ReportManager reportManager)
        {
            InitializeComponent();
            nccController = new NhaCungCapController(Utils.ConnectionString);
            buttonStateManager = new ButtonStateManager();
            buttonStateManager.BtnAdd = this.btnAdd;
            buttonStateManager.BtnDelete = this.btnDelete;
            buttonStateManager.BtnEdit = this.btnEdit;
            buttonStateManager.BtnRefresh = this.btnRefresh;
            this.reportManager = reportManager;// chia se report

        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                // Help config datagridview setting
                DataGridViewHelper.ConfigureDataGridView(dgvNhaCungCap);

                nccController.SelectAll();
                dgvNhaCungCap.DataSource = nccController.DataSource;
                // crud button setting buttonStateManager
                buttonStateManager.UpdateButtonStates(ButtonState.FormLoaded);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }
        }
        public void refresh()
        {
            txtTenNhaCC.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSDTNCC.Text = string.Empty;


            nccController.SelectAll();
            dgvNhaCungCap.DataSource = nccController.DataSource;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiem tra nhap thong tin
                if (ErrTextbox.CheckControlValue(txtTenNhaCC))
                {
                    MessageBox.Show("txtTenNhaCC", "Bắt buộc nhập!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ErrTextbox.CheckControlValue(txtSDTNCC))
                {
                    MessageBox.Show("txtSDTNCC", "Bắt buộc nhập!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                if (ErrTextbox.CheckControlValue(txtDiaChi))
                {
                    MessageBox.Show("txtDiaChi", "Bắt buộc nhập!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }


                nccController.SelectAll();
                //DataRow dongcuoicung = nccController.DataSource.Rows[nccController.DataSource.Rows.Count - 1];
                DataRow dongdautien = nccController.DataSource.Rows[0];
                // id tự động tăng
                //string id_cuoi = (string)dongcuoicung["NhanVienID"];
                string id_dau = (string)dongdautien["MANCC"];
                string ma = GenerateID.generateID("ncc", id_dau.Trim(), 3);

                string ten = txtTenNhaCC.Text;
                int sdt = int.Parse(txtSDTNCC.Text);
                string diachi = txtDiaChi.Text;
                NhaCungCap o = new NhaCungCap(ma, ten, diachi, sdt);
                nccController.Insert(o);
                nccController.SelectAll();
                dgvNhaCungCap.DataSource = nccController.DataSource;
                buttonStateManager.UpdateButtonStates(ButtonState.RefreshClicked);
                MessageBox.Show("Thêm thành công!", "Thông náo");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }
        }

        private void dgvNhaCungCap_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo số dòng đang chọn
                int dong = dgvNhaCungCap.CurrentCell.RowIndex;
                // lấy ra mã
                string manv = dgvNhaCungCap.Rows[dong].Cells[0].Value.ToString();
                // khởi tạo đối tượng bằng mã
                DataTable dt = nccController.SelectByID(manv);
                DataRow dr = dt.Rows[0];
                NhaCungCap o = (NhaCungCap)nccController.FromDataRow(dr);
                txtDiaChi.Text = o.Diachi;
                txtTenNhaCC.Text = o.Ten;
                txtSDTNCC.Text = o.Sdt.ToString();

                // cập nhật lại trang thái các nút
                buttonStateManager.UpdateButtonStates(ButtonState.DataGridViewSelected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            buttonStateManager.UpdateButtonStates(ButtonState.RefreshClicked);
            refresh();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int dong = dgvNhaCungCap.CurrentCell.RowIndex;
                    string id = dgvNhaCungCap.Rows[dong].Cells[0].Value.ToString();
                    nccController.Delete(id);
                    buttonStateManager.UpdateButtonStates(ButtonState.RefreshClicked);
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtDiaChi.Text = ex.Message;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa  không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    //Kiem tra nhap thong tin
                    if (ErrTextbox.CheckControlValue(txtTenNhaCC))
                    {
                        MessageBox.Show("txtTenNhaCC", "Bắt buộc nhập!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ErrTextbox.CheckControlValue(txtSDTNCC))
                    {
                        MessageBox.Show("txtSDTNCC", "Bắt buộc nhập!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                    if (ErrTextbox.CheckControlValue(txtDiaChi))
                    {
                        MessageBox.Show("txtDiaChi", "Bắt buộc nhập!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    int dong = dgvNhaCungCap.CurrentCell.RowIndex;
                    string id = dgvNhaCungCap.Rows[dong].Cells[0].Value.ToString();

                    string name = txtTenNhaCC.Text;
                    int phone = int.Parse(txtSDTNCC.Text);
                    string address = txtDiaChi.Text;

                    NhaCungCap o = new NhaCungCap(id, name, address, phone);
                    nccController.Update(o);

                    buttonStateManager.UpdateButtonStates(ButtonState.RefreshClicked);
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtDiaChi.Text = ex.Message;
                }
            }


        }

        private void tsmNhaCCOld_Click(object sender, EventArgs e)
        {
            try
            {
                nccController.SelectAllNhaCungCapCu();
                dgvNhaCungCap.DataSource = nccController.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }
        }

        private void tsmNCCNew_Click(object sender, EventArgs e)
        {
            try
            {
                nccController.SelectAllNhaCungCapMoi();
                dgvNhaCungCap.DataSource = nccController.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }
        }

        private void tsmNCCALL_Click(object sender, EventArgs e)
        {
            try
            {
                nccController.SelectAll();
                dgvNhaCungCap.DataSource = nccController.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }
        }

        private void tsmExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                /*                InFilePDFExcel o = new InFilePDFExcel(dgvNhaCungCap);*/
                /*                o.ExportToPDF();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }

        }

        private void tsmExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                /*                InFilePDFExcel o = new InFilePDFExcel(dgvNhaCungCap);
                                o.ExportToExcel();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtDiaChi.Text = ex.Message;
            }
        }
    }
}
