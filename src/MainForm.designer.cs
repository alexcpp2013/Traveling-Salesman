using System.Drawing;
using System.Windows.Forms;
namespace aiGenetic
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPR = new System.Windows.Forms.Button();
            this.checkBoxEditMode = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDetail = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBob = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPopulation = new System.Windows.Forms.NumericUpDown();
            this.nudMaxIterations = new System.Windows.Forms.NumericUpDown();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxAdvanced = new System.Windows.Forms.CheckBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRandNumber = new System.Windows.Forms.NumericUpDown();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxIterations)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandNumber)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(294, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 455);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Карта";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(11, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 430);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPR);
            this.groupBox2.Controls.Add(this.checkBoxEditMode);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nudBob);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudPopulation);
            this.groupBox2.Controls.Add(this.nudMaxIterations);
            this.groupBox2.Controls.Add(this.buttonReset);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.buttonLaunch);
            this.groupBox2.Location = new System.Drawing.Point(7, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 482);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Входные данные";
            // 
            // buttonPR
            // 
            this.buttonPR.Location = new System.Drawing.Point(86, 447);
            this.buttonPR.Name = "buttonPR";
            this.buttonPR.Size = new System.Drawing.Size(85, 23);
            this.buttonPR.TabIndex = 6;
            this.buttonPR.Text = "Продолжить";
            this.buttonPR.UseVisualStyleBackColor = true;
            this.buttonPR.Visible = false;
            this.buttonPR.Click += new System.EventHandler(this.buttonPR_Click);
            // 
            // checkBoxEditMode
            // 
            this.checkBoxEditMode.AutoSize = true;
            this.checkBoxEditMode.Location = new System.Drawing.Point(9, 30);
            this.checkBoxEditMode.Name = "checkBoxEditMode";
            this.checkBoxEditMode.Size = new System.Drawing.Size(119, 17);
            this.checkBoxEditMode.TabIndex = 5;
            this.checkBoxEditMode.Text = "Случайные города";
            this.checkBoxEditMode.UseVisualStyleBackColor = true;
            this.checkBoxEditMode.CheckedChanged += new System.EventHandler(this.checkBoxEditMode_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.nudDetail);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(11, 224);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 70);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Расширенный режим";
            this.groupBox5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выводить каждый n-ый потомок";
            // 
            // nudDetail
            // 
            this.nudDetail.Location = new System.Drawing.Point(9, 32);
            this.nudDetail.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDetail.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDetail.Name = "nudDetail";
            this.nudDetail.Size = new System.Drawing.Size(91, 20);
            this.nudDetail.TabIndex = 0;
            this.nudDetail.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Число генов для останова";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Число генов в популяции";
            // 
            // nudBob
            // 
            this.nudBob.Location = new System.Drawing.Point(20, 415);
            this.nudBob.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudBob.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBob.Name = "nudBob";
            this.nudBob.Size = new System.Drawing.Size(85, 20);
            this.nudBob.TabIndex = 1;
            this.nudBob.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Максимальное количество итераций";
            // 
            // nudPopulation
            // 
            this.nudPopulation.Location = new System.Drawing.Point(22, 364);
            this.nudPopulation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPopulation.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPopulation.Name = "nudPopulation";
            this.nudPopulation.Size = new System.Drawing.Size(85, 20);
            this.nudPopulation.TabIndex = 1;
            this.nudPopulation.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // nudMaxIterations
            // 
            this.nudMaxIterations.Location = new System.Drawing.Point(22, 313);
            this.nudMaxIterations.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMaxIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxIterations.Name = "nudMaxIterations";
            this.nudMaxIterations.Size = new System.Drawing.Size(85, 20);
            this.nudMaxIterations.TabIndex = 0;
            this.nudMaxIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(177, 447);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxAdvanced);
            this.groupBox4.Controls.Add(this.buttonGenerate);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.nudRandNumber);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(11, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 145);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Случайные города";
            // 
            // checkBoxAdvanced
            // 
            this.checkBoxAdvanced.AutoSize = true;
            this.checkBoxAdvanced.Location = new System.Drawing.Point(6, 113);
            this.checkBoxAdvanced.Name = "checkBoxAdvanced";
            this.checkBoxAdvanced.Size = new System.Drawing.Size(134, 17);
            this.checkBoxAdvanced.TabIndex = 4;
            this.checkBoxAdvanced.Text = "Расширенный режим";
            this.checkBoxAdvanced.UseVisualStyleBackColor = true;
            this.checkBoxAdvanced.Visible = false;
            this.checkBoxAdvanced.CheckedChanged += new System.EventHandler(this.checkBoxAdvanced_CheckedChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(6, 67);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(74, 24);
            this.buttonGenerate.TabIndex = 4;
            this.buttonGenerate.Text = "Построить";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество городов";
            // 
            // nudRandNumber
            // 
            this.nudRandNumber.Location = new System.Drawing.Point(6, 26);
            this.nudRandNumber.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudRandNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRandNumber.Name = "nudRandNumber";
            this.nudRandNumber.Size = new System.Drawing.Size(85, 20);
            this.nudRandNumber.TabIndex = 0;
            this.nudRandNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRandNumber.ValueChanged += new System.EventHandler(this.nudRandNumber_ValueChanged);
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Enabled = false;
            this.buttonLaunch.Location = new System.Drawing.Point(5, 447);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(75, 23);
            this.buttonLaunch.TabIndex = 2;
            this.buttonLaunch.Text = "Запуск";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.tbLog);
            this.groupBox3.Location = new System.Drawing.Point(7, 498);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(737, 99);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прогресс";
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(9, 19);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(719, 69);
            this.tbLog.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 608);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            Rectangle screen = SystemInformation.VirtualScreen;
            this.Location = new Point(screen.Width - this.Width - 100, screen.Height - this.Height - 100);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 900);
            this.MinimumSize = new System.Drawing.Size(770, 646);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Решение задачи коммивояжера с помощью генетических алгоритмов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxIterations)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandNumber)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDetail;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRandNumber;
        private System.Windows.Forms.CheckBox checkBoxAdvanced;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.CheckBox checkBoxEditMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaxIterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPopulation;
        private System.Windows.Forms.Button buttonPR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudBob;
        private System.Windows.Forms.TextBox tbLog;
    }
}

