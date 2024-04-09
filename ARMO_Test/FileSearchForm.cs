using System.Text.RegularExpressions;

namespace ARMO_Test
{
    public partial class FileSearchForm : Form
    {
        FileSearch fileSearch;
        const string currSearchDirConst = "Текущая директория поиска: ";
        const string allFilesConst = "Общее количество файлов: ";
        const string filesConst = "Количество найденных файлов: ";
        const string elapledTimeConst = "Время, затраченное на поиск: ";
        public FileSearchForm()
        {
            InitializeComponent();
            fileSearch = new FileSearch(treeView, this);
            fileSearch.OnSearchUpdate += FileSearch_OnSearchUpdate;
            fileSearch.OnSearchEnd += FileSearch_OnSearchEnd;
            fileSearch.OnCurrentSearchDirUpdate += FileSearch_OnCurrentSearchDirUpdate;
        }

        private void FileSearch_OnCurrentSearchDirUpdate(object? sender, FileSearch.CurrentSearchDirEventArgs e)
        {
            currentSearchDirLabel.Text = currSearchDirConst + e.currentSearchDir;
        }

        private void FileSearch_OnSearchEnd(object? sender, FileSearch.SearchEndEventArgs e)
        {
            elapledTimeLabel.Text = elapledTimeConst +
                e.timeElapsedMS.ToString() + "мс";
            countunueButton.Enabled = false;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            searchButton.Enabled = true;
            treeView.ExpandAll();
        }

        private void FileSearch_OnSearchUpdate()
        {
            allFilesLabel.Text = allFilesConst + fileSearch.AllFilesCounter;
            filesLabel.Text = filesConst + fileSearch.FilesCounter;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            currentSearchDirLabel.Text = currSearchDirConst;
            treeView.Nodes.Clear();
            string dirPath = directoryTextBox.Text;

            try
            {
                var regex = new Regex(regExTextBox.Text);
                if (!fileSearch.SearchFiles(dirPath, regex))
                    return;
                allFilesLabel.Text = allFilesConst +  "0";
                filesLabel.Text = filesConst + "0";
                elapledTimeLabel.Text = elapledTimeConst + "0";
                searchButton.Enabled = false;
                pauseButton.Enabled = true;
                stopButton.Enabled = true;
            }
            catch (RegexParseException)
            {
                MessageBox.Show("Ошибка в конструкции выражения");
            }
            catch (Exception)
            {

                MessageBox.Show("Неизвестная ошибка с выражением");
            }
            

        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            fileSearch.Pause();

            countunueButton.Enabled = true;
            pauseButton.Enabled = false;
        }

        private void CountunueButton_Click(object sender, EventArgs e)
        {
            fileSearch.Countinue();

            countunueButton.Enabled = false;
            pauseButton.Enabled = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {

            fileSearch.Stop();

            countunueButton.Enabled = false;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            searchButton.Enabled = true;

        }

        private void FileSearchForm_Load(object sender, EventArgs e)
        {
            var saver = new Saver();
            saver.Load(out string dir, out string regex);

            directoryTextBox.Text = dir;
            regExTextBox.Text = regex;
        }


        private void FileSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var saver = new Saver();
            saver.Save(directoryTextBox.Text, regExTextBox.Text);
            Environment.Exit(0);
        }
    }
}
