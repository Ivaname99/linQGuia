// See https://aka.ms/new-console-template for more information
using linqGuia;

// LinQ

#region Modelos

List<Casa> listaCasa = new List<Casa>();
List<Habitante> listaHabitante = new List<Habitante>();

#endregion

#region Casa

listaCasa.Add( new Casa { 
    Id = 1,
    Direccion = "3 vn chalatenango",
    Ciudad = "Chalatenango",
    NumeroHabitaciones = 20,
}); // Clase anonima, no se puede escribir?? sobre ellas , solo son de lectura
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

IEnumerable<Habitante> ListaEdad = from ObjetoProvicional
                                   in listaHabitante
                                   where ObjetoProvicional.Edad > 40
                                   select ObjetoProvicional; //Permite crear listas dentro de él

foreach (Habitante objetoProcicional2 in ListaEdad)
{
    Console.WriteLine(objetoProcicional2.datosHabitante());
}

//Join
IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in listaHabitante
                                         join objetoTemporalCasa in listaCasa
                                         on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.Id
                                         where objetoTemporalCasa.Ciudad == "Gothan City"
                                         select objetoTemporalHabitante;
Console.WriteLine("----------------------------------------------------------------------------------------------");
foreach (Habitante h in listaCasaGothan)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion

#region FirsthAndFirsthOrDefault

Console.WriteLine("--------------------------------------------------------------------------");
var primeraCasa = listaCasa.First();
Console.WriteLine(primeraCasa.dameDatosCasa());

Habitante personaEdad = (from tempItem
                         in listaHabitante where tempItem.Edad >38
                         select tempItem).First();
Console.WriteLine(personaEdad.datosHabitante());

// LAMBDA
Console.WriteLine("---------------------------Lo mismo pero con lambdas---------------------------------------------------------");
var Habitante1 = listaHabitante.First(objectTemp => objectTemp.Edad > 38);
Console.WriteLine(Habitante1.datosHabitante());

Casa CasaConFirsthOrDedault = listaCasa.FirstOrDefault(vCasa => vCasa.Id > 1);
if (CasaConFirsthOrDedault == null)
{
    Console.WriteLine("No existe el elemento");
    return;
}
Console.WriteLine("Si existe el elemento");
#endregion