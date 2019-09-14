using System;
using System.Collections.Generic;
using System.Text;

namespace Vita.Domain.Models
{
    public class Goal
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
