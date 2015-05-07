using System.Collections.Generic;

namespace Quacka.Models
{
    public class FeedViewModel
    {
        public Quack New { get; set; }
        public IEnumerable<Quack> Quacks { get; set; } 
    }
}