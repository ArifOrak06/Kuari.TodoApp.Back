using Kuari.TodoApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Core.Entities
{
    public class ToDo : BaseEntity
    {
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
    }
}
