using DatabaseCRUDTask5.Models;

namespace DatabaseCRUDTask5
{
    /// <inheritdoc />
    internal class TripEFRepository : IRepository<Trip, Guid>
    {
        private readonly AirlinesDbContext _context;

        public TripEFRepository(AirlinesDbContext context)
        {
            _context = context;
        }

        public List<Trip> GetAll() => _context.Trips.ToList();

        /// <inheritdoc />
        public Trip? GetById(Guid id) => _context.Trips.Find(id);


        public void Add(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(Trip trip)
        {
            _context.Trips.Update(trip);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            Trip trip = GetById(id);

            if (trip != null)
            {
                _context.Trips.Remove(trip);
                _context.SaveChanges();
            }
        }
    }
}
