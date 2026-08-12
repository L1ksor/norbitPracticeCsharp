using DatabaseCRUDTask5.Models;

namespace DatabaseCRUDTask5
{
    /// <inheritdoc />
    internal class CompanyEFRepository : IRepository<Company, Guid>
    {
        private readonly AirlinesDbContext _context;

        public CompanyEFRepository(AirlinesDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<Company> GetAll() => _context.Companies.ToList();

        /// <inheritdoc />
        public Company? GetById(Guid id) => _context.Companies.Find(id);

        /// <inheritdoc />
        public void Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            var company = GetById(id);

            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
        }
    }
}
