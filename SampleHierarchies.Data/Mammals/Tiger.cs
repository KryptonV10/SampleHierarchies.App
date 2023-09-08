using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Tiger : MammalBase, ITiger
    {
        #region Public Properties

        public int CountOfStrips { get; set; }
        public double LengthOfTooth { get; set; }
        public string PackHunting { get; set; }
        public string KindOf { get; set; }

        #endregion // Public Properties

        #region Public Methods

        public override void Display()
        {
            Console.WriteLine($"I am a tiger. My name is: {Name}, my age is: {Age}, and I have {CountOfStrips} stripes.");
        }

        public override void Copy(IAnimal animal)
        {
            if (animal is ITiger at)
            {
                base.Copy(animal);
                CountOfStrips = at.CountOfStrips;
                LengthOfTooth = at.LengthOfTooth;
                PackHunting = at.PackHunting;
                KindOf = at.KindOf;
            }
        }

        #endregion // Public Methods

        #region Constructors

        public Tiger(string name, int age, int countOfStrips, double lengthOfTooth, string packHunting, string kindOf)
            : base(name, age, MammalSpecies.Tiger)
        {
            CountOfStrips = countOfStrips;
            LengthOfTooth = lengthOfTooth;
            PackHunting = packHunting;
            KindOf = kindOf;
        }

        #endregion // Constructors
    }
}
