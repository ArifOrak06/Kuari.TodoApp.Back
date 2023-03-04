using Kuari.TodoApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Repository.Seeds
{
    public class TodoSeedData : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasData(new ToDo[]
            {
                new(){Id=1,Content="Angular 15 yeniliklerine bakılacak",IsCompleted=false},
                 new(){Id=2, Content="Asp.Net Core 6.0 WebAPI with ANGULAR M.Y TreversallApp geliştirilecek",IsCompleted=false},
                new(){Id=3, Content="Asp.NET Core 6.0 WebAPI with Angular SbrWebApp geliştirilecek",IsCompleted=false}

            });

        }
    }
}
