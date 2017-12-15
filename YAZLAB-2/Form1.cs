// 150202041 Berkay Ezdemir
// 150201216 İbrahim Burak Ezdemir
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAZLAB_2
{
    public partial class Form1 : Form
    {
        private int[,] sudokuCells = new int[9, 9];
        private int[,] tempSudokuCells = new int[9, 9];
        private int[,] tempSudokuCells2 = new int[9, 9];
        private int[,] tempSudokuCells3 = new int[9, 9];
        private int[,] tempSudokuCells4 = new int[9, 9];
        private int[,] sudokuTable = new int[9, 9];
        private bool isOpen = false;
        private System.Timers.Timer timer;
        private String fileName;
        private int[] threadHistory = new int[4];
        Thread thread1, thread2, thread3, thread4;
        private PossibilityArray[,] possibilities = new PossibilityArray[9, 9];
        DateTime timeNow, timeNow2;
        public static List<string> history = new List<string>();

        public Form1()
        {
            InitializeComponent();
            InitializePA();
        }

        public void InitializePA()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    possibilities[y, x] = new PossibilityArray(new BitArray(9), x, y);
                }
            }
        }

        private String OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text|*.txt;";
            
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                isOpen = true;
                return ofd.FileName;
            }
            return null;
        }

        private void GetTextFromFile()
        {
            fileName = OpenFile();
            char[] ch;
            int k = 0;
            if (fileName != null)
            {
                StreamReader reader = new StreamReader(fileName);
                string readText = reader.ReadToEnd().Replace(Environment.NewLine, "");
                ch = readText.ToCharArray();

                for (int y = 0; y < 9; y++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        if (ch[k] == '*')
                        {
                            sudokuCells[y, x] = 0;
                        }
                        else if (Char.IsDigit(ch[k]))
                        {
                            sudokuCells[y, x] = (int)Char.GetNumericValue(ch[k]);
                        }
                        Debug.Write(sudokuCells[y, x] + " ");

                        k++;
                    }
                    Debug.Write("\n");
                }
                reader.Close();
            }
            ArrayTemper();
            this.Refresh();
        }

        private void ArrayTemper()
        {
            Array.Copy(sudokuCells, tempSudokuCells, sudokuCells.Length);
            Array.Copy(sudokuCells, tempSudokuCells2, sudokuCells.Length);
            Array.Copy(sudokuCells, tempSudokuCells3, sudokuCells.Length);
            Array.Copy(sudokuCells, tempSudokuCells4, sudokuCells.Length);
            Array.Copy(sudokuCells, sudokuTable, sudokuCells.Length);
        }

        private void WriteHistoryToFile(int[,] grid)
        {            
            String tempFileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\Thread" + Thread.CurrentThread.Name + ".txt";
            int currentThreadName = Int32.Parse(Thread.CurrentThread.Name);

            if (!File.Exists(tempFileName))
            {
                File.Create(tempFileName).Dispose();
                using (TextWriter writer = new StreamWriter(tempFileName))
                {
                    writer.Write("#" + threadHistory[currentThreadName-1] + "\r\n");
                    for (int y = 0; y < 9; y++)
                    {
                        for (int x = 0; x < 9; x++)
                        {
                            writer.Write(grid[y, x]);
                        }
                        writer.Write("\r\n");
                    }
                    threadHistory[currentThreadName - 1]++;
                    writer.Close();
                }
            }
            else if (File.Exists(tempFileName))
            {
                threadHistory[currentThreadName-1]++;
                using (TextWriter writer = new StreamWriter(tempFileName, true))
                {
                    writer.Write("\r\n#" + threadHistory[currentThreadName-1] + "\r\n");
                    for (int y = 0; y < 9; y++)
                    {
                        for (int x = 0; x < 9; x++)
                        {
                            writer.Write(grid[y, x]);
                        }
                        writer.Write("\r\n");
                    }
                    threadHistory[currentThreadName - 1]++;
                    writer.Close();
                }
            }            
        }

        private void ThreadStarter()
        {
            thread1 = new Thread(new ThreadStart(ThreadsSolveCall))
            {
                Name = "1"
            };
            thread1.Start();
            //timeNow = DateTime.Now.ToString("h:mm:ss.fff");
            timeNow = DateTime.Parse(DateTime.Now.ToString("h:mm:ss.fff"));
            timer = new System.Timers.Timer();
            timer.Start();

            thread2 = new Thread(new ThreadStart(ThreadsSolveCall))
            {
                Name = "2"
            };
            thread2.Start();

            thread3 = new Thread(new ThreadStart(ThreadsSolveCall))
            {
                Name = "3"
            };
            thread3.Start();

            thread4 = new Thread(new ThreadStart(ThreadsSolveCall))
            {
                Name = "4"
            };
            thread4.Start();            
        }

        private void ThreadsSolveCall()
        {
            if(Thread.CurrentThread.Name == "1")
            {
                SolveTable(1);
            }
            if (Thread.CurrentThread.Name == "2")
            {
                SolveTable(3);
            }
            if (Thread.CurrentThread.Name == "3")
            {
                SolveTable(7);
            }
            if (Thread.CurrentThread.Name == "4")
            {
                SolveTable(9);
            }
        }

        private void SolveTable(int startCell)
        {                 
            if(startCell == 1)
            {
                if(SolveSudoku(tempSudokuCells))
                {
                    thread2.Abort();
                    thread3.Abort();
                    thread4.Abort();
                    Array.Copy(tempSudokuCells, sudokuTable, sudokuCells.Length);
                    Debug.Write("\nÇözüm Bulundu!\n");
                    timeNow2 = DateTime.Parse(DateTime.Now.ToString("h:mm:ss.fff"));
                    TimeCalculation();
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txt_ThreadName.Text = "Thread : Thread-1";
                    });
                }
                Array.Copy(tempSudokuCells, sudokuTable, sudokuCells.Length);
                PrintSudoku();
            }
            else if(startCell == 3)
            {
                if (SolveSudoku(tempSudokuCells2))
                {
                    thread1.Abort();
                    thread3.Abort();
                    thread4.Abort();
                    Array.Copy(tempSudokuCells2, sudokuTable, sudokuCells.Length);
                    Debug.Write("\nÇözüm Bulundu!\n");
                    timeNow2 = DateTime.Parse(DateTime.Now.ToString("h:mm:ss.fff"));
                    TimeCalculation();
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txt_ThreadName.Text = "Thread : Thread-2";
                    });
                }
                Array.Copy(tempSudokuCells2, sudokuTable, sudokuCells.Length);
                PrintSudoku();
            }
            else if(startCell == 7)
            {
                if (SolveSudoku(tempSudokuCells3))
                {
                    thread1.Abort();
                    thread2.Abort();
                    thread4.Abort();
                    Array.Copy(tempSudokuCells3, sudokuTable, sudokuCells.Length);
                    Debug.Write("\nÇözüm Bulundu!\n");
                    timeNow2 = DateTime.Parse(DateTime.Now.ToString("h:mm:ss.fff"));
                    TimeCalculation();
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txt_ThreadName.Text = "Thread : Thread-3";
                    });
                }
                Array.Copy(tempSudokuCells3, sudokuTable, sudokuCells.Length);
                PrintSudoku();
            }
            else if(startCell == 9)
            {
                if (SolveSudoku(tempSudokuCells4))
                {
                    thread1.Abort();
                    thread2.Abort();
                    thread3.Abort();
                    Array.Copy(tempSudokuCells4, sudokuTable, sudokuCells.Length);
                    Debug.Write("\nÇözüm Bulundu!\n");
                    timeNow2 = DateTime.Parse(DateTime.Now.ToString("h:mm:ss.fff"));
                    TimeCalculation();
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txt_ThreadName.Text = "Thread : Thread-4";
                    });
                }
                Array.Copy(tempSudokuCells4, sudokuTable, sudokuCells.Length);
                PrintSudoku();
            }
        }

        private void TimeCalculation()
        {
            TimeSpan Time = timeNow2.Subtract(timeNow);
            this.Invoke((MethodInvoker)delegate
            {
                this.txt_Timer.Text = "Time : " + Time.ToString();
            });
        }

        public static string GetFileName(int threadNum)
        {
            String fileName = Path.GetDirectoryName(Application.ExecutablePath) + 
                "\\Thread" + threadNum + ".txt";
            
            return fileName;
        }

        private void PrintSudoku()
        {
            Debug.Write("\r\n");
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Debug.Write(sudokuTable[y, x].ToString());
                }
                Debug.Write("\r\n");
            }
            this.Invoke((MethodInvoker)delegate
            {
                this.Refresh();
            });
        }

        private bool SolveSudoku(int[,] grid)
        {
            WriteHistoryToFile(grid);

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if(grid[y, x] == 0)
                    {
                        bool result = false;
                        int k = 1;
                        while(!result)
                        {
                            if(k == 10)
                            {
                                grid[y, x] = 0;
                                return false;
                            }
                            grid[y, x] = k;
                            k++;
                            result = testRow(grid, x, y) && testCol(grid, x, y) && testBlock(grid, x, y);
                            if(!result)
                            {
                                continue;
                            }
                            result = SolveSudoku(grid);
                        }
                    }
                }
               
            }
            return true;
        }

        public bool testRow(int[,] grid, int x, int y)
        {
            int key = grid[y, x];

            for(int i=0; i<9; i++)
            {
                if(i == x)
                {
                    continue;
                }
                if(key == grid[y, i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool testCol(int[,] grid, int x, int y)
        {
            int key = grid[y, x];

            for (int i = 0; i < 9; i++)
            {
                if (i == y)
                {
                    continue;
                }
                if (key == grid[i, x])
                {
                    return false;
                }
            }
            return true;
        }

        public bool testBlock(int[,] grid, int x, int y)
        {

            int key = grid[y, x];

            int k_gap = 3 * (y / 3);
            int l_gap = 3 * (x / 3);

            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    if (y == k_gap + k && x == l_gap + l)
                        continue;
                    if (grid[k_gap + k, l_gap + l] == key)
                        return false;
                }
            }
            return true;
        }

        private void btn_History_Click(object sender, EventArgs e)
        {
            HistoryForm hf = new HistoryForm();
            hf.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        public static void Exit()
        {
            for (int i = 1; i <= 4; i++)
            {
                String tempFileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\Thread" + i + ".txt";

                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            GetTextFromFile();           

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen black1 = new Pen(Color.FromArgb(255, 0, 0, 0));
            black1.Width = 1;
            Pen black2 = new Pen(Color.FromArgb(255, 0, 0, 0));
            black2.Width = 3;

            for (int i=0; i<=9; i++)
            {
                if (i == 0 || i == 3 || i == 6 || i == 9)
                {
                    e.Graphics.DrawLine(black2, 20 + i * 45, 20, 20 + i * 45, 425);
                    e.Graphics.DrawLine(black2, 20, 20 + i * 45, 425, 20 + i * 45);
                }
                else
                {
                    e.Graphics.DrawLine(black1, 20 + i * 45, 20, 20 + i * 45, 425);
                    e.Graphics.DrawLine(black1, 20, 20 + i * 45, 425, 20 + i * 45);
                }
            }

            Font drawFont = new System.Drawing.Font("Consolas", 16);
            SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            StringFormat drawFormat = new StringFormat();

            if (isOpen)
            {
                int i=0, j=0;
                for (int y = 0; y < 9; y++)
                {                                      
                    for (int x = 0; x < 9; x++)
                    {                        
                        e.Graphics.DrawString(sudokuTable[y, x].ToString(), drawFont, drawBrush, 20+10+i*22.5f, 20+10+j*22.5f, drawFormat);
                        i += 2;
                    }
                    i = 0;
                    j += 2;
                }
            }
        }

        private void btn_Solve_Click(object sender, EventArgs e)
        {
            GC.Collect();
            ThreadStarter();
            GC.Collect();
        }
    }
}
