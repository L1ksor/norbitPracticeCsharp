using Microsoft.EntityFrameworkCore; // <-- Не забудьте импортировать!
using DatabaseCRUDTask5.Models;
namespace DatabaseCRUDTask5.EF_Core
{
    internal class PassInTripEFRepository : IRepository<PassInTrip, Guid>
    {
        private readonly AirlinesDbContext _context;

        public PassInTripEFRepository(AirlinesDbContext context)
        {
            _context = context;
        }

        public List<PassInTrip> GetAll() => _context.PassInTrips
            .Include(pt => pt.Passenger)
            .Include(pt => pt.Trip)
            .ToList();

        /// <inheritdoc />
        public PassInTrip? GetById(Guid id) => _context.PassInTrips
            .Include(pt => pt.Passenger)
            .Include(pt => pt.Trip)
            .FirstOrDefault(pt => pt.Id == id);

        /// <inheritdoc />
        public void Add(PassInTrip passInTrip)
        {
            _context.PassInTrips.Add(passInTrip);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(PassInTrip passInTrip)
        {
            _context.PassInTrips.Update(passInTrip);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            PassInTrip? passInTrip = GetById(id);

            if (passInTrip != null)
            {
                _context.PassInTrips.Remove(passInTrip);
                _context.SaveChanges();
            }
        }
    }
}
