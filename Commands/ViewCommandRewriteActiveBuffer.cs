using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Commands
{
    public class ViewCommandRewriteActiveBuffer(string bufferContent) : IViewCommand
    {
        private readonly string _bufferContent = bufferContent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// args[0] - IUiAdapter ref
        /// </param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object[] args)
        {
            ValidateArgs(args);
            ((IUiAdapter)args[0]).UpdateBuffer(_bufferContent);
            throw new NotImplementedException(); // TODO: implement this command to rewrite the editor buffer with the provided content. This will be used for loading files and for updating the buffer after running code.
        }

        private void ValidateArgs(object[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException("Expected at least one argument of type IUiAdapter.");
            if (args[0] is not IUiAdapter)
                throw new ArgumentException("First argument must be of type IUiAdapter.");
        }
    }
}
