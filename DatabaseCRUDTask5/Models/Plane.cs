
namespace DatabaseCRUDTask5.Models
{
    public class Plane
    {
        public Guid Id { get; set; }

        public string Model { get; set; } = string.Empty!;

        public Guid CompanyId { get; set; }

        public int PassengerCapacity { get; set; }

        public override string ToString()
        {
            return $"[Самолет] ID: {Id} | Модель: {Model} | Мест: {PassengerCapacity}";
        }

    }
}
