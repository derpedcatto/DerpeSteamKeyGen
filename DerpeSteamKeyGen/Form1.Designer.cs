﻿namespace DerpeSteamKeyGen
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Button_GenerateKey = new System.Windows.Forms.Button();
            this.MainFormStrip = new System.Windows.Forms.MenuStrip();
            this.StripMenu_SavedKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_OpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_ChangeDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_ClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_Background = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_White = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_PickColor = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_Gradient = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_SaulGoodman = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_Derpe = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_WawusWithBalloon = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenu_Links = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_Github = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBox_Key = new System.Windows.Forms.TextBox();
            this.Flag_CopyToBuffer = new System.Windows.Forms.CheckBox();
            this.Flag_SaveToFile = new System.Windows.Forms.CheckBox();
            this.DerpeLeft = new System.Windows.Forms.PictureBox();
            this.DerpeRight = new System.Windows.Forms.PictureBox();
            this.PictureBox_SaulGoodman = new System.Windows.Forms.PictureBox();
            this.PictureBox_WawusWithBalloon = new System.Windows.Forms.PictureBox();
            this.StripMenuItem_ResetPathToDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DerpeLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DerpeRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_SaulGoodman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_WawusWithBalloon)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_GenerateKey
            // 
            this.Button_GenerateKey.Location = new System.Drawing.Point(39, 87);
            this.Button_GenerateKey.Name = "Button_GenerateKey";
            this.Button_GenerateKey.Size = new System.Drawing.Size(142, 27);
            this.Button_GenerateKey.TabIndex = 1;
            this.Button_GenerateKey.Text = "Generate Key";
            this.Button_GenerateKey.UseVisualStyleBackColor = true;
            this.Button_GenerateKey.Click += new System.EventHandler(this.Button_GenerateKey_Click);
            // 
            // MainFormStrip
            // 
            this.MainFormStrip.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MainFormStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenu_SavedKeys,
            this.backgroundToolStripMenuItem,
            this.StripMenu_Links});
            this.MainFormStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormStrip.Name = "MainFormStrip";
            this.MainFormStrip.Size = new System.Drawing.Size(219, 24);
            this.MainFormStrip.TabIndex = 1;
            this.MainFormStrip.Text = "menuStrip1";
            // 
            // StripMenu_SavedKeys
            // 
            this.StripMenu_SavedKeys.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripMenu_SavedKeys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItem_OpenFile,
            this.StripMenuItem_OpenDirectory,
            this.StripMenuItem_ChangeDirectory,
            this.StripMenuItem_ClearAll,
            this.StripMenuItem_ResetPathToDefault});
            this.StripMenu_SavedKeys.Name = "StripMenu_SavedKeys";
            this.StripMenu_SavedKeys.Size = new System.Drawing.Size(77, 20);
            this.StripMenu_SavedKeys.Text = "Saved Keys";
            // 
            // StripMenuItem_OpenFile
            // 
            this.StripMenuItem_OpenFile.Name = "StripMenuItem_OpenFile";
            this.StripMenuItem_OpenFile.Size = new System.Drawing.Size(185, 22);
            this.StripMenuItem_OpenFile.Text = "Open File";
            this.StripMenuItem_OpenFile.Click += new System.EventHandler(this.StripMenuItem_OpenFile_Click);
            // 
            // StripMenuItem_OpenDirectory
            // 
            this.StripMenuItem_OpenDirectory.Name = "StripMenuItem_OpenDirectory";
            this.StripMenuItem_OpenDirectory.Size = new System.Drawing.Size(185, 22);
            this.StripMenuItem_OpenDirectory.Text = "Open Directory";
            this.StripMenuItem_OpenDirectory.Click += new System.EventHandler(this.StripMenuItem_OpenDirectory_Click);
            // 
            // StripMenuItem_ChangeDirectory
            // 
            this.StripMenuItem_ChangeDirectory.Name = "StripMenuItem_ChangeDirectory";
            this.StripMenuItem_ChangeDirectory.Size = new System.Drawing.Size(185, 22);
            this.StripMenuItem_ChangeDirectory.Text = "Change Directory";
            this.StripMenuItem_ChangeDirectory.Click += new System.EventHandler(this.StripMenuItem_ChangeDirectory_Click);
            // 
            // StripMenuItem_ClearAll
            // 
            this.StripMenuItem_ClearAll.Name = "StripMenuItem_ClearAll";
            this.StripMenuItem_ClearAll.Size = new System.Drawing.Size(185, 22);
            this.StripMenuItem_ClearAll.Text = "Clear All";
            this.StripMenuItem_ClearAll.Click += new System.EventHandler(this.StripMenuItem_ClearAll_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItem_Background,
            this.StripMenuItem_Derpe,
            this.StripMenuItem_WawusWithBalloon});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(30, 20);
            this.backgroundToolStripMenuItem.Text = "UI";
            // 
            // StripMenuItem_Background
            // 
            this.StripMenuItem_Background.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItem_White,
            this.StripMenuItem_PickColor,
            this.StripMenuItem_Gradient,
            this.StripMenuItem_SaulGoodman});
            this.StripMenuItem_Background.Name = "StripMenuItem_Background";
            this.StripMenuItem_Background.Size = new System.Drawing.Size(183, 22);
            this.StripMenuItem_Background.Text = "Background";
            // 
            // StripMenuItem_White
            // 
            this.StripMenuItem_White.Name = "StripMenuItem_White";
            this.StripMenuItem_White.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_White.Text = "White";
            this.StripMenuItem_White.Click += new System.EventHandler(this.StripMenuItem_White_Click);
            // 
            // StripMenuItem_PickColor
            // 
            this.StripMenuItem_PickColor.Name = "StripMenuItem_PickColor";
            this.StripMenuItem_PickColor.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_PickColor.Text = "Pick Color";
            this.StripMenuItem_PickColor.Click += new System.EventHandler(this.StripMenuItem_PickColor_Click);
            // 
            // StripMenuItem_Gradient
            // 
            this.StripMenuItem_Gradient.Name = "StripMenuItem_Gradient";
            this.StripMenuItem_Gradient.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_Gradient.Text = "Gradient";
            this.StripMenuItem_Gradient.Click += new System.EventHandler(this.StripMenuItem_Gradient_Click);
            // 
            // StripMenuItem_SaulGoodman
            // 
            this.StripMenuItem_SaulGoodman.Name = "StripMenuItem_SaulGoodman";
            this.StripMenuItem_SaulGoodman.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_SaulGoodman.Text = "Saul Goodman";
            this.StripMenuItem_SaulGoodman.Click += new System.EventHandler(this.StripMenuItem_SaulGoodman_Click);
            // 
            // StripMenuItem_Derpe
            // 
            this.StripMenuItem_Derpe.Name = "StripMenuItem_Derpe";
            this.StripMenuItem_Derpe.Size = new System.Drawing.Size(183, 22);
            this.StripMenuItem_Derpe.Text = "Derpe";
            this.StripMenuItem_Derpe.Click += new System.EventHandler(this.StripMenuItem_Derpe_Click);
            // 
            // StripMenuItem_WawusWithBalloon
            // 
            this.StripMenuItem_WawusWithBalloon.Name = "StripMenuItem_WawusWithBalloon";
            this.StripMenuItem_WawusWithBalloon.Size = new System.Drawing.Size(183, 22);
            this.StripMenuItem_WawusWithBalloon.Text = "Wawus With Balloon";
            this.StripMenuItem_WawusWithBalloon.Click += new System.EventHandler(this.StripMenuItem_WawusWithBalloon_Click);
            // 
            // StripMenu_Links
            // 
            this.StripMenu_Links.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItem_Github});
            this.StripMenu_Links.Name = "StripMenu_Links";
            this.StripMenu_Links.Size = new System.Drawing.Size(46, 20);
            this.StripMenu_Links.Text = "Links";
            // 
            // StripMenuItem_Github
            // 
            this.StripMenuItem_Github.Image = ((System.Drawing.Image)(resources.GetObject("StripMenuItem_Github.Image")));
            this.StripMenuItem_Github.Name = "StripMenuItem_Github";
            this.StripMenuItem_Github.Size = new System.Drawing.Size(110, 22);
            this.StripMenuItem_Github.Text = "Github";
            this.StripMenuItem_Github.Click += new System.EventHandler(this.StripMenuItem_Github_Click);
            // 
            // TextBox_Key
            // 
            this.TextBox_Key.Location = new System.Drawing.Point(39, 58);
            this.TextBox_Key.MaxLength = 17;
            this.TextBox_Key.Name = "TextBox_Key";
            this.TextBox_Key.ReadOnly = true;
            this.TextBox_Key.Size = new System.Drawing.Size(142, 23);
            this.TextBox_Key.TabIndex = 2;
            this.TextBox_Key.Text = "AAAAA-BBBBB-CCCCC";
            this.TextBox_Key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Flag_CopyToBuffer
            // 
            this.Flag_CopyToBuffer.AutoSize = true;
            this.Flag_CopyToBuffer.Checked = true;
            this.Flag_CopyToBuffer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Flag_CopyToBuffer.Location = new System.Drawing.Point(56, 120);
            this.Flag_CopyToBuffer.Name = "Flag_CopyToBuffer";
            this.Flag_CopyToBuffer.Size = new System.Drawing.Size(104, 19);
            this.Flag_CopyToBuffer.TabIndex = 3;
            this.Flag_CopyToBuffer.TabStop = false;
            this.Flag_CopyToBuffer.Text = "Copy To Buffer";
            this.Flag_CopyToBuffer.UseVisualStyleBackColor = true;
            // 
            // Flag_SaveToFile
            // 
            this.Flag_SaveToFile.AutoSize = true;
            this.Flag_SaveToFile.Checked = true;
            this.Flag_SaveToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Flag_SaveToFile.Location = new System.Drawing.Point(56, 145);
            this.Flag_SaveToFile.Name = "Flag_SaveToFile";
            this.Flag_SaveToFile.Size = new System.Drawing.Size(86, 19);
            this.Flag_SaveToFile.TabIndex = 4;
            this.Flag_SaveToFile.TabStop = false;
            this.Flag_SaveToFile.Text = "Save To File";
            this.Flag_SaveToFile.UseVisualStyleBackColor = true;
            // 
            // DerpeLeft
            // 
            this.DerpeLeft.Image = ((System.Drawing.Image)(resources.GetObject("DerpeLeft.Image")));
            this.DerpeLeft.Location = new System.Drawing.Point(-3, 150);
            this.DerpeLeft.Name = "DerpeLeft";
            this.DerpeLeft.Size = new System.Drawing.Size(50, 55);
            this.DerpeLeft.TabIndex = 5;
            this.DerpeLeft.TabStop = false;
            this.DerpeLeft.Visible = false;
            // 
            // DerpeRight
            // 
            this.DerpeRight.Image = ((System.Drawing.Image)(resources.GetObject("DerpeRight.Image")));
            this.DerpeRight.Location = new System.Drawing.Point(167, 150);
            this.DerpeRight.Name = "DerpeRight";
            this.DerpeRight.Size = new System.Drawing.Size(52, 55);
            this.DerpeRight.TabIndex = 6;
            this.DerpeRight.TabStop = false;
            this.DerpeRight.Visible = false;
            // 
            // PictureBox_SaulGoodman
            // 
            this.PictureBox_SaulGoodman.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_SaulGoodman.Image")));
            this.PictureBox_SaulGoodman.Location = new System.Drawing.Point(0, 27);
            this.PictureBox_SaulGoodman.Name = "PictureBox_SaulGoodman";
            this.PictureBox_SaulGoodman.Size = new System.Drawing.Size(219, 178);
            this.PictureBox_SaulGoodman.TabIndex = 7;
            this.PictureBox_SaulGoodman.TabStop = false;
            // 
            // PictureBox_WawusWithBalloon
            // 
            this.PictureBox_WawusWithBalloon.BackColor = System.Drawing.SystemColors.Control;
            this.PictureBox_WawusWithBalloon.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_WawusWithBalloon.Image")));
            this.PictureBox_WawusWithBalloon.Location = new System.Drawing.Point(187, 27);
            this.PictureBox_WawusWithBalloon.Name = "PictureBox_WawusWithBalloon";
            this.PictureBox_WawusWithBalloon.Size = new System.Drawing.Size(47, 86);
            this.PictureBox_WawusWithBalloon.TabIndex = 8;
            this.PictureBox_WawusWithBalloon.TabStop = false;
            this.PictureBox_WawusWithBalloon.Visible = false;
            // 
            // StripMenuItem_ResetPathToDefault
            // 
            this.StripMenuItem_ResetPathToDefault.Name = "StripMenuItem_ResetPathToDefault";
            this.StripMenuItem_ResetPathToDefault.Size = new System.Drawing.Size(185, 22);
            this.StripMenuItem_ResetPathToDefault.Text = "Reset Path To Default";
            this.StripMenuItem_ResetPathToDefault.Click += new System.EventHandler(this.StripMenuItem_ResetPathToDefault_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(219, 206);
            this.Controls.Add(this.PictureBox_WawusWithBalloon);
            this.Controls.Add(this.DerpeRight);
            this.Controls.Add(this.DerpeLeft);
            this.Controls.Add(this.Flag_SaveToFile);
            this.Controls.Add(this.Flag_CopyToBuffer);
            this.Controls.Add(this.TextBox_Key);
            this.Controls.Add(this.Button_GenerateKey);
            this.Controls.Add(this.MainFormStrip);
            this.Controls.Add(this.PictureBox_SaulGoodman);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Derpe Steam Key Gen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_OnFormClosed);
            this.Load += new System.EventHandler(this.MainForm_OnFormLoad);
            this.MainFormStrip.ResumeLayout(false);
            this.MainFormStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DerpeLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DerpeRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_SaulGoodman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_WawusWithBalloon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Button_GenerateKey;
        private MenuStrip MainFormStrip;
        private ToolStripMenuItem StripMenu_SavedKeys;
        private ToolStripMenuItem StripMenuItem_OpenFile;
        private ToolStripMenuItem StripMenuItem_OpenDirectory;
        private ToolStripMenuItem StripMenuItem_ClearAll;
        private ToolStripMenuItem StripMenu_Links;
        private ToolStripMenuItem StripMenuItem_Github;
        private TextBox TextBox_Key;
        private CheckBox Flag_CopyToBuffer;
        private CheckBox Flag_SaveToFile;
        private ToolStripMenuItem StripMenuItem_ChangeDirectory;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripMenuItem StripMenuItem_Background;
        private PictureBox DerpeLeft;
        private PictureBox DerpeRight;
        private ToolStripMenuItem StripMenuItem_Derpe;
        private ToolStripMenuItem StripMenuItem_White;
        private ToolStripMenuItem StripMenuItem_Gradient;
        private ToolStripMenuItem StripMenuItem_SaulGoodman;
        private ToolStripMenuItem StripMenuItem_PickColor;
        private PictureBox PictureBox_SaulGoodman;
        private ToolStripMenuItem StripMenuItem_WawusWithBalloon;
        private PictureBox PictureBox_WawusWithBalloon;
        private ToolStripMenuItem StripMenuItem_ResetPathToDefault;
    }
}