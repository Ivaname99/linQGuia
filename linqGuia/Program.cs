// See https://aka.ms/new-console-template for more information
using linqGuia;

// LinQ

#region Modelos
// Listas para almacenar los objetos de cada tipo
List<Casa> listaCasa = new List<Casa>();
List<Habitante> listaHabitante = new List<Habitante>();

#endregion

#region Casa

// Creamos varios objetos de tipo casa y los añadimos a la lista que almacena los datos de las casas
listaCasa.Add( new Casa { 
    Id = 1,
    Direccion = "3 vn chalatenango",
    Ciudad = "Chalatenango",
    NumeroHabitaciones = 20,
}); // Clase anonima, solo son de lectura
    // No se les pueden agregar metodos y no pueden heredar de otras clases

listaCasa.Add(new Casa
{
    Id = 2,
    Direccion = "3 vn chalatenango",
    Ciudad = "San Salvador",
    NumeroHabitaciones = 30,
});

listaCasa.Add(new Casa
{
    Id = 3,
    Direccion = "3 vn chalatenango",
    Ciudad = "Gothan City",
    NumeroHabitaciones = 30,
});
#endregion

#region Habitante
// Creamos varios objetos de tipo Habitante y los añadimos a la lista que almacena los datos de cada habitante
listaHabitante.Add(new Habitante{
    IdHabitante= 1,
    Nombre = "Ever",
    Edad = 50,
    IdCasa= 1,
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Alfredo",
    Edad = 666,
    IdCasa = 2,
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Ricardo",
    Edad = 36,
    IdCasa = 3,
});

#endregion

#region sentenciaLinQ 
// Filtro LinQ buscando habitantes mayores de 40 años y los almacena en ListaEdad.
IEnumerable<Habitante> ListaEdad = from ObjetoProvicional
                                   in listaHabitante
                                   where ObjetoProvicional.Edad > 40
                                   select ObjetoProvicional; //Permite crear listas dentro de él

// Muestra los datos de cada habitante filtrado.
foreach (Habitante objetoProcicional2 in ListaEdad)
{
    Console.WriteLine(objetoProcicional2.datosHabitante());
}

Console.WriteLine("----------------------------------------------------------------------------------------------");
// Filtro LinQ buscando habitantes que viven en "Gotham City"
IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in listaHabitante
                                         join objetoTemporalCasa in listaCasa
                                         on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.Id
                                         where objetoTemporalCasa.Ciudad == "Gothan City"
                                         select objetoTemporalHabitante;
// Muestra los datos almacenados en listaCasaGothan
foreach (Habitante h in listaCasaGothan)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion

#region FirsthAndFirsthOrDefault
// LINQ
Console.WriteLine("---------------------------LINQ---------------------------------------");
var primeraCasa = listaCasa.First(); // Obtiene la primera casa de la lista.
Console.WriteLine(primeraCasa.dameDatosCasa());

// Filtra el primer habitante mayor de 38 años usando LINQ.
Habitante personaEdad = (from tempItem
                         in listaHabitante where tempItem.Edad >38
                         select tempItem).First();
Console.WriteLine(personaEdad.datosHabitante());

// LAMBDA
Console.WriteLine("---------------------------Lambda-------------------------------------");
// Filtra el primer habitante mayor de 38 años usando LAMBDA.
var Habitante1 = listaHabitante.First(objectTemp => objectTemp.Edad > 38);
Console.WriteLine(Habitante1.datosHabitante());

// Busca una casa con Id mayor a 1 usando FirstOrDefault.
Casa CasaConFirsthOrDedault = listaCasa.FirstOrDefault(vCasa => vCasa.Id > 1);
if (CasaConFirsthOrDedault == null)
{
    Console.WriteLine("No existe el elemento");
    return;
}
Console.WriteLine("Si existe el elemento");
#endregion

#region Last
Casa ultimaCasa = listaCasa.Last(temp => temp.Id > 1); // Obtiene la última casa en la lista con Id mayor a 1.
Console.WriteLine(ultimaCasa.dameDatosCasa());
Console.WriteLine("___________________________________________________");
// Filtra el último habitante con edad mayor a 700 usando LINQ.
var h1 = (from objHabitante 
          in listaHabitante 
          where objHabitante.Edad > 700 
          select objHabitante)
    .LastOrDefault(); // Si no se encuentra, devuelve null.

