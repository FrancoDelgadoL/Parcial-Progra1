namespace Parcial_Delgado.Models
{
public class Jugador
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public int Edad { get; set; }
    
    public int EquipoId { get; set; }
    public Equipo? Equipo { get; set; }
}
}
