namespace REvernus.Models.Interfaces
{
    internal interface IStation
    {
        long StationId { get; }
        string StationName { get; }
        long SolarSystemId { get; }
        long StationTypeId { get; }
    }
}
