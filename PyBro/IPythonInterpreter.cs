namespace PyBro
{
    public interface IPythonInterpreter
    {
        /// <summary>
        /// Run a Python Script
        /// </summary>
        /// <param name="script"></param>
        /// <param name="args"></param>
        /// <exception cref="PythonException">
        /// The exception is thrwon when a Python error occurs.
        /// </exception>
        (string, string) RunScript(string script, string[] args);
    }
}