using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private int mapSize;
        private Label[,] labelsMap;
        private static Random rnd = new Random();
        private static Random rndIndex = new Random();
        private List<int> ints = new List<int> { 2, 2, 2, 4 };
        private ClassName className;


        public MainForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ShowLoginMenu();
            InitMap();
            ShowRecord();
            GenerateNumber();
            ShowScore();
               
        }

        private void ShowRecord()
        {
            var Record = SaveResultClass.GetResultGame();
            var MaxScore = Record.Max(className => className.Score);
            if (Record.Count == 0)
            {
                labelRecord.Text = 0.ToString();
            }
            else
            {
                labelRecord.Text = MaxScore.ToString();
            }
        }

        private void ChangeLVL(Authorization authorization)
        {

            switch (authorization.comboBoxChooseLVL.SelectedIndex)
            {
                case 0:
                    {
                        mapSize = 4;
                        Width = 334;
                        Height = 445;
                    }
                    return;
                case 1:
                    {
                        mapSize = 5;
                        Width = 412;
                        Height = 523;
                    }
                    return;
                case 2:
                    {
                        mapSize = 6;
                        Width = 491;
                        Height = 602;

                    }
                    return;
            }

        }

        private void ShowLoginMenu()
        {
            Authorization authorization = new Authorization();
            authorization.ShowDialog();
            ChangeLVL(authorization);
            className = new ClassName(authorization.textBoxName.Text);
            label2.Text = $"Èãðàåò èãðîê - {className.Name}";
            labelRecord.Text = $"Ðåêîðä çà âñ¸ âðåìÿ : ";
        }
        private void ShowMenuRules()
        {
            Menu menu = new Menu();
            menu.ShowDialog();

        }

        private void ShowScore()
        {
            scoreLabel.Text = className.Score.ToString();
        }


        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
        }
        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = rnd.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexColumn = randomNumberLabel % mapSize;
                var randomIndexList = rndIndex.Next(ints.Count);
                if (labelsMap[indexRow, indexColumn].Text == string.Empty)
                {
                    labelsMap[indexRow, indexColumn].Text = ints[randomIndexList].ToString();
                    break;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.ScrollBar;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font("Leelawadee UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.Size = new Size(70, 70);
            label.BackColor = Color.FromArgb(238, 228, 218);
            int x = 10 + indexColumn * 76;
            int y = 100 + indexRow * 76;
            label.Location = new Point(x, y);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.TextChanged += Label_TextChanged;
            return label;
        }

        private void Label_TextChanged(object? sender, EventArgs e)
        {
            var label = (Label?)sender;
            switch (label.Text)
            {
                case "4": label.BackColor = Color.FromArgb(238, 225, 201); break;
                case "8": label.BackColor = Color.FromArgb(243, 178, 122); break;
                case "16": label.BackColor = Color.FromArgb(246, 150, 100); break;
                case "32": label.BackColor = Color.FromArgb(247, 124, 95); break;
                case "64": label.BackColor = Color.FromArgb(247, 94, 59); break;
                case "128": label.BackColor = Color.FromArgb(237, 207, 114); break;
                case "256": label.BackColor = Color.FromArgb(237, 204, 97); break;
                case "512": label.BackColor = Color.FromArgb(237, 200, 80); break;
                case "1024": label.BackColor = Color.FromArgb(237, 197, 63); break;
                case "2048": label.BackColor = Color.FromArgb(237, 194, 46); break;
                case "4096": label.BackColor = Color.FromArgb(173, 216, 230); break;
                case "8192": label.BackColor = Color.FromArgb(135, 206, 250); break;
                case "16384": label.BackColor = Color.FromArgb(0, 191, 255); break;
                case "32768": label.BackColor = Color.FromArgb(30, 144, 255); break;
                case "65536": label.BackColor = Color.FromArgb(0, 0, 255); break;
                default: label.BackColor = Color.FromArgb(238, 228, 218); break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool flagRight = false, flagLeft = false, flagUp = false, flagDown = false;
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        className.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[i, k].Text = string.Empty;
                                        flagRight = true;
                                    }
                                    break;
                                }

                            }
                        }
                    }

                }
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {

                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {

                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[i, k].Text;

                                    labelsMap[i, k].Text = string.Empty;
                                    flagRight = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        className.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();

                                        labelsMap[i, k].Text = string.Empty;
                                        flagLeft = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[i, k].Text;
                                    labelsMap[i, k].Text = string.Empty;
                                    flagLeft = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        className.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();

                                        labelsMap[k, j].Text = string.Empty;
                                        flagUp = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[k, j].Text;
                                    labelsMap[k, j].Text = string.Empty;
                                    flagUp = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        className.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();

                                        labelsMap[k, j].Text = string.Empty;
                                        flagDown = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[k, j].Text;
                                    labelsMap[k, j].Text = string.Empty;
                                    flagDown = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (flagRight == true || flagLeft == true || flagDown == true || flagUp == true)
            {
                GenerateNumber();
            }
            ShowScore();
            if (EndGame())
            {
                var DialogResult = MessageBox.Show($"Èãðà îêîí÷åíà! Âû íàáðàëè {className.Score} î÷êîâ!", "Êîíåö èãðû!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.OK)
                {
                    SaveResultClass.SaveFileResult(className);
                }
            }

        }

        private bool EndGame()
        {
            bool flagMap = false;
            foreach (var map in labelsMap)
            {
                if (map.Text == string.Empty)
                {
                    flagMap = true;
                    break;
                }
            }
            if (flagMap)
            {
                return false;
            }
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    if (labelsMap[i, j].Text == labelsMap[i, j + 1].Text)
                    {
                        return false;
                    }
                    if (j < mapSize - 1 && labelsMap[j, i].Text == labelsMap[j + 1, i].Text)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void ïðàâèëàÈãðûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMenuRules();
        }


        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ðåñòàðòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            string exePath = Application.ExecutablePath;
            Process.Start(exePath);
            Application.Exit();

        }

        private void òàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableResults table = new TableResults();
            table.ShowDialog();
        }

    }
}
