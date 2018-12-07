﻿namespace HBImageCrop
{
    partial class MainForm
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
            this.clbImageList = new System.Windows.Forms.CheckedListBox();
            this.btnOpenImageFolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtMain = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.rbResize = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbCrop = new System.Windows.Forms.RadioButton();
            this.dtwainImagelist = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbImageList
            // 
            this.clbImageList.FormattingEnabled = true;
            this.clbImageList.Location = new System.Drawing.Point(747, 15);
            this.clbImageList.Name = "clbImageList";
            this.clbImageList.Size = new System.Drawing.Size(205, 174);
            this.clbImageList.TabIndex = 8;
            this.clbImageList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbImageList_ItemCheck);
            this.clbImageList.SelectedIndexChanged += new System.EventHandler(this.clbImageList_SelectedIndexChanged);
            // 
            // btnOpenImageFolder
            // 
            this.btnOpenImageFolder.Location = new System.Drawing.Point(0, 0);
            this.btnOpenImageFolder.Name = "btnOpenImageFolder";
            this.btnOpenImageFolder.Size = new System.Drawing.Size(60, 32);
            this.btnOpenImageFolder.TabIndex = 7;
            this.btnOpenImageFolder.Text = "Open Folder";
            this.btnOpenImageFolder.UseVisualStyleBackColor = true;
            this.btnOpenImageFolder.Click += new System.EventHandler(this.btnOpenImageFolder_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.dtMain);
            this.panel1.Controls.Add(this.clbImageList);
            this.panel1.Location = new System.Drawing.Point(220, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 694);
            this.panel1.TabIndex = 10;
            // 
            // dtMain
            // 
            this.dtMain.AnnotationFillColor = System.Drawing.Color.White;
            this.dtMain.AnnotationPen = null;
            this.dtMain.AnnotationTextColor = System.Drawing.Color.Black;
            this.dtMain.AnnotationTextFont = null;
            this.dtMain.AutoScroll = true;
            this.dtMain.AutoSize = true;
            this.dtMain.IfShowCancelDialogWhenImageTransfer = false;
            this.dtMain.IfThrowException = false;
            this.dtMain.Location = new System.Drawing.Point(3, 3);
            this.dtMain.LogLevel = ((short)(0));
            this.dtMain.Name = "dtMain";
            this.dtMain.PDFConvertMode = Dynamsoft.DotNet.TWAIN.Enums.EnumPDFConvertMode.enumCM_DEFAULT;
            this.dtMain.PDFMarginBottom = ((uint)(0u));
            this.dtMain.PDFMarginLeft = ((uint)(0u));
            this.dtMain.PDFMarginRight = ((uint)(0u));
            this.dtMain.PDFMarginTop = ((uint)(0u));
            this.dtMain.PDFXConformance = ((uint)(0u));
            this.dtMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtMain.Size = new System.Drawing.Size(1184, 688);
            this.dtMain.TabIndex = 10;
            this.dtMain.OnDNTKeyDown += new Dynamsoft.DotNet.TWAIN.Delegate.OnDNTKeyDownHandler(this.dtMain_OnDNTKeyDown);
            this.dtMain.OnImageAreaSelected += new Dynamsoft.DotNet.TWAIN.Delegate.OnImageAreaSelectedHandler(this.dtMain_OnImageAreaSelected);
            this.dtMain.OnMouseClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseClickHandler(this.dtMain_OnMouseClick);
            this.dtMain.OnMouseRightClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseRightClickHandler(this.dtMain_OnMouseRightClick);
            this.dtMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtMain_KeyUp);
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(43, 34);
            this.nudHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(58, 22);
            this.nudHeight.TabIndex = 11;
            this.nudHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(135, 34);
            this.nudWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(60, 22);
            this.nudWidth.TabIndex = 12;
            this.nudWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // rbResize
            // 
            this.rbResize.AutoSize = true;
            this.rbResize.Location = new System.Drawing.Point(723, 21);
            this.rbResize.Name = "rbResize";
            this.rbResize.Size = new System.Drawing.Size(72, 21);
            this.rbResize.TabIndex = 13;
            this.rbResize.Text = "Resize";
            this.rbResize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "H:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "W:";
            // 
            // rbCrop
            // 
            this.rbCrop.AutoSize = true;
            this.rbCrop.Checked = true;
            this.rbCrop.Location = new System.Drawing.Point(655, 21);
            this.rbCrop.Name = "rbCrop";
            this.rbCrop.Size = new System.Drawing.Size(59, 21);
            this.rbCrop.TabIndex = 16;
            this.rbCrop.TabStop = true;
            this.rbCrop.Text = "Crop";
            this.rbCrop.UseVisualStyleBackColor = true;
            this.rbCrop.CheckedChanged += new System.EventHandler(this.rbCrop_CheckedChanged);
            // 
            // dtwainImagelist
            // 
            this.dtwainImagelist.AnnotationFillColor = System.Drawing.Color.White;
            this.dtwainImagelist.AnnotationPen = null;
            this.dtwainImagelist.AnnotationTextColor = System.Drawing.Color.Black;
            this.dtwainImagelist.AnnotationTextFont = null;
            this.dtwainImagelist.AutoScroll = true;
            this.dtwainImagelist.IfShowCancelDialogWhenImageTransfer = false;
            this.dtwainImagelist.IfThrowException = false;
            this.dtwainImagelist.Location = new System.Drawing.Point(3, 65);
            this.dtwainImagelist.LogLevel = ((short)(0));
            this.dtwainImagelist.Name = "dtwainImagelist";
            this.dtwainImagelist.PDFConvertMode = Dynamsoft.DotNet.TWAIN.Enums.EnumPDFConvertMode.enumCM_DEFAULT;
            this.dtwainImagelist.PDFMarginBottom = ((uint)(0u));
            this.dtwainImagelist.PDFMarginLeft = ((uint)(0u));
            this.dtwainImagelist.PDFMarginRight = ((uint)(0u));
            this.dtwainImagelist.PDFMarginTop = ((uint)(0u));
            this.dtwainImagelist.PDFXConformance = ((uint)(0u));
            this.dtwainImagelist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtwainImagelist.Size = new System.Drawing.Size(200, 694);
            this.dtwainImagelist.TabIndex = 10;
            this.dtwainImagelist.OnMouseClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseClickHandler(this.dtwainImagelist_OnMouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnOpenImageFolder);
            this.panel2.Controls.Add(this.rbCrop);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rbResize);
            this.panel2.Controls.Add(this.nudHeight);
            this.panel2.Controls.Add(this.nudWidth);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1416, 59);
            this.panel2.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 813);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtwainImagelist);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Cropper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbImageList;
        private System.Windows.Forms.Button btnOpenImageFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.RadioButton rbResize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbCrop;
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dtwainImagelist;
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dtMain;
        private System.Windows.Forms.Panel panel2;
    }
}

