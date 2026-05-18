using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    public interface IModel
    {
        /// <summary>
        /// Checks every tick for what it should do
        /// </summary>
        /// <param name="tickInfo">The tick information from the view.</param>
        /// <returns>The tick information to be applied to the model.</returns>
        ModelTickInfo ApplyTickInfo(ViewTickInfo tickInfo);

        void AddTextBuffer(ITextBuffer textBuffer);
    }
}