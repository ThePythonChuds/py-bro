using PyBro.Commands;
using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Commands
{
    public class ModelCommandRunPythonScript(string script) : IModelCommand
    {
        private readonly string _script = script;

        /// <summary>
        /// arg[0] -> A reference to the PythonInterpreter instance
        /// </summary>
        /// <param name="args"></param>
        public void Execute(object[] args) 
        {
            if (args[0] is IPythonInterpreter pi)
            {
                try 
                { 
                    var (stdout, stderr) =  pi.RunScript(_script);
                    var cmd = new ViewCommandSendOutputToConsole(stdout, stderr);
                    MessageQueues.SendViewCommand(cmd);
                }
                catch (PythonException pe)
                {
                    var cmd = new ViewCommandDisplayPythonError(pe.Message);
                    MessageQueues.SendViewCommand(cmd);
                }
            }
            else
            {
                throw new ArgumentException("args[0] must be an IPythonInterpreter reference");
            }
        }


    }
}
