namespace PyBro {
    public class Controller {
        private Model _model;
        private View _view;

        /// <summary>
        ///   
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        public Controller(Model model, View view)
        {

            this._model = model;
            this._view = view;

        }

        public void Tick()
        {
            var viewTickInfo = _view.PackViewTickInfo();
            var modelTickInfo = _model.ApplyTickInfo(viewTickInfo);
            _view.Show(modelTickInfo);
        }
    }
}