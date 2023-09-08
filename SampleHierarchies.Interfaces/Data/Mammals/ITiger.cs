using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface ITiger : IMammal
    {
        int CountOfStrips { get; set; }
        double LengthOfTooth { get; set; }
        string PackHunting { get; set; }
        string KindOf { get; set; }
    }
}
