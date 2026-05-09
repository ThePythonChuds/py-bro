class Program
{
    [System.STAThreadAttribute]
    public static void Main (string[] args)
    {
        //new PyBro.Application().RunMainLoop(); Trebuie regandita logica. Ori multithreading unu pt ui ,altul pentru main loop (cu tick cum ai facut tu(PhyBro) sau folosim ceva ce are deja WPF(dispatcher) sauuu aia MVP 
        var app = new System.Windows.Application();
        app.Run(new PyBro.UI.MainWindow());
    }
}