using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Models
{
    public class TodoGroup : ObservableCollection<Todo>
    {
        public string Name { get; set; }
        public Color Color { get; set; }

        public TodoGroup(string name, ObservableCollection<Todo> todos) : base(todos)
        {
            Name = name;
            Color = CatppuccinColorConverter.GetColor(Name);
        }
    }
}
