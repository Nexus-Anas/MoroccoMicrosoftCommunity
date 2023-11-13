namespace MMC.Core.Models;

public class Participant
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Mail { get; set; }
    public required string Phone { get; set; }
    public string? Company { get; set; }
    public char Gender { get; set; }
    public required string Message { get; set; }
}
