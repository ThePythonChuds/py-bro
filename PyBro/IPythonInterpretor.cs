namespace PyBro {
    public interface IPythonInterpretor {

        /// <summary>
        /// Runs a python script 
        /// </summary>
        /// <param name="script">string containing whole python script</param>
        /// <returns>string containing stdout and stderr info</returns>
        /// <exception cref="PythonException"> If the script is not valid python or Python.NET problem</exception>
        public string RunScript(string script);

    }
}