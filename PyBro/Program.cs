
﻿using PyBro;

class Program
{
    public static void Main(string[] args)
    {
        // Testare python interpreter (merge momentan)
        /*IPythonInterpreter interpreter = new PythonInterpreter();

        string script = @"
x = 5
y = 20
print(x * y)
";

        var result = interpreter.RunScript(script);
        System.Console.WriteLine("STDOUT:");
        System.Console.WriteLine(result.Item1);

        System.Console.WriteLine("STDERR:");
        System.Console.WriteLine(result.Item2);*/
        
        
        new PyBro.Application().RunMainLoop();
    }
}