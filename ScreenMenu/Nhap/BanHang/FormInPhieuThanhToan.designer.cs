﻿namespace LTUD1_BACHHOAXANH472
{
    partial class FormInPhieuThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.rpvInHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // rpvInHoaDon
            // 
            this.rpvInHoaDon.ActiveViewIndex = 0;
            this.rpvInHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpvInHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpvInHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rpvInHoaDon.Name = "rpvInHoaDon";
            //this.rpvInHoaDon.ReportSource = "D:\\Hoc_Tap\\LTUD1_BACHHOAXANH472\\ScreenMenu\\Nhap\\BanHang\\PhieuInHoaDon.rpt";
            this.rpvInHoaDon.Size = new System.Drawing.Size(1275, 507);
            this.rpvInHoaDon.TabIndex = 1;
            this.rpvInHoaDon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.rpvInHoaDon.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // FormInPhieuThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1275, 507);
            this.Controls.Add(this.rpvInHoaDon);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInPhieuThanhToan";
            this.Text = "FormInPhieuThanhToan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpvInHoaDon;
    }
}