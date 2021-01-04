using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace astroSharp
{
  ///<summary>Representa una colección de cuerpos celestes</summary>
  public class BodyCollection
  {
    [JsonPropertyName("bodies")]
    public List<Body> Bodies { get; set; }
  }

}
