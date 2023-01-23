using Energia;

namespace Borelli_TestBolletteMosconi {
    public class UnitTest1 {

        [Fact]
        public void CostruttoreEccezioni() {
            BollettaEnergetica b2;
            Assert.Throws<Exception>(() => (b2 = new BollettaEnergetica("ID", 8.5, 9, 30, 5)));
        }

        [Fact]
        public void CostruttoreEccezioniPositivi() {
            BollettaEnergetica b2;
            Assert.Throws<Exception>(() => (b2 = new BollettaEnergetica("ID0000", -8.5, -9, 30, -5)));
        }

        [Fact]
        public void CostruttoreEccezioniSpaziVuoti() {
            BollettaEnergetica b2;
            Assert.Throws<Exception>(() => (b2 = new BollettaEnergetica("", -8.5, -9, 30, -5)));
        }

        [Fact]
        public void CodiceGenerale() {
            BollettaEnergetica b2 = new BollettaEnergetica();
            string cod1 = b2.CodiceGenerale();
            string cod2 = b2.CodiceGenerale();

            Assert.True(cod1 != cod2);
        }

        [Fact]
        public void CalcoloTasse() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.True(b2.Tasse == ((5 + 10) * 20));
        }

        [Fact]
        public void CalcoloPrezzoTot() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.True(b2.PrezzoTot() == (((5 + 10) * 20)) * 2);
        }

        [Fact]
        public void TestIncrementaUnEnergetica() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.IncrementaUnitaEnergetica(100);
            Assert.True(b2.Prezunita == 5 * 2);
        }

        [Fact]
        public void TestIncrementaDistr() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.IncrementaUnitaDistribuzione(100);
            Assert.True(b2.Prezdistribuzione == 10 * 2);
        }

        [Fact]
        public void ConfrontaBolletteConStessaBolletta() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.Throws<Exception>(() => b2.Confronto(b2));
        }

        [Fact]
        public void ConfrontaBollette() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            BollettaEnergetica b1 = new BollettaEnergetica("234567", 10, 20, 40, 100);
            string uwu = b2.Confronto(b1);
            string uwuB2 = b2.ToString();

            Assert.True(uwuB2 == uwu);
        }

        [Fact]
        public void EqualsDiClone() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            BollettaEnergetica b1 = b2.Clone();

            Assert.True(b1.Equals(b2));
        }

        [Fact]
        public void TestDecrementaDistr() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.DecrementaUnitaDistribuzione(-100);
            Assert.True(b2.Prezdistribuzione == 0);
        }

        [Fact]
        public void TestModifica() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.Modifica("456789", 10, 20, 40, 50);
            Assert.True(b2.Id == "456789");
        }

        [Fact]
        public void TestToString() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.True(b2.ToString() == $"Bolletta:{b2.Id};{b2.Prezunita};{b2.Prezdistribuzione};{b2.Consumo};300;{b2.Perctassa}"); //è 300 perchè ho fatto io il calcolo di default darebbe 0 ed è sbagliato
        }

        [Fact]
        public void TestClone() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            BollettaEnergetica b1 = b2.Clone();

            Assert.True(b1 != null);
        }
    }
}