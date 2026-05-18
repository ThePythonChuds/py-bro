using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Commands
{
    public class ModelCommandSaveBuffer(string path, string script) : IModelCommand
    {
        private readonly string _path = path;
        private readonly string _script = script;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// args[0] = File Manager reference (IFileManager)
        /// </param>
        public void Execute(object[] args)
        {
            ValidateArgs(args);
            var fileManager = args[0] as IFileManager;
            fileManager.SaveBuffer(_path, _script);
        }

        private void ValidateArgs(object[] args)
        {
            if (args == null || args.Length < 1)
                throw new ArgumentException("Expected at least one argument: IFileManager reference.");
            if (args[0] is not IFileManager)
                throw new ArgumentException("First argument must be of type IFileManager.");
        }
    }
}
