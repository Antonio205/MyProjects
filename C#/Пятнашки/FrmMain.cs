using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Pyatnashki
{
    public partial class Pyatnashki : Form
    {
        private Game g;
        List<GameResult> userData = new List<GameResult>(10);
        XmlSerializer formatter; 
        string filename = "XMLFile2.xml";
        int time = 0;
        private DateTime startTime;
        private bool stop = false;
        public Pyatnashki()
        {
            InitializeComponent();
        }
        DateTime date1 = new DateTime(0, 0);
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            time++;
            date1 = date1.AddSeconds(1);
            textBoxTime.Text = date1.ToString("mm:ss");
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            cheat = 0;
            stop = false;
            g.StartGame(true);
            showGrid();
            startTime = DateTime.Now;
            check(g);
            timerRestart();
            count = 0;
            textBoxMot.Text = count.ToString();
        }
        private void showGrid()
        {
            dataGridView1.ClearSelection();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (g.puzzle[i, j] > 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = g.puzzle[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.AntiqueWhite;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "";
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Beige;
                    }
                }
            }
        }
        private void check(Game g)
        {
            if (!g.isPlayable())
            {
                g.StartGame(true);
                showGrid();
                check(g);
                timerRestart();
                count = 0;
                textBoxMot.Text = count.ToString();
            }
        }
        private void timerRestart()
        {
            textBoxTime.Text = "00:00";
            date1 = new DateTime(0, 0);
            gameTimer.Enabled = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            using (FileStream fs = new FileStream(filename, FileMode.Truncate))
            {
                /*using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("");
                }*/
                // userData = (:ist<GameResult>)formatter.Deserialize(fs);
                formatter.Serialize(fs, userData);
            }
            MessageBox.Show("Спасибо за игру!\n Результаты были сохранены.");
        }
        private void RepeatGameButton_Click(object sender, EventArgs e)
        {
            cheat = 0;
            stop = false;
            g.StartGame(false);
            showGrid();
            check(g);
            timerRestart();
            time = 0;
            startTime = DateTime.Now;
            count = 0;
            textBoxMot.Text = count.ToString();
        }

        private void Pyatnashki_Load(object sender, EventArgs e)
        {
            formatter = new XmlSerializer(typeof(List<GameResult>));
            startTime = DateTime.Now;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                if (fs.Length > 0)
                {
                    userData = (List<GameResult>)formatter.Deserialize(fs);
                    //formatter.Serialize(fs, userData);
                }
            }
            g = new Game();
            dataGridView1.RowCount = 4;
            dataGridView1.ColumnCount = 4;
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows[i].Height = 75;
                dataGridView1.Columns[i].Width = 75;
            }
            showGrid();
            check(g);
            gameTimer.Start();
            textBoxMot.Text = count.ToString();
            textBoxTime.Text = "00:00";
        }

        private bool Change_Place(int Row, int Column)
        {
            if (dataGridView1.CurrentCell.RowIndex == Row && dataGridView1.CurrentCell.ColumnIndex == Column)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

       

        int count = 0;
        private void GridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cheat = 0;
            if (Change_Place(g.getZeroRow(), g.getZeroColumn() + 1))
            {
                g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow(), g.getZeroColumn() + 1]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            if (Change_Place(g.getZeroRow(), g.getZeroColumn() - 1))
            {
                g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow(), g.getZeroColumn() - 1]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            if (Change_Place(g.getZeroRow() + 1, g.getZeroColumn()))
            {
                g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow() + 1, g.getZeroColumn()]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            if (Change_Place(g.getZeroRow() - 1, g.getZeroColumn()))
            {
                g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow() - 1, g.getZeroColumn()]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            showGrid();
            if (g.isFinished())
            {
                gameTimer.Stop();
                stop = true;
                MessageBox.Show("You win!");
                userData.Add(new GameResult(nick.Text, startTime, time, Convert.ToInt32(textBoxMot.Text)));
                userData.Sort((x, y) => (x.BeginTime).CompareTo(y.BeginTime));
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, userData);
                }
            }
        }


        private void Mix_Click(object sender, EventArgs e)
        {
            if (stop)
            {
                cheat = 0;
                for (int i = 0; i < 100; i++)
                {
                    
                    Random random = new Random();
                    int pos = random.Next(4);
                    if (pos == 0 && g.getZeroRow() - 1 > 0)
                    {
                        g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow() - 1, g.getZeroColumn()]);
                        count++;
                    }
                    else if (pos == 1 && g.getZeroColumn() - 1 > 0)
                    {
                        g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow(), g.getZeroColumn() - 1]);
                        count++;
                    }
                    else if (pos == 2 && g.getZeroColumn() + 1 < 4)
                    {
                        g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow(), g.getZeroColumn() + 1]);
                        count++;
                    }
                    else if (pos == 3 && g.getZeroRow() + 1 < 4)
                    {
                        g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow() + 1, g.getZeroColumn()]);
                        count++;
                    }
                    else
                    {
                        i--;
                    }
                }
                stop = false;
                timerRestart();
                count = 0;
                textBoxMot.Text = 0.ToString();
                showGrid();
            }
        }
        
        int cheat = 0;
        private void Time_Click(object sender, EventArgs e)
        {
            cheat++;
            if (cheat == 5)
            {
                int temp = 1;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        g.puzzle[i, j] = temp;
                        temp++;
                    }

                }
                g.puzzle[3, 3] = 0;
                gameTimer.Stop();
                
                userData.Add(new GameResult(nick.Text, startTime, time, Convert.ToInt32(textBoxMot.Text)));
                userData.Sort((x, y) => (x.BeginTime).CompareTo(y.BeginTime));
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, userData);
                }
                showGrid();
                stop = true;
                MessageBox.Show("You win!");
            }
        }

        private void Mix_New_Click(object sender, EventArgs e)
        {
            int t = 1;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(t == 16)
                    {
                        g.puzzle[i, j] = 0;
                    }
                    else
                    {
                        g.puzzle[i, j] = t;
                    }
                    t++;
                }
            }
            for (int i = 0; i < 100; i++)
            {
                Random f = new Random();
                int pos = f.Next(4);
                if (pos == 0 && g.getZeroRow() - 1 > 0)
                {
                    g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow() - 1, g.getZeroColumn()]);
                    count++;
                }
                else if (pos == 1 && g.getZeroColumn() - 1 > 0)
                {
                    g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow(), g.getZeroColumn() - 1]);
                    count++;
                }
                else if (pos == 2 && g.getZeroColumn() + 1 < 4)
                {
                    g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow(), g.getZeroColumn() + 1]);
                    count++;
                }
                else if (pos == 3 && g.getZeroRow() + 1 < 4)
                {
                    g.swap(ref g.puzzle[g.getZeroRow(), g.getZeroColumn()], ref g.puzzle[g.getZeroRow() + 1, g.getZeroColumn()]);
                    count++;
                }
                else
                {
                    i--;
                }
            }
            stop = false;
            count = 0;
            cheat = 0;
            startTime = DateTime.Now;
            textBoxMot.Text = 0.ToString();
            timerRestart();
            showGrid();
        }

        private void BLastResult_Click(object sender, EventArgs e)
        {
            string results = "";
            var dataToDisplay = (userData.Count > 10) ? userData.GetRange(userData.Count - 10, 10) : userData;
            foreach (var item in dataToDisplay)
            {
                results += String.Format("Время начала сборки:{0}, имя игрока: {1}, шаги: {2}, время: {3} sec\n",
                item.BeginTime, item.Player, item.StepNumber, item.CollectTime);
            }

            MessageBox.Show(results);
        }

        private void BBestSteps_Click_1(object sender, EventArgs e)
        {
            List<GameResult> userDataBS = userData;
            userDataBS.Sort((x, y) => x.StepNumber.CompareTo(y.StepNumber));
            string results = "";
            var dataToDisplay = (userDataBS.Count > 10) ? userDataBS.GetRange(userData.Count - 10, 10) : userDataBS;
            foreach (var item in dataToDisplay)
            {
                results += String.Format("Время начала сборки:{0}, имя игрока: {1}, шаги: {2}, время: {3} sec\n",
                item.BeginTime, item.Player, item.StepNumber, item.CollectTime);
            }

            MessageBox.Show(results);
        }

        private void BBestTime_Click_1(object sender, EventArgs e)
        {
            List<GameResult> userDataBT = userData;
            userDataBT.Sort((x, y) => x.CollectTime.CompareTo(y.CollectTime));
            string results = "";
            var dataToDisplay = (userDataBT.Count > 10) ? userDataBT.GetRange(userData.Count - 10, 10) : userDataBT;
            foreach (var item in dataToDisplay)
            {
                results += String.Format("Время начала сборки:{0}, имя игрока: {1}, шаги: {2}, время: {3} sec\n",
                item.BeginTime, item.Player, item.StepNumber, item.CollectTime);
            }

            MessageBox.Show(results);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            userData.RemoveAll(x => (x.BeginTime > data.Value));
        }
    }
}
