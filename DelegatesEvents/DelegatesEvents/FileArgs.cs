namespace DelegatesEvents
{
    public class FileArgs : EventArgs
    {
        private readonly string _fileName;

        public string FileName { get => _fileName; }

        public FileArgs(string fileName)
        {
            _fileName = fileName;
        }
    }
}
