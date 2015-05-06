namespace ViewCulling
{
    partial class FormTestOfImposition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestOfImposition));
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестируемыйФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.годныйФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показСовмещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.Location = new System.Drawing.Point(12, 42);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(925, 475);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.загрузкаToolStripMenuItem,
            this.стартToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(949, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // загрузкаToolStripMenuItem
            // 
            this.загрузкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестируемыйФайлToolStripMenuItem,
            this.годныйФайлToolStripMenuItem});
            this.загрузкаToolStripMenuItem.Name = "загрузкаToolStripMenuItem";
            this.загрузкаToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.загрузкаToolStripMenuItem.Text = "Загрузка";
            // 
            // тестируемыйФайлToolStripMenuItem
            // 
            this.тестируемыйФайлToolStripMenuItem.Name = "тестируемыйФайлToolStripMenuItem";
            this.тестируемыйФайлToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.тестируемыйФайлToolStripMenuItem.Text = "Тестируемый чип";
            this.тестируемыйФайлToolStripMenuItem.Click += new System.EventHandler(this.тестируемыйФайлToolStripMenuItem_Click);
            // 
            // годныйФайлToolStripMenuItem
            // 
            this.годныйФайлToolStripMenuItem.Name = "годныйФайлToolStripMenuItem";
            this.годныйФайлToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.годныйФайлToolStripMenuItem.Text = "Годный чип";
            this.годныйФайлToolStripMenuItem.Click += new System.EventHandler(this.годныйФайлToolStripMenuItem_Click);
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показСовмещенияToolStripMenuItem});
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.стартToolStripMenuItem.Text = "Совмещение";
            // 
            // показСовмещенияToolStripMenuItem
            // 
            this.показСовмещенияToolStripMenuItem.Name = "показСовмещенияToolStripMenuItem";
            this.показСовмещенияToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.показСовмещенияToolStripMenuItem.Text = "Показ совмещения";
            this.показСовмещенияToolStripMenuItem.Click += new System.EventHandler(this.показСовмещенияToolStripMenuItem_Click);
            // 
            // FormTestOfImposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(949, 529);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormTestOfImposition";
            this.Text = "FormTestOfImposition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTestOfImposition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестируемыйФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem годныйФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показСовмещенияToolStripMenuItem;
    }
}