using SolitarioMahjong;

namespace TestSolitarioMahjong
{
    [TestClass]
    public class TestCarta
    {
        [TestMethod]
        public void Carta_ValoreCarta_NonAccettabile_MinoreDiUno()
        {
            Assert.ThrowsException<ArgumentException>(() => { new Carta((Valore)(-1), (Seme)1); });
        }

        [TestMethod]
        public void Carta_ValoreCarta_NonAccettabile_MaggioreDiDieci()
        {
            Assert.ThrowsException<ArgumentException>(() => { new Carta((Valore)(11), (Seme)1); });
        }

        [TestMethod]
        public void Carta_SemeCarta_NonAccettabile_MinoreDiUno()
        {
            Assert.ThrowsException<ArgumentException>(() => { new Carta((Valore)1, (Seme)(-1)); });
        }

        [TestMethod]
        public void Carta_SemeCarta_NonAccettabile_MaggioreDiQuattro()
        {
            Assert.ThrowsException<ArgumentException>(() => { new Carta((Valore)1, (Seme)5); });
        }

        [TestMethod]
        public void Carta_Equals_False()
        {
            Carta carta1 = new Carta((Valore)3, (Seme)2);
            Carta carta2 = new Carta((Valore)4, (Seme)2);
            Assert.IsFalse(carta1.Equals(carta2));
        }

        [TestMethod]
        public void Carta_Equals_True()
        {
            Carta carta1 = new Carta((Valore)3, (Seme)2);
            Carta carta2 = new Carta((Valore)3, (Seme)4);
            Assert.IsTrue(carta1.Equals(carta2));
        }
    }
}
