using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quete_LINQ_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            using (var context = new AnimalContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var speciesCougar = new Species
                {
                    Name = "cougars",
                    Population = 3
                };
                var speciesTiger = new Species
                {
                    Name = "tigers",
                    Population = 100
                };
                var speciesTurtle = new Species
                {
                    Name = "turtles",
                    Population = 15
                };

                var animal1 = new Animal
                {
                    Name = "White Cougar",
                    Species = speciesCougar
                };

                var animal2 = new Animal
                {
                    Name = "White Tiger",
                    Species = speciesTiger
                };

                var animal3 = new Animal
                {
                    Name = "Albinos Turtle",
                    Species = speciesTurtle
                };
                List<Species> SpeciesList = new List<Species> { speciesCougar, speciesTiger, speciesTurtle };
                List<Animal> AnimalList = new List<Animal> { animal1, animal2, animal3 };

                context.AddRange(SpeciesList);
                context.AddRange(AnimalList);
                context.SaveChanges();

                //foreach(var animal in context.Species)
                //{

                //}

                var whiteCougars = (from spec in context.Species
                                    where spec.Name == "cougars"
                                    select new { spec.Name, spec.Population });

                var whiteTigers = from spec in context.Species
                                  where spec.Name == "tigers"
                                  select new { spec.Name, spec.Population };

                var albinosTurtle = from spec in context.Species
                                    where spec.Name == "turtles"
                                    select new { spec.Name, spec.Population };


                string species1 = String.Empty;
                foreach (var cougar in whiteCougars)
                {
                    species1 = "Species = " + cougar.Name + ", Population = " + cougar.Population;
                }
                string species2 = String.Empty;
                foreach (var tiger in whiteTigers)
                {
                    species2 = "Species = " + tiger.Name + ", Population = " + tiger.Population;
                }
                string species3 = String.Empty;
                foreach (var turtle in albinosTurtle)
                {
                    species3 = "Species = " + turtle.Name + ", Population = " + turtle.Population;
                }

                MessageBox.Show(species1 +"\n" + species2 + "\n" + species3);
            }
        }

    }
}
