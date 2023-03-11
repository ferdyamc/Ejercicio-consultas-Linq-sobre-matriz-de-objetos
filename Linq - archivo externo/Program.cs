using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.SqlServer.Server;

namespace Linq___archivo_externo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Estudiantes = new[] {
                new {
                    EstudianteID =1,
                    Nombre = "Andrés",
                    ApellidoPaterno = "Marulanda",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =2,
                    Nombre = "Juan",
                    ApellidoPaterno = "Gomez",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =3,
                    Nombre = "Pedro",
                    ApellidoPaterno = "Lopez",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =4,
                    Nombre = "Carlos",
                    ApellidoPaterno = "Perez",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =5,
                    Nombre = "Luis",
                    ApellidoPaterno = "Ramirez",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =6,
                    Nombre = "Felipe",
                    ApellidoPaterno = "Gonzales",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =7,
                    Nombre = "Laura",
                    ApellidoPaterno = "Hernandez",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =8,
                    Nombre = "Kathe",
                    ApellidoPaterno = "Martinez",
                    Univeridad = "Universidad de la calle"
                },
                new {
                    EstudianteID =9,
                    Nombre = "Ferney",
                    ApellidoPaterno = "Rueda",
                    Univeridad = "Pascual Bravo"
                },
                new {
                    EstudianteID =10,
                    Nombre = "Camilo",
                    ApellidoPaterno = "Castaño",
                    Univeridad = "Universidad de la calle"
                }

            };

            var Universidades = new[] {
                new {
                    Universidad = "Pascual Bravo",
                    Ciudad = "Medellin",
                    Pais = "Colombia"
                },
                new {
                    Universidad = "Universidad de la calle",
                    Ciudad = "Bogotá",
                    Pais = "Colombia"
                },
                new {
                    Universidad = "U de A",
                    Ciudad = "Medellin",
                    Pais = "Colombia"
                },
                new {
                    Universidad = "Universidad de la calle",
                    Ciudad = "Bogotá",
                    Pais = "Colombia"
                },
                new {
                    Universidad = "CESDE",
                    Ciudad = "Medellin",
                    Pais = "Colombia"
                }
            };

            //Agrupar universidades por ciudad o país y devolver el conteo
            var NombrescCompletos = Universidades.GroupBy(e => e.Ciudad).Select(x => (Key: x.Key, Conteo: x.Count()));

            foreach (var universidad in NombrescCompletos)
            {
                Console.WriteLine($"Universidad : {universidad.Key} - Cantidad : {universidad.Conteo}");
            }

            Console.WriteLine();


            //Ordenar de forma ascendente y descente las universidades como quieras, si por el nombre, país o ciudad
            var CiudadesUniversidad = Universidades.OrderBy(x => x.Universidad).Select(x => x.Universidad);

            foreach (var universidad in CiudadesUniversidad)
            {
                Console.WriteLine($"Universidad : {universidad}");

            }
            Console.WriteLine();

            var CiudadesUniversidadDescendetes = Universidades.OrderByDescending(x => x.Universidad).Select(x => x.Universidad);

            foreach (var universidad in CiudadesUniversidadDescendetes)
            {
                Console.WriteLine($"Universidad : {universidad}");

            }

            Console.WriteLine();

            //Join entre estudiantes y universidades
            var EstudiantesUniversidades = (from estudiante in Estudiantes
                                           join universidad in Universidades
                                           on estudiante.Univeridad equals universidad.Universidad
                                           select
                                           (
                                              num: estudiante.EstudianteID,
                                              Nom: estudiante.Nombre,
                                              Apellido: estudiante.ApellidoPaterno,
                                              Uni: estudiante.Univeridad,
                                              Ciu: universidad.Ciudad,
                                              P: universidad.Pais
                                           )).Distinct();

            foreach (var x in EstudiantesUniversidades)
            {
                Console.WriteLine($"Estudiante : {x.num} {x.Nom}, Apellido : {x.Apellido}, Univerdidad : {x.Uni}, Ciudad : {x.Ciu}, País : {x.P}");
            }

            Console.WriteLine();

            //Contains (universidades o estudiantes que contengan x palabra o letra)
            var universidadesConPa = Universidades.Where(u => u.Universidad.Contains("Pa"));         
            
            foreach (var u in universidadesConPa)
            {
                Console.WriteLine($"La universidad : {u.Universidad} contiene las letras PA");
            }
            Console.ReadKey();
        }
    }
}
