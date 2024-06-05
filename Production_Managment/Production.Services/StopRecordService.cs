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

        public async Task<StopRecordsDto> CreateAsync(StopRecordsDto records)
        {
            var recordEntity = _mapper.Map<StopRecords>(records);

            // Add the product entity to the repository
            await _unitOfWork.Repository<StopRecords, int>().AddAysnc(recordEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<StopRecordsDto>(recordEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingRecord = await _unitOfWork.Repository<StopRecords, int>().GetAsync(id);

            if (existingRecord == null)
                throw new Exception("Report not found.");

            // Remove the product entity from the repository
            _unitOfWork.Repository<StopRecords, int>().Delete(existingRecord);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<StopRecordsDto> UpdateAsync(StopRecordsDto records)
        {
            var existingRecord = await _unitOfWork.Repository<StopRecords, int>().GetAsync(records.StopRecordsId);
            if (existingRecord == null)
                throw new Exception("Report not found.");

            _mapper.Map(records, existingRecord);

            _unitOfWork.Repository<StopRecords, int>().Update(existingRecord);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<StopRecordsDto>(existingRecord);
        }

        public async Task<IEnumerable<StopRecordsDto>> GetAllRecords()
        {
            var records = await _unitOfWork.Repository<StopRecords, int>().GetAllAsync();
            return _mapper.Map<IReadOnlyList<StopRecordsDto>>(records);

        }

        public async Task<StopRecordsDto> GetByIdAsync(int id)
        {
            var record = await _unitOfWork.Repository<StopRecords, int>().GetAsync(id);
            return _mapper.Map<StopRecordsDto>(record);
        }

        public async Task<IEnumerable<StopRecords>> Search(RecordsSpecificationParams specificationParams)
        {
            var spec = new StopRecordsSpecification(specificationParams);
            return await _repository.GetAllWithSpecAsync(spec);
        }
    }
}
