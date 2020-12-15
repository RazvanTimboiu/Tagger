using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Application.Common.DTO
{
    public class DatasetInfo
    {
        public int DatasetId { get; set; }
        public DataType DataType { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public TagType TagType { get; set; }
        public int NoOfClasses { get; set; }
        public int NoOfSamples { get; set; }

        public DatasetInfo(int datasetId, DataType dataType, string name, string author, TagType tagType, int noOfClasses, int noOfSamples)
        {
            DatasetId = datasetId;
            DataType = dataType;
            Name = name;
            Author = author;
            TagType = tagType;
            NoOfClasses = noOfClasses;
            NoOfSamples = noOfSamples;
        }
    }
}
