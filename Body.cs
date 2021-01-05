using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace astroSharp
{
  ///<summary>Representa un cuerpo celeste</summary>
  public class Body
  {

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("englishName")]
    public string Name { get; set; }

    [JsonPropertyName("isPlanet")]
    public bool isPlanet { get; set; }

    [JsonPropertyName("moons")]
    public List<Moon> Moons { get; set; }

    [JsonPropertyName("aroundPlanet")]
    public AroundPlanet AroundPlanet { get; set; }

    [JsonPropertyName("semimajorAxis")]
    public double SemiMajorAxis { get; set; }

    [JsonPropertyName("polarRadius")]
    public double PolarRadius { get; set; }

    [JsonPropertyName("equaRadius")]
    public bool EquatorialRadius { get; set; }

    [JsonPropertyName("density")]
    public float Density { get; set; }

    [JsonPropertyName("gravity")]
    public float Gravity { get; set; }

    [JsonPropertyName("aphelion")]
    public double Aphelion { get; set; }

    [JsonPropertyName("perihelion")]
    public double Perihelion { get; set; }

    [JsonPropertyName("eccentricity")]
    public float Eccentricity { get; set; }

    [JsonPropertyName("inclination")]
    public float Inclination { get; set; }

    [JsonPropertyName("sideralOrbit")]
    public float SideralOrbit { get; set; }

    [JsonPropertyName("sideralRotation")]
    public float SideralRotation { get; set; }

  }

  public class Moon
  {
    public string moon { get; set; }
    public string rel { get; set; }
  }

  public class AroundPlanet
  {
    public string planet { get; set; }
    public string rel { get; set; }
  }
}
