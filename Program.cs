using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace astroSharp
{
  class Program
  {
    static async Task Main(string[] args)
    {

      string opcionPrincipal = "";
      string opcionMenuBody = "";
      bool salirPrograma = false;
      var bodyLoader = new Body_Loader();

      while (!salirPrograma)
      {
        // Menú principal
        Console.WriteLine("Bienvenido a AstroSharp. ¿Qué desea hacer?\n[1] Obtener información sobre un cuerpo celeste\n[2] Obtener el listado completo de cuerpos celestes disponibles\n[3] Salir de la aplicación");
        opcionPrincipal = Console.ReadLine();
        switch (opcionPrincipal)
        {
          case "1":
            bool volverAtras = false;
            // Submenú 1 - Información sobre un cuerpo celeste
            await listAllBodies(bodyLoader);

            Console.WriteLine("Introduzca el ID de un cuerpo celeste listado arriba:");
            string bodySelected = Console.ReadLine();
            Console.WriteLine($"Ha seleccionado {bodySelected}. Buscando información en red...");
            // Aquí se prepara la llamada al servidor...
            var body = await bodyLoader.getBodyInfo(bodySelected);

            if (body.Id != null)
            {
              while (!volverAtras)
              {
                Console.WriteLine("Seleccione una opción:\n[1] Obtener información básica\n[2] Medidas\n[3] Órbitas y posiciones\n[4] Volver al menú principal");
                opcionMenuBody = Console.ReadLine();
                switch (opcionMenuBody)
                {
                  case "1":
                    printBasicInfo(body);
                    break;
                  case "2":
                    printMeasurements(body);
                    break;
                  case "3":
                    printOrbitsPositions(body);
                    break;
                  case "4":
                    // Subir de nivel
                    volverAtras = !volverAtras;
                    break;
                  default:
                    Console.WriteLine("Opción desconocida");
                    break;
                }
              }
            }
            break;
          case "2":
            // Listado de todos los cuerpos
            await listAllBodies(bodyLoader);
            break;
          case "3":
            salirPrograma = !salirPrograma;
            break;
          default:
            Console.WriteLine("Opción desconocida");
            break;
        }
      }
    }

    public static void printBasicInfo(Body body)
    {
      Console.WriteLine("**************************");
      Console.WriteLine("*** Información Básica ***");
      Console.WriteLine($"ID: {body.Id}\nNombre: {body.Name}\nTipo: {(body.isPlanet ? "Planeta" : "Otro Astro")}\n{(body.isPlanet ? "Satélites: " + getListMoon(body.Moons) : body.AroundPlanet != null ? "Pertenece a: " + body.AroundPlanet.planet : "No pertenece a ningún planeta")}");
      Console.WriteLine("**************************");
    }

    public static String getListMoon(List<astroSharp.Moon> MoonsList) {
      string moons = "";

      if (MoonsList != null) {

        foreach(var moon in MoonsList) {
          if (MoonsList.IndexOf(moon) == MoonsList.Count - 1) {
            moons += $"{moon.moon}.";
          } else {
            moons += $"{moon.moon}, ";
          }
        }

      } else {
        moons = "No se le conocen satélites";
      }

      return moons;
    }

    public static void printMeasurements(Body body)
    {
      Console.WriteLine("*******************");
      Console.WriteLine("*** Medidas ***");
      Console.WriteLine($"Semiaxis Mayor: {body.SemiMajorAxis} Km.\nRadio Polar: {body.PolarRadius} Km.\nRadio Ecuatorial: {body.EquatorialRadius} Km.\nDensidad: {body.Density} g/cm3\nGravedad: {body.Gravity}m/s2");
      Console.WriteLine("*******************");
    }

    public static void printOrbitsPositions(Body body)
    {
      Console.WriteLine("******************");
      Console.WriteLine("*** Órbitas y Posiciones ***");
      Console.WriteLine($"Afelio {body.Aphelion} Km.\nPerihelio: {body.Perihelion} Km.\nExcentricidad: {body.Eccentricity}\nInclinación: {body.Inclination}º\nTraslación: {body.SideralOrbit} días\nRotación sideral: {body.SideralRotation} horas");
      Console.WriteLine("*******************");
    }

    public async static Task listAllBodies(Body_Loader bodyLoader)
    {
      var bodyList = await bodyLoader.getBodyList();
      Console.WriteLine("Cargando listado...");
      Console.WriteLine("Listado completo de cuerpos celestes disponibles");
      //Pintaremos un primer listado de planetas
      Console.WriteLine("--------------------");
      Console.WriteLine("Listado de planetas:");
      Console.WriteLine("--------------------");
      foreach (var cuerpo in bodyList.Bodies)
      {
        if (cuerpo.isPlanet)
        {
          Console.WriteLine(cuerpo.Id);
        }
      }
      Console.WriteLine("-----------------------");
      Console.WriteLine("Listado de otros astros:");
      Console.WriteLine("-----------------------");
      foreach (var cuerpo in bodyList.Bodies)
      {
        if (!cuerpo.isPlanet)
        {
          Console.WriteLine(cuerpo.Id);
        }
      }
      Console.WriteLine("------------------");
    }
  }
}
