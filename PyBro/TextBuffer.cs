namespace PyBro
{
    public class TextBuffer
    {
        /// <summary>
        /// Number of indents to apply to the next line. 
        /// This is a static variable because it should be shared across all instances of TextBuffer.
        /// </summary>
        public static UInt32 IndentLevel = 0;
        /// <summary>
        /// Specifies the string to use for indentation in formatted output.
        /// Used to differentiate between tabs and spaces indentation in Python.
        /// </summary>
        public static string? IndentString = "  ";
        public List<string> Lines { get; private set; } = new List<string>();
        public TextBuffer(string text)
        {
            Lines.AddRange(text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
        }
    }
}