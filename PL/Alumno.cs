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

            alumno.Semestre = new ML.Semestre(); //Instanciamos la llave foranea

            Console.WriteLine("Ingrese el Id del semestre");
            alumno.Semestre.IdSemestre = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Alumno.Add(alumno); 
            //ML.Result result = BL.Alumno.AddSP(alumno);
            ML.Result result = BL.Alumno.AddEF(alumno);

            if(result.Correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar el registro" );
            }
        }

        public static void Update()
        {
            ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Ingrese el Id del usuario");
            alumno.IdAlumno = int.Parse(Console.ReadLine());

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

            ML.Result result = BL.Alumno.Update(alumno);

            if(result.Correct)
            {
                Console.WriteLine("El registro se actulizo exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al actualizar");
            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            
            if(result.Correct)
            {
                foreach(ML.Alumno alumno in result.Objects)
                {
                    Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                    Console.WriteLine("Nombre: " + alumno.Nombre);
                    Console.WriteLine("ApellidoPaterno" + alumno.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + alumno.ApellidoMaterno);
                    Console.WriteLine("Sexo" + alumno.Sexo);
                    Console.WriteLine("Email" + alumno.Email);
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id a consultar");
            ML.Result result = BL.Alumno.GetById(int.Parse(Console.ReadLine()));

            if(result.Correct)
            {
                ML.Alumno alumno = ((ML.Alumno)result.Object); //UNBOXING : Proceso de convertir un tipo de objeto a un tipo de dato
                Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                Console.WriteLine("Nombre: " + alumno.Nombre);
                Console.WriteLine("ApellidoPaterno" + alumno.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + alumno.ApellidoMaterno);
                Console.WriteLine("Sexo" + alumno.Sexo);
                Console.WriteLine("Email" + alumno.Email);
                Console.WriteLine("-------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta");
            }
        }
    }
}
