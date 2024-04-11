using System.ComponentModel.DataAnnotations;

public class Utente {
    public int UtenteId { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public string? NomeUtente { get; set; }
    public string? Email { get; set; }
    public string? Sesso { get; set; }
    public DateOnly DataNascita { get; set; }
    public string? Password { get; set; }

    public virtual ICollection<Carrello> Carrellos { get; set; } = new List<Carrello>();
}
  