namespace Parcial_Delgado.Models
{
public class Equipo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public List<Jugador> Jugadores { get; set; } = new();
}
}