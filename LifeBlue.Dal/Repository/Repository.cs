using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeBlue.Dal.Contexts;

namespace LifeBlue.Dal.Repository
{
    public class Repository : IRepository
    {
        private readonly LifeBlueContext _context;

        private readonly Lazy<IVisitorInformationRepository> _visitorInformationRepository;
        public IVisitorInformationRepository VisitorInformationRepository => _visitorInformationRepository.Value;

        public Repository(LifeBlueContext context)
        {
            _context = context;
            _visitorInformationRepository =
                new Lazy<IVisitorInformationRepository>(() => new VisitorInformationRepository(_context));
        }

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
