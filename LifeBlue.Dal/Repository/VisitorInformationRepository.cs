using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeBlue.Dal.Contexts;
using LifeBlue.Dal.DTO;

namespace LifeBlue.Dal.Repository
{
    public class VisitorInformationRepository : RepositoryBase<VisitorInformation>, IVisitorInformationRepository
    {
        public VisitorInformationRepository(LifeBlueContext context) : base(context)
        {
        }

    }
}
