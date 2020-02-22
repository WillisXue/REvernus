namespace REvernus.Models.Interfaces
{
    internal interface IStation
    {
        long StationId { get; }
        string StationName { get; }
        int SolarSystemId { get; }
        long StationTypeId { get; }
        bool IsPublic { get; }
    }
}
