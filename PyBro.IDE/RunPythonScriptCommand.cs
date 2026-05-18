using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    public class RunPythonScriptCommand : IPyBroCommand
    {
        private string _script;
        public RunPythonScriptCommand(string script) 
        {
            _script = script;
        }

        /// <summary>
        /// arg[0] python interpretor reference
        /// </summary>
        /// <param name="args"></param>
        public void Execute(object[] args) 
        {
            if (args[0] is IPythonInterpreter pi)
            {
                try { pi.RunScript(_script); }

                catch
                {
                    
                }
                


            }
            else
            {
                throw new ArgumentException();
            }
        }


    }
}
