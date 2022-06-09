using PcapConverter;

namespace PcapConverterTests;

[TestClass]
public class PcapConverterTests
{
    private readonly RawPcapConverter _pcapConverter = new();

    [TestClass]
    public class ValueConverter : PcapConverterTests
    {
        private DataPacket? _pcap;

        [TestInitialize]
        public void ConvertPacket()
        {
            var packet =
                @"Jun 07 23:46:12.788  L2CAP Send       0x0044  F4:BE:EC:C2:2C:11  Channel ID: 0x6612  Length: 0x0006 (06) [ 03 04 1A 1B 00 00 ]  44 00 0A 00 06 00 12 66 03 04 1A 1B 00 00  ";
            _pcap = _pcapConverter.ConvertToPcap(packet);
        }

        [TestMethod]
        public void ValidDate_ShouldSucceed()
        {
            var expectedDate = new DateTime(2022, 06, 07, 23, 46, 12, 788);
            Assert.IsNotNull(_pcap);
            Assert.AreEqual(expectedDate, _pcap.DateCaptured);
        }

        [TestMethod]
        public void ValidPackets_ShouldSucceed()
        {
            Assert.IsNotNull(_pcap);
            //44 00 0A 00 06 00 12 66 03 04 1A 1B 00 00 
            var expectedBytes = new byte[] { 0x44, 0x00, 0x0A, 0x00, 0x06, 0x00, 0x12, 0x66, 0x03, 0x04, 0x1A, 0x1B, 0x00, 0x00 };
            CollectionAssert.AreEqual(expectedBytes, _pcap.PacketData.ToArray());
        }

        [TestMethod]
        public void ValidLength_ShouldSucceed()
        {
            Assert.IsNotNull(_pcap);
            Assert.AreEqual(14, _pcap.CapturedPacketLength);
            Assert.AreEqual(14, _pcap.OriginalPacketLength);
        }
    }
}