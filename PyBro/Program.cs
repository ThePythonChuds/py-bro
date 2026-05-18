
using PyBro;

class Program
{
    [System.STAThreadAttribute]
    public static void Main(string[] args)
    {
        var app = new ApplicationBuilder()
            .WithPythonInterpreter(new PythonInterpreter())
            .WithFileManager(new FileManager())
            .WithTextBufferManager(new TextBufferManager())
            .Build();

        app.Run();
    }
}
