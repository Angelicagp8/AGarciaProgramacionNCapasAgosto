using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Alumno alumno = new ML.Alumno();  //CREAR OBJETO // INSTANCIAMOS PARA PODER ACCEDER A LOS MÉTODOS Y ATRIBUTOS

            Console.WriteLine("Ingrese el nombre");
            alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el  ApellidoPaterno");
            alumno.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoMaterno");
            alumno.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo");
            alumno.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el email");
            alumno.Email = Console.ReadLine();

            ML.Result result = BL.Alumno.Add(alumno); 

            if(result.Correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar el registro" );
            }
        }
    }
}
