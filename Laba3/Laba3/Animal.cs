using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    class Animal
    {
        public string species;
        public string klass;
        public int weight;
        const int Max_Places = 10;
        public string places;
        //Конструктор без параметров
        public Animal() { }
        //Конструктор с параметрами
        public Animal(string p1, string p2, int p3, string Pl)
        {
            // TODO: Complete member initialization
            species = p1;
            klass = p2;
            weight = p3;
            places = Pl;
        }
    }
}
