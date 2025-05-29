using System.Text;

namespace Design_Patterns_CSharp.CreationalPatterns;

interface IQueryBuilder
{
    IQueryBuilder AddParam(string name, string value);
    string Build();
}

class QueryBuilder : IQueryBuilder
{
    StringBuilder resultUrl = new();

    public IQueryBuilder AddParam(string name, string value)
    {
        if (resultUrl.Length == 0)
            resultUrl.Append("?");
        else
            resultUrl.Append("&");

        resultUrl.Append($"{name}={value}");

        return this;
    }

    public string Build() => resultUrl.ToString();
}

class QueryBuilderDirector
{
    private readonly IQueryBuilder queryBuilder;

    public QueryBuilderDirector(IQueryBuilder queryBuilder)
    {
        this.queryBuilder = queryBuilder;
    }

    public string CreateProfileLink() => queryBuilder.AddParam("profileId", "1").Build();
}

public class BuilderPatternDemo
{
    public static void Run()
    {
        IQueryBuilder queryBuilder = new QueryBuilder();

        QueryBuilderDirector director = new(queryBuilder);

        var userProfileLink = director.CreateProfileLink();

        Console.WriteLine(userProfileLink);
    }
}
