namespace JsonTester.Models;

public class ConnectionPreset
{
    public required string Name { get; set; }
    public required  string Addr { get; set; }
    public required  ConnectionType ConnectionType { get; set; }
}