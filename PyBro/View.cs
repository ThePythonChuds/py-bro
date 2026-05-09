using System.Security.Cryptography.X509Certificates;

namespace PyBro {
    public class View {
        private IUi _ui;
        private ITreeDir _treeDir;

        public View()
        {
            _ui = new Ui();
            _treeDir = new TreeDir();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelInfo"></param>
        public void Show(Model.TickInfo modelInfo)
        {
            if (!string.IsNullOrWhiteSpace(modelInfo.OutputToConsole))
            {
                System.Console.WriteLine("STDOUT:");
                System.Console.WriteLine(modelInfo.OutputToConsole);
            }

            if (!string.IsNullOrWhiteSpace(modelInfo.ErroredToConsole))
            {
                System.Console.WriteLine("STDERR:");
                System.Console.WriteLine(modelInfo.ErroredToConsole);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public View.TickInfo PackViewTickInfo()
        {
            string? input = System.Console.ReadLine();
            if (input == null || input.Trim().ToUpper() == "EXIT")
            {
                return new View.TickInfo
                {
                    ShouldExit = true
                };
            }
            return new View.TickInfo()
            {
                ShouldRunScript = true,
                ScriptToRun = input
            };
            
        }

        public class TickInfo
        {

            public bool ShouldExit { get; set; }
            public bool ShouldRunScript { get; set; }
            public string ScriptToRun { get; set; } = "";
            public TickInfo()
            {
                
            }
        }
    }
}