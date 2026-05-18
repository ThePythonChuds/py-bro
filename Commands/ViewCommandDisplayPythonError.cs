using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Commands
{
    public class ViewCommandDisplayPythonError(string errMsg) : IViewCommand
    {
        private string _errMsg = errMsg;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// args[0] - UiAdapter reference
        /// </param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object[] args)
        {
            var uia = ValidateArgs(args);
            uia.DisplayError(_errMsg);
        }

        private IUiAdapter ValidateArgs(object[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("Expected at least one argument of type IUiAdapter");
            }
            if (args[0] is not IUiAdapter uia)
            {
                throw new ArgumentException("Expected first argument to be of type IUiAdapter");
            }
            return uia;
        }
    }
}
