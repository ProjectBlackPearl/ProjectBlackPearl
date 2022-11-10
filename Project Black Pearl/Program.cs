using System.Runtime.InteropServices;


namespace Project_Black_Pearl
{
    internal static class Program
    {
        public static LauncherForm LauncherForm = new LauncherForm();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]     
        static void Main()
        {           
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(LauncherForm);
        }        
    }
}