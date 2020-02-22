namespace REvernus.Models.Interfaces
{
    public interface IStation
    {
        long StationId { get; }
        string StationName { get; }
        long SolarSystemId { get; }
        long StationTypeId { get; }
    }
}
