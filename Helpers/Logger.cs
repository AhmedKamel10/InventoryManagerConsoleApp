
namespace myconsoleapp.Helpers
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[INFO] [{DateTime.Now}] {message}");
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] [{DateTime.Now}] {message}");
            Console.ResetColor();
        }

        public static void LogError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] [{DateTime.Now}] {ex.Message}");
            Console.ResetColor();
        }
    }
}
