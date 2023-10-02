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

        public async Task<VisitorResponse> GetVisitorInformationAsync(int id)
        {
            var visitorInfo = await _repository.VisitorInformationRepository.Get(id);

            var errors = new List<string>();

            if (visitorInfo == null)
                errors.Add($"Visitor Information not found for Id {id}");

            return CreateVisitorResponse(visitorInfo, errors);
        }

        public async Task<VisitorResponse> SaveVisitorInformation(VisitorRequest request)
        {
            var visitorInfo = _mapper.Map<VisitorInformation>(request);
            MapBudget(visitorInfo, request);

            var errors = new List<string>();

            if (HasLowAndHighBudget(visitorInfo))
            {
                await _repository.VisitorInformationRepository.Add(visitorInfo);

                await _repository.Save();
            }
            else
            {
                errors = new List<string> { $"Budget value of {request.Budget} could not be mapped to a lower and higher value" };
                visitorInfo.Id = -1;
            }

            return CreateVisitorResponse(visitorInfo, errors);

        }

        private static void MapBudget(VisitorInformation visitorInfo, VisitorRequest request)
        {
            var splitBudget = request.Budget.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var intBudgetList = new List<int>();

            foreach (var budget in splitBudget)
            {
                if (int.TryParse(budget, out var intBudget))
                    intBudgetList.Add(intBudget);
            }

            _ = intBudgetList.OrderBy(x => x);

            if (intBudgetList.Count != 2) return;

            visitorInfo.LowBudget = intBudgetList[0];
            visitorInfo.HighBudget = intBudgetList[1];

        }

        private VisitorResponse CreateVisitorResponse(VisitorInformation visitorInfo, IEnumerable<string>? errors)
        {
            return new VisitorResponse
            {
                VisitorInformation = visitorInfo,
                Errors = errors
            };
        }

        private static bool HasLowAndHighBudget(VisitorInformation visitorInfo)
        {
            return visitorInfo is { LowBudget: > 0, HighBudget: > 0 };
        }
    }
}
