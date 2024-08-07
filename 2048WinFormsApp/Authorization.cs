using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class Authorization : Form
    {

        public Authorization()
        {
            InitializeComponent();
            textBoxName.TextChanged += textBoxName_TextChanged;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseLVL.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали размер поля!");
                return;
            }
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = !string.IsNullOrWhiteSpace(textBoxName.Text);

        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            buttonLogin.Enabled = false;
            ControlBox = false;
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
