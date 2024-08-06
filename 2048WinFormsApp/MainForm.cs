using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private const int mapSize = 4;
        private Label[,] labelsMap;
        private static Random rnd = new Random();
        private static Random rndIndex = new Random();
        private List<string> ints = new List<string> { "2", "2", "2", "4" };
        private ClassName className;



        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLoginMenu();
            InitMap();
            GenerateNumber();
            ShowScore();
        }

        private void ShowLoginMenu()
        {

            Authorization authorization = new Authorization();
            authorization.ShowDialog();
            className = new ClassName(authorization.textBoxName.Text);
            label2.Text = $"Èãðàåò èãðîê - {className.Name}";
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
                    labelsMap[indexRow, indexColumn].Text = ints[randomIndexList];
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
            int x = 10 + indexColumn * 76;
            int y = 40 + indexRow * 76;
            label.Location = new Point(x, y);
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;
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
