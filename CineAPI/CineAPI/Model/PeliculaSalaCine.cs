using System.Text.Json.Serialization;

public class PeliculaSalaCine
{
    public int Id_Pelicula_Sala { get; set; }

    public int Id_Pelicula { get; set; }
    public int Id_Sala_Cine { get; set; }

    public DateTime Fecha_Publicacion { get; set; }
    public DateTime Fecha_Fin { get; set; }

    [JsonIgnore]
    public Pelicula? Pelicula { get; set; }

    [JsonIgnore]
    public SalaCine? SalaCine { get; set; }
}
