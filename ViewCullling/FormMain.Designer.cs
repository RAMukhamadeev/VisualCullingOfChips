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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBКомпонентаОбразцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускАнализаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.анализToolStripMenuItem,
            this.проектToolStripMenuItem,
            this.запускToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.msMain.Size = new System.Drawing.Size(685, 24);
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
            // проектToolStripMenuItem
            // 
            this.проектToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьНовыToolStripMenuItem});
            this.проектToolStripMenuItem.Name = "проектToolStripMenuItem";
            this.проектToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.проектToolStripMenuItem.Text = "Проект";
            // 
            // добавитьНовыToolStripMenuItem
            // 
            this.добавитьНовыToolStripMenuItem.Name = "добавитьНовыToolStripMenuItem";
            this.добавитьНовыToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.добавитьНовыToolStripMenuItem.Text = "Добавить новый проект визуального контроля";
            this.добавитьНовыToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовыToolStripMenuItem_Click);
            // 
            // запускToolStripMenuItem
            // 
            this.запускToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запускАнализаToolStripMenuItem});
            this.запускToolStripMenuItem.Name = "запускToolStripMenuItem";
            this.запускToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.запускToolStripMenuItem.Text = "Запуск";
            // 
            // запускАнализаToolStripMenuItem
            // 
            this.запускАнализаToolStripMenuItem.Name = "запускАнализаToolStripMenuItem";
            this.запускАнализаToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.запускАнализаToolStripMenuItem.Text = "Запуск визуального контроля";
            this.запускАнализаToolStripMenuItem.Click += new System.EventHandler(this.запускАнализаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(685, 485);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "ViewCulling";
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

    }
}

