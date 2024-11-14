public class NuomosUzsakymas
{
    public int Id { get; set; }
    public int KlientoId { get; set; }
    public int AutomobilioId { get; set; }
    public DateTime NuomosPradžia { get; set; }
    public DateTime NuomosPabaiga { get; set; }

    public Klientas Klientas { get; set; } // Navigacijos savybė
    public Automobilis Automobilis { get; set; } // Navigacijos savybė
}