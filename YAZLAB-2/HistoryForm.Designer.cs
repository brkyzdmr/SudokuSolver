namespace YAZLAB_2
{
    partial class HistoryForm
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
            this.cb_ThreadName = new System.Windows.Forms.ComboBox();
            this.rtb_History = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cb_ThreadName
            // 
            this.cb_ThreadName.FormattingEnabled = true;
            this.cb_ThreadName.Items.AddRange(new object[] {
            "Thread-1",
            "Thread-2",
            "Thread-3",
            "Thread-4"});
            this.cb_ThreadName.Location = new System.Drawing.Point(12, 12);
            this.cb_ThreadName.Name = "cb_ThreadName";
            this.cb_ThreadName.Size = new System.Drawing.Size(458, 24);
            this.cb_ThreadName.TabIndex = 1;
            this.cb_ThreadName.SelectedIndexChanged += new System.EventHandler(this.cb_ThreadName_SelectedIndexChanged);
            // 
            // rtb_History
            // 
            this.rtb_History.Location = new System.Drawing.Point(12, 42);
            this.rtb_History.Name = "rtb_History";
            this.rtb_History.Size = new System.Drawing.Size(458, 662);
            this.rtb_History.TabIndex = 2;
            this.rtb_History.Text = "";
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 716);
            this.Controls.Add(this.rtb_History);
            this.Controls.Add(this.cb_ThreadName);
            this.Name = "HistoryForm";
            this.Text = "HistoryForm";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_ThreadName;
        private System.Windows.Forms.RichTextBox rtb_History;
    }
}