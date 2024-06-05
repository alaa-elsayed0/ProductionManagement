using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Specifications.Tracking;

namespace Production.Core.Interface.Service
{
    public interface ITrackingService
    {
        Task<TrackingDto> CreateAsync(TrackingDto track);
        Task<TrackingDto> UpdateAsync(TrackingDto track);
        Task DeleteAsync(int id);
        Task<TrackingDto> GetByIdAsync(int id);
        Task<IEnumerable<TrackingDto>> GetAllTracks();
        Task<IEnumerable<Tracking>> Search(TrackingSpecificationParams specificationParams);
    }
}
