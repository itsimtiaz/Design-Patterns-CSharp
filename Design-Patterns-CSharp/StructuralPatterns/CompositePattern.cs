namespace Design_Patterns_CSharp.StructuralPatterns;

interface ITeam
{
    void Render(int offset = 0);
}

class Team : ITeam
{
    public Team()
    {
        members = new();
    }
    readonly List<string> members;

    public void Add(string memberName) => members.Add(memberName);

    public void Render(int offset = 0)
    {
        var offsetValue = new string(' ', offset);
        Console.WriteLine($"{offsetValue}Members: {string.Join(", ", members)}");
    }
}

class TeamGroup : ITeam
{
    public TeamGroup(string teamName)
    {
        TeamName = teamName;
        teams = new();
    }

    public string TeamName { get; }

    readonly List<ITeam> teams;

    public void Add(ITeam team) => teams.Add(team);

    public void Remove(ITeam team) => teams.Remove(team);

    public void Render(int offset = 0)
    {
        var offsetValue = new string(' ', offset);
        Console.WriteLine($"{offsetValue}Team: {TeamName}");

        foreach (var team in teams)
        {
            team.Render(offset + 2);
        }
    }
}

public class CompositePatternDemo
{
    public static void Run()
    {
        var rescueTeam = new Team();
        rescueTeam.Add("John");
        rescueTeam.Add("Katie");
        rescueTeam.Add("Sara");

        var policeTeam = new Team();
        policeTeam.Add("Stevie");

        TeamGroup rescueTeamGroup = new("Rescue Team");
        rescueTeamGroup.Add(rescueTeam);

        TeamGroup policeTeamGroup = new("Police Team");
        policeTeamGroup.Add(policeTeam);

        TeamGroup teamGroup = new("Main Group");
        teamGroup.Add(rescueTeamGroup);
        teamGroup.Add(policeTeamGroup);

        teamGroup.Render();
    }
}
