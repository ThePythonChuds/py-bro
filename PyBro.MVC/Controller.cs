using PyBro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro.MVC
{
    public class Controller(IModel model, IView view) : IController
    {
        private readonly IModel _model = model;
        private readonly IView _view = view;

        public void Tick()
        {
            _model.ExecuteCommands();
            _view.ExecuteCommands();
        }
    }
}
