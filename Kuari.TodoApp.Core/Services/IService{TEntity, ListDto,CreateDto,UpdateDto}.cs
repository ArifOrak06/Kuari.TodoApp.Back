using Kuari.TodoApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Core.Services
{
    public interface IService<TEntity,ListDto,CreateDto,UpdateDto>
        where TEntity : class
        where ListDto : class
        where CreateDto : class
        where UpdateDto : class
    {
        Task<CustomResponseDto<IEnumerable<ListDto>>> GetAllAsync();
        Task<CustomResponseDto<IEnumerable<ListDto>>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task<CustomResponseDto<ListDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<CreateDto>> AddAsync(CreateDto createDto);
        Task<CustomResponseDto<IEnumerable<CreateDto>>> AddRangeAsync(IEnumerable<CreateDto> createDtos);
        Task<CustomResponseDto<UpdateDto>> UpdateAsync(UpdateDto updateDto,int  id);
        Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);
      

    }
}
