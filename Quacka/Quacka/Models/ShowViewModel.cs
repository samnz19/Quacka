using System.Collections.Generic;

namespace Quacka.Models
{
    public class ShowViewModel
    {
        public bool IsFollowing { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Quack> Quacks { get; set; }
        public IEnumerable<string> Following { get; set; } 
        public IEnumerable<string> Followers { get; set; } 
    }
}