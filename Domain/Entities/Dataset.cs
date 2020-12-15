using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Entities
{
    public class Dataset
    {
        public int Id { get; set; }
        public Account Creator { get; set; }
        public List<Class> Classes { get; set; }
        public List<Sample> Samples { get; set; }
        public string Name { get; set; }
        public TagType TagType { get; set; }
        public DataType DataType { get; set; }

    }
}
