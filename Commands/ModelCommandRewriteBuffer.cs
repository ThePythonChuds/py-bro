using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyBro.Contracts;
using PyBro.Core;

namespace PyBro.Commands
{
    public class ModelCommandRewriteBuffer(string path, string content) : IModelCommand
    {
        private readonly string _path = path;
        private readonly string _content = content;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// args[0] - Dictionary<string, ITextBuffer> ref
        /// </param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object[] args)
        {
            ValidateArgs(args);
            var dict = ((Dictionary<string, ITextBuffer>)args[0]);

            if (!dict.ContainsKey(_path))
            {
                dict[_path] = new ArrayListTextBuffer();
            }
            dict[_path].SetContent(_content);
        }

        private void ValidateArgs(object[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException("Expected at least one argument of type Dictionary<string, ITextBuffer>.");
            if (args[0] is not Dictionary<string, ITextBuffer>)
                throw new ArgumentException("First argument must be of type Dictionary<string, ITextBuffer>.");
        }
    }
}
