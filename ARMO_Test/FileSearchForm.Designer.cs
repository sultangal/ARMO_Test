
namespace ARMO_Test
{
    partial class FileSearchForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            treeView = new TreeView();
            directoryTextBox = new TextBox();
            regExTextBox = new TextBox();
            label3 = new Label();
            searchButton = new Button();
            stopButton = new Button();
            pauseButton = new Button();
            label2 = new Label();
            allFilesLabel = new Label();
            elapledTimeLabel = new Label();
            filesLabel = new Label();
            countunueButton = new Button();
            currentSearchDirLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(412, 28);
            label1.Name = "label1";
            label1.Size = new Size(185, 15);
            label1.TabIndex = 1;
            label1.Text = "Введите стартовую директорию:";
            // 
            // treeView1
            // 
            treeView.Location = new Point(-1, 28);
            treeView.Name = "treeView1";
            treeView.Size = new Size(407, 619);
            treeView.TabIndex = 2;
            // 
            // directoryTextBox
            // 
            directoryTextBox.Location = new Point(412, 47);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.Size = new Size(376, 23);
            directoryTextBox.TabIndex = 3;
            directoryTextBox.Text = "F:\\tutorials";
            // 
            // regExTextBox
            // 
            regExTextBox.Location = new Point(412, 92);
            regExTextBox.Name = "regExTextBox";
            regExTextBox.Size = new Size(376, 23);
            regExTextBox.TabIndex = 7;
            regExTextBox.Text = "^\\w\\.mp4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(412, 73);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 6;
            label3.Text = "Введите Regex файла:";
            // 
            // searchButton
            // 
            searchButton.Location = new Point(713, 121);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 10;
            searchButton.Text = "ПОИСК";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // stopButton
            // 
            stopButton.AllowDrop = true;
            stopButton.Enabled = false;
            stopButton.Location = new Point(632, 121);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 23);
            stopButton.TabIndex = 11;
            stopButton.Text = "СТОП";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.AllowDrop = true;
            pauseButton.Enabled = false;
            pauseButton.Location = new Point(551, 121);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(75, 23);
            pauseButton.TabIndex = 12;
            pauseButton.Text = "ПАУЗА";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += PauseButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-1, 9);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 13;
            label2.Text = "Результат: ";
            // 
            // allFilesLabel
            // 
            allFilesLabel.AutoSize = true;
            allFilesLabel.Location = new Point(412, 154);
            allFilesLabel.Name = "allFilesLabel";
            allFilesLabel.Size = new Size(170, 15);
            allFilesLabel.TabIndex = 14;
            allFilesLabel.Text = "Общее количество файлов: 0";
            // 
            // elapledTimeLabel
            // 
            elapledTimeLabel.AutoSize = true;
            elapledTimeLabel.Location = new Point(412, 205);
            elapledTimeLabel.Name = "elapledTimeLabel";
            elapledTimeLabel.Size = new Size(202, 15);
            elapledTimeLabel.TabIndex = 15;
            elapledTimeLabel.Text = "Время, затраченное на поиск:  0 мс";
            // 
            // filesLabel
            // 
            filesLabel.AutoSize = true;
            filesLabel.Location = new Point(412, 180);
            filesLabel.Name = "filesLabel";
            filesLabel.Size = new Size(193, 15);
            filesLabel.TabIndex = 16;
            filesLabel.Text = "Количество найденных файлов: 0";
            // 
            // countunueButton
            // 
            countunueButton.AllowDrop = true;
            countunueButton.Enabled = false;
            countunueButton.Location = new Point(412, 121);
            countunueButton.Name = "countunueButton";
            countunueButton.Size = new Size(133, 23);
            countunueButton.TabIndex = 17;
            countunueButton.Text = "ПРОДОЛЖИТЬ";
            countunueButton.UseVisualStyleBackColor = true;
            countunueButton.Click += CountunueButton_Click;
            // 
            // currentSearchDirLabel
            // 
            currentSearchDirLabel.AutoSize = true;
            currentSearchDirLabel.Location = new Point(412, 232);
            currentSearchDirLabel.Name = "currentSearchDirLabel";
            currentSearchDirLabel.Size = new Size(169, 15);
            currentSearchDirLabel.TabIndex = 18;
            currentSearchDirLabel.Text = "Текущая директория поиска: ";
            // 
            // FileSearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 646);
            Controls.Add(currentSearchDirLabel);
            Controls.Add(countunueButton);
            Controls.Add(filesLabel);
            Controls.Add(elapledTimeLabel);
            Controls.Add(allFilesLabel);
            Controls.Add(label2);
            Controls.Add(pauseButton);
            Controls.Add(stopButton);
            Controls.Add(searchButton);
            Controls.Add(regExTextBox);
            Controls.Add(label3);
            Controls.Add(directoryTextBox);
            Controls.Add(treeView);
            Controls.Add(label1);
            Name = "FileSearchForm";
            Text = "Поиск файла по Regex выражению";
            FormClosed += this.FileSearchForm_FormClosed;
            Load += FileSearchForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TreeView treeView;
        private TextBox directoryTextBox;
        private TextBox regExTextBox;
        private Label label3;
        private Button searchButton;
        private Button stopButton;
        private Button pauseButton;
        private Label label2;
        private Label allFilesLabel;
        private Label elapledTimeLabel;
        private Label filesLabel;
        private Button countunueButton;
        private Label currentSearchDirLabel;
    }
}
