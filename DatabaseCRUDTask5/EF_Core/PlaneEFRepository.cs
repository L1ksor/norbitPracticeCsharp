using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCRUDTask5.Models;
namespace DatabaseCRUDTask5.EF_Core
{
    internal class PlaneEFRepository : IRepository<Plane, Guid>
    {
        private readonly AirlinesDbContext _context;

        public PlaneEFRepository(AirlinesDbContext context)
        {
            _context = context;
        }

        public List<Plane> GetAll() => _context.Planes.ToList();

        /// <inheritdoc />
        public Plane? GetById(Guid id) => _context.Planes.Find(id);

        /// <inheritdoc />
        public void Add(Plane plane)
        {
            _context.Planes.Add(plane);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(Plane plane)
        {
            _context.Planes.Update(plane);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            Plane? plane = GetById(id);

            if (plane != null)
            {
                _context.Planes.Remove(plane);
                _context.SaveChanges();
            }
        }
    }
}
