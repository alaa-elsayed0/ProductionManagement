using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Core.Specifications.Tracking;
using Production.Reprository.Specifications.Track;

namespace Production.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Tracking , int> _repository;

        public TrackingService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Tracking, int> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        //Create New Product Track
        public async Task<TrackingDto> CreateAsync(TrackingDto track)
        {
            //Apply Mapping
            var trackEntity = _mapper.Map<Tracking>(track);

            // Add the track entity to the repository
            await _unitOfWork.Repository<Tracking, int>().AddAysnc(trackEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TrackingDto>(trackEntity);
        }

        //Delete Product Track by Id
        public async Task DeleteAsync(int id)
        {
            var existingTrack = await _unitOfWork.Repository<Tracking, int>().GetAsync(id);

            // Check if Tracking Exist
            if (existingTrack == null)
                throw new Exception("Product not found.");

            // Remove the Tracking entity from the repository
            _unitOfWork.Repository<Tracking, int>().Delete(existingTrack);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();
        }

        //Edit Product Tracking
        public async Task<TrackingDto> UpdateAsync(TrackingDto track)
        {
            var existingTrack = await _unitOfWork.Repository<Tracking, int>().GetAsync(track.Id);
            
            // Check if Operation Exist
            if (existingTrack == null)
                throw new Exception("Product not found.");

            // Apply Mapping
            _mapper.Map(track, existingTrack);

            // Update the tracking entity from the repository
            _unitOfWork.Repository<Tracking, int>().Update(existingTrack);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TrackingDto>(existingTrack);
        }

        // Get All Tracking
        public async Task<IEnumerable<TrackingDto>> GetAllTracks()
        {
            // Get the Tracking entity from the repository
            var trackings = await _unitOfWork.Repository<Tracking, int>().GetAllAsync();
            return _mapper.Map<IReadOnlyList<TrackingDto>>(trackings);
        }

        // Get One Product Tracking By Id
        public async Task<TrackingDto> GetByIdAsync(int id)
        {
            // Get the Tracking entity from the repository
            var tracking = await _unitOfWork.Repository<Tracking, int>().GetAsync(id);
            return _mapper.Map<TrackingDto>(tracking);
        }

        // Apply Search By Product Name
        public async Task<IEnumerable<Tracking>> Search(TrackingSpecificationParams specificationParams)
        {
            var spec = new TrackingSpecification(specificationParams);
            return await _repository.GetAllWithSpecAsync(spec);
        }
    }
}
