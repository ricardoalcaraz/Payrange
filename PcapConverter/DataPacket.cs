namespace PcapConverter;

public record DataPacket
{
    public DateTime DateCaptured { get; init; }
    public int CapturedPacketLength { get; init; }
    public int OriginalPacketLength { get; init; }
    public IEnumerable<byte> PacketData { get; init; } = Enumerable.Empty<byte>();
}

public static class PCapReference
{
}

public enum LinkType : short
{
    PerPacketInformation = 192,
    BleWithPhdr = 256,
    NordicBle = 272
}