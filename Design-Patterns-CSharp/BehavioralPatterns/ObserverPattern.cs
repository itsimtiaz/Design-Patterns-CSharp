namespace Design_Patterns_CSharp.BehavioralPatterns;

interface IProductNotification
{
    /// <summary>
    /// push Notification
    /// </summary>
    /// <param name="productName"></param>
    void Change(string productName);

    /// <summary>
    /// Pull Notification
    /// </summary>
    void Update();
}

abstract class EventBase
{
    private readonly List<IProductNotification> _productNotifications;
    public EventBase()
    {
        _productNotifications = new();
    }

    public void Attach(IProductNotification notification) =>
        _productNotifications.Add(notification);

    public void Detach(IProductNotification notification) =>
        _productNotifications.Remove(notification);

    protected void NotifyNameUpdate(string productName) =>
        _productNotifications.ForEach(notify => notify.Change(productName));

    protected void NotifyUpdate() =>
        _productNotifications.ForEach(notify => notify.Update());
}

class Product : EventBase
{
    private string name = null!;

    public int Id { get; set; }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            NotifyNameUpdate(name);
        }
    }

    public decimal Price { get; set; }

    public void Update() => NotifyUpdate();

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, price: {Price}";
    }
}

class ProductSubscriber : IProductNotification
{
    private readonly Product product;

    public ProductSubscriber(Product product)
    {
        this.product = product;
    }
    public void Change(string name)
    {
        Console.WriteLine($"Product name has been changed to {name}");
    }

    public void Update()
    {
        Console.WriteLine($"Product has been updated. Product: {product}");
    }
}

public class ObserverPatternDemo
{
    public static void Run()
    {
        var product = new Product();

        IProductNotification productSubscriber = new ProductSubscriber(product);

        product.Attach(productSubscriber);

        product.Id = 1;
        product.Name = "Electronics"; // It will notify the subscribers with the updated name.

        product.Price = 12m;
        product.Update(); // It will trigger pull notification
    }
}
