namespace _2048WinFormsApp
{
    partial class Authorization
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
            buttonLogin = new Button();
            textBoxName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxChooseLVL = new ComboBox();
            SuspendLayout();
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(12, 93);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(236, 23);
            buttonLogin.TabIndex = 0;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(49, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(199, 23);
            textBoxName.TabIndex = 1;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 3;
            label2.Text = "Выбор размера поля";
            // 
            // comboBoxChooseLVL
            // 
            comboBoxChooseLVL.FormattingEnabled = true;
            comboBoxChooseLVL.Items.AddRange(new object[] { "4x4", "5x5", "6x6" });
            comboBoxChooseLVL.Location = new Point(141, 49);
            comboBoxChooseLVL.Name = "comboBoxChooseLVL";
            comboBoxChooseLVL.Size = new Size(107, 23);
            comboBoxChooseLVL.TabIndex = 4;
            comboBoxChooseLVL.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 126);
            Controls.Add(comboBoxChooseLVL);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(buttonLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Authorization";
            Text = "Авторизация";
            FormClosed += Authorization_FormClosed;
            Load += Authorization_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLogin;
        public TextBox textBoxName;
        private Label label1;
        private Label label2;
        public ComboBox comboBoxChooseLVL;
    }
}