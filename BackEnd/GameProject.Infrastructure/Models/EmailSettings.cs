using System.ComponentModel.DataAnnotations;

namespace GameProject.Identity.Models;

public class EmailSettings
{
    [Required]
    public string Server { get; set; }
    
    [Required]
    public int Port { get; set; }
    
    [Required]
    public string SenderName { get; set; }
    
    [Required]
    public string SenderEmail { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Username { get; set; }
}