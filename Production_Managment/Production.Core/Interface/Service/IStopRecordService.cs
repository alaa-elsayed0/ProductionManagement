using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Specifications.StopRecords;

namespace Production.Core.Interface.Service
{
    public interface IStopRecordService
    {
        Task<StopRecordsDto> CreateAsync(StopRecordsDto records);
        Task<StopRecordsDto> UpdateAsync(StopRecordsDto records);
        Task DeleteAsync(int id);
        Task<StopRecordsDto> GetByIdAsync(int id);
        Task<IEnumerable<StopRecordsDto>> GetAllRecords();

        Task<IEnumerable<StopRecords>> Search(RecordsSpecificationParams specificationParams);
    }
}
