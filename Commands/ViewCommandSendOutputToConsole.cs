using PyBro.Contracts;

namespace PyBro.Commands
{
    public class ViewCommandSendOutputToConsole(string stdout, string stderr) : IViewCommand
    {
        private readonly string _stdout  = stdout;
        private readonly string _stdErr = stderr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// args[0] - UiAdapter reference
        /// </param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object[] args)
        {
            if (args[0] is IUiAdapter uia)
            {
                uia.DisplayOutput(_stdout, _stdErr);
            } else
            {
                throw new ArgumentException("Expected IUiAdapter as first argument");
            }
        }
    }
}
