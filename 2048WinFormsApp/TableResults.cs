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
    public partial class TableResults : Form
    {
        public TableResults()
        {
            InitializeComponent();
        }

        private void dataGridViewResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableResults_Load(object sender, EventArgs e)
        {
            dataGridViewResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var result = SaveResultClass.GetResultGame();
            foreach (var data in result)
            {
                dataGridViewResult.Rows.Add(data.Name, data.Score);
            }
        }
    }
}
