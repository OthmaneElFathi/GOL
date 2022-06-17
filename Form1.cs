namespace GOL
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;  //Tell the user how the process went
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            Reset();
        }
        private void Reset()
        {
            Changed = false;
            Draw = false;
            for (int i = 0; i < numHorizontal * numVertical; i++)
            {
                State[i] = false;
                if (i / numVertical == 0)
                {
                    if (i % numHorizontal == 0)
                    {
                        Moves[i] = new int[3];
                        Moves[i][0] = 1;
                        Moves[i][1] = numHorizontal;
                        Moves[i][2] = numHorizontal + 1;
                    }
                    else if (i % numHorizontal == numHorizontal - 1)
                    {
                        Moves[i] = new int[3];
                        Moves[i][0] = -1;
                        Moves[i][1] = numHorizontal;
                        Moves[i][2] = numHorizontal - 1;
                    }
                    else
                    {
                        Moves[i] = new int[5];
                        Moves[i][0] = 1;
                        Moves[i][1] = -1;
                        Moves[i][2] = numHorizontal;
                        Moves[i][3] = numHorizontal + 1;
                        Moves[i][4] = numHorizontal - 1;
                    }
                }
                else if (i / numVertical == numVertical - 1)
                {
                    if (i % numHorizontal == 0)
                    {
                        Moves[i] = new int[3];
                        Moves[i][0] = 1;
                        Moves[i][1] = -numHorizontal;
                        Moves[i][2] = -numHorizontal + 1;
                    }
                    else if (i % numHorizontal == numHorizontal- 1)
                    {
                        Moves[i] = new int[3];
                        Moves[i][0] = -1;
                        Moves[i][1] = -numHorizontal;
                        Moves[i][2] = -numHorizontal - 1;
                    }
                    else
                    {
                        Moves[i] = new int[5];
                        Moves[i][0] = 1;
                        Moves[i][1] = -1;
                        Moves[i][2] = -numHorizontal;
                        Moves[i][3] = -numHorizontal + 1;
                        Moves[i][4] = -numHorizontal - 1;
                    }
                }
                else
                {
                    if (i % numHorizontal == 0)
                    {
                        Moves[i] = new int[5];
                        Moves[i][0] = 1;
                        Moves[i][1] = numHorizontal;
                        Moves[i][2] = numHorizontal + 1;
                        Moves[i][3] = -numHorizontal;
                        Moves[i][4] = -numHorizontal + 1;
                    }
                    else if (i % numHorizontal == numHorizontal - 1)
                    {
                        Moves[i] = new int[5];
                        Moves[i][0] = -1;
                        Moves[i][1] = numHorizontal;
                        Moves[i][2] = numHorizontal - 1;
                        Moves[i][3] = -numHorizontal;
                        Moves[i][4] = -numHorizontal - 1;
                    }
                    else
                    {
                        Moves[i] = new int[8];
                        Moves[i][0] = 1;
                        Moves[i][1] = -1;
                        Moves[i][2] = numHorizontal;
                        Moves[i][3] = numHorizontal + 1;
                        Moves[i][4] = numHorizontal - 1;
                        Moves[i][5] = -numHorizontal;
                        Moves[i][6] = -numHorizontal + 1;
                        Moves[i][7] = -numHorizontal - 1;
                    }
                }
            }
        }
        private void Repaint()
        {
            Panel1.Refresh();
            Panel1.CreateGraphics().FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 0, squareDim*numHorizontal, squareDim*numVertical));
            for (int i = 0; i <= numVertical; i++)
            {
                Panel1.CreateGraphics().DrawLine(Pens.Black, new Point(xOffset, yOffset + i * squareDim), new Point(xOffset + numVertical * squareDim, yOffset + i * squareDim));
            }
            for (int i = 0; i <= numHorizontal; i++)
            {
                Panel1.CreateGraphics().DrawLine(Pens.Black, new Point(xOffset + i * squareDim, yOffset), new Point(xOffset + i * squareDim, yOffset + numHorizontal * squareDim));
            }
        }
        private bool Changed = false;
        private bool Draw=false;
        static private readonly int numHorizontal = 80;
        static private readonly int numVertical =80;
        static private readonly int squareDim = 10;
        static private readonly int xOffset = 0;
        static private readonly int yOffset = 0;
        private bool[] State =new bool[numHorizontal* numVertical];
        private int[][] Moves =new int[numHorizontal * numVertical][];
        private int[] Changes = new int[numHorizontal * numVertical];
        private int K = 0;
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i <= numVertical; i++)
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(xOffset, yOffset + i * squareDim), new Point(xOffset + numVertical * squareDim, yOffset + i * squareDim));
                }
                for (int i = 0; i <= numHorizontal; i++)
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(xOffset + i * squareDim, yOffset), new Point(xOffset + i * squareDim, yOffset + numHorizontal * squareDim));
                }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Draw = true;
            Button1.Enabled = false;
            Button2.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int i = 0;
            Changed = false;
            
            while (true)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                Compute(i);
                i++;
                if (i == State.Length)
                {
                    Thread.Sleep(100);
                    if (Changed)
                    {
                        for (int j = 0; j < K; j++)
                        {
                            State[Changes[j]] = !State[Changes[j]];
                            Panel1_Draw((Changes[j] % numHorizontal) * squareDim, (Changes[j] / numVertical) * squareDim, Color.Black, !State[Changes[j]]);
                        }
                        Changes = new int[numHorizontal * numVertical];
                        K = 0;
                        i = 0;
                        Changed = false;
                    }
                    else
                        break;
                }

            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Label1.Text = "Process was paused";
            }
            else if (e.Error != null)
            {
                Label1.Text = "There was an error running the process. The thread aborted";
            }
            else
            {
                Label1.Text = "Process was completed";
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Draw = false;
            Button2.Enabled = false;
            Button1.Enabled = true;
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
        private void Panel1_Click(object sender, EventArgs e)
        {
            if (!Draw)
            {
                Point point = Panel1.PointToClient(Cursor.Position);
                int index = (point.Y / squareDim) * numHorizontal + point.X / squareDim;
                int X_S = point.X - (point.X % squareDim);
                int Y_S = point.Y - (point.Y % squareDim);
                Panel1_Draw(X_S, Y_S,Color.Black,State[index]);
                State[index] = !State[index];
            }
        }
        private void Panel1_Draw(int X_S,int Y_S,Color C,bool Mode)
        {
            if (!Mode) { 
            Panel1.CreateGraphics().FillRectangle(new SolidBrush(C), new Rectangle(X_S, Y_S, squareDim, squareDim));
            }
            else
            {
                Panel1.CreateGraphics().FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(X_S, Y_S, squareDim, squareDim));
                Panel1.CreateGraphics().DrawLine(Pens.Black, new Point(X_S, Y_S), new Point(X_S + squareDim, Y_S));
                Panel1.CreateGraphics().DrawLine(Pens.Black, new Point(X_S, Y_S), new Point(X_S, Y_S+squareDim));
                Panel1.CreateGraphics().DrawLine(Pens.Black, new Point(X_S+squareDim, Y_S), new Point(X_S + squareDim, Y_S+squareDim));
                Panel1.CreateGraphics().DrawLine(Pens.Black, new Point(X_S, Y_S+squareDim), new Point(X_S + squareDim, Y_S+squareDim));
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Button2.Enabled = false;
            Button1.Enabled = true;
            Reset();
            Repaint();
        }

        private void Compute(int x)
        {
            int NUM = 0;
            for (int i = 0; i < Moves[x].Length; i++)
            { 
                if (State[x + Moves[x][i]])
                    NUM++;
            }
            if (State[x])
            { 
                if (NUM <= 1 || NUM >= 4)
                {
                    Changed = true;
                    Changes[K]=x;
                    K++;
                }
            }
            else
            {
                if (NUM == 3)
                {
                    Changed = true;
                    Changes[K] = x;
                    K++;
                }
            }
        }
    }
}