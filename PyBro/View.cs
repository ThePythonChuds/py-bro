using PyBro.UI;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Automation.Peers;

namespace PyBro {
    public class View : IView{
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
        public void Show(ModelTickInfo modelInfo)
        {
            if (modelInfo.Commands != null)
            {
                foreach (var command in modelInfo.Commands)
                {
                    command.Execute(_ui, _treeDir);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ViewTickInfo PackViewTickInfo()
        {

            return new ViewTickInfo(_ui.GetBuffer());
            
        }
    }
}
