using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeBlue.Core.Models;
using LifeBlue.Dal.DTO;

namespace LifeBlue.Core.Interfaces
{
    public interface IVistorInfoService
    {
        public Task<VisitorResponse> GetVisitorInformationAsync(int id);
        public Task<VisitorResponse> SaveVisitorInformation(VisitorRequest request);
    }
}
