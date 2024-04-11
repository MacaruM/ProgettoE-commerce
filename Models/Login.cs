using System.ComponentModel.DataAnnotations;

public class Login
{
    [Required]
    public string? NomeUtente { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}