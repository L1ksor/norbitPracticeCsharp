namespace DatabaseCRUDTask5.Models;

public partial class Trip
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public string Plane { get; set; } = null!;

    public string TownFrom { get; set; } = null!;

    public string TownTo { get; set; } = null!;

    public DateTime TimeOut { get; set; }

    public DateTime TimeIn { get; set; }

    public override string ToString()
    {
        return $"[Рейс {Id}] Самолет: {Plane} | Marshrut: {TownFrom} -> {TownTo} | Вылет: {TimeOut:dd.MM.yyyy HH:mm} | Прилет: {TimeIn:dd.MM.yyyy HH:mm}";
    }
}
