namespace PyBro {
    public interface IConsole {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd">Command to be executed.</param>
        /// <returns>stdout and stderr</returns>
        public String RunCommand(string cmd);
    }
}