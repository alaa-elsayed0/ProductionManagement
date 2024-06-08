using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Core.Specifications.StopRecords;
using Production.Reprository.Specifications.Record;

namespace Production.Services
{
    public class StopRecordService : IStopRecordService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<StopRecords, int> _repository;


        public StopRecordService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<StopRecords, int> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        //Create New Stop Record
        public async Task<StopRecordsDto> CreateAsync(StopRecordsDto records)
        {
            //Apply Mapping
            var recordEntity = _mapper.Map<StopRecords>(records);

            // Add the Stop Record entity to the repository
            await _unitOfWork.Repository<StopRecords, int>().AddAysnc(recordEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<StopRecordsDto>(recordEntity);
        }

        //Delete Stop Record by Id
        public async Task DeleteAsync(int id)
        {
            var existingRecord = await _unitOfWork.Repository<StopRecords, int>().GetAsync(id);

            // Check if Stop Record Exist
            if (existingRecord == null)
                throw new Exception("Report not found.");

            // Remove the Stop Record entity from the repository
            _unitOfWork.Repository<StopRecords, int>().Delete(existingRecord);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();
        }
        //Edit Srop Record
        public async Task<StopRecordsDto> UpdateAsync(StopRecordsDto records)
        {
            var existingRecord = await _unitOfWork.Repository<StopRecords, int>().GetAsync(records.Id);

            // Check if Stop Record Exist
            if (existingRecord == null)
                throw new Exception("Report not found.");

            // Apply Mapping
            _mapper.Map(records, existingRecord);

            // Update the Stop Record entity from the repository
            _unitOfWork.Repository<StopRecords, int>().Update(existingRecord);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<StopRecordsDto>(existingRecord);
        }

        // Get All Srop Record
        public async Task<IEnumerable<StopRecordsDto>> GetAllRecords()
        {
            // Get All the Stop Record entity from the repository
            var records = await _unitOfWork.Repository<StopRecords, int>().GetAllAsync();

            // Apply Mapping
            return _mapper.Map<IReadOnlyList<StopRecordsDto>>(records);

        }

        // Get One Product Stop Record By Id
        public async Task<StopRecordsDto> GetByIdAsync(int id)
        {
            // Get the Stop Record entity from the repository
            var record = await _unitOfWork.Repository<StopRecords, int>().GetAsync(id);
            return _mapper.Map<StopRecordsDto>(record);
        }

        //Allow Search by Product Name
        public async Task<IEnumerable<StopRecords>> Search(RecordsSpecificationParams specificationParams)
        {
            var spec = new StopRecordsSpecification(specificationParams);
            return await _repository.GetAllWithSpecAsync(spec);
        }
    }
}
