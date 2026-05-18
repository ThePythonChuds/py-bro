using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyBro
{
    class ApplicationBuilder
    {
        private IPythonInterpreter? _pi = null;
        private IFileManager? _fm = null;

        public ApplicationBuilder()
        {

        }

        public ApplicationBuilder WithPythonInterpreter(IPythonInterpreter pi)
        {
            _pi = pi;
            return this;
        }

        public ApplicationBuilder WithFileManager(IFileManager fm)
        {
            _fm = fm;
            return this;
        }

        public Application Build()
        {
            if (_pi == null)
            {
                throw new InvalidOperationException("PythonInterpreter is required to build the application.");
            }
            if (_fm == null)
            {
                throw new InvalidOperationException("FileManager is required to build the application.");
            }

            var model = new Model(_pi, _fm);
            var view = new View();
            var controller = new Controller(model, view);
            return new Application(model, view, controller);
        }
    }
}
