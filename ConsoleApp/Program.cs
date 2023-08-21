using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp
{
    internal class Program
    {
        public static string directoryPath = $"D:\\BEKEND\\FileStream-txt\\TEST\\";
        public static string filePath = "D:\\BEKEND\\FileStream-txt\\TEST\\FILE.txt";
        public static string copyPath = "D:\\BEKEND\\FileStream-txt\\TEST\\FILE-COPY.txt";
        static void Main(string[] args)
        {
            while (true) // vječna petlja
            {
                Console.WriteLine("\nUnesite broj za ono što želite:\n");
                string[] izbornik = {
                "1. Sve u jednom, redom",
                "2. Napravi folder TEST ako ga nema",
                "3. Napravi file FILE.txt ako ga nema",
                "4. Read FILE.txt",
                "5. Dodaj tekst u FILE.txt",
                "6. Overwrite sadržaj iz FILE.txt",
                "7. Kopiraj sadržaj iz FILE.txt u FILE-COPY.txt (napravit će novi file ako ga nema)",
                "8. Read FILE-COPY.txt",
                "9. Read FILE.txt i FILE-COPY.txt"
            };

                int i = 0;
                do
                {
                    Console.WriteLine(izbornik[i]);
                    i++;
                }
                while (i < izbornik.Length);
                Console.WriteLine("\n"); // ide mi na živce bez novog reda
                string izbor = Console.ReadLine();

                switch (izbor)
                {
                    case "1":
                        CreateFolder();
                        CreateFile();
                        WriteToFile();
                        CopyFile();
                        ReadBoth();
                        break;

                    case "2":
                        CreateFolder();
                        break;

                    case "3":
                        CreateFile();
                        break;

                    case "4":
                        ReadFile();
                        break;

                    case "5":
                        WriteToFile();
                        break;

                    case "6":
                        OverwriteFile();
                        break;

                    case "7":
                        CopyFile();
                        break;

                    case "8":
                        ReadCopy();
                        break;

                    case "9":
                        ReadBoth();
                        break;

                    default:
                        Console.WriteLine("\nNepoznat unos. Pokušajte ponovo.");
                        continue;
                }
            }
        }
        static void CreateFolder()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("\nLooking for the folder. Folder was not found, so it was created.\n");
            }
            else { Console.WriteLine("\nLooking for the folder. Found existing folder.\n"); }
        }
        static void CreateFile()
        {
            if (!File.Exists(filePath))
            {
                FileStream stream = File.Create(filePath);
                stream.Flush();
                stream.Close();
                Console.WriteLine("\nLooking for the file. File was not found, so it was created.\n");
            }
            else { Console.WriteLine("\nLooking for the file. Found existing file.\n"); }
        }
        static void WriteToFile()
        {
            Console.WriteLine("\nType in stuff you want in the txt file. Enter goes to a new row. To exit enter 0.\n");
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "0") { break; }

                File.AppendAllText(filePath, "\n" + input);
            }
            
        }
        static void OverwriteFile()
        {
            Console.WriteLine("\nThis will overwrite the previous file contents. Type in stuff you want in the txt file. Enter goes to a new row. To exit enter 0.\n");
            File.WriteAllText(filePath, "");
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "0") { break; }

                File.AppendAllText(filePath, "\n" + input);
            }
        }
        static void CopyFile()
        {

            if (!File.Exists(copyPath))
            {
                FileStream stream = File.Create(copyPath);
                stream.Flush();
                stream.Close();
                Console.WriteLine("\nLooking for the file for copy. File was not found, so it was created.\n");
            }
            else { Console.WriteLine("\nLooking for the file for copy. Found existing file.\n"); }

            FileStream startStream = File.OpenRead(filePath);
            FileStream endStream = File.OpenWrite(copyPath);
            startStream.CopyTo(endStream);

            startStream.Flush(); startStream.Close();
            endStream.Flush(); endStream.Close();            
        }
        static void ReadFile()
        {
            string tekst = File.ReadAllText(filePath);
            Console.WriteLine("\nFILE tekst: \n" + tekst);
        }
        static void ReadCopy()
        {
            string kopija = File.ReadAllText(copyPath);
            Console.WriteLine("\nFILE-COPY tekst: \n" + kopija);
        }
        static void ReadBoth()
        {
            string tekst = File.ReadAllText(filePath);
            string kopija = File.ReadAllText(copyPath);
            Console.WriteLine("\nFILE tekst: \n" + tekst);
            Console.WriteLine("\nFILE-COPY tekst: \n" + kopija);
        }
    }
}