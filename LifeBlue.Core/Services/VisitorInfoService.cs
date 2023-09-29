using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LifeBlue.Core.Interfaces;
using LifeBlue.Core.Models;
using LifeBlue.Dal.DTO;
using LifeBlue.Dal.Repository;

namespace LifeBlue.Core.Services
{
    public class VisitorInfoService : IVistorInfoService
    {
        private IMapper _mapper;
        private IRepository _repository;

        public VisitorInfoService(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<VisitorInformation> GetVisitorInformationAsync(int id)
        {
            var visitorInfo = await _repository.VisitorInformationRepository.Get(id);

            return visitorInfo;
        }

        public async Task<VisitorInformation> SaveVisitorInformation(VisitorRequest request)
        {
            var visitorInfo = _mapper.Map<VisitorInformation>(request);
            MapBudget(visitorInfo, request);

            await _repository.VisitorInformationRepository.Add(visitorInfo);

            await _repository.Save();

            return visitorInfo;

        }

        private void MapBudget(VisitorInformation visitorInfo, VisitorRequest request)
        {
            var splitBudget = request.Budget.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var intBudgetList = new List<int>();

            foreach (var budget in splitBudget)
            {
                if(int.TryParse(budget, out int intBudget))
                    intBudgetList.Add(intBudget);
            }

            _ = intBudgetList.OrderBy(x => x);

            visitorInfo.LowBudget = intBudgetList[0];
            visitorInfo.HighBudget = intBudgetList[1];
        }
    }
}
