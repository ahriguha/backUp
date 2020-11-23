namespace AMAZING_STOPWATCH
{
    partial class StopwatchForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new FontAwesome.Sharp.IconButton();
            this.btnPause = new FontAwesome.Sharp.IconButton();
            this.btnStop = new FontAwesome.Sharp.IconButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(50, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "0:0:0.000";
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnStart.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStart.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            this.btnStart.IconColor = System.Drawing.Color.Gainsboro;
            this.btnStart.IconSize = 40;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.Location = new System.Drawing.Point(67, 117);
            this.btnStart.Name = "btnStart";
            this.btnStart.Rotation = 0D;
            this.btnStart.Size = new System.Drawing.Size(37, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPause.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPause.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
            this.btnPause.IconColor = System.Drawing.Color.Gainsboro;
            this.btnPause.IconSize = 40;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.Location = new System.Drawing.Point(110, 117);
            this.btnPause.Name = "btnPause";
            this.btnPause.Rotation = 0D;
            this.btnPause.Size = new System.Drawing.Size(37, 34);
            this.btnPause.TabIndex = 2;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnStop.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStop.IconChar = FontAwesome.Sharp.IconChar.StopCircle;
            this.btnStop.IconColor = System.Drawing.Color.Gainsboro;
            this.btnStop.IconSize = 40;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Location = new System.Drawing.Point(153, 117);
            this.btnStop.Name = "btnStop";
            this.btnStop.Rotation = 0D;
            this.btnStop.Size = new System.Drawing.Size(37, 34);
            this.btnStop.TabIndex = 3;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StopwatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(61)))), ((int)(((byte)(159)))));
            this.ClientSize = new System.Drawing.Size(237, 163);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Name = "StopwatchForm";
            this.Text = "StopwatchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnStart;
        private FontAwesome.Sharp.IconButton btnPause;
        private FontAwesome.Sharp.IconButton btnStop;
        private System.Windows.Forms.Timer timer1;
    }
}