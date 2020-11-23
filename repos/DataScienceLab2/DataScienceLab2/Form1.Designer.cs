namespace DataScienceLab2
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Исходные данные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.temperature,
            this.windSpeed,
            this.windDir,
            this.precip});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(566, 319);
            this.dataGridView1.TabIndex = 1;
            // 
            // date
            // 
            this.date.HeaderText = "date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // temperature
            // 
            this.temperature.HeaderText = "temperature";
            this.temperature.Name = "temperature";
            this.temperature.ReadOnly = true;
            // 
            // windSpeed
            // 
            this.windSpeed.HeaderText = "wind Speed";
            this.windSpeed.Name = "windSpeed";
            this.windSpeed.ReadOnly = true;
            // 
            // windDir
            // 
            this.windDir.HeaderText = "wind Direction";
            this.windDir.Name = "windDir";
            this.windDir.ReadOnly = true;
            // 
            // precip
            // 
            this.precip.HeaderText = "precipation";
            this.precip.Name = "precip";
            this.precip.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 64);
            this.button2.TabIndex = 2;
            this.button2.Text = "Данные после обработки аномалий";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(205, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 64);
            this.button3.TabIndex = 4;
            this.button3.Text = "Данные после нормализации";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(301, 337);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 64);
            this.button4.TabIndex = 5;
            this.button4.Text = "Кодирование категориальных данных";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 408);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn windSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn windDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn precip;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

