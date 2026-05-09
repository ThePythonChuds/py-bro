using System;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace PyBro
{
    /// <summary>
    /// A class representing a Python interpreter. 
    /// </summary>
    public class PythonInterpreter : IPythonInterpreter
    {
        private ScriptEngine _scriptEngine;


        public PythonInterpreter()
        {
            _scriptEngine = Python.CreateEngine();
        }

        /// <summary>
        /// Runs a python script 
        /// </summary>
        /// <param name="script">string containing whole python script</param>
        /// <returns>tuple containing stdout (first) and stderr (second) output.</returns>
        /// <exception cref="PythonException"> If the script is not valid python or Python.NET problem</exception>
        public (string, string) RunScript(string script)
        {
            // Filip: Orice exceptie prinsa este cel mai probabilo eroare in scriptul python pe care il rulam.
            // F: Poate sa fie si o eroare interna IronPython, dar cred ca sansele sunt mici. Nu uita sa bei apa!
            // A: grija mare la indentarea la codul python e grava acolo
            try
            {
                var scope = _scriptEngine.CreateScope();

                using var stdout = new MemoryStream();
                using var stderr = new MemoryStream();

                _scriptEngine.Runtime.IO.SetOutput(stdout, Encoding.UTF8);
                _scriptEngine.Runtime.IO.SetErrorOutput(stderr, Encoding.UTF8);

                _scriptEngine.Execute(script, scope);

                stdout.Position = 0;
                stderr.Position = 0;

                string outText = new StreamReader(stdout).ReadToEnd();
                string errText = new StreamReader(stderr).ReadToEnd();

                return (outText, errText);
            } catch (Exception e)
            {
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // !!!: Filip: DACA VEZI ASTA, AMINTESTE-I LUI BELIGAN CA TREBUIE SA AFISAM SI O EROARE PT USER IN CAZ CA SCRIPTUL PYTHON NU POATE RULA! MERCI!

                System.Console.WriteLine("Error: PythonInterpreter.RunScript()");
                //throw new PythonException("Error running Python script", e);
                return (string.Empty, e.Message);
            }
        }
    }
}