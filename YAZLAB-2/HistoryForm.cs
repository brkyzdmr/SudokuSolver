using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAZLAB_2
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            Application.DoEvents();
        }

        public static void ChangeText(int num)
        {
            //HistoryForm hf = new HistoryForm();
            //StreamReader reader = new StreamReader(Form1.GetFileName(num));
            //string readText = reader.ReadToEnd().Replace(Environment.NewLine, "");
            //Application.DoEvents();

            //hf.rtb_History.AppendText(readText);
        }

        private void cb_ThreadName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cb_ThreadName.Text == "Thread-1")
            //{
            //    ChangeText(1);
            //}
            //else if (cb_ThreadName.Text == "Thread-2")
            //{
            //    ChangeText(2);
            //}
            //else if (cb_ThreadName.Text == "Thread-3")
            //{
            //    ChangeText(3);
            //}
            //else if (cb_ThreadName.Text == "Thread-4")
            //{
            //    ChangeText(4);
            //}
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            //HistoryForm hf = new HistoryForm();
            //hf.rtb_History.Text = "Thread-1";
            //ChangeText(1);
        }
    }
}
