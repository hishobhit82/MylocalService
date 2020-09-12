using System.Collections.Generic;
using System.Linq;

namespace MyLocalEntities
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public List<Quality> Qualities { get; set; }

        public static List<Quality> GetQualities(string line)
        {
            var arrQuals = line.Split('|');
            return arrQuals.Select(q => new Quality { QualityName = q.Split('~')[0], QualityDesc = q.Split('~')[1] }).ToList();
        }

        public override string ToString()
        {
            return Name + "_" + Age + "_" + City;
        }
    }
}
