using CineAPI.Model;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations; 

public class SalaCine
{
    [SwaggerSchema(ReadOnly = true)] 
    public int Id_Sala { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Estado { get; set; } = "Activa";

    [JsonIgnore]
    public ICollection<PeliculaSalaCine> PeliculasSalas { get; set; } = new List<PeliculaSalaCine>();
}
