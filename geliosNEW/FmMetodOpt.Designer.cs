namespace geliosNEW
{
    partial class FmMetodOpt
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
            this.label1 = new System.Windows.Forms.Label();
            this.rgMetod = new System.Windows.Forms.GroupBox();
            this.rg1 = new System.Windows.Forms.RadioButton();
            this.rg0 = new System.Windows.Forms.RadioButton();
            this.cbxMetod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edPercent = new System.Windows.Forms.TextBox();
            this.btOkClick = new System.Windows.Forms.Button();
            this.btCancelClick = new System.Windows.Forms.Button();
            this.rgMetod.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Метод:";
            // 
            // rgMetod
            // 
            this.rgMetod.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.rgMetod.Controls.Add(this.rg1);
            this.rgMetod.Controls.Add(this.rg0);
            this.rgMetod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgMetod.Location = new System.Drawing.Point(16, 83);
            this.rgMetod.Name = "rgMetod";
            this.rgMetod.Size = new System.Drawing.Size(244, 77);
            this.rgMetod.TabIndex = 1;
            this.rgMetod.TabStop = false;
            // 
            // rg1
            // 
            this.rg1.AutoSize = true;
            this.rg1.Location = new System.Drawing.Point(16, 53);
            this.rg1.Name = "rg1";
            this.rg1.Size = new System.Drawing.Size(214, 17);
            this.rg1.TabIndex = 1;
            this.rg1.Text = "С учетом ограничений на показатели";
            this.rg1.UseVisualStyleBackColor = true;
            // 
            // rg0
            // 
            this.rg0.AutoSize = true;
            this.rg0.Checked = true;
            this.rg0.Location = new System.Drawing.Point(16, 19);
            this.rg0.Name = "rg0";
            this.rg0.Size = new System.Drawing.Size(118, 17);
            this.rg0.TabIndex = 0;
            this.rg0.TabStop = true;
            this.rg0.Text = "Случайное сжатие";
            this.rg0.UseVisualStyleBackColor = true;
            // 
            // cbxMetod
            // 
            this.cbxMetod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxMetod.FormattingEnabled = true;
            this.cbxMetod.Items.AddRange(new object[] {
            "Точного решения",
            "Приближенного решения"});
            this.cbxMetod.Location = new System.Drawing.Point(12, 40);
            this.cbxMetod.Name = "cbxMetod";
            this.cbxMetod.Size = new System.Drawing.Size(248, 24);
            this.cbxMetod.TabIndex = 2;
            this.cbxMetod.SelectedIndexChanged += new System.EventHandler(this.CbxMetod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Приближенное решение %:";
            // 
            // edPercent
            // 
            this.edPercent.Location = new System.Drawing.Point(166, 180);
            this.edPercent.Name = "edPercent";
            this.edPercent.Size = new System.Drawing.Size(94, 20);
            this.edPercent.TabIndex = 4;
            this.edPercent.Text = "0";
            // 
            // btOkClick
            // 
            this.btOkClick.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOkClick.Location = new System.Drawing.Point(98, 231);
            this.btOkClick.Name = "btOkClick";
            this.btOkClick.Size = new System.Drawing.Size(75, 23);
            this.btOkClick.TabIndex = 5;
            this.btOkClick.Text = "Принять";
            this.btOkClick.UseVisualStyleBackColor = true;
            this.btOkClick.Click += new System.EventHandler(this.BtOkClick_Click);
            // 
            // btCancelClick
            // 
            this.btCancelClick.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelClick.Location = new System.Drawing.Point(196, 231);
            this.btCancelClick.Name = "btCancelClick";
            this.btCancelClick.Size = new System.Drawing.Size(75, 23);
            this.btCancelClick.TabIndex = 6;
            this.btCancelClick.Text = "Отменить";
            this.btCancelClick.UseVisualStyleBackColor = true;
            this.btCancelClick.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FmMetodOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 266);
            this.Controls.Add(this.btCancelClick);
            this.Controls.Add(this.btOkClick);
            this.Controls.Add(this.edPercent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxMetod);
            this.Controls.Add(this.rgMetod);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FmMetodOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Метод оптимизации";
            this.rgMetod.ResumeLayout(false);
            this.rgMetod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox rgMetod;
        private System.Windows.Forms.RadioButton rg1;
        private System.Windows.Forms.RadioButton rg0;
        private System.Windows.Forms.ComboBox cbxMetod;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox edPercent;
        private System.Windows.Forms.Button btOkClick;
        private System.Windows.Forms.Button btCancelClick;
    }
}