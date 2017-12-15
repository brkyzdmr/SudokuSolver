namespace YAZLAB_2
{
    partial class Form1
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
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Solve = new System.Windows.Forms.Button();
            this.btn_History = new System.Windows.Forms.Button();
            this.txt_Timer = new System.Windows.Forms.Label();
            this.txt_ThreadName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Open
            // 
            this.btn_Open.Font = new System.Drawing.Font("Schadow BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Open.Location = new System.Drawing.Point(600, 20);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(112, 39);
            this.btn_Open.TabIndex = 1;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Solve
            // 
            this.btn_Solve.Font = new System.Drawing.Font("Schadow BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Solve.Location = new System.Drawing.Point(600, 67);
            this.btn_Solve.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Solve.Name = "btn_Solve";
            this.btn_Solve.Size = new System.Drawing.Size(112, 39);
            this.btn_Solve.TabIndex = 3;
            this.btn_Solve.Text = "Solve";
            this.btn_Solve.UseVisualStyleBackColor = true;
            this.btn_Solve.Click += new System.EventHandler(this.btn_Solve_Click);
            // 
            // btn_History
            // 
            this.btn_History.Font = new System.Drawing.Font("Schadow BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_History.Location = new System.Drawing.Point(600, 114);
            this.btn_History.Margin = new System.Windows.Forms.Padding(4);
            this.btn_History.Name = "btn_History";
            this.btn_History.Size = new System.Drawing.Size(112, 39);
            this.btn_History.TabIndex = 4;
            this.btn_History.Text = "History";
            this.btn_History.UseVisualStyleBackColor = true;
            this.btn_History.Click += new System.EventHandler(this.btn_History_Click);
            // 
            // txt_Timer
            // 
            this.txt_Timer.AutoSize = true;
            this.txt_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_Timer.Location = new System.Drawing.Point(333, 544);
            this.txt_Timer.Name = "txt_Timer";
            this.txt_Timer.Size = new System.Drawing.Size(61, 20);
            this.txt_Timer.TabIndex = 7;
            this.txt_Timer.Text = "Time : ";
            // 
            // txt_ThreadName
            // 
            this.txt_ThreadName.AutoSize = true;
            this.txt_ThreadName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_ThreadName.Location = new System.Drawing.Point(12, 544);
            this.txt_ThreadName.Name = "txt_ThreadName";
            this.txt_ThreadName.Size = new System.Drawing.Size(76, 20);
            this.txt_ThreadName.TabIndex = 8;
            this.txt_ThreadName.Text = "Thread : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 586);
            this.Controls.Add(this.txt_ThreadName);
            this.Controls.Add(this.txt_Timer);
            this.Controls.Add(this.btn_History);
            this.Controls.Add(this.btn_Solve);
            this.Controls.Add(this.btn_Open);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sudoku Solver";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Solve;
        private System.Windows.Forms.Button btn_History;
        private System.Windows.Forms.Label txt_Timer;
        private System.Windows.Forms.Label txt_ThreadName;
    }
}

