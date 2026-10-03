namespace Lab_02
{
    public class Program
    {
        public static string CheckConfiguration(int online, int ping, double cpu)
        {
            string b;

            if (online == 0)
                b = "The server isn't ready. There aren't enough players.";
            else if (online > 200)
                b = "Warning: the server can be started, but the administrator should be warned.";
            else if (online > 0 && cpu < 30.1 && ping < 100)
                b = "The server is ready";
            else if (online > 0 && cpu > 30.1 && ping > 100)
                b = "The server isn't ready. The ping is too high. There's a heavy load on the CPU.";
            else
                b = "Warning: check the server configuration.";

            return b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Administrator panel");
            Console.Write("Server name: ");
            string n = Console.ReadLine();

            Console.WriteLine("Administrator panel");
            Console.WriteLine($"Technical specifications of the “{n}” server");

            Console.Write("Players Online: ");
            int online = int.Parse(Console.ReadLine());

            Console.Write("Ping: ");
            int ping = int.Parse(Console.ReadLine());

            Console.Write("CPU: ");
            double cpu = double.Parse(Console.ReadLine());

            string b = CheckConfiguration(online, ping, cpu);

            Console.WriteLine(b);
        }
    }
}