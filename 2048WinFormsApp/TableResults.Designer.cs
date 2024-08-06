namespace _2048WinFormsApp
{
    partial class TableResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewResult = new DataGridView();
            ColumnName = new DataGridViewTextBoxColumn();
            ColumnScore = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.AllowUserToAddRows = false;
            dataGridViewResult.AllowUserToDeleteRows = false;
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Columns.AddRange(new DataGridViewColumn[] { ColumnName, ColumnScore });
            dataGridViewResult.Dock = DockStyle.Fill;
            dataGridViewResult.Location = new Point(0, 0);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.ReadOnly = true;
            dataGridViewResult.Size = new Size(208, 346);
            dataGridViewResult.TabIndex = 0;
            dataGridViewResult.CellContentClick += dataGridViewResult_CellContentClick;
            // 
            // ColumnName
            // 
            ColumnName.HeaderText = "Имя";
            ColumnName.Name = "ColumnName";
            ColumnName.ReadOnly = true;
            // 
            // ColumnScore
            // 
            ColumnScore.HeaderText = "Очки";
            ColumnScore.Name = "ColumnScore";
            ColumnScore.ReadOnly = true;
            ColumnScore.Width = 65;
            // 
            // TableResults
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(208, 346);
            Controls.Add(dataGridViewResult);
            Name = "TableResults";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Таблица результатов";
            Load += TableResults_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewResult;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnScore;
    }
}