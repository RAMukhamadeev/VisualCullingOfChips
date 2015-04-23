﻿namespace ViewCullling
{
    partial class FormStartAnalyze
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartAnalyze));
            this.gpTesting = new System.Windows.Forms.GroupBox();
            this.dgvTestingOfChips = new System.Windows.Forms.DataGridView();
            this.btnStartTesting = new System.Windows.Forms.Button();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPathToTestFolder = new System.Windows.Forms.Label();
            this.gpTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestingOfChips)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpTesting
            // 
            this.gpTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTesting.AutoSize = true;
            this.gpTesting.Controls.Add(this.dgvTestingOfChips);
            this.gpTesting.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpTesting.Location = new System.Drawing.Point(22, 70);
            this.gpTesting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpTesting.Name = "gpTesting";
            this.gpTesting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpTesting.Size = new System.Drawing.Size(1908, 1362);
            this.gpTesting.TabIndex = 5;
            this.gpTesting.TabStop = false;
            this.gpTesting.Text = "Проверка чипов";
            // 
            // dgvTestingOfChips
            // 
            this.dgvTestingOfChips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTestingOfChips.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTestingOfChips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestingOfChips.Location = new System.Drawing.Point(28, 46);
            this.dgvTestingOfChips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTestingOfChips.Name = "dgvTestingOfChips";
            this.dgvTestingOfChips.RowTemplate.Height = 33;
            this.dgvTestingOfChips.Size = new System.Drawing.Size(1852, 1290);
            this.dgvTestingOfChips.TabIndex = 0;
            this.dgvTestingOfChips.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTestingOfChips_CellMouseDoubleClick);
            // 
            // btnStartTesting
            // 
            this.btnStartTesting.Location = new System.Drawing.Point(882, 1456);
            this.btnStartTesting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartTesting.Name = "btnStartTesting";
            this.btnStartTesting.Size = new System.Drawing.Size(348, 58);
            this.btnStartTesting.TabIndex = 6;
            this.btnStartTesting.Text = "Старт!";
            this.btnStartTesting.UseVisualStyleBackColor = true;
            this.btnStartTesting.Click += new System.EventHandler(this.btnStartTesting_Click);
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(1952, 48);
            this.msMain.TabIndex = 7;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem,
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(513, 40);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(513, 40);
            this.открытьToolStripMenuItem.Text = "Открыть набор для тестирования";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // lblPathToTestFolder
            // 
            this.lblPathToTestFolder.AutoSize = true;
            this.lblPathToTestFolder.Location = new System.Drawing.Point(22, 1456);
            this.lblPathToTestFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPathToTestFolder.Name = "lblPathToTestFolder";
            this.lblPathToTestFolder.Size = new System.Drawing.Size(131, 25);
            this.lblPathToTestFolder.TabIndex = 8;
            this.lblPathToTestFolder.Text = "<undefined>";
            // 
            // FormStartAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1952, 1540);
            this.Controls.Add(this.lblPathToTestFolder);
            this.Controls.Add(this.btnStartTesting);
            this.Controls.Add(this.gpTesting);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormStartAnalyze";
            this.Text = "FormStartAnalyze";
            this.Load += new System.EventHandler(this.FormStartAnalyze_Load);
            this.gpTesting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestingOfChips)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpTesting;
        private System.Windows.Forms.DataGridView dgvTestingOfChips;
        private System.Windows.Forms.Button btnStartTesting;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.Label lblPathToTestFolder;
    }
}