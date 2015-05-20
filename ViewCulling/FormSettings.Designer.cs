namespace ViewCulling
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSegmentation = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbKeyPoints = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRadiusOfStartFilling = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbMainSettings = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSumOfClasters = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSizeOfClaster = new System.Windows.Forms.TextBox();
            this.gbImposition = new System.Windows.Forms.GroupBox();
            this.tbAcceptablePercent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.msMain.SuspendLayout();
            this.gbSegmentation.SuspendLayout();
            this.gbMainSettings.SuspendLayout();
            this.gbImposition.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(594, 26);
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
            // gbSegmentation
            // 
            this.gbSegmentation.Controls.Add(this.label3);
            this.gbSegmentation.Controls.Add(this.tbRadiusOfStartFilling);
            this.gbSegmentation.Controls.Add(this.label2);
            this.gbSegmentation.Controls.Add(this.radioButton1);
            this.gbSegmentation.Controls.Add(this.rbKeyPoints);
            this.gbSegmentation.Controls.Add(this.label1);
            this.gbSegmentation.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbSegmentation.Location = new System.Drawing.Point(24, 212);
            this.gbSegmentation.Name = "gbSegmentation";
            this.gbSegmentation.Size = new System.Drawing.Size(542, 191);
            this.gbSegmentation.TabIndex = 1;
            this.gbSegmentation.TabStop = false;
            this.gbSegmentation.Text = "Сегментация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Режим определения цвета фоновой области :";
            // 
            // rbKeyPoints
            // 
            this.rbKeyPoints.AutoSize = true;
            this.rbKeyPoints.Checked = true;
            this.rbKeyPoints.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbKeyPoints.Location = new System.Drawing.Point(25, 52);
            this.rbKeyPoints.Name = "rbKeyPoints";
            this.rbKeyPoints.Size = new System.Drawing.Size(134, 22);
            this.rbKeyPoints.TabIndex = 2;
            this.rbKeyPoints.TabStop = true;
            this.rbKeyPoints.Text = "Ключевые точки";
            this.rbKeyPoints.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(25, 80);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(132, 22);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Анализ пикселей";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(403, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Радиус начальной области закрашивания фоновой области :";
            // 
            // tbRadiusOfStartFilling
            // 
            this.tbRadiusOfStartFilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbRadiusOfStartFilling.Location = new System.Drawing.Point(25, 145);
            this.tbRadiusOfStartFilling.Name = "tbRadiusOfStartFilling";
            this.tbRadiusOfStartFilling.Size = new System.Drawing.Size(80, 24);
            this.tbRadiusOfStartFilling.TabIndex = 5;
            this.tbRadiusOfStartFilling.Text = "7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(111, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "px";
            // 
            // gbMainSettings
            // 
            this.gbMainSettings.Controls.Add(this.label6);
            this.gbMainSettings.Controls.Add(this.label7);
            this.gbMainSettings.Controls.Add(this.tbSizeOfClaster);
            this.gbMainSettings.Controls.Add(this.label5);
            this.gbMainSettings.Controls.Add(this.label4);
            this.gbMainSettings.Controls.Add(this.tbSumOfClasters);
            this.gbMainSettings.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbMainSettings.Location = new System.Drawing.Point(24, 41);
            this.gbMainSettings.Name = "gbMainSettings";
            this.gbMainSettings.Size = new System.Drawing.Size(542, 159);
            this.gbMainSettings.TabIndex = 2;
            this.gbMainSettings.TabStop = false;
            this.gbMainSettings.Text = "Основные параметры визуального контроля";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(484, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Максимальная сумма пикселей несогласованных кластеров годного чипа :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(111, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "px";
            // 
            // tbSumOfClasters
            // 
            this.tbSumOfClasters.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSumOfClasters.Location = new System.Drawing.Point(25, 115);
            this.tbSumOfClasters.Name = "tbSumOfClasters";
            this.tbSumOfClasters.Size = new System.Drawing.Size(80, 24);
            this.tbSumOfClasters.TabIndex = 7;
            this.tbSumOfClasters.Text = "250";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(111, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "px";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(22, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(428, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Минимальное количество пикселей несогласованного кластера :";
            // 
            // tbSizeOfClaster
            // 
            this.tbSizeOfClaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSizeOfClaster.Location = new System.Drawing.Point(25, 54);
            this.tbSizeOfClaster.Name = "tbSizeOfClaster";
            this.tbSizeOfClaster.Size = new System.Drawing.Size(80, 24);
            this.tbSizeOfClaster.TabIndex = 10;
            this.tbSizeOfClaster.Text = "80";
            // 
            // gbImposition
            // 
            this.gbImposition.Controls.Add(this.tbAcceptablePercent);
            this.gbImposition.Controls.Add(this.label9);
            this.gbImposition.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbImposition.Location = new System.Drawing.Point(24, 413);
            this.gbImposition.Name = "gbImposition";
            this.gbImposition.Size = new System.Drawing.Size(542, 107);
            this.gbImposition.TabIndex = 7;
            this.gbImposition.TabStop = false;
            this.gbImposition.Text = "Совмещение";
            // 
            // tbAcceptablePercent
            // 
            this.tbAcceptablePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbAcceptablePercent.Location = new System.Drawing.Point(25, 71);
            this.tbAcceptablePercent.Name = "tbAcceptablePercent";
            this.tbAcceptablePercent.Size = new System.Drawing.Size(80, 24);
            this.tbAcceptablePercent.TabIndex = 5;
            this.tbAcceptablePercent.Text = "0.15";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(22, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(327, 36);
            this.label9.TabIndex = 4;
            this.label9.Text = "Максимальная процентная доля несоотвествия \r\nпотенциальных областей совмещения :";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(283, 543);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "<>";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(611, 498);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gbImposition);
            this.Controls.Add(this.gbMainSettings);
            this.Controls.Add(this.gbSegmentation);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки проекта";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbSegmentation.ResumeLayout(false);
            this.gbSegmentation.PerformLayout();
            this.gbMainSettings.ResumeLayout(false);
            this.gbMainSettings.PerformLayout();
            this.gbImposition.ResumeLayout(false);
            this.gbImposition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbSegmentation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbKeyPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRadiusOfStartFilling;
        private System.Windows.Forms.GroupBox gbMainSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSumOfClasters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSizeOfClaster;
        private System.Windows.Forms.GroupBox gbImposition;
        private System.Windows.Forms.TextBox tbAcceptablePercent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Label label8;
    }
}