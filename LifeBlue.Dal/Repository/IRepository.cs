using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBlue.Dal.Repository
{
    public interface IRepository
    {
        public IVisitorInformationRepository VisitorInformationRepository { get; }

        Task Save();
    }
}
