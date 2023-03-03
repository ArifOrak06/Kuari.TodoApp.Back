using Kuari.TodoApp.Core.Repositories;
using Kuari.TodoApp.Core.Services;
using Kuari.TodoApp.Core.UnitOfWork;
using Kuari.TodoApp.Service.Mappings.AutoMapper;
using Kuari.TodoApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Service.Services
{
    public class Service<TEntity, ListDto, CreateDto, UpdateDto> : IService<TEntity, ListDto, CreateDto, UpdateDto>
        where TEntity : class
        where ListDto : class,new()
        where CreateDto : class, new()
        where UpdateDto : class, new()
    {
        
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<CreateDto>> AddAsync(CreateDto createDto)
        {
            if (createDto == null)
            {
                return CustomResponseDto<CreateDto>.Fail(400,"Dto is null");
            }
            var entity = ObjectMapper.Mapper.Map<TEntity>(createDto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            var dto = ObjectMapper.Mapper.Map<CreateDto>(entity);
            return CustomResponseDto<CreateDto>.Success(201, dto);
        }

        public async Task<CustomResponseDto<IEnumerable<CreateDto>>> AddRangeAsync(IEnumerable<CreateDto> createDtos)
        {
            if (createDtos == null)
            {
                return CustomResponseDto<IEnumerable<CreateDto>>.Fail(400, "Dto is null");
            }
            var entities = ObjectMapper.Mapper.Map<List<TEntity>>(createDtos);
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            var dtos = ObjectMapper.Mapper.Map<IEnumerable<CreateDto>>(entities);
            return CustomResponseDto<IEnumerable<CreateDto>>.Success(201, dtos);

        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id)
        {
            var deletedEntity = await _repository.GetByIdAsync(id);
            if (deletedEntity == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Data is not found");
            }
            _repository.Delete(deletedEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(200);
        }

        public async Task<CustomResponseDto<IEnumerable<ListDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            if (entities == null)
            {
                return CustomResponseDto<IEnumerable<ListDto>>.Fail(404, "Data is not found");
            }
            var listDto = ObjectMapper.Mapper.Map<IEnumerable<ListDto>>(entities);
            return CustomResponseDto<IEnumerable<ListDto>>.Success(200, listDto);
        }

        public async Task<CustomResponseDto<IEnumerable<ListDto>>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            var data = _repository.GetByFilter(filter);
            if (data == null)
            {
                return CustomResponseDto<IEnumerable<ListDto>>.Fail(404, "Filter hatası boş veya filter seçilmedi.");
            }
            var dto = ObjectMapper.Mapper.Map<IEnumerable<ListDto>>(data);
            return CustomResponseDto<IEnumerable<ListDto>>.Success(200, dto);
        }

        public async Task<CustomResponseDto<ListDto>> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return CustomResponseDto<ListDto>.Fail(404, $"{id}'ye sahip data bulunamadı");
            }
            var dto = ObjectMapper.Mapper.Map<ListDto>(data);
            return CustomResponseDto<ListDto>.Success(200, dto);    
        }

        public async Task<CustomResponseDto<UpdateDto>> UpdateAsync(UpdateDto updateDto, int id)
        {
            var unchangedEntity = await _repository.GetByIdAsync(id);
            if (unchangedEntity == null)
                return CustomResponseDto<UpdateDto>.Fail(404, $"{id}'ye sahip data bulunamadı");
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(updateDto);
            _repository.Update(newEntity);
            await _unitOfWork.CommitAsync();

            var newUpdateDto = ObjectMapper.Mapper.Map<UpdateDto>(newEntity);
            return CustomResponseDto<UpdateDto>.Success(200,newUpdateDto);

        }
    }
}
