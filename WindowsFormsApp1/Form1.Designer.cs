
namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.solutionGraph = new ZedGraph.ZedGraphControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.compareOption = new System.Windows.Forms.RadioButton();
            this.rungeKuttaOption = new System.Windows.Forms.RadioButton();
            this.modifEulerOption = new System.Windows.Forms.RadioButton();
            this.eulerOption = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.simpleSquareOption = new System.Windows.Forms.RadioButton();
            this.squareOption = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rightBorder = new System.Windows.Forms.TextBox();
            this.leftBorder = new System.Windows.Forms.TextBox();
            this.iterMax = new System.Windows.Forms.TextBox();
            this.startYValue = new System.Windows.Forms.TextBox();
            this.solutionTable = new System.Windows.Forms.DataGridView();
            this.calculation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solutionTable)).BeginInit();
            this.SuspendLayout();
            // 
            // solutionGraph
            // 
            this.solutionGraph.BackColor = System.Drawing.Color.Turquoise;
            this.solutionGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.solutionGraph.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solutionGraph.IsEnableHPan = false;
            this.solutionGraph.IsEnableHZoom = false;
            this.solutionGraph.IsEnableVPan = false;
            this.solutionGraph.IsEnableVZoom = false;
            this.solutionGraph.Location = new System.Drawing.Point(305, 12);
            this.solutionGraph.Name = "solutionGraph";
            this.solutionGraph.ScrollGrace = 0D;
            this.solutionGraph.ScrollMaxX = 0D;
            this.solutionGraph.ScrollMaxY = 0D;
            this.solutionGraph.ScrollMaxY2 = 0D;
            this.solutionGraph.ScrollMinX = 0D;
            this.solutionGraph.ScrollMinY = 0D;
            this.solutionGraph.ScrollMinY2 = 0D;
            this.solutionGraph.Size = new System.Drawing.Size(480, 456);
            this.solutionGraph.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Aquamarine;
            this.groupBox1.Controls.Add(this.compareOption);
            this.groupBox1.Controls.Add(this.rungeKuttaOption);
            this.groupBox1.Controls.Add(this.modifEulerOption);
            this.groupBox1.Controls.Add(this.eulerOption);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 66);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Метод";
            // 
            // compareOption
            // 
            this.compareOption.AutoSize = true;
            this.compareOption.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compareOption.Location = new System.Drawing.Point(101, 42);
            this.compareOption.Name = "compareOption";
            this.compareOption.Size = new System.Drawing.Size(129, 19);
            this.compareOption.TabIndex = 3;
            this.compareOption.TabStop = true;
            this.compareOption.Text = "сравнение методов";
            this.compareOption.UseVisualStyleBackColor = true;
            this.compareOption.CheckedChanged += new System.EventHandler(this.CompareOption_CheckedChanged);
            // 
            // rungeKuttaOption
            // 
            this.rungeKuttaOption.AutoSize = true;
            this.rungeKuttaOption.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rungeKuttaOption.Location = new System.Drawing.Point(6, 41);
            this.rungeKuttaOption.Name = "rungeKuttaOption";
            this.rungeKuttaOption.Size = new System.Drawing.Size(87, 19);
            this.rungeKuttaOption.TabIndex = 2;
            this.rungeKuttaOption.Text = "Рунге-Кутта";
            this.rungeKuttaOption.UseVisualStyleBackColor = true;
            this.rungeKuttaOption.CheckedChanged += new System.EventHandler(this.MethodOption_CheckedChanged);
            // 
            // modifEulerOption
            // 
            this.modifEulerOption.AutoSize = true;
            this.modifEulerOption.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modifEulerOption.Location = new System.Drawing.Point(101, 19);
            this.modifEulerOption.Name = "modifEulerOption";
            this.modifEulerOption.Size = new System.Drawing.Size(173, 19);
            this.modifEulerOption.TabIndex = 1;
            this.modifEulerOption.Text = "модифицированный Эйлер";
            this.modifEulerOption.UseVisualStyleBackColor = true;
            this.modifEulerOption.CheckedChanged += new System.EventHandler(this.MethodOption_CheckedChanged);
            // 
            // eulerOption
            // 
            this.eulerOption.AutoSize = true;
            this.eulerOption.Checked = true;
            this.eulerOption.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eulerOption.Location = new System.Drawing.Point(6, 19);
            this.eulerOption.Name = "eulerOption";
            this.eulerOption.Size = new System.Drawing.Size(58, 19);
            this.eulerOption.TabIndex = 0;
            this.eulerOption.TabStop = true;
            this.eulerOption.Text = "Эйлер";
            this.eulerOption.UseVisualStyleBackColor = true;
            this.eulerOption.CheckedChanged += new System.EventHandler(this.MethodOption_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox2.Controls.Add(this.simpleSquareOption);
            this.groupBox2.Controls.Add(this.squareOption);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 66);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Функция производной";
            // 
            // simpleSquareOption
            // 
            this.simpleSquareOption.AutoSize = true;
            this.simpleSquareOption.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpleSquareOption.Location = new System.Drawing.Point(159, 29);
            this.simpleSquareOption.Name = "simpleSquareOption";
            this.simpleSquareOption.Size = new System.Drawing.Size(61, 19);
            this.simpleSquareOption.TabIndex = 2;
            this.simpleSquareOption.Text = "y + x^2";
            this.simpleSquareOption.UseVisualStyleBackColor = true;
            this.simpleSquareOption.CheckedChanged += new System.EventHandler(this.DerivativeOption_CheckedChanged);
            // 
            // squareOption
            // 
            this.squareOption.AutoSize = true;
            this.squareOption.Checked = true;
            this.squareOption.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.squareOption.Location = new System.Drawing.Point(32, 29);
            this.squareOption.Name = "squareOption";
            this.squareOption.Size = new System.Drawing.Size(90, 19);
            this.squareOption.TabIndex = 1;
            this.squareOption.TabStop = true;
            this.squareOption.Text = "1 + ( x - y )^2";
            this.squareOption.UseVisualStyleBackColor = true;
            this.squareOption.CheckedChanged += new System.EventHandler(this.DerivativeOption_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Aquamarine;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.iterMax);
            this.groupBox3.Controls.Add(this.startYValue);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 141);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Условия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество итераций";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Значение y в x0";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.rightBorder);
            this.groupBox4.Controls.Add(this.leftBorder);
            this.groupBox4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(142, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 65);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Область решений";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(68, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "A";
            // 
            // rightBorder
            // 
            this.rightBorder.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightBorder.Location = new System.Drawing.Point(90, 29);
            this.rightBorder.Name = "rightBorder";
            this.rightBorder.Size = new System.Drawing.Size(30, 23);
            this.rightBorder.TabIndex = 1;
            this.rightBorder.TextChanged += new System.EventHandler(this.CheckTextChanged);
            this.rightBorder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RightBorderKeyPress);
            // 
            // leftBorder
            // 
            this.leftBorder.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftBorder.Location = new System.Drawing.Point(27, 29);
            this.leftBorder.Name = "leftBorder";
            this.leftBorder.Size = new System.Drawing.Size(30, 23);
            this.leftBorder.TabIndex = 0;
            this.leftBorder.TextChanged += new System.EventHandler(this.CheckTextChanged);
            this.leftBorder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LeftBorderKeyPress);
            // 
            // iterMax
            // 
            this.iterMax.BackColor = System.Drawing.SystemColors.Window;
            this.iterMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iterMax.Location = new System.Drawing.Point(23, 98);
            this.iterMax.Name = "iterMax";
            this.iterMax.Size = new System.Drawing.Size(83, 20);
            this.iterMax.TabIndex = 3;
            this.iterMax.TextChanged += new System.EventHandler(this.CheckTextChanged);
            this.iterMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IterMaxKeyPress);
            // 
            // startYValue
            // 
            this.startYValue.BackColor = System.Drawing.SystemColors.Window;
            this.startYValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startYValue.Location = new System.Drawing.Point(23, 44);
            this.startYValue.Name = "startYValue";
            this.startYValue.Size = new System.Drawing.Size(83, 20);
            this.startYValue.TabIndex = 2;
            this.startYValue.TextChanged += new System.EventHandler(this.CheckTextChanged);
            this.startYValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartYValueKeyPress);
            // 
            // solutionTable
            // 
            this.solutionTable.BackgroundColor = System.Drawing.Color.Turquoise;
            this.solutionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solutionTable.Location = new System.Drawing.Point(12, 351);
            this.solutionTable.Name = "solutionTable";
            this.solutionTable.Size = new System.Drawing.Size(287, 117);
            this.solutionTable.TabIndex = 4;
            // 
            // calculation
            // 
            this.calculation.BackColor = System.Drawing.Color.PaleTurquoise;
            this.calculation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calculation.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculation.Location = new System.Drawing.Point(12, 315);
            this.calculation.Name = "calculation";
            this.calculation.Size = new System.Drawing.Size(287, 30);
            this.calculation.TabIndex = 5;
            this.calculation.Text = "Вычислить";
            this.calculation.UseVisualStyleBackColor = false;
            this.calculation.Click += new System.EventHandler(this.CalculationClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(797, 481);
            this.Controls.Add(this.calculation);
            this.Controls.Add(this.solutionTable);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.solutionGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Решение задачи Коши для ОДУ 1 порядка";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solutionTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl solutionGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton eulerOption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton squareOption;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rightBorder;
        private System.Windows.Forms.TextBox leftBorder;
        private System.Windows.Forms.TextBox iterMax;
        private System.Windows.Forms.TextBox startYValue;
        private System.Windows.Forms.DataGridView solutionTable;
        private System.Windows.Forms.Button calculation;
        private System.Windows.Forms.RadioButton rungeKuttaOption;
        private System.Windows.Forms.RadioButton modifEulerOption;
        private System.Windows.Forms.RadioButton simpleSquareOption;
        private System.Windows.Forms.RadioButton compareOption;
    }
}

