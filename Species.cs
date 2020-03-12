using System;
using System.Collections.Generic;
using System.Text;

namespace Quete_LINQ_Form
{
    class Species
    {
        public Guid SpeciesID { get; set; }
        public String Name { get; set; }
        public int Population { get; set; }
        public List<Animal> Animal { get; set; }
    }
}
