using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Data
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public DataType Type { get; set; }
        public string Description { get; set; }
        public Sample Sample { get; set; }
        public int SampleId { get; set; }
    }
}
