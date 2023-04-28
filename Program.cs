using Views;

namespace ProductsCSharp;


static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Views.Menu());
    }    
}