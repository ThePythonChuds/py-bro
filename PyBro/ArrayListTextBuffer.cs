using System.Text;
using System.Windows.Controls;

namespace PyBro
{
    public class ArrayListTextBuffer : ITextBuffer
    {
        private List<string> _buffer {  get; set; }

        public ArrayListTextBuffer()
        {
            this._buffer = new List<string>();
        }

        public void AddLine(string line)
        {
            if (line.Last() == '\n')
            {
                line = line.Substring(0, line.Length - 1);
            }

            _buffer.Add(line);
        }

        public string GetContent()
        {
            var sb = new StringBuilder();
            foreach (var line in _buffer)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public (uint, string?) GetCurrentIndentInfo()
        {
            uint indentLevel = 0;
            string? indentString = null;
            for (int i = 0 ; i < _buffer.Count; ++i)
            {
                var line = _buffer[i];
                if (indentLevel >= 1 && indentString == null)
                {
                    indentString = GetIndentString(line);
                }
                else if (indentLevel >= 1 && indentString != null && !indentString.Equals(GetIndentString(line)))
                {
                    // Trebuie sa corectam indentarea, deoarece am intalnit un indent diferit fata de cel curent
                    var correctedLine = indentString + line.TrimStart();
                    _buffer[i] = correctedLine;
                }

                if (line.Contains(":"))
                {
                    indentLevel++;
                }
            }
            return (indentLevel, indentString);
        }

        public void SetContent(string content)
        {
            _buffer = new List<string>(content.Split('\n'));
        }

        private static string GetIndentString(string line)
        {
            return line.Substring(0, line.Length - line.TrimStart().Length);
        }

        public void Autoindent()
        {
            var (indentLevel, indentString) = this.GetCurrentIndentInfo();
            if (_buffer.Last() == "")
            {
                var sb = new StringBuilder();
                for (int i = 0; i < indentLevel; ++i)
                {
                    sb.Append(indentString);
                }

                _buffer[_buffer.Count - 1] = sb.ToString();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}