using Lab_facultativ.repository;
using Lab_facultativ.repository.file;

namespace Lab_facultativ.service;

public class Service
{
    private Repository<int, Team> teams;
    private Repository<int, Player> players;
    private Repository<Tuple<Tuple<int, int>, DateTime>, Game> games;
    private Repository<Tuple<int, Tuple<Tuple<int, int>, DateTime>>, ActivePlayer> activePlayers;

    public Service(Repository<int, Team> teams, Repository<int, Player> players,
        Repository<Tuple<Tuple<int, int>, DateTime>, Game> games, Repository<Tuple<int, Tuple<Tuple<int, int>, DateTime>>, ActivePlayer> activePlayers)
    {
        this.teams = teams;
        this.players = players;
        this.games = games;
        this.activePlayers = activePlayers;
    }

    public void getAllPlayersForTeam(int idTeam)
    {
        players.findAll().Where(x => x.idTeam == idTeam).ToList().ForEach(Console.WriteLine);
    }

    public void getAllActivePlayersForGame(int idTeam, Tuple<Tuple<int, int>, DateTime> idGame)
    {
        activePlayers.findAll()
            .Where(x => Equals(x.id.Item2, idGame) &&
                        Equals(players.findOne(x.id.Item1).idTeam, idTeam))
            .ToList().ForEach(Console.WriteLine);
    }

    public void getMatchesBetweenDates(DateTime start, DateTime end)
    {
        games.findAll().Where(x => x.id.Item2 >= start && x.id.Item2 <= end).ToList().ForEach(Console.WriteLine);
    }

    public void getScoreForMatch(Tuple<Tuple<int, int>, DateTime> idGame)
    {
        Console.WriteLine("Scorul de la meciul introdus este: " + activePlayers.findAll()
            .Where(x => Equals(x.id.Item2, idGame)).Sum(x => x.points));
    }

    public List<Team> getTeams()
    {
        return teams.findAll().ToList();
    }

    public List<Player> getPlayers()
    {
        return players.findAll().ToList();
    }

    public List<Game> getGames()
    {
        return games.findAll().ToList();
    }

    public List<ActivePlayer> getActivePlayers()
    {
        return activePlayers.findAll().ToList();
    }
}