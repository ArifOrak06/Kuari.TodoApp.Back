using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Core.DTOs
{
    public class TodoUpdateDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
     
    }
}
