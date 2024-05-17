using SolitarioMahjong;

namespace TestSolitarioMahjong
{
    [TestClass]
    public class TestGiocatore
    {
        [TestMethod]
        public void Giocatore_Nome_NonAccettabile()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { new Giocatore(null); });
        }
    }
}