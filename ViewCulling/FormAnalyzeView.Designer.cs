namespace ViewCulling
{
    partial class FormAnalyzeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalyzeView));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbViewPicture = new System.Windows.Forms.PictureBox();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оригиналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спрайтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сегментацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.краяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.rbGood = new System.Windows.Forms.RadioButton();
            this.rbBad = new System.Windows.Forms.RadioButton();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.gbInstruments = new System.Windows.Forms.GroupBox();
            this.ключевыеТочкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.gbImage.SuspendLayout();
            this.gbInstruments.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1954, 42);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(83, 38);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(180, 36);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // pbViewPicture
            // 
            this.pbViewPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbViewPicture.Location = new System.Drawing.Point(18, 25);
            this.pbViewPicture.Name = "pbViewPicture";
            this.pbViewPicture.Size = new System.Drawing.Size(1559, 847);
            this.pbViewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbViewPicture.TabIndex = 1;
            this.pbViewPicture.TabStop = false;
            this.pbViewPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbViewPicture_MouseDoubleClick);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оригиналToolStripMenuItem,
            this.спрайтыToolStripMenuItem,
            this.сегментацияToolStripMenuItem,
            this.краяToolStripMenuItem,
            this.ключевыеТочкиToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(68, 38);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // оригиналToolStripMenuItem
            // 
            this.оригиналToolStripMenuItem.Name = "оригиналToolStripMenuItem";
            this.оригиналToolStripMenuItem.Size = new System.Drawing.Size(366, 36);
            this.оригиналToolStripMenuItem.Text = "Оригинал";
            this.оригиналToolStripMenuItem.Click += new System.EventHandler(this.оригиналToolStripMenuItem_Click);
            // 
            // спрайтыToolStripMenuItem
            // 
            this.спрайтыToolStripMenuItem.Name = "спрайтыToolStripMenuItem";
            this.спрайтыToolStripMenuItem.Size = new System.Drawing.Size(366, 36);
            this.спрайтыToolStripMenuItem.Text = "Подсветка повреждений";
            this.спрайтыToolStripMenuItem.Click += new System.EventHandler(this.спрайтыToolStripMenuItem_Click);
            // 
            // сегментацияToolStripMenuItem
            // 
            this.сегментацияToolStripMenuItem.Name = "сегментацияToolStripMenuItem";
            this.сегментацияToolStripMenuItem.Size = new System.Drawing.Size(366, 36);
            this.сегментацияToolStripMenuItem.Text = "Сегментация";
            this.сегментацияToolStripMenuItem.Click += new System.EventHandler(this.сегментацияToolStripMenuItem_Click);
            // 
            // краяToolStripMenuItem
            // 
            this.краяToolStripMenuItem.Name = "краяToolStripMenuItem";
            this.краяToolStripMenuItem.Size = new System.Drawing.Size(366, 36);
            this.краяToolStripMenuItem.Text = "Края";
            this.краяToolStripMenuItem.Click += new System.EventHandler(this.краяToolStripMenuItem_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(28, 40);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(220, 199);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 2;
            this.pbStatus.TabStop = false;
            // 
            // rbGood
            // 
            this.rbGood.AutoSize = true;
            this.rbGood.Location = new System.Drawing.Point(28, 264);
            this.rbGood.Name = "rbGood";
            this.rbGood.Size = new System.Drawing.Size(97, 29);
            this.rbGood.TabIndex = 3;
            this.rbGood.TabStop = true;
            this.rbGood.Text = "Годен";
            this.rbGood.UseVisualStyleBackColor = true;
            this.rbGood.CheckedChanged += new System.EventHandler(this.rbGood_CheckedChanged);
            // 
            // rbBad
            // 
            this.rbBad.AutoSize = true;
            this.rbBad.Location = new System.Drawing.Point(28, 299);
            this.rbBad.Name = "rbBad";
            this.rbBad.Size = new System.Drawing.Size(126, 29);
            this.rbBad.TabIndex = 4;
            this.rbBad.TabStop = true;
            this.rbBad.Text = "Не годен";
            this.rbBad.UseVisualStyleBackColor = true;
            this.rbBad.CheckedChanged += new System.EventHandler(this.rbBad_CheckedChanged);
            // 
            // gbImage
            // 
            this.gbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImage.Controls.Add(this.pbViewPicture);
            this.gbImage.Location = new System.Drawing.Point(23, 58);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(1583, 878);
            this.gbImage.TabIndex = 4;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Изображение";
            // 
            // gbInstruments
            // 
            this.gbInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInstruments.Controls.Add(this.pbStatus);
            this.gbInstruments.Controls.Add(this.rbGood);
            this.gbInstruments.Controls.Add(this.rbBad);
            this.gbInstruments.Location = new System.Drawing.Point(1645, 58);
            this.gbInstruments.Name = "gbInstruments";
            this.gbInstruments.Size = new System.Drawing.Size(270, 878);
            this.gbInstruments.TabIndex = 6;
            this.gbInstruments.TabStop = false;
            this.gbInstruments.Text = "Инструменты";
            // 
            // ключевыеТочкиToolStripMenuItem
            // 
            this.ключевыеТочкиToolStripMenuItem.Name = "ключевыеТочкиToolStripMenuItem";
            this.ключевыеТочкиToolStripMenuItem.Size = new System.Drawing.Size(366, 36);
            this.ключевыеТочкиToolStripMenuItem.Text = "Ключевые точки";
            this.ключевыеТочкиToolStripMenuItem.Click += new System.EventHandler(this.ключевыеТочкиToolStripMenuItem_Click);
            // 
            // FormAnalyzeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1954, 948);
            this.Controls.Add(this.gbInstruments);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FormAnalyzeView";
            this.Text = "FormViewPicture";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormViewPicture_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.gbImage.ResumeLayout(false);
            this.gbInstruments.ResumeLayout(false);
            this.gbInstruments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbViewPicture;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оригиналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спрайтыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сегментацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem краяToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.RadioButton rbBad;
        private System.Windows.Forms.RadioButton rbGood;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.GroupBox gbInstruments;
        private System.Windows.Forms.ToolStripMenuItem ключевыеТочкиToolStripMenuItem;
    }
}