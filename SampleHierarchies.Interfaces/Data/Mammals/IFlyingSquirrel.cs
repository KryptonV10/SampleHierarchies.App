using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IFlyingSquirrel: IMammal
    {
        int AirSpeed { get; set; }
        double PawSpan { get; set; }
        string FurColor { get; set; }
        string Habitat { get; set; }
    }
}
