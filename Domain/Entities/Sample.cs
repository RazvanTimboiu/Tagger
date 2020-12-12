using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Sample
    {
        public int Id { get; set; }
        public Data Data { get; set; }
        public Dictionary<Class, int> Choices { get; set; }
    }
}
