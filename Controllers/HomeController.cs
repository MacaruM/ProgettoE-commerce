using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using massimo.macaru._5i.FORMDotNetMVC.Models;
using System.Security.Cryptography;
using NuGet.Packaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace massimo.macaru._5i.FORMDotNetMVC.Controllers;


public class HomeController : Controller
{
    private readonly dbContext _context;

    public HomeController(dbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ChiSiamo()
    {
        return View();
    }

    public IActionResult Negozio()
    {
        return View();
    }

    public IActionResult Jordan()
    {
        return View();
    }

    public IActionResult Jordan1()
    {
        return View();
    }

    public IActionResult Jordan3()
    {
        return View();
    }

    public IActionResult Jordan4()
    {
        return View();
    }

    public IActionResult NewBalance()
    {
        return View();
    }

    public IActionResult Nike()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        string? nomeUtente = HttpContext.Session.GetString("NomeUtente");
        if (string.IsNullOrEmpty(nomeUtente))
            return Redirect("\\home\\SignUp");
        return View();
    }

    static string HashString(string text, string salt = "")
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        // Uses SHA256 to create the hash
        // Convert the string to a byte array first, to be processed
        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
        byte[] hashBytes = SHA256.HashData(textBytes);

        // Convert back to a string, removing the '-' that BitConverter adds
        string hash = BitConverter
            .ToString(hashBytes)
            .Replace("-", String.Empty);

        return hash;
    }

    [HttpPost]
    public IActionResult SignUp(Registrazione model)
    {
        if (ModelState.IsValid)
        {
            // Crea il nuovo utente in base al modello
            Utente nuovoUtente = new()
            {
                Nome = model.Nome,
                Cognome = model.Cognome,
                NomeUtente = model.NomeUtente,
                Email = model.Email,
                DataNascita = model.DataNascita,
                Sesso = model.Sesso,
                Password = HashString(model.Password!)
            };

            // Aggiungi il nuovo utente al database utilizzando il contesto
            _context.Utente.Add(nuovoUtente);
            _context.SaveChanges();

            // Aggiungi utente nelle variabili di sessione
            HttpContext.Session.SetString("UtenteId", nuovoUtente.UtenteId.ToString());
            HttpContext.Session.SetString("NomeUtente", nuovoUtente.NomeUtente!);

            // Reindirizza l'utente alla pagina di login o ad un'altra pagina di destinazione
            return RedirectToAction("Index");
        }

        // Se il modello non è valido, torna alla pagina di registrazione con gli errori di validazione
        return View(model);
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(Login model)
    {
        var utente = _context.Utente.FirstOrDefault(utente => utente.NomeUtente == model.NomeUtente && utente.Password == HashString(model.Password!, ""));
        if (utente != null)
        {
            HttpContext.Session.SetString("UtenteId", utente.UtenteId.ToString());
            HttpContext.Session.SetString("NomeUtente", utente.NomeUtente!);

            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.SetString("UtenteId", "");
        HttpContext.Session.SetString("NomeUtente", "");

        return RedirectToAction("Index");
    }

    public IActionResult Cart()
    {
        string? idUtente = HttpContext.Session.GetString("UtenteId");
        if (string.IsNullOrEmpty(idUtente)) return RedirectToAction("SignIn");

        var utente = _context.Utente
        .Include(utente => utente.Carrellos)
        .First(utente => utente.UtenteId == Convert.ToInt32(idUtente));

        return View(utente.Carrellos);
    }

    [HttpPost]
    public IActionResult AddToCart(Carrello model)
    {
        string? idUtente = HttpContext.Session.GetString("UtenteId");
        if (string.IsNullOrEmpty(idUtente))
            return RedirectToAction("SignIn");

        model.UtenteId = Convert.ToInt32(idUtente);

        var utente = _context.Utente
        .Include(utente => utente.Carrellos)
        .First(utente => utente.UtenteId == Convert.ToInt32(idUtente));

        if (utente.Carrellos.Any(carr => carr.Articolo == model.Articolo))
        {
            var carrello = utente.Carrellos.First(carr => carr.Articolo == model.Articolo);
            carrello.Quantita += 1;
        }
        else
        {
            model.Quantita = 1;
            _context.Carrello.Add(model);
        }

        _context.SaveChanges();

        return RedirectToAction("Cart");
    }

    [HttpPost]
    public IActionResult Remove(int carrelloId)
    {
        var item = _context.Carrello.FirstOrDefault(carr => carr.CarrelloId == carrelloId);
        if (item == null)
        {
            return NotFound(); // Handle case where item is not found
        }

        _context.Carrello.Remove(item); // remove item
        _context.SaveChanges();

        return RedirectToAction("Cart"); // Redirect back to the Cart page (or appropriate view)
    }

    public IActionResult Order()
    {
        string? idUtente = HttpContext.Session.GetString("UtenteId");
        if (string.IsNullOrEmpty(idUtente))
            return RedirectToAction("SignIn");

        var utente = _context.Utente
        .Include(utente => utente.Carrellos)
        .First(utente => utente.UtenteId == Convert.ToInt32(idUtente));

        utente.Carrellos = new List<Carrello>(); // remove everything
        _context.SaveChanges();

        return RedirectToAction("Cart"); // Redirect back to the Cart page (or appropriate view)
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
