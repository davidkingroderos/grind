using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Model
{
    public class TodoGroup : List<Todo>
    {
        public string Name { get; set; }

        public TodoGroup(string name, List<Todo> todos) : base(todos)
        {
            Name = name;
        }
    }
}
