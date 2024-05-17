using SolitarioMahjong;

namespace TestSolitarioMahjong
{
    [TestClass]
    public class TestMazzetto
    {
        [TestMethod]
        public void Mazzetto_ContaCarteMazzetto()
        {
            Mazzetto mazzetto = new Mazzetto();
            Carta carta1 = new Carta((Valore)3, (Seme)2);
            Carta carta2 = new Carta((Valore)3, (Seme)4);
            mazzetto.AggiungiCarta(carta1);
            mazzetto.AggiungiCarta(carta2);
            Assert.AreEqual(2, mazzetto.ContaCarteMazzetto());
        }

        [TestMethod]
        public void Mazzetto_AggiungiCarta()
        {
            Mazzetto mazzetto = new Mazzetto();
            Carta carta1 = new Carta((Valore)3, (Seme)2);
            mazzetto.AggiungiCarta(carta1);
            Assert.AreEqual(1, mazzetto.ContaCarteMazzetto());
        }

        [TestMethod]
        public void Mazzetto_RimuoviCarta()
        {
            Mazzetto mazzetto = new Mazzetto();
            Carta carta1 = new Carta((Valore)3, (Seme)2);
            Carta carta2 = new Carta((Valore)3, (Seme)4);
            mazzetto.AggiungiCarta(carta1);
            mazzetto.AggiungiCarta(carta2);
            mazzetto.RimuoviCarta(carta1);
            Assert.AreEqual(1, mazzetto.ContaCarteMazzetto());
        }
    }
}