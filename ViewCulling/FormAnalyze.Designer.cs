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
            this.открытьКартуРаскрояToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автопрокруткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.калибровкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.порогСегментацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.коэффициентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNameOfTestFolder = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProjectOfCulling = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCullingPattern = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.gbStatistic = new System.Windows.Forms.GroupBox();
            this.lblCountOfFiles = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTimeOfCalculation = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCountOfBad = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCountOfGood = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPercentOfProgress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPercentOfOut = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCountOfCalced = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.gbInstruments = new System.Windows.Forms.GroupBox();
            this.pbSaveMap = new System.Windows.Forms.PictureBox();
            this.pbOpenMap = new System.Windows.Forms.PictureBox();
            this.pbChooseFolder = new System.Windows.Forms.PictureBox();
            this.pbChooseCullingProject = new System.Windows.Forms.PictureBox();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.pbStart = new System.Windows.Forms.PictureBox();
            this.gpTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestingOfChips)).BeginInit();
            this.msMain.SuspendLayout();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.gbStatistic.SuspendLayout();
            this.gbInstruments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChooseFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChooseCullingProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
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
            this.gpTesting.Location = new System.Drawing.Point(12, 62);
            this.gpTesting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpTesting.Name = "gpTesting";
            this.gpTesting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpTesting.Size = new System.Drawing.Size(1110, 938);
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
            this.dgvTestingOfChips.Location = new System.Drawing.Point(8, 44);
            this.dgvTestingOfChips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTestingOfChips.Name = "dgvTestingOfChips";
            this.dgvTestingOfChips.ReadOnly = true;
            this.dgvTestingOfChips.RowTemplate.Height = 33;
            this.dgvTestingOfChips.Size = new System.Drawing.Size(1066, 874);
            this.dgvTestingOfChips.TabIndex = 0;
            this.dgvTestingOfChips.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTestingOfChips_CellMouseDoubleClick);
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.запускАнализаToolStripMenuItem,
            this.картаРаскрояToolStripMenuItem,
            this.видToolStripMenuItem,
            this.калибровкаToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(1722, 48);
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
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьПроектОтбраковкиToolStripMenuItem
            // 
            this.открытьПроектОтбраковкиToolStripMenuItem.Name = "открытьПроектОтбраковкиToolStripMenuItem";
            this.открытьПроектОтбраковкиToolStripMenuItem.Size = new System.Drawing.Size(448, 40);
            this.открытьПроектОтбраковкиToolStripMenuItem.Text = "Открыть проект отбраковки";
            this.открытьПроектОтбраковкиToolStripMenuItem.Click += new System.EventHandler(this.открытьПроектОтбраковкиToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(448, 40);
            this.открытьToolStripMenuItem.Text = "Открыть файлы для анализа";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(448, 40);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // запускАнализаToolStripMenuItem
            // 
            this.запускАнализаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стартToolStripMenuItem,
            this.остановкаToolStripMenuItem});
            this.запускАнализаToolStripMenuItem.Name = "запускАнализаToolStripMenuItem";
            this.запускАнализаToolStripMenuItem.Size = new System.Drawing.Size(300, 40);
            this.запускАнализаToolStripMenuItem.Text = "Визуальный контроль";
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(223, 40);
            this.стартToolStripMenuItem.Text = "Запуск";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click);
            // 
            // остановкаToolStripMenuItem
            // 
            this.остановкаToolStripMenuItem.Name = "остановкаToolStripMenuItem";
            this.остановкаToolStripMenuItem.Size = new System.Drawing.Size(223, 40);
            this.остановкаToolStripMenuItem.Text = "Остановка";
            this.остановкаToolStripMenuItem.Click += new System.EventHandler(this.остановкаToolStripMenuItem_Click);
            // 
            // картаРаскрояToolStripMenuItem
            // 
            this.картаРаскрояToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem1,
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem,
            this.открытьКартуРаскрояToolStripMenuItem});
            this.картаРаскрояToolStripMenuItem.Name = "картаРаскрояToolStripMenuItem";
            this.картаРаскрояToolStripMenuItem.Size = new System.Drawing.Size(211, 40);
            this.картаРаскрояToolStripMenuItem.Text = "Карта раскроя";
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(529, 40);
            this.открытьToolStripMenuItem1.Text = "Открыть шаблон карты раскроя";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
            // 
            // сохранитьТекущуюКартуРаскрояToolStripMenuItem
            // 
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Name = "сохранитьТекущуюКартуРаскрояToolStripMenuItem";
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Size = new System.Drawing.Size(529, 40);
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Text = "Сохранить текущую карту раскроя";
            this.сохранитьТекущуюКартуРаскрояToolStripMenuItem.Click += new System.EventHandler(this.сохранитьТекущуюКартуРаскрояToolStripMenuItem_Click);
            // 
            // открытьКартуРаскрояToolStripMenuItem
            // 
            this.открытьКартуРаскрояToolStripMenuItem.Name = "открытьКартуРаскрояToolStripMenuItem";
            this.открытьКартуРаскрояToolStripMenuItem.Size = new System.Drawing.Size(529, 40);
            this.открытьКартуРаскрояToolStripMenuItem.Text = "Открыть форму карту раскроя";
            this.открытьКартуРаскрояToolStripMenuItem.Click += new System.EventHandler(this.открытьКартуРаскрояToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.автопрокруткаToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(75, 40);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // автопрокруткаToolStripMenuItem
            // 
            this.автопрокруткаToolStripMenuItem.Name = "автопрокруткаToolStripMenuItem";
            this.автопрокруткаToolStripMenuItem.Size = new System.Drawing.Size(282, 40);
            this.автопрокруткаToolStripMenuItem.Text = "Автопрокрутка";
            this.автопрокруткаToolStripMenuItem.Click += new System.EventHandler(this.автопрокруткаToolStripMenuItem_Click);
            // 
            // калибровкаToolStripMenuItem
            // 
            this.калибровкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.порогСегментацииToolStripMenuItem,
            this.коэффициентыToolStripMenuItem});
            this.калибровкаToolStripMenuItem.Name = "калибровкаToolStripMenuItem";
            this.калибровкаToolStripMenuItem.Size = new System.Drawing.Size(162, 40);
            this.калибровкаToolStripMenuItem.Text = "Настройки";
            // 
            // порогСегментацииToolStripMenuItem
            // 
            this.порогСегментацииToolStripMenuItem.Name = "порогСегментацииToolStripMenuItem";
            this.порогСегментацииToolStripMenuItem.Size = new System.Drawing.Size(240, 40);
            this.порогСегментацииToolStripMenuItem.Text = "Калибровка";
            this.порогСегментацииToolStripMenuItem.Click += new System.EventHandler(this.порогСегментацииToolStripMenuItem_Click);
            // 
            // коэффициентыToolStripMenuItem
            // 
            this.коэффициентыToolStripMenuItem.Name = "коэффициентыToolStripMenuItem";
            this.коэффициентыToolStripMenuItem.Size = new System.Drawing.Size(240, 40);
            this.коэффициентыToolStripMenuItem.Text = "Параметры";
            this.коэффициентыToolStripMenuItem.Click += new System.EventHandler(this.коэффициентыToolStripMenuItem_Click);
            // 
            // lblNameOfTestFolder
            // 
            this.lblNameOfTestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameOfTestFolder.AutoSize = true;
            this.lblNameOfTestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNameOfTestFolder.Location = new System.Drawing.Point(28, 196);
            this.lblNameOfTestFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameOfTestFolder.Name = "lblNameOfTestFolder";
            this.lblNameOfTestFolder.Size = new System.Drawing.Size(159, 29);
            this.lblNameOfTestFolder.TabIndex = 8;
            this.lblNameOfTestFolder.Text = "<undefined>";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(26, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(487, 37);
            this.label5.TabIndex = 9;
            this.label5.Text = "Папка с тестируемыми образцами :";
            // 
            // lblProjectOfCulling
            // 
            this.lblProjectOfCulling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProjectOfCulling.AutoSize = true;
            this.lblProjectOfCulling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProjectOfCulling.Location = new System.Drawing.Point(28, 100);
            this.lblProjectOfCulling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectOfCulling.Name = "lblProjectOfCulling";
            this.lblProjectOfCulling.Size = new System.Drawing.Size(159, 29);
            this.lblProjectOfCulling.TabIndex = 10;
            this.lblProjectOfCulling.Text = "<undefined>";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label7.Location = new System.Drawing.Point(20, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 37);
            this.label7.TabIndex = 11;
            this.label7.Text = "Проект отбраковки :";
            // 
            // lblCullingPattern
            // 
            this.lblCullingPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCullingPattern.AutoSize = true;
            this.lblCullingPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCullingPattern.Location = new System.Drawing.Point(28, 296);
            this.lblCullingPattern.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCullingPattern.Name = "lblCullingPattern";
            this.lblCullingPattern.Size = new System.Drawing.Size(159, 29);
            this.lblCullingPattern.TabIndex = 12;
            this.lblCullingPattern.Text = "<undefined>";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label9.Location = new System.Drawing.Point(20, 250);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(336, 37);
            this.label9.TabIndex = 13;
            this.label9.Text = "Шаблон карты раскроя :";
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.label9);
            this.gbInfo.Controls.Add(this.lblNameOfTestFolder);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.lblCullingPattern);
            this.gbInfo.Controls.Add(this.lblProjectOfCulling);
            this.gbInfo.Controls.Add(this.label7);
            this.gbInfo.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbInfo.Location = new System.Drawing.Point(1132, 656);
            this.gbInfo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbInfo.Size = new System.Drawing.Size(572, 344);
            this.gbInfo.TabIndex = 14;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация";
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.Location = new System.Drawing.Point(344, 296);
            this.pbLoading.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(204, 198);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 15;
            this.pbLoading.TabStop = false;
            // 
            // gbStatistic
            // 
            this.gbStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatistic.Controls.Add(this.lblCountOfFiles);
            this.gbStatistic.Controls.Add(this.label13);
            this.gbStatistic.Controls.Add(this.lblTimeLeft);
            this.gbStatistic.Controls.Add(this.label10);
            this.gbStatistic.Controls.Add(this.lblTimeOfCalculation);
            this.gbStatistic.Controls.Add(this.label6);
            this.gbStatistic.Controls.Add(this.lblCountOfBad);
            this.gbStatistic.Controls.Add(this.label11);
            this.gbStatistic.Controls.Add(this.lblCountOfGood);
            this.gbStatistic.Controls.Add(this.label4);
            this.gbStatistic.Controls.Add(this.lblPercentOfProgress);
            this.gbStatistic.Controls.Add(this.label2);
            this.gbStatistic.Controls.Add(this.lblPercentOfOut);
            this.gbStatistic.Controls.Add(this.label8);
            this.gbStatistic.Controls.Add(this.lblCountOfCalced);
            this.gbStatistic.Controls.Add(this.label3);
            this.gbStatistic.Controls.Add(this.pbProgress);
            this.gbStatistic.Controls.Add(this.pbLoading);
            this.gbStatistic.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbStatistic.Location = new System.Drawing.Point(1128, 62);
            this.gbStatistic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbStatistic.Name = "gbStatistic";
            this.gbStatistic.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbStatistic.Size = new System.Drawing.Size(572, 584);
            this.gbStatistic.TabIndex = 16;
            this.gbStatistic.TabStop = false;
            this.gbStatistic.Text = "Статистика";
            // 
            // lblCountOfFiles
            // 
            this.lblCountOfFiles.AutoSize = true;
            this.lblCountOfFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountOfFiles.Location = new System.Drawing.Point(326, 44);
            this.lblCountOfFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountOfFiles.Name = "lblCountOfFiles";
            this.lblCountOfFiles.Size = new System.Drawing.Size(51, 33);
            this.lblCountOfFiles.TabIndex = 36;
            this.lblCountOfFiles.Text = "<>";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label13.Location = new System.Drawing.Point(40, 44);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(273, 37);
            this.label13.TabIndex = 35;
            this.label13.Text = "Количество чипов :";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeLeft.Location = new System.Drawing.Point(36, 410);
            this.lblTimeLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(51, 33);
            this.lblTimeLeft.TabIndex = 34;
            this.lblTimeLeft.Text = "<>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label10.Location = new System.Drawing.Point(34, 370);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 37);
            this.label10.TabIndex = 33;
            this.label10.Text = "Осталось :";
            // 
            // lblTimeOfCalculation
            // 
            this.lblTimeOfCalculation.AutoSize = true;
            this.lblTimeOfCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeOfCalculation.Location = new System.Drawing.Point(36, 324);
            this.lblTimeOfCalculation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeOfCalculation.Name = "lblTimeOfCalculation";
            this.lblTimeOfCalculation.Size = new System.Drawing.Size(51, 33);
            this.lblTimeOfCalculation.TabIndex = 32;
            this.lblTimeOfCalculation.Text = "<>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label6.Location = new System.Drawing.Point(34, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 37);
            this.label6.TabIndex = 31;
            this.label6.Text = "Время расчета :";
            // 
            // lblCountOfBad
            // 
            this.lblCountOfBad.AutoSize = true;
            this.lblCountOfBad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountOfBad.Location = new System.Drawing.Point(324, 182);
            this.lblCountOfBad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountOfBad.Name = "lblCountOfBad";
            this.lblCountOfBad.Size = new System.Drawing.Size(51, 33);
            this.lblCountOfBad.TabIndex = 30;
            this.lblCountOfBad.Text = "<>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label11.Location = new System.Drawing.Point(40, 182);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 37);
            this.label11.TabIndex = 29;
            this.label11.Text = "Не годные :";
            // 
            // lblCountOfGood
            // 
            this.lblCountOfGood.AutoSize = true;
            this.lblCountOfGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountOfGood.Location = new System.Drawing.Point(326, 136);
            this.lblCountOfGood.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountOfGood.Name = "lblCountOfGood";
            this.lblCountOfGood.Size = new System.Drawing.Size(51, 33);
            this.lblCountOfGood.TabIndex = 28;
            this.lblCountOfGood.Text = "<>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(40, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 37);
            this.label4.TabIndex = 27;
            this.label4.Text = "Годные :";
            // 
            // lblPercentOfProgress
            // 
            this.lblPercentOfProgress.AutoSize = true;
            this.lblPercentOfProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPercentOfProgress.Location = new System.Drawing.Point(188, 456);
            this.lblPercentOfProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentOfProgress.Name = "lblPercentOfProgress";
            this.lblPercentOfProgress.Size = new System.Drawing.Size(51, 33);
            this.lblPercentOfProgress.TabIndex = 26;
            this.lblPercentOfProgress.Text = "<>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(34, 456);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 37);
            this.label2.TabIndex = 25;
            this.label2.Text = "Прогресс :";
            // 
            // lblPercentOfOut
            // 
            this.lblPercentOfOut.AutoSize = true;
            this.lblPercentOfOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPercentOfOut.Location = new System.Drawing.Point(326, 226);
            this.lblPercentOfOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentOfOut.Name = "lblPercentOfOut";
            this.lblPercentOfOut.Size = new System.Drawing.Size(51, 33);
            this.lblPercentOfOut.TabIndex = 24;
            this.lblPercentOfOut.Text = "<>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label8.Location = new System.Drawing.Point(40, 226);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 37);
            this.label8.TabIndex = 23;
            this.label8.Text = "Процент выхода :";
            // 
            // lblCountOfCalced
            // 
            this.lblCountOfCalced.AutoSize = true;
            this.lblCountOfCalced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountOfCalced.Location = new System.Drawing.Point(326, 90);
            this.lblCountOfCalced.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountOfCalced.Name = "lblCountOfCalced";
            this.lblCountOfCalced.Size = new System.Drawing.Size(51, 33);
            this.lblCountOfCalced.TabIndex = 20;
            this.lblCountOfCalced.Text = "<>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(40, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 37);
            this.label3.TabIndex = 19;
            this.label3.Text = "Обработано :";
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbProgress.Location = new System.Drawing.Point(40, 526);
            this.pbProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(508, 30);
            this.pbProgress.TabIndex = 16;
            // 
            // gbInstruments
            // 
            this.gbInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbInstruments.Controls.Add(this.pbSaveMap);
            this.gbInstruments.Controls.Add(this.pbOpenMap);
            this.gbInstruments.Controls.Add(this.pbChooseFolder);
            this.gbInstruments.Controls.Add(this.pbChooseCullingProject);
            this.gbInstruments.Controls.Add(this.pbPause);
            this.gbInstruments.Controls.Add(this.pbStop);
            this.gbInstruments.Controls.Add(this.pbStart);
            this.gbInstruments.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbInstruments.Location = new System.Drawing.Point(12, 1018);
            this.gbInstruments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbInstruments.Name = "gbInstruments";
            this.gbInstruments.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbInstruments.Size = new System.Drawing.Size(1360, 202);
            this.gbInstruments.TabIndex = 17;
            this.gbInstruments.TabStop = false;
            this.gbInstruments.Text = "Управление";
            // 
            // pbSaveMap
            // 
            this.pbSaveMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSaveMap.Image = ((System.Drawing.Image)(resources.GetObject("pbSaveMap.Image")));
            this.pbSaveMap.Location = new System.Drawing.Point(1192, 56);
            this.pbSaveMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbSaveMap.Name = "pbSaveMap";
            this.pbSaveMap.Size = new System.Drawing.Size(136, 120);
            this.pbSaveMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSaveMap.TabIndex = 6;
            this.pbSaveMap.TabStop = false;
            this.pbSaveMap.Click += new System.EventHandler(this.pbSaveMap_Click);
            // 
            // pbOpenMap
            // 
            this.pbOpenMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOpenMap.Image = ((System.Drawing.Image)(resources.GetObject("pbOpenMap.Image")));
            this.pbOpenMap.Location = new System.Drawing.Point(1024, 56);
            this.pbOpenMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbOpenMap.Name = "pbOpenMap";
            this.pbOpenMap.Size = new System.Drawing.Size(136, 120);
            this.pbOpenMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOpenMap.TabIndex = 5;
            this.pbOpenMap.TabStop = false;
            this.pbOpenMap.Click += new System.EventHandler(this.pbOpenMap_Click);
            // 
            // pbChooseFolder
            // 
            this.pbChooseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChooseFolder.Image = ((System.Drawing.Image)(resources.GetObject("pbChooseFolder.Image")));
            this.pbChooseFolder.Location = new System.Drawing.Point(200, 56);
            this.pbChooseFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbChooseFolder.Name = "pbChooseFolder";
            this.pbChooseFolder.Size = new System.Drawing.Size(136, 120);
            this.pbChooseFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChooseFolder.TabIndex = 4;
            this.pbChooseFolder.TabStop = false;
            this.pbChooseFolder.Click += new System.EventHandler(this.pbChooseFolder_Click);
            // 
            // pbChooseCullingProject
            // 
            this.pbChooseCullingProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChooseCullingProject.Image = ((System.Drawing.Image)(resources.GetObject("pbChooseCullingProject.Image")));
            this.pbChooseCullingProject.Location = new System.Drawing.Point(28, 56);
            this.pbChooseCullingProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbChooseCullingProject.Name = "pbChooseCullingProject";
            this.pbChooseCullingProject.Size = new System.Drawing.Size(128, 120);
            this.pbChooseCullingProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChooseCullingProject.TabIndex = 3;
            this.pbChooseCullingProject.TabStop = false;
            this.pbChooseCullingProject.Click += new System.EventHandler(this.pbChooseCullingProject_Click);
            // 
            // pbPause
            // 
            this.pbPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPause.Image = ((System.Drawing.Image)(resources.GetObject("pbPause.Image")));
            this.pbPause.Location = new System.Drawing.Point(558, 56);
            this.pbPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(136, 120);
            this.pbPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPause.TabIndex = 2;
            this.pbPause.TabStop = false;
            this.pbPause.Click += new System.EventHandler(this.pbPause_Click);
            // 
            // pbStop
            // 
            this.pbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStop.Image = ((System.Drawing.Image)(resources.GetObject("pbStop.Image")));
            this.pbStop.Location = new System.Drawing.Point(730, 56);
            this.pbStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(136, 120);
            this.pbStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStop.TabIndex = 1;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // pbStart
            // 
            this.pbStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStart.Image = ((System.Drawing.Image)(resources.GetObject("pbStart.Image")));
            this.pbStart.Location = new System.Drawing.Point(384, 56);
            this.pbStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(136, 120);
            this.pbStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStart.TabIndex = 0;
            this.pbStart.TabStop = false;
            this.pbStart.Click += new System.EventHandler(this.pbStart_Click);
            // 
            // FormAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1722, 1242);
            this.Controls.Add(this.gbInstruments);
            this.Controls.Add(this.gbStatistic);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gpTesting);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.gbStatistic.ResumeLayout(false);
            this.gbStatistic.PerformLayout();
            this.gbInstruments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChooseFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChooseCullingProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
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
        private System.Windows.Forms.Label lblNameOfTestFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProjectOfCulling;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCullingPattern;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.GroupBox gbStatistic;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblCountOfCalced;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPercentOfOut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPercentOfProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountOfBad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCountOfGood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTimeOfCalculation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCountOfFiles;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автопрокруткаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem калибровкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem порогСегментацииToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbInstruments;
        private System.Windows.Forms.PictureBox pbPause;
        private System.Windows.Forms.PictureBox pbStop;
        private System.Windows.Forms.PictureBox pbStart;
        private System.Windows.Forms.PictureBox pbChooseFolder;
        private System.Windows.Forms.PictureBox pbChooseCullingProject;
        private System.Windows.Forms.ToolStripMenuItem коэффициентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьКартуРаскрояToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbSaveMap;
        private System.Windows.Forms.PictureBox pbOpenMap;
    }
}