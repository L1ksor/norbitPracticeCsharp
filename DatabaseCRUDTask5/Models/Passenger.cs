namespace DatabaseCRUDTask5.Models;

public partial class Passenger
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public override string ToString()
    {
        return $"[Пассажир] ID: {Id} | Имя: {Name}";
    }
}
