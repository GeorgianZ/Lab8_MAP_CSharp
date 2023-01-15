using Lab_facultativ.repository.file;
using Lab_facultativ.service;

namespace Lab_facultativ.ui;

public class UI
{
    private static Service service = new Service(new TeamFileRepository("..\\..\\..\\data\\echipe.txt"),
        new PlayerFileRepository("..\\..\\..\\data\\jucatori.txt"),
        new GameFileRepository("..\\..\\..\\data\\meciuri.txt"),
        new ActivePlayerFileRepository("..\\..\\..\\data\\jucatoriActivi.txt"));

    private static void printMenu()
    {
        string s = "";
        s = s + "Alegeti o optiune de mai jos: \n";
        s = s + "\t \n  1. Sa se afiseze toti jucatorii unei echipe dată";
        s = s + "\t \n  2. Sa se afiseze toti jucatorii activi ai unei echipe de la un anumit meci";
        s = s + "\t \n  3. Sa se afiseze toate meciurile dintr-o anumita perioada calendaristica";
        s = s + "\t \n  4. Sa se afiseze numarul de puncte din meci";
        s = s + "\n";
        s = s + "\t \n 0. Iesire";
        Console.WriteLine(s);
    }

    public void runMenu()
    {
        int opt = 1;
        while (opt != 0)
        {
            printMenu();
            Console.WriteLine("Introduceti optiunea: ");
            opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 0:
                    Console.WriteLine("Exiting...");
                    break;
                case 1:
                    printAllPlayersForTeam();
                    break;
                case 2:
                    printAllActivePlayersForGame();
                    break;
                case 3:
                    printMatchesBetweenDates();
                    break;
                case 4:
                    printScoreForMatch();
                    break;
                case 5:
                    printTeams();
                    break;
                case 6:
                    printPlayers();
                    break;
                case 7:
                    printGames();
                    break;
                case 8:
                    printActivePlayers();
                    break;
                default:
                    Console.WriteLine("Introduceti o optiune valabila!");
                    break;
            }
        }
    }
    
    public static void printAllPlayersForTeam()
    {
        Console.WriteLine("Introduceti id-ul echipei: ");
        int idTeam = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Toti jucatorii echipei date sunt:");
        service.getAllPlayersForTeam(idTeam);
    }

    public static void printAllActivePlayersForGame()
    {
        Console.WriteLine("Introduceti id-ul echipei cautate: ");
        int idTeam = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduceti id-ul primei echipe din meci: ");
        int idTeam1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduceti id-ul celei de-al doilea echipe din meci: ");
        int idTeam2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduceti data si ora meciului dupa formatul ZZ/LL/AAAA HH:MM:SS AM(/PM)");
        string date = Console.ReadLine();
        Console.WriteLine("Toti jucatorii activi ai echipei date de la un anumit meci sunt:");
        service.getAllActivePlayersForGame(idTeam,
            new Tuple<Tuple<int, int>, DateTime>(new Tuple<int, int>(idTeam1, idTeam2), Convert.ToDateTime(date)));
        Console.WriteLine();
    }

    public static void printMatchesBetweenDates()
    {
        Console.WriteLine("Introduceti data si ora de inceput dupa formatul ZZ/LL/AAAA (HH:MM:SS) ");
        string start = Console.ReadLine();
        Console.WriteLine("Introduceti data si ora de final dupa formatul ZZ/LL/AAAA (HH:MM:SS) ");
        string end = Console.ReadLine();
        Console.WriteLine("Toate meciurile din perioada data");
        service.getMatchesBetweenDates(Convert.ToDateTime(start), Convert.ToDateTime(end));
        Console.WriteLine();
    }

    public static void printScoreForMatch()
    {
        Console.WriteLine("Introduceti id-ul primei echipe din meci: ");
        int idEchipa1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduceti id-ul celei de-a doua echipe din meci: ");
        int idEchipa2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduceti data si ora meciului dupa formatul ZZ/LL/AAAA HH:MM:SS AM(/PM)");
        string data = Console.ReadLine();
        service.getScoreForMatch(new Tuple<Tuple<int, int>, DateTime>(new Tuple<int, int>(idEchipa1,idEchipa2),Convert.ToDateTime(data)));
        Console.WriteLine();
    }

    public static void printTeams()
    {
        service.getTeams().ForEach(Console.WriteLine);
    }
    
    public static void printPlayers()
    {
        service.getPlayers().ForEach(Console.WriteLine);
    }
    
    public static void printGames()
    {
        service.getGames().ForEach(Console.WriteLine);
    }
    
    public static void printActivePlayers()
    {
        service.getActivePlayers().ForEach(Console.WriteLine);
    }
    
    
}