using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Commands
{
    public class ModelCommandLoadFile(string path) : IModelCommand
    {
        private readonly string _path = path;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">args[0] -> File Manager ref</param>
        public void Execute(object[] args)
        {
            ValidateArgs(args);
            var fileManager = (IFileManager)args[0];
            var textBufferContent = fileManager.GetFileContent(_path);

            var _modelCommand = new ModelCommandRewriteBuffer(_path, textBufferContent);
            MessageQueues.SendModelCommand(_modelCommand);

            var _viewCommand = new ViewCommandRewriteActiveBuffer(textBufferContent);
            MessageQueues.SendViewCommand(_viewCommand);
        }

        private void ValidateArgs(object[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("File Manager reference is required.");
            }
            if (args[0] is not IFileManager fileManager)
            {
                throw new ArgumentException("First argument must be of type IFileManager.");
            }
        }
    }
}
