using Production.Core.DataTransferObject;

namespace Production.Core.Interface.Service
{
    public interface ITrackingService
    {
        Task<TrackingDto> CreateAsync(TrackingDto track);
        Task<TrackingDto> UpdateAsync(TrackingDto track);
        Task DeleteAsync(int id);
        Task<TrackingDto> GetByIdAsync(int id);
        Task<IEnumerable<TrackingDto>> GetAllTracks();
    }
}
