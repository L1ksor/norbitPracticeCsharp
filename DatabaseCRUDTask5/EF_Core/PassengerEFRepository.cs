using DatabaseCRUDTask5.Models;

namespace DatabaseCRUDTask5
{
    internal class PassengerEFRepository : IRepository<Passenger, Guid>
    {
        private readonly AirlinesDbContext _context;

        public PassengerEFRepository(AirlinesDbContext context)
        {
            _context = context;
        }

        public List<Passenger> GetAll() => _context.Passengers.ToList();

        /// <inheritdoc />
        public Passenger? GetById(Guid id) => _context.Passengers.Find(id);


        public void Add(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            Passenger passenger = GetById(id);

            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                _context.SaveChanges();
            }
        }
    }
}
