using CineAPI.Model;
using System.Text.Json.Serialization;

public class Pelicula
{
    public int Id_Pelicula { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Duracion { get; set; }

    [JsonIgnore]
    public List<PeliculaSalaCine> PeliculasSalas { get; set; } = new();
}
