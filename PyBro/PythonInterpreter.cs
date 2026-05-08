using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;




        // 2. Execute code directly from a string


namespace PyBro
{
    /// <summary>
    /// A class representing a Python interpreter. 
    /// NOTE: Don't forget to call Dispose()! Thanks! :)     
    /// </summary>
    public class PythonInterpreter : IPythonInterpreter
    {
        private ScriptEngine _scriptEngine = null;


        public PythonInterpreter()
        {
            _scriptEngine = Python.CreateEngine();
        }

        /// <summary>
        /// Runs a python script 
        /// </summary>
        /// <param name="script">string containing whole python script</param>
        /// <returns>string containing stdout and stderr info</returns>
        /// <exception cref="PythonException"> If the script is not valid python or Python.NET problem</exception>
        public string RunScript(string script)
        {
            try {
                var scope = _scriptEngine.CreateScope();
                _scriptEngine.Execute(script, scope);
            } catch (Exception e)
            {
                Console.WriteLine("Error: PythonInterpreter.RunScript()");
                throw new PythonException();
            }
        }

        public Dispose()
        {
            
        }
    }
}