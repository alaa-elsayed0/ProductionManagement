using Production.Core.DataTransferObject;

namespace Production.Core.Interface.Service
{
    public interface IStopRecordService
    {
        Task<StopRecordsDto> CreateAsync(StopRecordsDto records);
        Task<StopRecordsDto> UpdateAsync(StopRecordsDto records);
        Task DeleteAsync(int id);
        Task<StopRecordsDto> GetByIdAsync(int id);
        Task<IEnumerable<StopRecordsDto>> GetAllRecords();
    }
}
