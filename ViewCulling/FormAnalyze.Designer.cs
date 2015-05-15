namespace ViewCulling
{
    partial class FormAnalyze
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalyze));
            this.gpTesting = new System.Windows.Forms.GroupBox();
            this.dgvTestingOfChips = new System.Windows.Forms.DataGridView();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьПроектОтбраковкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускАнализаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.картаРаскрояToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPathToTestFolder = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProjectOfCulling = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCullingPattern = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.gpTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestingOfChips)).BeginInit();
            this.msMain.SuspendLayout();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
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
            this.gpTesting.Location = new System.Drawing.Point(11, 28);
            this.gpTesting.Margin = new System.Windows.Forms.Padding(2);
            this.gpTesting.Name = "gpTesting";
            this.gpTesting.Padding = new System.Windows.Forms.Padding(2);
            this.gpTesting.Size = new System.Drawing.Size(942, 490);
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
            this.dgvTestingOfChips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTestingOfChips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestingOfChips.Location = new System.Drawing.Point(13, 23);
            this.dgvTestingOfChips.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTestingOfChips.Name = "dgvTestingOfChips";
            this.dgvTestingOfChips.ReadOnly = true;
            this.dgvTestingOfChips.RowTemplate.Height = 33;
            this.dgvTestingOfChips.Size = new System.Drawing.Size(916, 458);
            this.dgvTestingOfChips.TabIndex = 0;
            this.dgvTestingOfChips.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestingOfChips_CellClick);
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.запускАнализаToolStripMenuItem,
            this.картаРаскрояToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(964, 26);
            this.msMain.TabIndex = 7;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьПроектОтбраковкиToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьПроектОтбраковкиToolStripMenuItem
            // 
            this.открытьПроектОтбраковкиToolStripMenuItem.Name = "открытьПроектОтбраковкиToolStripMenuItem";
            this.открытьПроектОтбраковкиToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.открытьПроектОтбраковкиToolStripMenuItem.Text = "Открыть проект отбраковки";
            this.открытьПроектОтбраковкиToolStripMenuItem.Click += new System.EventHandler(this.открытьПроектОтбраковкиToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.открытьToolStripMenuItem.Text = "Открыть файлы для анализа";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // запускАнализаToolStripMenuItem
            // 
            this.запускАнализаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стартToolStripMenuItem,
            this.остановкаToolStripMenuItem});
            this.запускАнализаToolStripMenuItem.Name = "запускАнализаToolStripMenuItem";
            this.запускАнализаToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.запускАнализаToolStripMenuItem.Text = "Визуальный контроль";
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.стартToolStripMenuItem.Text = "Запуск";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click);
            // 
            // остановкаToolStripMenuItem
            // 
            this.остановкаToolStripMenuItem.Name = "остановкаToolStripMenuItem";
            this.остановкаToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.остановкаToolStripMenuItem.Text = "Остановка";
            // 
            // картаРаскрояToolStripMenuItem
            // 
            this.картаРаскрояToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem1,
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem});
            this.картаРаскрояToolStripMenuItem.Name = "картаРаскрояToolStripMenuItem";
            this.картаРаскрояToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.картаРаскрояToolStripMenuItem.Text = "Карта раскроя";
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(302, 22);
            this.открытьToolStripMenuItem1.Text = "Открыть шаблон карты раскроя";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
            // 
            // сохранитьТекущуюКартуРаскрояToolStripMenuItem
            // 
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Name = "сохранитьТекущуюКартуРаскрояToolStripMenuItem";
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Text = "Сохранить текущую карту раскроя";
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Click += new System.EventHandler(this.сохранитьТекущуюКартуРаскрояToolStripMenuItem_Click);
            // 
            // lblPathToTestFolder
            // 
            this.lblPathToTestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPathToTestFolder.AutoSize = true;
            this.lblPathToTestFolder.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPathToTestFolder.Location = new System.Drawing.Point(238, 47);
            this.lblPathToTestFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPathToTestFolder.Name = "lblPathToTestFolder";
            this.lblPathToTestFolder.Size = new System.Drawing.Size(89, 18);
            this.lblPathToTestFolder.TabIndex = 8;
            this.lblPathToTestFolder.Text = "<undefined>";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(10, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Путь к тестируемым образцам: ";
            // 
            // lblProjectOfCulling
            // 
            this.lblProjectOfCulling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProjectOfCulling.AutoSize = true;
            this.lblProjectOfCulling.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProjectOfCulling.Location = new System.Drawing.Point(238, 23);
            this.lblProjectOfCulling.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProjectOfCulling.Name = "lblProjectOfCulling";
            this.lblProjectOfCulling.Size = new System.Drawing.Size(89, 18);
            this.lblProjectOfCulling.TabIndex = 10;
            this.lblProjectOfCulling.Text = "<undefined>";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label7.Location = new System.Drawing.Point(10, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Проект отбраковки :";
            // 
            // lblCullingPattern
            // 
            this.lblCullingPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCullingPattern.AutoSize = true;
            this.lblCullingPattern.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCullingPattern.Location = new System.Drawing.Point(238, 70);
            this.lblCullingPattern.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCullingPattern.Name = "lblCullingPattern";
            this.lblCullingPattern.Size = new System.Drawing.Size(89, 18);
            this.lblCullingPattern.TabIndex = 12;
            this.lblCullingPattern.Text = "<undefined>";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label9.Location = new System.Drawing.Point(10, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "Шаблон файла отбраковки :";
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbInfo.Controls.Add(this.label9);
            this.gbInfo.Controls.Add(this.lblPathToTestFolder);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.lblCullingPattern);
            this.gbInfo.Controls.Add(this.lblProjectOfCulling);
            this.gbInfo.Controls.Add(this.label7);
            this.gbInfo.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbInfo.Location = new System.Drawing.Point(11, 526);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(436, 98);
            this.gbInfo.TabIndex = 14;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация";
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.Location = new System.Drawing.Point(822, 526);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(130, 130);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 15;
            this.pbLoading.TabStop = false;
            // 
            // FormAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(964, 678);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gpTesting);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FormAnalyze";
            this.Text = "Визуальный контроль";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStartAnalyze_FormClosing);
            this.Load += new System.EventHandler(this.FormStartAnalyze_Load);
            this.gpTesting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestingOfChips)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpTesting;
        private System.Windows.Forms.DataGridView dgvTestingOfChips;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускАнализаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьПроектОтбраковкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem картаРаскрояToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem остановкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьТекущуюКартуРаскрояToolStripMenuItem;
        private System.Windows.Forms.Label lblPathToTestFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProjectOfCulling;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCullingPattern;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.PictureBox pbLoading;
    }
}