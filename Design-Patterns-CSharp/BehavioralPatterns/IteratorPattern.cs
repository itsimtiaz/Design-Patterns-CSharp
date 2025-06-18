namespace Design_Patterns_CSharp.BehavioralPatterns;

interface IIterator<T> where T : class
{
    bool HasNext();
    T Current();
    void Next();
    void Reset();
}

record User(string Name);

class UserHandler
{
    readonly List<User> _users = new();

    public void Add(User user) => _users.Add(user);

    public void Remove(User user) => _users.Remove(user);

    public IIterator<User> CreateIterator() => new UsersListIterator(this);

    class UsersListIterator : IIterator<User>
    {
        private readonly UserHandler userHandler;
        private int offset = 0;

        public UsersListIterator(UserHandler userHandler)
        {
            this.userHandler = userHandler;
        }
        public User Current() => userHandler._users[offset];

        public bool HasNext() => offset < userHandler._users.Count;

        public void Next() => offset++;

        public void Reset() => offset = 0;
    }

}

public class IteratorPatternDemo
{
    public static void Run()
    {
        var userHandler = new UserHandler();

        userHandler.Add(new("Test"));
        userHandler.Add(new("Test 1"));
        userHandler.Add(new("Test 2"));

        var userIterator = userHandler.CreateIterator();

        while (userIterator.HasNext())
        {
            var current = userIterator.Current();
            Console.WriteLine($"{current}");
            userIterator.Next();
        }
    }
}
