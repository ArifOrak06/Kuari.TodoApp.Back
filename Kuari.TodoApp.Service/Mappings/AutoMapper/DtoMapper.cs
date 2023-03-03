using AutoMapper;
using Kuari.TodoApp.Core.DTOs;
using Kuari.TodoApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Service.Mappings.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<TodoCreateDto, ToDo>().ReverseMap();
            CreateMap<TodoUpdateDto, ToDo>().ReverseMap();
            CreateMap<TodoListDto, ToDo>().ReverseMap();
        }
    }
}
