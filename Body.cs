using System.Text.Json.Serialization;


namespace astroSharp
{
  ///<summary>Representa un cuerpo celeste</summary>
  public class Body {

    [JsonPropertyName("id")]
    public string Id{get; set;}
  
    [JsonPropertyName("englishName")]
    public string Name {get; set;}

    [JsonPropertyName("isPlanet")]
    public bool isPlanet{get; set;}

    [JsonPropertyName("inclination")]
    public float Inclination {get; set;}

    [JsonPropertyName("density")]
    public float Density {get; set;}

    [JsonPropertyName("gravity")]
    public float Gravity{get; set;}

    [JsonPropertyName("aphelion")]
    public double Aphelion{get; set;}

    [JsonPropertyName("perihelion")]
    public double Perihelion{get; set;}

    [JsonPropertyName("sideralRotation")]
    public float SideralRotation{get; set;}

  }
}
