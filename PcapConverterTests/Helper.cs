namespace PcapConverterTests;

public static class Helper
{
    public static async IAsyncEnumerable<string?> OpenSample(string filePath = "Samples/RawCapture.txt")
    {
        var streamReader = new StreamReader(filePath);
        while (!streamReader.EndOfStream)
        {
            yield return await streamReader.ReadLineAsync();
        }
    }
}