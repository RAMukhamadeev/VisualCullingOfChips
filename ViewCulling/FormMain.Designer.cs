namespace ViewCulling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускАнализаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBКомпонентаОбразцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.совмещениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.запускToolStripMenuItem,
            this.проектToolStripMenuItem,
            this.анализToolStripMenuItem,
            this.тестированиеToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(2130, 44);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "msMain";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(195, 40);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // запускToolStripMenuItem
            // 
            this.запускToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запускАнализаToolStripMenuItem});
            this.запускToolStripMenuItem.Name = "запускToolStripMenuItem";
            this.запускToolStripMenuItem.Size = new System.Drawing.Size(300, 40);
            this.запускToolStripMenuItem.Text = "Визуальный контроль";
            // 
            // запускАнализаToolStripMenuItem
            // 
            this.запускАнализаToolStripMenuItem.Name = "запускАнализаToolStripMenuItem";
            this.запускАнализаToolStripMenuItem.Size = new System.Drawing.Size(475, 40);
            this.запускАнализаToolStripMenuItem.Text = "Открыть визуальный контроль";
            this.запускАнализаToolStripMenuItem.Click += new System.EventHandler(this.запускАнализаToolStripMenuItem_Click);
            // 
            // проектToolStripMenuItem
            // 
            this.проектToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьНовыToolStripMenuItem});
            this.проектToolStripMenuItem.Name = "проектToolStripMenuItem";
            this.проектToolStripMenuItem.Size = new System.Drawing.Size(138, 40);
            this.проектToolStripMenuItem.Text = "Проекты";
            // 
            // добавитьНовыToolStripMenuItem
            // 
            this.добавитьНовыToolStripMenuItem.Name = "добавитьНовыToolStripMenuItem";
            this.добавитьНовыToolStripMenuItem.Size = new System.Drawing.Size(560, 40);
            this.добавитьНовыToolStripMenuItem.Text = " Новый проект визуального контроля";
            this.добавитьНовыToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовыToolStripMenuItem_Click);
            // 
            // анализToolStripMenuItem
            // 
            this.анализToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBКомпонентаОбразцаToolStripMenuItem});
            this.анализToolStripMenuItem.Name = "анализToolStripMenuItem";
            this.анализToolStripMenuItem.Size = new System.Drawing.Size(116, 40);
            this.анализToolStripMenuItem.Text = "Анализ";
            // 
            // rGBКомпонентаОбразцаToolStripMenuItem
            // 
            this.rGBКомпонентаОбразцаToolStripMenuItem.Name = "rGBКомпонентаОбразцаToolStripMenuItem";
            this.rGBКомпонентаОбразцаToolStripMenuItem.Size = new System.Drawing.Size(412, 40);
            this.rGBКомпонентаОбразцаToolStripMenuItem.Text = "RGB компонента образца";
            this.rGBКомпонентаОбразцаToolStripMenuItem.Click += new System.EventHandler(this.rGBКомпонентаОбразцаToolStripMenuItem_Click);
            // 
            // тестированиеToolStripMenuItem
            // 
            this.тестированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.совмещениеToolStripMenuItem,
            this.загрузкаToolStripMenuItem});
            this.тестированиеToolStripMenuItem.Name = "тестированиеToolStripMenuItem";
            this.тестированиеToolStripMenuItem.Size = new System.Drawing.Size(203, 40);
            this.тестированиеToolStripMenuItem.Text = "Тестирование";
            // 
            // совмещениеToolStripMenuItem
            // 
            this.совмещениеToolStripMenuItem.Name = "совмещениеToolStripMenuItem";
            this.совмещениеToolStripMenuItem.Size = new System.Drawing.Size(254, 40);
            this.совмещениеToolStripMenuItem.Text = "Совмещение";
            this.совмещениеToolStripMenuItem.Click += new System.EventHandler(this.совмещениеToolStripMenuItem_Click);
            // 
            // загрузкаToolStripMenuItem
            // 
            this.загрузкаToolStripMenuItem.Name = "загрузкаToolStripMenuItem";
            this.загрузкаToolStripMenuItem.Size = new System.Drawing.Size(254, 40);
            this.загрузкаToolStripMenuItem.Text = "Загрузка";
            this.загрузкаToolStripMenuItem.Click += new System.EventHandler(this.загрузкаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2130, 1182);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Программный комплекс для визуального контроля полупроводниковых приборов и моноли" +
    "тных интегральных схем \"СVMICS\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBКомпонентаОбразцаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускАнализаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem совмещениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаToolStripMenuItem;

    }
}

