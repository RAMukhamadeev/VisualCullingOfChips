﻿namespace ViewCulling
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
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оригиналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спрайтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сегментацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.краяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ключевыеТочкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbViewPicture = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.rbGood = new System.Windows.Forms.RadioButton();
            this.rbBad = new System.Windows.Forms.RadioButton();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.gbInstruments = new System.Windows.Forms.GroupBox();
            this.шаблонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbLeftArrow = new System.Windows.Forms.PictureBox();
            this.pbRightArrow = new System.Windows.Forms.PictureBox();
            this.lblNameOfChip = new System.Windows.Forms.Label();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.gbImage.SuspendLayout();
            this.gbInstruments.SuspendLayout();
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
            this.msMain.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.msMain.Size = new System.Drawing.Size(881, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.видToolStripMenuItem.Size = new System.Drawing.Size(45, 22);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // оригиналToolStripMenuItem
            // 
            this.оригиналToolStripMenuItem.Name = "оригиналToolStripMenuItem";
            this.оригиналToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.оригиналToolStripMenuItem.Text = "Оригинал";
            this.оригиналToolStripMenuItem.Click += new System.EventHandler(this.оригиналToolStripMenuItem_Click);
            // 
            // спрайтыToolStripMenuItem
            // 
            this.спрайтыToolStripMenuItem.Name = "спрайтыToolStripMenuItem";
            this.спрайтыToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.спрайтыToolStripMenuItem.Text = "Подсветка повреждений";
            this.спрайтыToolStripMenuItem.Click += new System.EventHandler(this.спрайтыToolStripMenuItem_Click);
            // 
            // сегментацияToolStripMenuItem
            // 
            this.сегментацияToolStripMenuItem.Name = "сегментацияToolStripMenuItem";
            this.сегментацияToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.сегментацияToolStripMenuItem.Text = "Сегментация";
            this.сегментацияToolStripMenuItem.Click += new System.EventHandler(this.сегментацияToolStripMenuItem_Click);
            // 
            // краяToolStripMenuItem
            // 
            this.краяToolStripMenuItem.Name = "краяToolStripMenuItem";
            this.краяToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.краяToolStripMenuItem.Text = "Края";
            this.краяToolStripMenuItem.Click += new System.EventHandler(this.краяToolStripMenuItem_Click);
            // 
            // ключевыеТочкиToolStripMenuItem
            // 
            this.ключевыеТочкиToolStripMenuItem.Name = "ключевыеТочкиToolStripMenuItem";
            this.ключевыеТочкиToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ключевыеТочкиToolStripMenuItem.Text = "Ключевые точки";
            this.ключевыеТочкиToolStripMenuItem.Click += new System.EventHandler(this.ключевыеТочкиToolStripMenuItem_Click);
            // 
            // pbViewPicture
            // 
            this.pbViewPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbViewPicture.Location = new System.Drawing.Point(12, 20);
            this.pbViewPicture.Margin = new System.Windows.Forms.Padding(2);
            this.pbViewPicture.Name = "pbViewPicture";
            this.pbViewPicture.Size = new System.Drawing.Size(635, 508);
            this.pbViewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbViewPicture.TabIndex = 1;
            this.pbViewPicture.TabStop = false;
            this.pbViewPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbViewPicture_MouseDoubleClick);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(34, 56);
            this.pbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 100);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 2;
            this.pbStatus.TabStop = false;
            // 
            // rbGood
            // 
            this.rbGood.AutoSize = true;
            this.rbGood.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbGood.Location = new System.Drawing.Point(13, 160);
            this.rbGood.Margin = new System.Windows.Forms.Padding(2);
            this.rbGood.Name = "rbGood";
            this.rbGood.Size = new System.Drawing.Size(65, 22);
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
            this.rbBad.Location = new System.Drawing.Point(82, 160);
            this.rbBad.Margin = new System.Windows.Forms.Padding(2);
            this.rbBad.Name = "rbBad";
            this.rbBad.Size = new System.Drawing.Size(85, 22);
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
            this.gbImage.Location = new System.Drawing.Point(11, 26);
            this.gbImage.Margin = new System.Windows.Forms.Padding(2);
            this.gbImage.Name = "gbImage";
            this.gbImage.Padding = new System.Windows.Forms.Padding(2);
            this.gbImage.Size = new System.Drawing.Size(659, 542);
            this.gbImage.TabIndex = 4;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Изображение";
            // 
            // gbInstruments
            // 
            this.gbInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInstruments.Controls.Add(this.lblNameOfChip);
            this.gbInstruments.Controls.Add(this.pbRightArrow);
            this.gbInstruments.Controls.Add(this.pbLeftArrow);
            this.gbInstruments.Controls.Add(this.pbStatus);
            this.gbInstruments.Controls.Add(this.rbGood);
            this.gbInstruments.Controls.Add(this.rbBad);
            this.gbInstruments.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbInstruments.Location = new System.Drawing.Point(689, 26);
            this.gbInstruments.Margin = new System.Windows.Forms.Padding(2);
            this.gbInstruments.Name = "gbInstruments";
            this.gbInstruments.Padding = new System.Windows.Forms.Padding(2);
            this.gbInstruments.Size = new System.Drawing.Size(181, 542);
            this.gbInstruments.TabIndex = 6;
            this.gbInstruments.TabStop = false;
            this.gbInstruments.Text = "Инструменты";
            // 
            // шаблонToolStripMenuItem
            // 
            this.шаблонToolStripMenuItem.Name = "шаблонToolStripMenuItem";
            this.шаблонToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.шаблонToolStripMenuItem.Text = "Шаблон";
            this.шаблонToolStripMenuItem.Click += new System.EventHandler(this.шаблонToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // pbLeftArrow
            // 
            this.pbLeftArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbLeftArrow.Image")));
            this.pbLeftArrow.Location = new System.Drawing.Point(34, 200);
            this.pbLeftArrow.Name = "pbLeftArrow";
            this.pbLeftArrow.Size = new System.Drawing.Size(50, 50);
            this.pbLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftArrow.TabIndex = 5;
            this.pbLeftArrow.TabStop = false;
            this.pbLeftArrow.Click += new System.EventHandler(this.pbLeftArrow_Click);
            // 
            // pbRightArrow
            // 
            this.pbRightArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbRightArrow.Image")));
            this.pbRightArrow.Location = new System.Drawing.Point(94, 200);
            this.pbRightArrow.Name = "pbRightArrow";
            this.pbRightArrow.Size = new System.Drawing.Size(50, 50);
            this.pbRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightArrow.TabIndex = 6;
            this.pbRightArrow.TabStop = false;
            // 
            // lblNameOfChip
            // 
            this.lblNameOfChip.AutoSize = true;
            this.lblNameOfChip.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNameOfChip.Location = new System.Drawing.Point(12, 25);
            this.lblNameOfChip.Name = "lblNameOfChip";
            this.lblNameOfChip.Size = new System.Drawing.Size(101, 18);
            this.lblNameOfChip.TabIndex = 7;
            this.lblNameOfChip.Text = "<nameOfChip>";
            // 
            // FormAnalyzeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(881, 577);
            this.Controls.Add(this.gbInstruments);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAnalyzeView";
            this.Text = "Просмотр и редактирование";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormViewPicture_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.gbImage.ResumeLayout(false);
            this.gbInstruments.ResumeLayout(false);
            this.gbInstruments.PerformLayout();
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
    }
}