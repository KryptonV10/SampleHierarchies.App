using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class FlyingSquirrel : MammalBase, IFlyingSquirrel
    {
        #region Public Properties

        public int AirSpeed { get; set; }
        public double PawSpan { get; set; }
        public string FurColor { get; set; }
        public string Habitat { get; set; }

        #endregion // Public Properties

        #region Public Methods

        public override void MakeSound()
        {
            Console.WriteLine("I am a flying squirrel, and I can glide through the air.");
        }

        public override void Move()
        {
            Console.WriteLine("I am a flying squirrel, and I am gliding.");
        }

        public override void Display()
        {
            Console.WriteLine($"I am a flying squirrel. My name is: {Name}, my age is: {Age}, and my fur color is {FurColor}.");
        }

        public override void Copy(IAnimal animal)
        {
            if (animal is IFlyingSquirrel fs)
            {
                base.Copy(animal);
                AirSpeed = fs.AirSpeed;
                PawSpan = fs.PawSpan;
                FurColor = fs.FurColor;
                Habitat = fs.Habitat;
            }
        }

        #endregion // Public Methods

        #region Constructors

        public FlyingSquirrel(string name, int age, int airSpeed, double pawSpan, string furColor, string habitat)
            : base(name, age, MammalSpecies.FlyingSquirrel)
        {
            AirSpeed = airSpeed;
            PawSpan = pawSpan;
            FurColor = furColor;
            Habitat = habitat;
        }

        #endregion // Constructors
    }
}
