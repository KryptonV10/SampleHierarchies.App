using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IHedgehog : IMammal
    {
        int SpinesLength { get; set; }
        string Diet { get; set; }
        string ColorOfQuills { get; set; }
        int NumberOfSpikes { get; set; }
    }
}
