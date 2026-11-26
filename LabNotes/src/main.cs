namespace Labnote
{
    // The app's entry point. Put this file in C:\Labnotes\Labnotes\src
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Frontend.Start();
        }
    }

    // The backend's main file can also call Frontend.Start() to open the UI.
    public static class Frontend
    {
        public static void Start()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }
    }
}
