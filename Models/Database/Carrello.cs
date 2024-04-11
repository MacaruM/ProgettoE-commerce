using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Carrello {
    public int CarrelloId { get; set; }
    public string? Articolo { get; set; }
    public int Quantita { get; set; }
    public double Prezzo { get; set; }
    public string? Immagine { get; set; }

    [ForeignKey("Utente")]
    public int UtenteId { get; set; }
}