// verifica si hay coincidencias
if (h1 == null)
{
    Console.WriteLine("Ocurrio un error");
    return;
}
Console.WriteLine(h1.datosHabitante());
#endregion

#region ElementAt
var terceraCasa = listaCasa.ElementAt(2); // Obtiene la tercera casa de la lista.
Console.WriteLine($"La tercera casa es {terceraCasa.dameDatosCasa()}");

var casaError = listaCasa.ElementAtOrDefault(3); // Intenta obtener la casa en el índice 3
if (casaError != null) { Console.WriteLine($"La tercera casa es {casaError.dameDatosCasa()}"); }

// filtro que obtiene el segundo habitante de la lista usando LINQ.
var segundoHabitante = (from objetoTem 
                        in listaHabitante 
                        select objetoTem).ElementAtOrDefault(2);
Console.WriteLine($"El segundo habitante es : {segundoHabitante.datosHabitante()}");

#endregion

#region single
try
{
    // Obtiene un único habitante con edad entre 40 y 70 años.
    var habitantes = listaHabitante.Single(variableTem => variableTem.Edad > 40 && variableTem.Edad < 70);
    // Creando esta consulta pero con LinQ
    var habitante2 = (from obtem in listaHabitante where obtem.Edad > 70 select obtem).SingleOrDefault();

    Console.WriteLine($"habitante con menos de 20 años {habitantes.datosHabitante()}");
    // Muestra los datos del habitante mayor de 70 años
    if (habitante2 != null) Console.WriteLine($"habitante con mas de 70 años {habitante2.datosHabitante()}");
}
catch (Exception) // Maneja las excepciones que puedan ocurrir en el codigo
{
    Console.WriteLine($"Ocurrio el error");
}
#endregion

#region typeOf
// Crea una lista de empleados con instancias de Medico y Enfermero.
var listaEmpleados = new List<Empleado>() {
    new Medico(){ nombre= "Jorge Casa" },
    new Enfermero(){ nombre = "Raul Blanco"}
};

var medico = listaEmpleados.OfType<Medico>(); // Filtra la lista para obtener solo objetos de tipo Medico.
Console.WriteLine(medico.Single().nombre); // Muestra el nombre del único Medico encontrado en la lista.
#endregion

#region OrderBy
var edadA = listaHabitante.OrderBy(x => x.Edad); // Ordena los habitantes por edad en orden ascendente usando lambda
// Ordena los habitantes por edad en orden ascendente usando Linq
var edadAC = from vt 
             in listaHabitante 
             orderby vt.Edad 
             select vt; 
// Muestra los datos ordenados
foreach (var edad in edadAC)
{
    Console.WriteLine(edad.datosHabitante());
}
#endregion

#region OrderBYDescending()
// Ordena los habitantes por edad en orden descendente usando lambda.
var listaEdad = listaHabitante.OrderByDescending(x => x.Edad);

// Se imprimen los datos ordenados
foreach (Habitante h in listaEdad)
{
    Console.WriteLine(h.datosHabitante());
}
Console.WriteLine("-------------------------------------------");

// Ordena los habitantes por edad en orden descendente usando LINQ.
var ListaEdad2 = from h 
                 in listaHabitante 
                 orderby h.Edad 
                 descending select h;

// Se imprimen los datos ordenados
foreach (Habitante h in ListaEdad2)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion

#region ThenBy
// Ordena los habitantes primero por edad en orden ascendente y luego por nombre en orden ascendente usando Lambda.
var habitantes3 = listaHabitante.OrderBy(x => x.Edad).ThenBy(x => x.Nombre);
// Ordena los habitantes primero por edad en orden ascendente y luego por nombre en orden descendente usando LinQ.
var edadATA = from h 
              in listaHabitante 
              orderby h.Edad, h.Nombre 
              descending select h;

// Muestra los datos
foreach (var h in edadATA)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("------------------");

// Ordena los habitantes por edad de manera ascendente, y luego por nombre de manera descendente usando Lambda
var habitantes4 = listaHabitante.OrderBy(x => x.Edad).ThenByDescending(x => x.Nombre);
// Ordena los habitantes primero por edad en orden ascendente y luego por nombre en orden ascendente usando LinQ.
var lista4 = from h 
             in listaHabitante 
             orderby h.Edad, h.Nombre 
             ascending select h;

// Muestra los datos
foreach (var h in lista4)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion
