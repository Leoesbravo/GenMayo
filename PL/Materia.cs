using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        public static void Add()
        {

            Console.WriteLine("Ingrese el nombre de la materia");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el costo de la materia");
            decimal costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese los creditos de la materia");
            byte creditos = byte.Parse(Console.ReadLine());

            //instancia
            // ML.Result result = new ML.Result();

            ML.Result result = BL.Materia.Add(nombre, costo, creditos);

            if (result.Correct)
            {
                Console.WriteLine("La materia se ha agregado");
            }
            else
            {
                Console.WriteLine("La materia no se pudo agregar " + result.ErrorMessage);
            }
        }
        public static void AddConObjeto()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese los creditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            //instancia
            // ML.Result result = new ML.Result();

            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                Console.WriteLine("La materia se ha agregado");
            }
            else
            {
                Console.WriteLine("La materia no se pudo agregar " + result.ErrorMessage);
            }
        }
    }
}
