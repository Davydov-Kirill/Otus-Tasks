namespace DelegatesEvents
{
    public class FileExplorer
    {
        private bool _cancelSearch = default;

        public event EventHandler<FileArgs> FileFound;

        public void Explore(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path), "Path cannot be empty.");

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($"Directory doesn`t exist: {path}");

            ExploreDirectory(path);
        }

        private void ExploreDirectory(string path)
        {
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileFound.Invoke(this, new FileArgs(Path.GetFileName(file)));

                if (_cancelSearch)
                    return;
            }

            var directories = Directory.GetDirectories(path);

            foreach (var directory in directories)
            {
                ExploreDirectory(directory);

                if (_cancelSearch)
                    return;
            }
        }

        public void CancelSearch() => _cancelSearch = true;
    }
}
