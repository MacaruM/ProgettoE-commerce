using System.ComponentModel.DataAnnotations;

public class Registrazione
{
    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Cognome { get; set; }

    [Required]
    public string? NomeUtente { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    public string? Sesso { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly DataNascita { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}