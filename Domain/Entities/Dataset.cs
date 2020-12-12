using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Dataset
    {
        public int Id { get; set; }
        public Account Creator { get; set; }
        public List<Class> Classes { get; set; }
        public List<Sample> Samples { get; set; }

    }
}
