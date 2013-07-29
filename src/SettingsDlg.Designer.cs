namespace aiGenetic
{
    partial class SettingsDlg
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
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.nudCrossover = new System.Windows.Forms.NumericUpDown();
            this.nudElite = new System.Windows.Forms.NumericUpDown();
            this.nudMutation = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chbTwins = new System.Windows.Forms.CheckBox();
            this.cbCrossover = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSelection = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudElite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMutation)).BeginInit();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(12, 171);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(197, 171);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // nudCrossover
            // 
            this.nudCrossover.Location = new System.Drawing.Point(152, 40);
            this.nudCrossover.Name = "nudCrossover";
            this.nudCrossover.Size = new System.Drawing.Size(45, 20);
            this.nudCrossover.TabIndex = 2;
            this.nudCrossover.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // nudElite
            // 
            this.nudElite.Location = new System.Drawing.Point(153, 88);
            this.nudElite.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudElite.Name = "nudElite";
            this.nudElite.Size = new System.Drawing.Size(45, 20);
            this.nudElite.TabIndex = 2;
            this.nudElite.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudMutation
            // 
            this.nudMutation.Location = new System.Drawing.Point(152, 116);
            this.nudMutation.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMutation.Name = "nudMutation";
            this.nudMutation.Size = new System.Drawing.Size(45, 20);
            this.nudMutation.TabIndex = 2;
            this.nudMutation.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Способ кроссовера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вероятность кроссовера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Удаление близнецов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Процент элиты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Процент мутаций";
            // 
            // chbTwins
            // 
            this.chbTwins.AutoSize = true;
            this.chbTwins.Checked = true;
            this.chbTwins.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTwins.Location = new System.Drawing.Point(153, 64);
            this.chbTwins.Name = "chbTwins";
            this.chbTwins.Size = new System.Drawing.Size(15, 14);
            this.chbTwins.TabIndex = 4;
            this.chbTwins.UseVisualStyleBackColor = true;
            // 
            // cbCrossover
            // 
            this.cbCrossover.FormattingEnabled = true;
            this.cbCrossover.Items.AddRange(new object[] {
            "Cycle",
            "Greedy"});
            this.cbCrossover.Location = new System.Drawing.Point(152, 12);
            this.cbCrossover.Name = "cbCrossover";
            this.cbCrossover.Size = new System.Drawing.Size(121, 21);
            this.cbCrossover.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Способ выбора";
            // 
            // cbSelection
            // 
            this.cbSelection.FormattingEnabled = true;
            this.cbSelection.Items.AddRange(new object[] {
            "Roulette",
            "Tournament"});
            this.cbSelection.Location = new System.Drawing.Point(151, 143);
            this.cbSelection.Name = "cbSelection";
            this.cbSelection.Size = new System.Drawing.Size(121, 21);
            this.cbSelection.TabIndex = 5;
            // 
            // SettingsDlg
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(284, 205);
            this.Controls.Add(this.cbSelection);
            this.Controls.Add(this.cbCrossover);
            this.Controls.Add(this.chbTwins);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMutation);
            this.Controls.Add(this.nudElite);
            this.Controls.Add(this.nudCrossover);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Опции алгоритма";
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudElite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMutation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.NumericUpDown nudCrossover;
        private System.Windows.Forms.NumericUpDown nudElite;
        private System.Windows.Forms.NumericUpDown nudMutation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbTwins;
        private System.Windows.Forms.ComboBox cbCrossover;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSelection;
    }
}