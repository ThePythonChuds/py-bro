namespace PyBro {
    public class Model : IModel {

        private IPythonInterpreter _pythonInterpreter;


        private IFileManager _fileManager;


        private Dictionary<string, ITextBuffer> _textBuffers;

        public Model(IPythonInterpreter pi, IFileManager fm)
        {
            _pythonInterpreter = pi;
            _fileManager = fm;
            _textBuffers = new Dictionary<string, ITextBuffer>();
        }


        /// <summary>
        /// Checks every tick for what it should do
        /// </summary>
        /// <param name="tickInfo">The tick information from the view.</param>
        /// <returns>The tick information to be applied to the model.</returns>
        public ModelTickInfo ApplyTickInfo(ViewTickInfo tickInfo)
        {
            var result = new ModelTickInfo();

            return result; 
        }

        
    }
}