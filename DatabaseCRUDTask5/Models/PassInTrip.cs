namespace DatabaseCRUDTask5.Models;

public partial class PassInTrip
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public Guid PassengerId { get; set; }

    public string Place { get; set; } = null!;

}
