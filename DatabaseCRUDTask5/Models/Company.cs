namespace DatabaseCRUDTask5.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();

    public override string ToString()
    {
        return $"[Компания] ID: {Id} | Название: {Name}";
    }
}
