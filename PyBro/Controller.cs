namespace PyBro {
    public class Controller {
        private Model model;
        private View view;

        /// <summary>
        ///   
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <exception cref="Exception">No memory</exception>
        Controller(Model model, View view)
        {
            if (_model == null || _view == null)
            {
                Console.WriteLine("Model or View is null!");
                throw new Exception();
            }

            this._model = model;
            this._view = view;

        }

        public void Tick()
        {
            var viewTickInfo  = _view.PackViewTickInfo();
            var modelTickInfo = _model.ApplyTickInfo(tickInfo);
            view.Show(modelTickInfo);
        }
    }
}