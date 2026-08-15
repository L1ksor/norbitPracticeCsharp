using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseCRUDTask5.Models;

public partial class PassInTrip
{
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public virtual Trip Trip { get; set; } = null!;

    public Guid PassengerId { get; set; }
    public virtual Passenger Passenger { get; set; } = null!;


    public string Place { get; set; } = null!;      



    public override string ToString()
    {
        string passengerInfo = Passenger != null ? Passenger.Name : PassengerId.ToString();
        string tripInfo = Trip != null ? $"{Trip.TownFrom} -> {Trip.TownTo}" : TripId.ToString();

        return $"[Билет] Место: {Place} | Пассажир: {passengerInfo} | Рейс: {tripInfo}";
    }

}
