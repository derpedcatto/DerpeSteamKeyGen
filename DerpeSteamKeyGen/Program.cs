namespace DerpeSteamKeyGen
{
    internal static class Program
    {
        /// <summary>
        /// Stores path to key list (example: "D:\\keys.txt"). 'keys.txt' can't be changed.
        /// </summary>
        public static string LISTPATH = Path.GetFullPath("keys.txt");   // Copies path to the same folder as .exe file

        /// <summary>
        /// Stores a generated key.
        /// </summary>
        public static string KEY = new("AAAAA-BBBBB-CCCCC");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}