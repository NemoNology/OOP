
namespace OOP__IV__Lab_7_WF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.history = new System.Windows.Forms.ToolStripComboBox();
            this.b_div = new System.Windows.Forms.Button();
            this.b_sin = new System.Windows.Forms.Button();
            this.b_clearEverything = new System.Windows.Forms.Button();
            this.b_cos = new System.Windows.Forms.Button();
            this.b_tan = new System.Windows.Forms.Button();
            this.b_ln = new System.Windows.Forms.Button();
            this.b_exp = new System.Windows.Forms.Button();
            this.b_hook = new System.Windows.Forms.Button();
            this.b_clear = new System.Windows.Forms.Button();
            this.b_7 = new System.Windows.Forms.Button();
            this.b_8 = new System.Windows.Forms.Button();
            this.b_9 = new System.Windows.Forms.Button();
            this.b_4 = new System.Windows.Forms.Button();
            this.b_5 = new System.Windows.Forms.Button();
            this.b_6 = new System.Windows.Forms.Button();
            this.b_1 = new System.Windows.Forms.Button();
            this.b_2 = new System.Windows.Forms.Button();
            this.b_3 = new System.Windows.Forms.Button();
            this.b_0 = new System.Windows.Forms.Button();
            this.b_dot = new System.Windows.Forms.Button();
            this.b_mul = new System.Windows.Forms.Button();
            this.b_sub = new System.Windows.Forms.Button();
            this.b_add = new System.Windows.Forms.Button();
            this.b_getAnswer = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.previousExpression = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(348, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.history});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(67, 20);
            this.toolStripDropDownButton1.Text = "История";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.History_Click);
            // 
            // history
            // 
            this.history.BackColor = System.Drawing.SystemColors.Window;
            this.history.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.history.ForeColor = System.Drawing.SystemColors.ControlText;
            this.history.Name = "history";
            this.history.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.history.Size = new System.Drawing.Size(121, 23);
            this.history.SelectedIndexChanged += new System.EventHandler(this.SelectedIndex_Changed);
            this.history.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_div
            // 
            this.b_div.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_div.BackColor = System.Drawing.Color.Orange;
            this.b_div.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_div.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_div.Location = new System.Drawing.Point(276, 112);
            this.b_div.Name = "b_div";
            this.b_div.Size = new System.Drawing.Size(60, 50);
            this.b_div.TabIndex = 1;
            this.b_div.TabStop = false;
            this.b_div.Text = "÷";
            this.b_div.UseVisualStyleBackColor = false;
            this.b_div.Click += new System.EventHandler(this.ArithmeticFunction_Click);
            this.b_div.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_sin
            // 
            this.b_sin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_sin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.b_sin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_sin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_sin.ForeColor = System.Drawing.SystemColors.Control;
            this.b_sin.Location = new System.Drawing.Point(12, 112);
            this.b_sin.Name = "b_sin";
            this.b_sin.Size = new System.Drawing.Size(60, 50);
            this.b_sin.TabIndex = 1;
            this.b_sin.TabStop = false;
            this.b_sin.Text = "sin";
            this.b_sin.UseVisualStyleBackColor = false;
            this.b_sin.Click += new System.EventHandler(this.TriginometricFunction_Click);
            this.b_sin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_clearEverything
            // 
            this.b_clearEverything.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_clearEverything.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_clearEverything.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_clearEverything.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_clearEverything.ForeColor = System.Drawing.SystemColors.Control;
            this.b_clearEverything.Location = new System.Drawing.Point(78, 112);
            this.b_clearEverything.Name = "b_clearEverything";
            this.b_clearEverything.Size = new System.Drawing.Size(60, 50);
            this.b_clearEverything.TabIndex = 1;
            this.b_clearEverything.TabStop = false;
            this.b_clearEverything.Text = "CE";
            this.b_clearEverything.UseVisualStyleBackColor = false;
            this.b_clearEverything.Click += new System.EventHandler(this.ClearEverything_Click);
            this.b_clearEverything.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_cos
            // 
            this.b_cos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_cos.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.b_cos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_cos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.b_cos.ForeColor = System.Drawing.SystemColors.Control;
            this.b_cos.Location = new System.Drawing.Point(12, 168);
            this.b_cos.Name = "b_cos";
            this.b_cos.Size = new System.Drawing.Size(60, 50);
            this.b_cos.TabIndex = 1;
            this.b_cos.TabStop = false;
            this.b_cos.Text = "cos";
            this.b_cos.UseVisualStyleBackColor = false;
            this.b_cos.Click += new System.EventHandler(this.TriginometricFunction_Click);
            this.b_cos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_tan
            // 
            this.b_tan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_tan.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.b_tan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_tan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.b_tan.ForeColor = System.Drawing.SystemColors.Control;
            this.b_tan.Location = new System.Drawing.Point(12, 224);
            this.b_tan.Name = "b_tan";
            this.b_tan.Size = new System.Drawing.Size(60, 50);
            this.b_tan.TabIndex = 1;
            this.b_tan.TabStop = false;
            this.b_tan.Text = "tan";
            this.b_tan.UseVisualStyleBackColor = false;
            this.b_tan.Click += new System.EventHandler(this.TriginometricFunction_Click);
            this.b_tan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_ln
            // 
            this.b_ln.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_ln.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.b_ln.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_ln.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.b_ln.ForeColor = System.Drawing.SystemColors.Control;
            this.b_ln.Location = new System.Drawing.Point(12, 280);
            this.b_ln.Name = "b_ln";
            this.b_ln.Size = new System.Drawing.Size(60, 50);
            this.b_ln.TabIndex = 1;
            this.b_ln.TabStop = false;
            this.b_ln.Text = "ln";
            this.b_ln.UseVisualStyleBackColor = false;
            this.b_ln.Click += new System.EventHandler(this.TriginometricFunction_Click);
            this.b_ln.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_exp
            // 
            this.b_exp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_exp.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.b_exp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.b_exp.ForeColor = System.Drawing.SystemColors.Control;
            this.b_exp.Location = new System.Drawing.Point(12, 336);
            this.b_exp.Name = "b_exp";
            this.b_exp.Size = new System.Drawing.Size(60, 50);
            this.b_exp.TabIndex = 1;
            this.b_exp.TabStop = false;
            this.b_exp.Text = "exp";
            this.b_exp.UseVisualStyleBackColor = false;
            this.b_exp.Click += new System.EventHandler(this.TriginometricFunction_Click);
            this.b_exp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_hook
            // 
            this.b_hook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_hook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_hook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_hook.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_hook.ForeColor = System.Drawing.SystemColors.Control;
            this.b_hook.Location = new System.Drawing.Point(144, 112);
            this.b_hook.Name = "b_hookOpen";
            this.b_hook.Size = new System.Drawing.Size(27, 50);
            this.b_hook.TabIndex = 1;
            this.b_hook.TabStop = false;
            this.b_hook.Text = "(";
            this.b_hook.UseVisualStyleBackColor = false;
            this.b_hook.Click += new System.EventHandler(this.Hook_Click);
            this.b_hook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_clear
            // 
            this.b_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_clear.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_clear.ForeColor = System.Drawing.SystemColors.Control;
            this.b_clear.Location = new System.Drawing.Point(210, 112);
            this.b_clear.Name = "b_clear";
            this.b_clear.Size = new System.Drawing.Size(60, 50);
            this.b_clear.TabIndex = 1;
            this.b_clear.TabStop = false;
            this.b_clear.Text = "C";
            this.b_clear.UseVisualStyleBackColor = false;
            this.b_clear.Click += new System.EventHandler(this.Clear_Click);
            this.b_clear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_7
            // 
            this.b_7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_7.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_7.ForeColor = System.Drawing.SystemColors.Control;
            this.b_7.Location = new System.Drawing.Point(78, 168);
            this.b_7.Name = "b_7";
            this.b_7.Size = new System.Drawing.Size(60, 50);
            this.b_7.TabIndex = 1;
            this.b_7.TabStop = false;
            this.b_7.Text = "7";
            this.b_7.UseVisualStyleBackColor = false;
            this.b_7.Click += new System.EventHandler(this.Digit_Click);
            this.b_7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_8
            // 
            this.b_8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_8.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_8.ForeColor = System.Drawing.SystemColors.Control;
            this.b_8.Location = new System.Drawing.Point(144, 168);
            this.b_8.Name = "b_8";
            this.b_8.Size = new System.Drawing.Size(60, 50);
            this.b_8.TabIndex = 1;
            this.b_8.TabStop = false;
            this.b_8.Text = "8";
            this.b_8.UseVisualStyleBackColor = false;
            this.b_8.Click += new System.EventHandler(this.Digit_Click);
            this.b_8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_9
            // 
            this.b_9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_9.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_9.ForeColor = System.Drawing.SystemColors.Control;
            this.b_9.Location = new System.Drawing.Point(210, 168);
            this.b_9.Name = "b_9";
            this.b_9.Size = new System.Drawing.Size(60, 50);
            this.b_9.TabIndex = 1;
            this.b_9.TabStop = false;
            this.b_9.Text = "9";
            this.b_9.UseVisualStyleBackColor = false;
            this.b_9.Click += new System.EventHandler(this.Digit_Click);
            this.b_9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_4
            // 
            this.b_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_4.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_4.ForeColor = System.Drawing.SystemColors.Control;
            this.b_4.Location = new System.Drawing.Point(78, 224);
            this.b_4.Name = "b_4";
            this.b_4.Size = new System.Drawing.Size(60, 50);
            this.b_4.TabIndex = 1;
            this.b_4.TabStop = false;
            this.b_4.Text = "4";
            this.b_4.UseVisualStyleBackColor = false;
            this.b_4.Click += new System.EventHandler(this.Digit_Click);
            this.b_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_5
            // 
            this.b_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_5.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_5.ForeColor = System.Drawing.SystemColors.Control;
            this.b_5.Location = new System.Drawing.Point(144, 224);
            this.b_5.Name = "b_5";
            this.b_5.Size = new System.Drawing.Size(60, 50);
            this.b_5.TabIndex = 1;
            this.b_5.TabStop = false;
            this.b_5.Text = "5";
            this.b_5.UseVisualStyleBackColor = false;
            this.b_5.Click += new System.EventHandler(this.Digit_Click);
            this.b_5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_6
            // 
            this.b_6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_6.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_6.ForeColor = System.Drawing.SystemColors.Control;
            this.b_6.Location = new System.Drawing.Point(210, 224);
            this.b_6.Name = "b_6";
            this.b_6.Size = new System.Drawing.Size(60, 50);
            this.b_6.TabIndex = 1;
            this.b_6.TabStop = false;
            this.b_6.Text = "6";
            this.b_6.UseVisualStyleBackColor = false;
            this.b_6.Click += new System.EventHandler(this.Digit_Click);
            this.b_6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_1
            // 
            this.b_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_1.ForeColor = System.Drawing.SystemColors.Control;
            this.b_1.Location = new System.Drawing.Point(78, 280);
            this.b_1.Name = "b_1";
            this.b_1.Size = new System.Drawing.Size(60, 50);
            this.b_1.TabIndex = 1;
            this.b_1.TabStop = false;
            this.b_1.Text = "1";
            this.b_1.UseVisualStyleBackColor = false;
            this.b_1.Click += new System.EventHandler(this.Digit_Click);
            this.b_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_2
            // 
            this.b_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_2.ForeColor = System.Drawing.SystemColors.Control;
            this.b_2.Location = new System.Drawing.Point(144, 280);
            this.b_2.Name = "b_2";
            this.b_2.Size = new System.Drawing.Size(60, 50);
            this.b_2.TabIndex = 1;
            this.b_2.TabStop = false;
            this.b_2.Text = "2";
            this.b_2.UseVisualStyleBackColor = false;
            this.b_2.Click += new System.EventHandler(this.Digit_Click);
            this.b_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_3
            // 
            this.b_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_3.ForeColor = System.Drawing.SystemColors.Control;
            this.b_3.Location = new System.Drawing.Point(210, 280);
            this.b_3.Name = "b_3";
            this.b_3.Size = new System.Drawing.Size(60, 50);
            this.b_3.TabIndex = 1;
            this.b_3.TabStop = false;
            this.b_3.Text = "3";
            this.b_3.UseVisualStyleBackColor = false;
            this.b_3.Click += new System.EventHandler(this.Digit_Click);
            this.b_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_0
            // 
            this.b_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_0.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_0.ForeColor = System.Drawing.SystemColors.Control;
            this.b_0.Location = new System.Drawing.Point(78, 336);
            this.b_0.Name = "b_0";
            this.b_0.Size = new System.Drawing.Size(126, 50);
            this.b_0.TabIndex = 1;
            this.b_0.TabStop = false;
            this.b_0.Text = "0";
            this.b_0.UseVisualStyleBackColor = false;
            this.b_0.Click += new System.EventHandler(this.Digit_Click);
            this.b_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_dot
            // 
            this.b_dot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_dot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.b_dot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_dot.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_dot.ForeColor = System.Drawing.SystemColors.Control;
            this.b_dot.Location = new System.Drawing.Point(210, 336);
            this.b_dot.Name = "b_dot";
            this.b_dot.Size = new System.Drawing.Size(60, 50);
            this.b_dot.TabIndex = 1;
            this.b_dot.TabStop = false;
            this.b_dot.Text = ".";
            this.b_dot.UseVisualStyleBackColor = false;
            this.b_dot.Click += new System.EventHandler(this.Dot_Click);
            this.b_dot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_mul
            // 
            this.b_mul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_mul.BackColor = System.Drawing.Color.Orange;
            this.b_mul.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_mul.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_mul.Location = new System.Drawing.Point(276, 168);
            this.b_mul.Name = "b_mul";
            this.b_mul.Size = new System.Drawing.Size(60, 50);
            this.b_mul.TabIndex = 1;
            this.b_mul.TabStop = false;
            this.b_mul.Text = "×";
            this.b_mul.UseVisualStyleBackColor = false;
            this.b_mul.Click += new System.EventHandler(this.ArithmeticFunction_Click);
            this.b_mul.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_sub
            // 
            this.b_sub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_sub.BackColor = System.Drawing.Color.Orange;
            this.b_sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_sub.Location = new System.Drawing.Point(276, 224);
            this.b_sub.Name = "b_sub";
            this.b_sub.Size = new System.Drawing.Size(26, 50);
            this.b_sub.TabIndex = 1;
            this.b_sub.TabStop = false;
            this.b_sub.Text = "-";
            this.b_sub.UseVisualStyleBackColor = false;
            this.b_sub.Click += new System.EventHandler(this.ArithmeticFunction_Click);
            this.b_sub.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_add
            // 
            this.b_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_add.BackColor = System.Drawing.Color.Orange;
            this.b_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_add.Location = new System.Drawing.Point(310, 224);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(26, 50);
            this.b_add.TabIndex = 1;
            this.b_add.TabStop = false;
            this.b_add.Text = "+";
            this.b_add.UseVisualStyleBackColor = false;
            this.b_add.Click += new System.EventHandler(this.ArithmeticFunction_Click);
            this.b_add.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // b_getAnswer
            // 
            this.b_getAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_getAnswer.BackColor = System.Drawing.Color.Orange;
            this.b_getAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_getAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_getAnswer.Location = new System.Drawing.Point(276, 336);
            this.b_getAnswer.Name = "b_getAnswer";
            this.b_getAnswer.Size = new System.Drawing.Size(60, 50);
            this.b_getAnswer.TabIndex = 1;
            this.b_getAnswer.TabStop = false;
            this.b_getAnswer.Text = "=";
            this.b_getAnswer.UseVisualStyleBackColor = false;
            this.b_getAnswer.Click += new System.EventHandler(this.GetAnswer_Click);
            this.b_getAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // input
            // 
            this.input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input.Enabled = false;
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input.ForeColor = System.Drawing.SystemColors.Control;
            this.input.Location = new System.Drawing.Point(12, 60);
            this.input.MaximumSize = new System.Drawing.Size(324, 37);
            this.input.Name = "input";
            this.input.ReadOnly = true;
            this.input.ShortcutsEnabled = false;
            this.input.Size = new System.Drawing.Size(324, 37);
            this.input.TabIndex = 2;
            this.input.TabStop = false;
            this.input.Text = "0";
            this.input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.input.TextChanged += new System.EventHandler(this.InputText_Changed);
            this.input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // previousExpression
            // 
            this.previousExpression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.previousExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previousExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.previousExpression.ForeColor = System.Drawing.Color.Silver;
            this.previousExpression.Location = new System.Drawing.Point(12, 35);
            this.previousExpression.MaximumSize = new System.Drawing.Size(324, 19);
            this.previousExpression.Name = "previousExpression";
            this.previousExpression.ReadOnly = true;
            this.previousExpression.Size = new System.Drawing.Size(324, 19);
            this.previousExpression.TabIndex = 2;
            this.previousExpression.TabStop = false;
            this.previousExpression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.previousExpression.Click += new System.EventHandler(this.PreviousExpression_Click);
            this.previousExpression.TextChanged += new System.EventHandler(this.PreviousExpressionText_Changed);
            this.previousExpression.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            this.previousExpression.MouseLeave += new System.EventHandler(this.PreviousExpression_MouseLeave);
            this.previousExpression.MouseHover += new System.EventHandler(this.PreviousExpression_MouseHover);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(177, 112);
            this.button1.Name = "b_hookClose";
            this.button1.Size = new System.Drawing.Size(27, 50);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = ")";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Hook_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(276, 280);
            this.button2.Name = "b_exponentiation";
            this.button2.Size = new System.Drawing.Size(60, 50);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "^";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ArithmeticFunction_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(348, 411);
            this.Controls.Add(this.previousExpression);
            this.Controls.Add(this.input);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.b_getAnswer);
            this.Controls.Add(this.b_add);
            this.Controls.Add(this.b_sub);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.b_mul);
            this.Controls.Add(this.b_div);
            this.Controls.Add(this.b_exp);
            this.Controls.Add(this.b_ln);
            this.Controls.Add(this.b_tan);
            this.Controls.Add(this.b_cos);
            this.Controls.Add(this.b_sin);
            this.Controls.Add(this.b_dot);
            this.Controls.Add(this.b_3);
            this.Controls.Add(this.b_6);
            this.Controls.Add(this.b_9);
            this.Controls.Add(this.b_clear);
            this.Controls.Add(this.b_2);
            this.Controls.Add(this.b_0);
            this.Controls.Add(this.b_1);
            this.Controls.Add(this.b_5);
            this.Controls.Add(this.b_4);
            this.Controls.Add(this.b_8);
            this.Controls.Add(this.b_7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_hook);
            this.Controls.Add(this.b_clearEverything);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button b_div;
        private System.Windows.Forms.Button b_sin;
        private System.Windows.Forms.Button b_clearEverything;
        private System.Windows.Forms.Button b_cos;
        private System.Windows.Forms.Button b_tan;
        private System.Windows.Forms.Button b_ln;
        private System.Windows.Forms.Button b_exp;
        private System.Windows.Forms.Button b_hook;
        private System.Windows.Forms.Button b_clear;
        private System.Windows.Forms.Button b_7;
        private System.Windows.Forms.Button b_8;
        private System.Windows.Forms.Button b_9;
        private System.Windows.Forms.Button b_4;
        private System.Windows.Forms.Button b_5;
        private System.Windows.Forms.Button b_6;
        private System.Windows.Forms.Button b_1;
        private System.Windows.Forms.Button b_2;
        private System.Windows.Forms.Button b_3;
        private System.Windows.Forms.Button b_0;
        private System.Windows.Forms.Button b_dot;
        private System.Windows.Forms.Button b_mul;
        private System.Windows.Forms.Button b_sub;
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.Button b_getAnswer;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox previousExpression;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripComboBox history;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

