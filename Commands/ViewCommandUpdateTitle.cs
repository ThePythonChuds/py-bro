using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyBro.Commands;
using PyBro.Contracts;

namespace PyBro.Commands
{
    public class ViewCommandUpdateTitle(string newTitle) : IViewCommand
    {
        private readonly string _newTitle = newTitle;

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
            ((IUiAdapter)args[0]).UpdateTitle(_newTitle);
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
