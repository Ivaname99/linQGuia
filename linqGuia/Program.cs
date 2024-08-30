﻿// See https://aka.ms/new-console-template for more information
using linqGuia;

Console.WriteLine("Hello, World!");

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
    numeroHabitaciones = 20,
}); // Clase anonima, no se puede escribir?? sobre ellas , solo son de lectura

listaCasa.Add(new Casa
{
    Id = 1,
    Direccion = "3 vn chalatenango",
    Ciudad = "San Salvador",
    numeroHabitaciones = 30,
});

listaCasa.Add(new Casa
{
    Id = 1,
    Direccion = "3 vn chalatenango",
    Ciudad = "San Miguel",
    numeroHabitaciones = 30,
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
    IdCasa = 1,
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Ricardo",
    Edad = 36,
    IdCasa = 1,
});

#endregion

#region SentenciasLinQ

IEnumerable<Habitante> listaEdad =  //Permite crear listas dentro de el
    from obTem in listaHabitante where obTem.Edad >= 40 select obTem;

foreach( var it in listaEdad)
{
    Console.WriteLine( it.datosHabitante());
};
#endregion

#region sentenciaLinQ 

IEnumerable<Habitante> ListaEdad = from ObjetoProvicional
                                   in listaHabitante
                                   where ObjetoProvicional.Edad > 40
                                   select ObjetoProvicional;

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