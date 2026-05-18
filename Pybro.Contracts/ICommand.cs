using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.Contracts
{
    public interface ICommand
    {
        public void Execute(object[] args);
    }
}
