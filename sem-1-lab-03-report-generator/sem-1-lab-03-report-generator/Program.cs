namespace sem_1_lab_03_report_generator;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("event_server.log");

            Console.WriteLine(BuildReport(lines));
        }

        public static string BuildReport(string[] lines)
        {
            string report = "# Итоги события: Восстание Ледяного Пламени\n\n";

            report += "Дата: " + StartDate(lines).ToString("dd.MM.yyyy") + "\n";

            report += "Победитель: " + Winner(lines) + "\n";

            report += "Очки победителя: " + Points(lines) + "\n";

            report += "Ивентовый предмет: " + Loooot(lines) + "\n";

            report += "Утешительная награда Железных волков: " + LoserAwards(lines) + " очков\n";

            report += "Предупреждений во время события: " + Warning(lines) + "\n";

            report += "Ошибок во время события: " + Error(lines);

            return report;
        }

        public static int Warning(string[] lines)
        {
            bool start = false;

            int warn = 0;

            foreach (string str in lines)
            {
                if (str.Contains("Событие началось: Восстание Ледяного Пламени")) start = true;

                if (str.Contains("[Warning]") && start == true) warn++;

                if (str.Contains("Событие \"Восстание Ледяного Пламени\" закрыто")) start = false;
            }

            return warn;
        }

        public static int Error(string[] lines)
        {
            bool start = false;

            int eror = 0;

            foreach (string str in lines)
            {
                if (str.Contains("Событие началось: Восстание Ледяного Пламени")) start = true;

                if (str.Contains("[Error") && start == true) eror++;

                if (str.Contains("Событие \"Восстание Ледяного Пламени\" закрыто")) start = false;
            }

            return eror;
        }

        public static DateTime StartDate(string[] lines)
        {
            foreach (string str in lines)
            {
                if (str.Contains("Событие началось: Восстание Ледяного Пламени"))
                {
                    string dat = str.Substring(0, 10);

                    return DateTime.Parse(dat);
                }
            }

            return DateTime.MinValue;
        }

        public static string Winner(string[] lines)
        {
            bool start = false;

            foreach (string str in lines)
            {
                if (str.Contains("Событие началось: Восстание Ледяного Пламени")) start = true;

                if (str.Contains("объявлены победителями события") && start == true)
                {
                    int win_pos = str.IndexOf("] ") + 2;

                    int win_pos1 = str.IndexOf(" объявлены победителями");

                    string part = str.Substring(win_pos, win_pos1 - win_pos);

                    return part;
                }

                if (str.Contains("Событие \"Восстание Ледяного Пламени\" закрыто")) start = false;
            }

            return "";
        }

        public static int Points(string[] lines)
        {
            string winner = Winner(lines);

            bool start = false;

            foreach (string str in lines)
            {
                if (str.Contains("Событие началось: Восстание Ледяного Пламени")) start = true;

                if (str.Contains(winner) && str.Contains("получили") && str.Contains("очков события") && start == true)
                {
                    int point1 = str.IndexOf("получили") + 9;

                    int point2 = str.IndexOf(" очков");

                    string great_point = str.Substring(point1, point2 - point1);

                    return int.Parse(great_point);
                }

                if (str.Contains("Событие \"Восстание Ледяного Пламени\" закрыто")) start = false;
            }

            return 0;
        }

        public static string Loooot(string[] lines)
        {
            bool start = false;

            foreach (string str in lines)
            {
                if (str.Contains("Событие началось: Восстание Ледяного Пламени")) start = true;

                if (str.Contains("[Loot]") && str.Contains("получили ивентовый предмет:") && start == true)
                {
                    int loot1 = str.IndexOf("предмет:") + 9;

                    string loot_name1 = str.Substring(loot1);

                    return loot_name1;
                }

                if (str.Contains("Событие \"Восстание Ледяного Пламени\" закрыто")) start = false;
            }

            return "";
        }

        public static int LoserAwards(string[] lines)
        {
            bool start = false;

            foreach (string str in lines)
            {
                if (str.Contains("Событие началось: Восстание Ледяного Пламени")) start = true;

                if (str.Contains("[Reward]") && str.Contains("утешительную награду:") && start == true)
                {
                    int loser = str.IndexOf("награду:") + "награду:".Length;

                    int point = str.IndexOf("очков");

                    string loser_point = str.Substring(loser, point - loser);

                    return int.Parse(loser_point);
                }

                if (str.Contains("Событие \"Восстание Ледяного Пламени\" закрыто")) start = false;
            }

            return 0;
        }
    }