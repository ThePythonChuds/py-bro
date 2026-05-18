using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    public interface IView
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelInfo"></param>
        void Show(ModelTickInfo modelInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ViewTickInfo PackViewTickInfo();

    }
}
