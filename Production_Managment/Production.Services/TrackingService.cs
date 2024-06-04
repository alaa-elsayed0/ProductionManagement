using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Reprository.Repositories;

namespace Production.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TrackingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<TrackingDto> CreateAsync(TrackingDto track)
        {
            var trackEntity = _mapper.Map<Tracking>(track);

            // Add the product entity to the repository
            await _unitOfWork.Repository<Tracking, int>().AddAysnc(trackEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TrackingDto>(trackEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingTrack = await _unitOfWork.Repository<Tracking, int>().GetAsync(id);

            if (existingTrack == null)
                throw new Exception("Product not found.");

            // Remove the product entity from the repository
            _unitOfWork.Repository<Tracking, int>().Delete(existingTrack);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<TrackingDto> UpdateAsync(TrackingDto track)
        {
            var existingTrack = await _unitOfWork.Repository<Tracking, int>().GetAsync(track.TrackingId);
            if (existingTrack == null)
                throw new Exception("Product not found.");

            _mapper.Map(track, existingTrack);

            _unitOfWork.Repository<Tracking, int>().Update(existingTrack);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TrackingDto>(existingTrack);
        }

        public async Task<IEnumerable<TrackingDto>> GetAllTracks()
        {
            var trackings = await _unitOfWork.Repository<Tracking, int>().GetAllAsync();
            return _mapper.Map<IReadOnlyList<TrackingDto>>(trackings);
        }

        public async Task<TrackingDto> GetByIdAsync(int id)
        {
            var tracking = await _unitOfWork.Repository<Tracking, int>().GetAsync(id);
            return _mapper.Map<TrackingDto>(tracking);
        }

    }
}
