
namespace DateClassUsing_WF
{
    partial class MainForm
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
            this.input_year = new System.Windows.Forms.NumericUpDown();
            this.l_year = new System.Windows.Forms.Label();
            this.l_month = new System.Windows.Forms.Label();
            this.input_month = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.l_day = new System.Windows.Forms.Label();
            this.input_day = new System.Windows.Forms.NumericUpDown();
            this.l_leapness = new System.Windows.Forms.Label();
            this.leapness = new System.Windows.Forms.Label();
            this.l_separator = new System.Windows.Forms.Label();
            this.l_daysAmount = new System.Windows.Forms.Label();
            this.daysAmount = new System.Windows.Forms.Label();
            this.l_monthName = new System.Windows.Forms.Label();
            this.monthName = new System.Windows.Forms.Label();
            this.arrayOfData = new System.Windows.Forms.TextBox();
            this.b_generate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.input_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_month)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_day)).BeginInit();
            this.SuspendLayout();
            // 
            // input_year
            // 
            this.input_year.BackColor = System.Drawing.SystemColors.Control;
            this.input_year.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input_year.Location = new System.Drawing.Point(85, 10);
            this.input_year.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.input_year.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.input_year.Name = "input_year";
            this.input_year.Size = new System.Drawing.Size(87, 22);
            this.input_year.TabIndex = 0;
            this.input_year.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.input_year.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_Changed);
            // 
            // l_year
            // 
            this.l_year.AutoSize = true;
            this.l_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_year.Location = new System.Drawing.Point(12, 9);
            this.l_year.Name = "l_year";
            this.l_year.Size = new System.Drawing.Size(46, 20);
            this.l_year.TabIndex = 1;
            this.l_year.Text = "Год:";
            // 
            // l_month
            // 
            this.l_month.AutoSize = true;
            this.l_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_month.Location = new System.Drawing.Point(12, 37);
            this.l_month.Name = "l_month";
            this.l_month.Size = new System.Drawing.Size(67, 20);
            this.l_month.TabIndex = 3;
            this.l_month.Text = "Месяц:";
            // 
            // input_month
            // 
            this.input_month.BackColor = System.Drawing.SystemColors.Control;
            this.input_month.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input_month.Location = new System.Drawing.Point(85, 38);
            this.input_month.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.input_month.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.input_month.Name = "input_month";
            this.input_month.Size = new System.Drawing.Size(87, 22);
            this.input_month.TabIndex = 2;
            this.input_month.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.input_month.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_Changed);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(395, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(16, 17);
            this.status.Text = "...";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(23, 23);
            // 
            // l_day
            // 
            this.l_day.AutoSize = true;
            this.l_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_day.Location = new System.Drawing.Point(12, 65);
            this.l_day.Name = "l_day";
            this.l_day.Size = new System.Drawing.Size(57, 20);
            this.l_day.TabIndex = 6;
            this.l_day.Text = "День:";
            // 
            // input_day
            // 
            this.input_day.BackColor = System.Drawing.SystemColors.Control;
            this.input_day.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input_day.Location = new System.Drawing.Point(85, 66);
            this.input_day.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.input_day.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.input_day.Name = "input_day";
            this.input_day.Size = new System.Drawing.Size(87, 22);
            this.input_day.TabIndex = 5;
            this.input_day.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.input_day.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_Changed);
            // 
            // l_leapness
            // 
            this.l_leapness.AutoSize = true;
            this.l_leapness.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_leapness.Location = new System.Drawing.Point(13, 128);
            this.l_leapness.Name = "l_leapness";
            this.l_leapness.Size = new System.Drawing.Size(107, 17);
            this.l_leapness.TabIndex = 6;
            this.l_leapness.Text = "Весокосен? -";
            // 
            // leapness
            // 
            this.leapness.AutoSize = true;
            this.leapness.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leapness.Location = new System.Drawing.Point(126, 128);
            this.leapness.Name = "leapness";
            this.leapness.Size = new System.Drawing.Size(23, 17);
            this.leapness.TabIndex = 6;
            this.leapness.Text = "...";
            // 
            // l_separator
            // 
            this.l_separator.AutoSize = true;
            this.l_separator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_separator.Location = new System.Drawing.Point(-4, 101);
            this.l_separator.Name = "l_separator";
            this.l_separator.Size = new System.Drawing.Size(194, 17);
            this.l_separator.TabIndex = 6;
            this.l_separator.Text = "-------------------------------";
            // 
            // l_daysAmount
            // 
            this.l_daysAmount.AutoSize = true;
            this.l_daysAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_daysAmount.Location = new System.Drawing.Point(13, 163);
            this.l_daysAmount.Name = "l_daysAmount";
            this.l_daysAmount.Size = new System.Drawing.Size(124, 17);
            this.l_daysAmount.TabIndex = 6;
            this.l_daysAmount.Text = "Дней в месяце:";
            // 
            // daysAmount
            // 
            this.daysAmount.AutoSize = true;
            this.daysAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.daysAmount.Location = new System.Drawing.Point(143, 163);
            this.daysAmount.Name = "daysAmount";
            this.daysAmount.Size = new System.Drawing.Size(23, 17);
            this.daysAmount.TabIndex = 6;
            this.daysAmount.Text = "...";
            // 
            // l_monthName
            // 
            this.l_monthName.AutoSize = true;
            this.l_monthName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_monthName.Location = new System.Drawing.Point(13, 198);
            this.l_monthName.Name = "l_monthName";
            this.l_monthName.Size = new System.Drawing.Size(60, 17);
            this.l_monthName.TabIndex = 6;
            this.l_monthName.Text = "Месяц:";
            // 
            // monthName
            // 
            this.monthName.AutoSize = true;
            this.monthName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthName.Location = new System.Drawing.Point(79, 198);
            this.monthName.Name = "monthName";
            this.monthName.Size = new System.Drawing.Size(23, 17);
            this.monthName.TabIndex = 6;
            this.monthName.Text = "...";
            // 
            // arrayOfData
            // 
            this.arrayOfData.Location = new System.Drawing.Point(12, 261);
            this.arrayOfData.Multiline = true;
            this.arrayOfData.Name = "arrayOfData";
            this.arrayOfData.ReadOnly = true;
            this.arrayOfData.Size = new System.Drawing.Size(371, 155);
            this.arrayOfData.TabIndex = 7;
            // 
            // b_generate
            // 
            this.b_generate.Location = new System.Drawing.Point(119, 232);
            this.b_generate.Name = "b_generate";
            this.b_generate.Size = new System.Drawing.Size(160, 23);
            this.b_generate.TabIndex = 8;
            this.b_generate.Text = "Сгинерировать массив";
            this.b_generate.UseVisualStyleBackColor = true;
            this.b_generate.Click += new System.EventHandler(this.b_generate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 441);
            this.Controls.Add(this.b_generate);
            this.Controls.Add(this.arrayOfData);
            this.Controls.Add(this.monthName);
            this.Controls.Add(this.daysAmount);
            this.Controls.Add(this.leapness);
            this.Controls.Add(this.l_separator);
            this.Controls.Add(this.l_monthName);
            this.Controls.Add(this.l_daysAmount);
            this.Controls.Add(this.l_leapness);
            this.Controls.Add(this.l_day);
            this.Controls.Add(this.input_day);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.l_month);
            this.Controls.Add(this.input_month);
            this.Controls.Add(this.l_year);
            this.Controls.Add(this.input_year);
            this.Name = "MainForm";
            this.Text = "Лаб-ая №1: Дата ";
            ((System.ComponentModel.ISupportInitialize)(this.input_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_month)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_day)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown input_year;
        private System.Windows.Forms.Label l_year;
        private System.Windows.Forms.Label l_month;
        private System.Windows.Forms.NumericUpDown input_month;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label l_day;
        private System.Windows.Forms.NumericUpDown input_day;
        private System.Windows.Forms.Label l_leapness;
        private System.Windows.Forms.Label leapness;
        private System.Windows.Forms.Label l_separator;
        private System.Windows.Forms.Label l_daysAmount;
        private System.Windows.Forms.Label daysAmount;
        private System.Windows.Forms.Label l_monthName;
        private System.Windows.Forms.Label monthName;
        private System.Windows.Forms.TextBox arrayOfData;
        private System.Windows.Forms.Button b_generate;
        private System.Windows.Forms.ToolStripStatusLabel status;
    }
}

