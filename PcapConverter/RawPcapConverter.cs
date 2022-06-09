using System.Text;

namespace PcapConverter;

public class RawPcapConverter
{
    public RawPcapConverter()
    {
        
    }

    public DataPacket? ConvertToPcap(string? rawData)
    {
        var stringBuilder = new StringBuilder();
        if (rawData is null)
        {
            return null;
        }

        var data = rawData.Split("  ", StringSplitOptions.RemoveEmptyEntries);
        var dateStringSplit = data.First().Split(' ');
        var time = TimeOnly.Parse(dateStringSplit.Last());
        var date = DateOnly.Parse($"{dateStringSplit[0]} {dateStringSplit[1]}");

        var packetData = StringToByteArray(data.Last()).ToArray();
        
        return new DataPacket()
        {
            DateCaptured = date.ToDateTime(time),
            CapturedPacketLength = packetData.Length,
            OriginalPacketLength = packetData.Length,
            PacketData = packetData
        };
    }
    
    public static IEnumerable<byte> StringToByteArray(string hex) {
        return hex.Split(' ')
            .Where(x => x.Length % 2 == 0)
            .Select(x => Convert.ToByte(x, 16))
            .ToArray();
    }
}

