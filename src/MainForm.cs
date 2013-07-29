using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace aiGenetic
{
    public partial class MainForm : Form
    {
        int w = 10;
        int h = 10;
        List<Point> listG = new List<Point>();

        Genetic ga;
        Settings s;
        TSP tsp;
        List<Chromosome> bob = new List<Chromosome>();
        int maxBob = 2;
        Chromosome best = null;

        public MainForm()
        {
            //Rectangle screen = SystemInformation.VirtualScreen;
            //this.Location = new Point(screen.Width - this.Width - 100, screen.Height - this.Height - 100);
            InitializeComponent();
            nudDetail.Maximum = nudPopulation.Value;
            s = new Settings();
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            buttonLaunch.Enabled = false;
            tsp = new TSP(listG);
            SettingsDlg dlg = new SettingsDlg(s);

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                s = dlg.S;
                tsp.Init();
                tbLog.Text = string.Empty;
                Run((int)nudMaxIterations.Value);
            }
            buttonLaunch.Enabled = true;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            listG.Clear();
            panel1.Refresh();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            listG.Clear();

            for (int i = 0; i < nudRandNumber.Value; ++i)
            {
                int x = 0;
                int y = 0;
                x = rnd.Next(0, panel1.Width - w) / 10;
                y = rnd.Next(0, panel1.Height - h) / 10;
                listG.Add(new Point(x, y));
            }
            if (groupBox5.Enabled == false)
                if (listG.Count > 3)
                {
                    buttonLaunch.Enabled = true;
                    buttonLaunch.Select();
                }
            panel1.Refresh();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (groupBox4.Enabled == false)
            {
                //MessageBox.Show(e.X.ToString() + " " + e.Y.ToString());
                int x = 0;
                int y = 0;
                x = e.X;
                y = e.Y;
                listG.Add(new Point(x / 10, y / 10));
                Refresh();
                if (listG.Count > 3)
                {
                    buttonLaunch.Enabled = true;
                    buttonLaunch.Select();
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void checkBoxEditMode_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox4.Enabled == false)
                groupBox4.Enabled = true;
            else
                groupBox4.Enabled = false;

            listG.Clear();
            checkBoxAdvanced.Checked = false;
            nudRandNumber.Value = 1;
            buttonLaunch.Enabled = false;
            panel1.Refresh();
        }

        private void checkBoxAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdvanced.Checked == true)
                groupBox5.Enabled = true;
            else
                groupBox5.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int i = 0;
            foreach (Point p in listG)
            {
                e.Graphics.FillEllipse(Brushes.Red, (p.X /*- w / 2*/) * 10, p.Y * 10, w, h);
                String drawString = i.ToString() + " (" + listG[i].X.ToString() + ", " + listG[i].Y.ToString() + ")";
                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                Point drawPoint = new Point(((panel1.Width - listG[i].X * 10) > 100 ?
                    (listG[i].X + 2) * 10 : (listG[i].X - 7) * 10), listG[i].Y * 10);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
                ++i;
            }
            DrawBestPath(e.Graphics);
        }

        /// <summary>
        /// Гдавная процедура работы ГА.
        /// </summary>
        /// <param name="generations">Макс. число поколений.</param>
        private void Run(int generations)
        {
            Graphics dc = panel1.CreateGraphics();
            tbLog.AppendText("Города:\r\n");
            for (int i = 0; i != listG.Count; ++i)
                tbLog.AppendText(i + ": (" + listG[i].X + ", " + listG[i].Y + ")\r\n");
            tbLog.AppendText("\r\nХод решения:\r\n");

            uint generation = 0;

            bool bRun = true;
            if ((ga = new Genetic((int)nudPopulation.Value, tsp, s)) == null)
                MessageBox.Show("Error 0");
            else
            {
                bob.Clear();
                ga.Update();
                while (bRun && (generations-- != 0))
                {
                    generation++;
                    ga.DoRecombination();
                    ga.Update();
                    best = ga.FindBest();
                    bob.Add(best);
                    UpdateBest(generation, dc);

                    if (ga.DoMutation())
                    {
                        ga.Update();
                        best = ga.FindBest();
                        bob.Add(best);
                        UpdateBest(generation, dc);
                    }

                    bRun = !Stop();
                    bool b = bRun;
                }
                buttonLaunch.Enabled = true;
                nudBob.Select();
            }
        }

        /// <summary>
        /// Проверяет условие выхода.
        /// </summary>
        /// <returns>true, если можно остановить алгоритм.</returns>
        private bool Stop()
        {
            maxBob = (int)nudBob.Value;
            while (bob.Count > maxBob)
                bob.RemoveAt(0);
            int eqs = -1;

            for (int i = 0; i < bob.Count - 1; )
                if (bob[i].Equals(bob[++i]))
                    ++eqs;

            bool b = (eqs >= 0 && (eqs == maxBob - 2));
            return b;
        }

        /// <summary>
        /// Выводит данные о лучшем экземпляре.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="era"></param>
        /// <param name="dc"></param>
        private void UpdateBest(uint era, Graphics dc)
        {
            Refresh();
            DrawBestPath(dc);
            tbLog.AppendText("Поколение: " + era +
               "\r\nЛучший = {" + best.ToString() + "}\r\nРасстояние: " + best.NonFitness + "\r\n");

            //MessageBox.Show("Поколение: " + era +
            //   "\r\nЛучший = {" + best.ToString() + "}\r\nРасстояние: " + best.NonFitness);
        }

        /// <summary>
        /// Рисует лучший путь.
        /// </summary>
        /// <param name="dc"></param>
        void DrawBestPath(Graphics dc)
        {
            if (best == null)
                return;
            int Nlines = listG.Count - 1;
            Point cur, next;
            for (int i = 0; i != Nlines; )
            {
                cur = listG[best.Path[i]];
                next = listG[best.Path[++i]];
                dc.DrawLine(new Pen(Color.Blue), new Point(cur.X * 10 + 5, cur.Y * 10 + 5), new Point(next.X * 10 + 5, next.Y * 10 + 5));
            }
            cur = listG[best.Path[Nlines]];
            next = listG[best.Path[0]];
            dc.DrawLine(new Pen(Color.Blue), new Point(cur.X * 10 + 5, cur.Y * 10 + 5), new Point(next.X * 10 + 5, next.Y * 10 + 5));

        }

        /// <summary>
        /// Сбрасывает информацию на форме.
        /// </summary>
        private void ClearForm()
        {
            listG.Clear();
            checkBoxAdvanced.Checked = false;
            nudRandNumber.Value = 1;
            buttonLaunch.Enabled = false;
            checkBoxEditMode.Checked = false;
            tbLog.Text = string.Empty;
            panel1.Refresh();
            s.Init();
        }

        private void buttonPR_Click(object sender, EventArgs e)
        {
        }

        private void nudRandNumber_ValueChanged(object sender, EventArgs e)
        {
            buttonGenerate.Select();
        }
    }
}
