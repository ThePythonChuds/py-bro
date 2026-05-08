namespace PyBro {
    public class View {
        private IUi _ui;
        private ITreeDir _treeDir;

        public View()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelInfo"></param>
        public void Show(Model.TickInfo modelInfo)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public View.TickInfo PackViewTickInfo()
        {
            return new View.TickInfo();
        }

        public class TickInfo
        {
            public TickInfo()
            {
                
            }
        }
    }
}