using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Hedgehog : MammalBase, IHedgehog
    {
        #region Public Properties

        public int SpinesLength { get; set; }
        public string Diet { get; set; }
        public string ColorOfQuills { get; set; }
        public int NumberOfSpikes { get; set; }

        #endregion // Public Properties

        #region Public Methods

        public override void MakeSound()
        {
            Console.WriteLine("I am a hedgehog, and I make a snuffling sound.");
        }

        public override void Move()
        {
            Console.WriteLine("I am a hedgehog, and I am moving slowly.");
        }

        public override void Display()
        {
            Console.WriteLine($"I am a hedgehog. My name is: {Name}, my age is: {Age}, and my color of quills is {ColorOfQuills}.");
        }

        public override void Copy(IAnimal animal)
        {
            if (animal is IHedgehog hedgehog)
            {
                base.Copy(animal);
                SpinesLength = hedgehog.SpinesLength;
                Diet = hedgehog.Diet;
                ColorOfQuills = hedgehog.ColorOfQuills;
                NumberOfSpikes = hedgehog.NumberOfSpikes;
            }
        }

        #endregion // Public Methods

        #region Constructors

        public Hedgehog(string name, int age, int spinesLength, string diet, string colorOfQuills, int numberOfSpikes)
            : base(name, age, MammalSpecies.Hedgehog)
        {
            SpinesLength = spinesLength;
            Diet = diet;
            ColorOfQuills = colorOfQuills;
            NumberOfSpikes = numberOfSpikes;
        }

        #endregion // Constructors
    }

}
