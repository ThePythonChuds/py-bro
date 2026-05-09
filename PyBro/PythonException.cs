namespace PyBro
{
    public class PythonException : System.Exception
    {
        public PythonException(string message) : base(message)
        {
            
        }

        public PythonException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
    }
}