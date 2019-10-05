namespace geliosNEW
{
    partial class FmParamAlternative
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
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.acAddExecute = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.acDelExecute = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTypeParam = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.lbNum = new System.Windows.Forms.Label();
            this.pbTfs = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sgParam = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTfs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sgParam)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(797, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 385);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(885, 37);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // acAddExecute
            // 
            this.acAddExecute.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acAddExecute.Location = new System.Drawing.Point(3, 3);
            this.acAddExecute.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.acAddExecute.Name = "acAddExecute";
            this.acAddExecute.Size = new System.Drawing.Size(112, 44);
            this.acAddExecute.TabIndex = 1;
            this.acAddExecute.Text = "Добавить альтернативу";
            this.acAddExecute.UseVisualStyleBackColor = true;
            this.acAddExecute.Click += new System.EventHandler(this.AcAddExecute_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(121, 3);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "Редактировать альтернативу";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(357, 3);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 44);
            this.button4.TabIndex = 3;
            this.button4.Text = "Генерация возможных альтернатив";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(523, 3);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(157, 44);
            this.button5.TabIndex = 4;
            this.button5.Text = "Формирование парам. альтернатив";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanel2.Controls.Add(this.acAddExecute);
            this.flowLayoutPanel2.Controls.Add(this.button3);
            this.flowLayoutPanel2.Controls.Add(this.acDelExecute);
            this.flowLayoutPanel2.Controls.Add(this.button4);
            this.flowLayoutPanel2.Controls.Add(this.button5);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(885, 54);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // acDelExecute
            // 
            this.acDelExecute.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acDelExecute.Location = new System.Drawing.Point(239, 3);
            this.acDelExecute.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.acDelExecute.Name = "acDelExecute";
            this.acDelExecute.Size = new System.Drawing.Size(112, 44);
            this.acDelExecute.TabIndex = 5;
            this.acDelExecute.Text = "Удалить альтернативу";
            this.acDelExecute.UseVisualStyleBackColor = true;
            this.acDelExecute.Click += new System.EventHandler(this.acDelExecute_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lbTypeParam, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbType, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbCount, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbNum, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbTfs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 123);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lbTypeParam
            // 
            this.lbTypeParam.AutoSize = true;
            this.lbTypeParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTypeParam.Location = new System.Drawing.Point(619, 90);
            this.lbTypeParam.Name = "lbTypeParam";
            this.lbTypeParam.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbTypeParam.Size = new System.Drawing.Size(21, 21);
            this.lbTypeParam.TabIndex = 8;
            this.lbTypeParam.Text = "0";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbType.Location = new System.Drawing.Point(619, 60);
            this.lbType.Name = "lbType";
            this.lbType.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbType.Size = new System.Drawing.Size(21, 21);
            this.lbType.TabIndex = 7;
            this.lbType.Text = "0";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCount.Location = new System.Drawing.Point(619, 30);
            this.lbCount.Name = "lbCount";
            this.lbCount.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbCount.Size = new System.Drawing.Size(21, 21);
            this.lbCount.TabIndex = 6;
            this.lbCount.Text = "0";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNum.Location = new System.Drawing.Point(619, 0);
            this.lbNum.Name = "lbNum";
            this.lbNum.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbNum.Size = new System.Drawing.Size(21, 21);
            this.lbNum.TabIndex = 5;
            this.lbNum.Text = "0";
            // 
            // pbTfs
            // 
            this.pbTfs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbTfs.Location = new System.Drawing.Point(3, 3);
            this.pbTfs.Name = "pbTfs";
            this.tableLayoutPanel1.SetRowSpan(this.pbTfs, 4);
            this.pbTfs.Size = new System.Drawing.Size(191, 117);
            this.pbTfs.TabIndex = 0;
            this.pbTfs.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(355, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер блока-родителя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(355, 30);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(184, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Кол-во параметрических альтернатив:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(355, 60);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Тип подблока:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(355, 90);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Тип параметров:";
            // 
            // sgParam
            // 
            this.sgParam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sgParam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sgParam.BackgroundColor = System.Drawing.SystemColors.Control;
            this.sgParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sgParam.Location = new System.Drawing.Point(3, 181);
            this.sgParam.MultiSelect = false;
            this.sgParam.Name = "sgParam";
            this.sgParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sgParam.Size = new System.Drawing.Size(879, 201);
            this.sgParam.TabIndex = 5;
            // 
            // FmParamAlternative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 422);
            this.Controls.Add(this.sgParam);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(733, 300);
            this.Name = "FmParamAlternative";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Формирование параметрических альтернатив";
            this.Shown += new System.EventHandler(this.FmParamAlternative_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTfs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sgParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button acAddExecute;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView sgParam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTypeParam;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label lbNum;
        public System.Windows.Forms.PictureBox pbTfs;
        private System.Windows.Forms.Button acDelExecute;
    }
}