using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace astroSharp
{
  ///<summary>Clase que realiza solicitudes a la API con el fin de obtener datos sobre astros</summary>
  class Body_Loader
  {
    static readonly HttpClient client = new HttpClient();
    private string url = "https://api.le-systeme-solaire.net/rest/bodies/";

    public Body_Loader()
    {

    }

    ///<summary>Obtiene la información de un cuerpo celeste especificado</summary>
    ///<param><c>id</c>Identificador del cuerpo a buscar</param>
    ///<returns>Devuelve un objeto de tipo Body que contiene los datos del cuerpo celeste solicitado</returns>
    public async Task<Body> getBodyInfo(string id)
    {

      Body body = new Body();

      try
      {
        var response = await client.GetAsync(url + id);
        response.EnsureSuccessStatusCode();
        body = JsonConvert.DeserializeObject<Body>(await response.Content.ReadAsStringAsync());
      }
      catch (HttpRequestException)
      {
        Console.WriteLine("Error al procesar la petición. Es posible que el servidor tenga problemas actualmente o que el objeto seleccionado no exista. Regresando al menú principal.");
      }

      return body;

    }

    ///<summary>Obtiene todos los cuerpos celestes recogidos en la API</summary>
    ///<returns>Un objeto de tipo BodyCollection que contiene un listado con todos los cuerpos</returns>
    public async Task<BodyCollection> getBodyList()
    {
      BodyCollection bodyCollection = new BodyCollection();
      
      try
      {
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        bodyCollection = JsonConvert.DeserializeObject<BodyCollection>(await response.Content.ReadAsStringAsync());
      }
      catch (HttpRequestException)
      {
        Console.WriteLine("Error al procesar la petición. Es posible que el servidor tenga problemas actualmente o que el objeto seleccionado no exista. Regresando al menú principal.");
      }

      return bodyCollection;
    }
  }
}
