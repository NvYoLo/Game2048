﻿using System;
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

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
