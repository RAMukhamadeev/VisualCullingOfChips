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
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оригиналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спрайтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сегментацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.краяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ключевыеТочкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шаблонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbViewPicture = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.rbGood = new System.Windows.Forms.RadioButton();
            this.rbBad = new System.Windows.Forms.RadioButton();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.gbInstruments = new System.Windows.Forms.GroupBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCoeff = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNameOfChip = new System.Windows.Forms.Label();
            this.gbView = new System.Windows.Forms.GroupBox();
            this.pbLeftArrow = new System.Windows.Forms.PictureBox();
            this.rbShowGoods = new System.Windows.Forms.RadioButton();
            this.rbShowAll = new System.Windows.Forms.RadioButton();
            this.pbRightArrow = new System.Windows.Forms.PictureBox();
            this.rbShowBads = new System.Windows.Forms.RadioButton();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.gbImage.SuspendLayout();
            this.gbInstruments.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1576, 44);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оригиналToolStripMenuItem,
            this.спрайтыToolStripMenuItem,
            this.сегментацияToolStripMenuItem,
            this.краяToolStripMenuItem,
            this.ключевыеТочкиToolStripMenuItem,
            this.шаблонToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(75, 40);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // оригиналToolStripMenuItem
            // 
            this.оригиналToolStripMenuItem.Name = "оригиналToolStripMenuItem";
            this.оригиналToolStripMenuItem.Size = new System.Drawing.Size(402, 40);
            this.оригиналToolStripMenuItem.Text = "Оригинал";
            this.оригиналToolStripMenuItem.Click += new System.EventHandler(this.оригиналToolStripMenuItem_Click);
            // 
            // спрайтыToolStripMenuItem
            // 
            this.спрайтыToolStripMenuItem.Checked = true;
            this.спрайтыToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.спрайтыToolStripMenuItem.Name = "спрайтыToolStripMenuItem";
            this.спрайтыToolStripMenuItem.Size = new System.Drawing.Size(402, 40);
            this.спрайтыToolStripMenuItem.Text = "Подсветка повреждений";
            this.спрайтыToolStripMenuItem.Click += new System.EventHandler(this.спрайтыToolStripMenuItem_Click);
            // 
            // сегментацияToolStripMenuItem
            // 
            this.сегментацияToolStripMenuItem.Name = "сегментацияToolStripMenuItem";
            this.сегментацияToolStripMenuItem.Size = new System.Drawing.Size(402, 40);
            this.сегментацияToolStripMenuItem.Text = "Сегментация";
            this.сегментацияToolStripMenuItem.Click += new System.EventHandler(this.сегментацияToolStripMenuItem_Click);
            // 
            // краяToolStripMenuItem
            // 
            this.краяToolStripMenuItem.Name = "краяToolStripMenuItem";
            this.краяToolStripMenuItem.Size = new System.Drawing.Size(402, 40);
            this.краяToolStripMenuItem.Text = "Края";
            this.краяToolStripMenuItem.Click += new System.EventHandler(this.краяToolStripMenuItem_Click);
            // 
            // ключевыеТочкиToolStripMenuItem
            // 
            this.ключевыеТочкиToolStripMenuItem.Name = "ключевыеТочкиToolStripMenuItem";
            this.ключевыеТочкиToolStripMenuItem.Size = new System.Drawing.Size(402, 40);
            this.ключевыеТочкиToolStripMenuItem.Text = "Ключевые точки";
            this.ключевыеТочкиToolStripMenuItem.Click += new System.EventHandler(this.ключевыеТочкиToolStripMenuItem_Click);
            // 
            // шаблонToolStripMenuItem
            // 
            this.шаблонToolStripMenuItem.Name = "шаблонToolStripMenuItem";
            this.шаблонToolStripMenuItem.Size = new System.Drawing.Size(402, 40);
            this.шаблонToolStripMenuItem.Text = "Шаблон";
            this.шаблонToolStripMenuItem.Click += new System.EventHandler(this.шаблонToolStripMenuItem_Click);
            // 
            // pbViewPicture
            // 
            this.pbViewPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbViewPicture.Location = new System.Drawing.Point(24, 40);
            this.pbViewPicture.Margin = new System.Windows.Forms.Padding(4);
            this.pbViewPicture.Name = "pbViewPicture";
            this.pbViewPicture.Size = new System.Drawing.Size(1086, 1016);
            this.pbViewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbViewPicture.TabIndex = 1;
            this.pbViewPicture.TabStop = false;
            this.pbViewPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbViewPicture_MouseDoubleClick);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(64, 240);
            this.pbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(200, 200);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 2;
            this.pbStatus.TabStop = false;
            // 
            // rbGood
            // 
            this.rbGood.AutoSize = true;
            this.rbGood.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbGood.Location = new System.Drawing.Point(29, 448);
            this.rbGood.Margin = new System.Windows.Forms.Padding(4);
            this.rbGood.Name = "rbGood";
            this.rbGood.Size = new System.Drawing.Size(121, 41);
            this.rbGood.TabIndex = 3;
            this.rbGood.TabStop = true;
            this.rbGood.Text = "Годен";
            this.rbGood.UseVisualStyleBackColor = true;
            this.rbGood.CheckedChanged += new System.EventHandler(this.rbGood_CheckedChanged);
            // 
            // rbBad
            // 
            this.rbBad.AutoSize = true;
            this.rbBad.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbBad.Location = new System.Drawing.Point(167, 448);
            this.rbBad.Margin = new System.Windows.Forms.Padding(4);
            this.rbBad.Name = "rbBad";
            this.rbBad.Size = new System.Drawing.Size(160, 41);
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
            this.gbImage.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbImage.Location = new System.Drawing.Point(22, 52);
            this.gbImage.Margin = new System.Windows.Forms.Padding(4);
            this.gbImage.Name = "gbImage";
            this.gbImage.Padding = new System.Windows.Forms.Padding(4);
            this.gbImage.Size = new System.Drawing.Size(1134, 1084);
            this.gbImage.TabIndex = 1;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Изображение";
            // 
            // gbInstruments
            // 
            this.gbInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInstruments.Controls.Add(this.gbInfo);
            this.gbInstruments.Controls.Add(this.gbView);
            this.gbInstruments.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbInstruments.Location = new System.Drawing.Point(1181, 52);
            this.gbInstruments.Margin = new System.Windows.Forms.Padding(4);
            this.gbInstruments.Name = "gbInstruments";
            this.gbInstruments.Padding = new System.Windows.Forms.Padding(4);
            this.gbInstruments.Size = new System.Drawing.Size(382, 1084);
            this.gbInstruments.TabIndex = 2;
            this.gbInstruments.TabStop = false;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.pbStatus);
            this.gbInfo.Controls.Add(this.rbBad);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.lblCoeff);
            this.gbInfo.Controls.Add(this.rbGood);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.lblNameOfChip);
            this.gbInfo.Location = new System.Drawing.Point(17, 40);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(352, 517);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "Коэфф. расхождения :";
            // 
            // lblCoeff
            // 
            this.lblCoeff.AutoSize = true;
            this.lblCoeff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCoeff.Location = new System.Drawing.Point(16, 178);
            this.lblCoeff.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCoeff.Name = "lblCoeff";
            this.lblCoeff.Size = new System.Drawing.Size(51, 36);
            this.lblCoeff.TabIndex = 9;
            this.lblCoeff.Text = "<>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название чипа :";
            // 
            // lblNameOfChip
            // 
            this.lblNameOfChip.AutoSize = true;
            this.lblNameOfChip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNameOfChip.Location = new System.Drawing.Point(17, 92);
            this.lblNameOfChip.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNameOfChip.Name = "lblNameOfChip";
            this.lblNameOfChip.Size = new System.Drawing.Size(51, 36);
            this.lblNameOfChip.TabIndex = 7;
            this.lblNameOfChip.Text = "<>";
            // 
            // gbView
            // 
            this.gbView.Controls.Add(this.pbLeftArrow);
            this.gbView.Controls.Add(this.rbShowGoods);
            this.gbView.Controls.Add(this.rbShowAll);
            this.gbView.Controls.Add(this.pbRightArrow);
            this.gbView.Controls.Add(this.rbShowBads);
            this.gbView.Location = new System.Drawing.Point(17, 575);
            this.gbView.Name = "gbView";
            this.gbView.Size = new System.Drawing.Size(352, 326);
            this.gbView.TabIndex = 1;
            this.gbView.TabStop = false;
            this.gbView.Text = "Просмотр";
            // 
            // pbLeftArrow
            // 
            this.pbLeftArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLeftArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbLeftArrow.Image")));
            this.pbLeftArrow.Location = new System.Drawing.Point(42, 54);
            this.pbLeftArrow.Margin = new System.Windows.Forms.Padding(6);
            this.pbLeftArrow.Name = "pbLeftArrow";
            this.pbLeftArrow.Size = new System.Drawing.Size(100, 100);
            this.pbLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftArrow.TabIndex = 5;
            this.pbLeftArrow.TabStop = false;
            this.pbLeftArrow.Click += new System.EventHandler(this.pbLeftArrow_Click);
            // 
            // rbShowGoods
            // 
            this.rbShowGoods.AutoSize = true;
            this.rbShowGoods.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbShowGoods.Location = new System.Drawing.Point(42, 269);
            this.rbShowGoods.Margin = new System.Windows.Forms.Padding(4);
            this.rbShowGoods.Name = "rbShowGoods";
            this.rbShowGoods.Size = new System.Drawing.Size(140, 41);
            this.rbShowGoods.TabIndex = 13;
            this.rbShowGoods.Text = "Годные";
            this.rbShowGoods.UseVisualStyleBackColor = true;
            // 
            // rbShowAll
            // 
            this.rbShowAll.AutoSize = true;
            this.rbShowAll.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbShowAll.Location = new System.Drawing.Point(42, 171);
            this.rbShowAll.Margin = new System.Windows.Forms.Padding(4);
            this.rbShowAll.Name = "rbShowAll";
            this.rbShowAll.Size = new System.Drawing.Size(89, 41);
            this.rbShowAll.TabIndex = 11;
            this.rbShowAll.Text = "Все";
            this.rbShowAll.UseVisualStyleBackColor = true;
            // 
            // pbRightArrow
            // 
            this.pbRightArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRightArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbRightArrow.Image")));
            this.pbRightArrow.Location = new System.Drawing.Point(185, 54);
            this.pbRightArrow.Margin = new System.Windows.Forms.Padding(6);
            this.pbRightArrow.Name = "pbRightArrow";
            this.pbRightArrow.Size = new System.Drawing.Size(100, 100);
            this.pbRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightArrow.TabIndex = 6;
            this.pbRightArrow.TabStop = false;
            this.pbRightArrow.Click += new System.EventHandler(this.pbRightArrow_Click);
            // 
            // rbShowBads
            // 
            this.rbShowBads.AutoSize = true;
            this.rbShowBads.Checked = true;
            this.rbShowBads.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbShowBads.Location = new System.Drawing.Point(42, 220);
            this.rbShowBads.Margin = new System.Windows.Forms.Padding(4);
            this.rbShowBads.Name = "rbShowBads";
            this.rbShowBads.Size = new System.Drawing.Size(179, 41);
            this.rbShowBads.TabIndex = 12;
            this.rbShowBads.TabStop = true;
            this.rbShowBads.Text = "Не годные";
            this.rbShowBads.UseVisualStyleBackColor = true;
            // 
            // FormAnalyzeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1576, 1154);
            this.Controls.Add(this.gbInstruments);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAnalyzeView";
            this.Text = "Просмотр и редактирование";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAnalyzeView_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.gbImage.ResumeLayout(false);
            this.gbInstruments.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbView.ResumeLayout(false);
            this.gbView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шаблонToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbRightArrow;
        private System.Windows.Forms.PictureBox pbLeftArrow;
        private System.Windows.Forms.Label lblNameOfChip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCoeff;
        private System.Windows.Forms.RadioButton rbShowGoods;
        private System.Windows.Forms.RadioButton rbShowAll;
        private System.Windows.Forms.RadioButton rbShowBads;
        private System.Windows.Forms.GroupBox gbView;
        private System.Windows.Forms.GroupBox gbInfo;
    }
}