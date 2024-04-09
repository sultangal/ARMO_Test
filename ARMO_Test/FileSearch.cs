using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ARMO_Test;

internal class FileSearch
{
    public event Action OnSearchUpdate;
    public event EventHandler<SearchEndEventArgs> OnSearchEnd;
    public class SearchEndEventArgs : EventArgs
    {
        public double timeElapsedMS;
    }

    public event EventHandler<CurrentSearchDirEventArgs> OnCurrentSearchDirUpdate;
    public class CurrentSearchDirEventArgs : EventArgs
    {
        public required string currentSearchDir;
    }

    private readonly TreeView _treeView;
    private TreeNode _rootNode;
    private int dirStartLevel;
    public int AllFilesCounter { get; private set; }
    public int FilesCounter { get; private set; }
    public double SearchPerformance { get; private set; }

    private readonly Form _currentForm;

    private readonly Stopwatch _sw = new Stopwatch();

    private CancellationTokenSource _cts;
    private ManualResetEventSlim _pauseEvent;

    public FileSearch(TreeView treeView, Form currentForm)
    {
        this._treeView = treeView;
        this._currentForm = currentForm;
    }

    ~FileSearch()
    {
        _cts.Dispose();
        _pauseEvent.Dispose();
    }

    private async void RunSearch(DirectoryInfo dir, Regex fileRegex)
    {
        _pauseEvent = new ManualResetEventSlim(true);
        _cts = new CancellationTokenSource();
        CancellationToken token = _cts.Token;

        try
        {
            await Task.Run(() =>
            {
                GetDirectories(dir.GetDirectories(), fileRegex, token);

                _sw.Stop();

                _currentForm.Invoke(() =>
                {
                    OnSearchEnd?.Invoke(this, new SearchEndEventArgs() { timeElapsedMS = _sw.ElapsedMilliseconds });
                });

            }, token);
        }

        catch (OperationCanceledException)
        {
            MessageBox.Show("Поиск файлов отменен");

        }
        catch (Exception)
        {
            MessageBox.Show("Произошла неизвестная ошибка");
        }
        finally
        {
            _cts.Dispose();
            _pauseEvent.Dispose();
        }
    }

    public bool SearchFiles(string path, Regex fileRegex)
    {
        if ((path == "") || (path == null) || (path.IndexOfAny(Path.GetInvalidPathChars()) != -1))
        {
            MessageBox.Show("Ошибка в пути директории");
            return false;
        }

        var dir = new DirectoryInfo(path);
        if (!dir.Exists) 
        {
            MessageBox.Show("Данная директория не существует");
            return false; 
        }

        _treeView.Nodes.Clear();
        AllFilesCounter = 0;
        FilesCounter = 0;

        _rootNode = new TreeNode(dir.Name);
        _rootNode.Tag = path;
        _treeView.Nodes.Add(_rootNode);

        var rootNodeTag = (string)_treeView.Nodes[0].Tag;
        var partsOfRootPath = rootNodeTag.Split('\\');
        dirStartLevel = partsOfRootPath.Length;

        _sw.Reset();
        _sw.Start();

        RunSearch(dir, fileRegex);

        return true;
    }

    public void Pause()
    {
        _pauseEvent?.Reset();
    }

    public void Countinue()
    {
        _pauseEvent?.Set();
    }

    public void Stop()
    {
        _cts?.Cancel();
    }

    public void CheckSyncStatus(ManualResetEventSlim pauseEvent, CancellationToken token)
    {
        if (token.IsCancellationRequested)
        {
            token.ThrowIfCancellationRequested();
        }
        pauseEvent.Wait(token);
    }

    private void GetDirectories(DirectoryInfo[] dirs, Regex fileRegex, CancellationToken token)
    {
        DirectoryInfo[] subSubDirs;
        foreach (DirectoryInfo subDir in dirs)
        {
            CheckSyncStatus(_pauseEvent, token);

            _currentForm.Invoke(() =>
            {
                OnCurrentSearchDirUpdate?.Invoke(this, new CurrentSearchDirEventArgs()
                {
                    currentSearchDir = subDir.Name
                });
            });

            subSubDirs = subDir.GetDirectories();
            if (subSubDirs.Length != 0)
            {
                GetDirectories(subSubDirs, fileRegex, token);
            }
            FileInfo[] files = subDir.GetFiles();
            foreach (FileInfo file in files)
            {
                CheckSyncStatus(_pauseEvent, token);

                AllFilesCounter++;
                if (!fileRegex.IsMatch(file.Name)) continue;
                FilesCounter++;

                _currentForm.Invoke(() =>
                {
                    PopulateTreeView(file);
                });
                //Thread.Sleep(1000);
            }
        }

    }

    private void PopulateTreeView(FileInfo file)
    {
        var path = file.FullName;
        var partsOfFilePath = path.Split('\\');

        AddNode(_treeView.Nodes[0], partsOfFilePath, dirStartLevel);
    }

    private void AddNode(TreeNode node, string[] filePath, int level)
    {
        if (level >= filePath.Length) return;
        bool isContain = false;
        string dirNameFromFile = filePath[level];
        foreach (TreeNode item in node.Nodes)
        {
            if (item.Text != dirNameFromFile) continue;

            isContain = true;
            AddNode(item, filePath, level + 1);
            break;
        }

        if (!isContain)
        {
            OnSearchUpdate?.Invoke();
            var newNode = new TreeNode(filePath[level]);
            node.Nodes.Add(newNode);
            AddNode(newNode, filePath, level + 1);
        }
    }
}
