namespace ViewCullling
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChooseOfGoodChip = new System.Windows.Forms.Button();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBКомпонентаОбразцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChooseFolderWithTest = new System.Windows.Forms.Button();
            this.gbBtnChoose = new System.Windows.Forms.GroupBox();
            this.btnStartTesting = new System.Windows.Forms.Button();
            this.lblPathToTestFolder = new System.Windows.Forms.Label();
            this.lblPathToGoodChip = new System.Windows.Forms.Label();
            this.gpTesting = new System.Windows.Forms.GroupBox();
            this.dgvTestingOfChips = new System.Windows.Forms.DataGridView();
            this.msMain.SuspendLayout();
            this.gbBtnChoose.SuspendLayout();
            this.gpTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestingOfChips)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseOfGoodChip
            // 
            this.btnChooseOfGoodChip.Location = new System.Drawing.Point(17, 25);
            this.btnChooseOfGoodChip.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseOfGoodChip.Name = "btnChooseOfGoodChip";
            this.btnChooseOfGoodChip.Size = new System.Drawing.Size(174, 28);
            this.btnChooseOfGoodChip.TabIndex = 0;
            this.btnChooseOfGoodChip.Text = "Выбрать образец годного чипа";
            this.btnChooseOfGoodChip.UseVisualStyleBackColor = true;
            this.btnChooseOfGoodChip.Click += new System.EventHandler(this.btnChooseOfGoodChip_Click);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.анализToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.msMain.Size = new System.Drawing.Size(1173, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "msMain";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // анализToolStripMenuItem
            // 
            this.анализToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBКомпонентаОбразцаToolStripMenuItem});
            this.анализToolStripMenuItem.Name = "анализToolStripMenuItem";
            this.анализToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.анализToolStripMenuItem.Text = "Анализ";
            // 
            // rGBКомпонентаОбразцаToolStripMenuItem
            // 
            this.rGBКомпонентаОбразцаToolStripMenuItem.Name = "rGBКомпонентаОбразцаToolStripMenuItem";
            this.rGBКомпонентаОбразцаToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.rGBКомпонентаОбразцаToolStripMenuItem.Text = "RGB компонента образца";
            this.rGBКомпонентаОбразцаToolStripMenuItem.Click += new System.EventHandler(this.rGBКомпонентаОбразцаToolStripMenuItem_Click);
            // 
            // btnChooseFolderWithTest
            // 
            this.btnChooseFolderWithTest.Location = new System.Drawing.Point(17, 90);
            this.btnChooseFolderWithTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseFolderWithTest.Name = "btnChooseFolderWithTest";
            this.btnChooseFolderWithTest.Size = new System.Drawing.Size(174, 44);
            this.btnChooseFolderWithTest.TabIndex = 2;
            this.btnChooseFolderWithTest.Text = "Выбрать папку с чипами для проверки";
            this.btnChooseFolderWithTest.UseVisualStyleBackColor = true;
            this.btnChooseFolderWithTest.Click += new System.EventHandler(this.btnChooseFolderWithTest_Click);
            // 
            // gbBtnChoose
            // 
            this.gbBtnChoose.AutoSize = true;
            this.gbBtnChoose.Controls.Add(this.btnStartTesting);
            this.gbBtnChoose.Controls.Add(this.lblPathToTestFolder);
            this.gbBtnChoose.Controls.Add(this.lblPathToGoodChip);
            this.gbBtnChoose.Controls.Add(this.btnChooseFolderWithTest);
            this.gbBtnChoose.Controls.Add(this.btnChooseOfGoodChip);
            this.gbBtnChoose.Location = new System.Drawing.Point(6, 26);
            this.gbBtnChoose.Margin = new System.Windows.Forms.Padding(2);
            this.gbBtnChoose.Name = "gbBtnChoose";
            this.gbBtnChoose.Padding = new System.Windows.Forms.Padding(2);
            this.gbBtnChoose.Size = new System.Drawing.Size(202, 646);
            this.gbBtnChoose.TabIndex = 3;
            this.gbBtnChoose.TabStop = false;
            this.gbBtnChoose.Text = "Обзор файлов";
            // 
            // btnStartTesting
            // 
            this.btnStartTesting.Location = new System.Drawing.Point(17, 600);
            this.btnStartTesting.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartTesting.Name = "btnStartTesting";
            this.btnStartTesting.Size = new System.Drawing.Size(174, 29);
            this.btnStartTesting.TabIndex = 5;
            this.btnStartTesting.Text = "Старт!";
            this.btnStartTesting.UseVisualStyleBackColor = true;
            this.btnStartTesting.Click += new System.EventHandler(this.btnStartTesting_Click);
            // 
            // lblPathToTestFolder
            // 
            this.lblPathToTestFolder.AutoSize = true;
            this.lblPathToTestFolder.Location = new System.Drawing.Point(14, 144);
            this.lblPathToTestFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPathToTestFolder.Name = "lblPathToTestFolder";
            this.lblPathToTestFolder.Size = new System.Drawing.Size(66, 13);
            this.lblPathToTestFolder.TabIndex = 4;
            this.lblPathToTestFolder.Text = "<undefined>";
            // 
            // lblPathToGoodChip
            // 
            this.lblPathToGoodChip.AutoSize = true;
            this.lblPathToGoodChip.Location = new System.Drawing.Point(14, 60);
            this.lblPathToGoodChip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPathToGoodChip.Name = "lblPathToGoodChip";
            this.lblPathToGoodChip.Size = new System.Drawing.Size(66, 13);
            this.lblPathToGoodChip.TabIndex = 3;
            this.lblPathToGoodChip.Text = "<undefined>";
            // 
            // gpTesting
            // 
            this.gpTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTesting.AutoSize = true;
            this.gpTesting.Controls.Add(this.dgvTestingOfChips);
            this.gpTesting.Location = new System.Drawing.Point(220, 26);
            this.gpTesting.Margin = new System.Windows.Forms.Padding(2);
            this.gpTesting.Name = "gpTesting";
            this.gpTesting.Padding = new System.Windows.Forms.Padding(2);
            this.gpTesting.Size = new System.Drawing.Size(942, 646);
            this.gpTesting.TabIndex = 4;
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
            this.dgvTestingOfChips.Location = new System.Drawing.Point(17, 19);
            this.dgvTestingOfChips.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTestingOfChips.Name = "dgvTestingOfChips";
            this.dgvTestingOfChips.RowTemplate.Height = 33;
            this.dgvTestingOfChips.Size = new System.Drawing.Size(921, 610);
            this.dgvTestingOfChips.TabIndex = 0;
            this.dgvTestingOfChips.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTestingOfChips_CellMouseDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1173, 676);
            this.Controls.Add(this.gpTesting);
            this.Controls.Add(this.gbBtnChoose);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "ViewCulling";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbBtnChoose.ResumeLayout(false);
            this.gbBtnChoose.PerformLayout();
            this.gpTesting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestingOfChips)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseOfGoodChip;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.Button btnChooseFolderWithTest;
        private System.Windows.Forms.GroupBox gbBtnChoose;
        private System.Windows.Forms.GroupBox gpTesting;
        private System.Windows.Forms.DataGridView dgvTestingOfChips;
        private System.Windows.Forms.Label lblPathToTestFolder;
        private System.Windows.Forms.Label lblPathToGoodChip;
        private System.Windows.Forms.Button btnStartTesting;
        private System.Windows.Forms.ToolStripMenuItem анализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBКомпонентаОбразцаToolStripMenuItem;

    }
}

