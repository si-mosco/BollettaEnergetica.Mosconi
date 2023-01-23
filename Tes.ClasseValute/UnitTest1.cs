using LibreriaMacchinaCambiaValute;

namespace TestCambiaValute
{
    public class UnitTest1
    {
        MacchinaCambiaValute m1;

        [Fact]
        public void Test1() //carica 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(12, "€");

            Assert.True(m1.Importo == 12);
        }

        [Fact]
        public void Test2() //carica 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            Assert.Throws<Exception>(() => m1.Carica(-12, "€"));
        }

        [Fact]
        public void Test3() //carica 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            Assert.Throws<Exception>(() => m1.Carica(0, "€"));
        }

        [Fact]
        public void Test4() //converti 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");
            m1.Converti("£");

            Assert.True(m1.Importo == 8.9);
        }

        [Fact]
        public void Test5() //converti 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");
            m1.Converti("£");

            Assert.True(m1.Importo != 9);
        }

        [Fact]
        public void Test6() //converti 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");
            m1.Converti("€");

            Assert.True(m1.Importo == 10);
        }

        [Fact]
        public void Test7() //disponibilita 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            Assert.True(m1.VerificaDisponibilitaValuta("€"));
        }

        [Fact]
        public void Test8() //disponibilita 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            Assert.False(m1.VerificaDisponibilitaValuta("."));
        }

        [Fact]
        public void Test9() //disponibilita 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            Assert.False(m1.VerificaDisponibilitaValuta(""));
        }

        [Fact]
        public void Test10() //eroga 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");
            m1.Eroga();

            Assert.True(m1.Importo == 0);
        }

        [Fact]
        public void Test11() //neroga 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");
            m1.Eroga();

            Assert.True(m1.ContaErogazioni == 1);
        }

        [Fact]
        public void Test12() //neroga 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            Assert.True(m1.ContaErogazioni == 0);
        }

        [Fact]
        public void Test13() //neroga 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");
            m1.Eroga();

            Assert.True(m1.ContaErogazioni == 1);
        }

        [Fact]
        public void Test14() //neroga 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");
            m1.Eroga();
            m1.Carica(10, "€");
            m1.Eroga();
            m1.Carica(10, "€");
            m1.Eroga();

            Assert.False(m1.ContaErogazioni == 2);
        }

        [Fact]
        public void Test18() //neroga 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            m1.Carica(10, "€");

            Assert.False(m1.Eroga()== "10 €");
        }

        [Fact]
        public void Test15() //clone 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");
            MacchinaCambiaValute m2;

            m2 = m1.Clone();

            Assert.True(m1.Equals(m2));
        }

        [Fact]
        public void Test16() //idunivoco 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");
            MacchinaCambiaValute m2;

            Assert.Throws<Exception>(() => m2 = new MacchinaCambiaValute("m1", "", ""));
            //non verifica se esiste già una macchina con lo stesso id
        }

        [Fact]
        public void Test17() //tostring 
        {
            m1 = new MacchinaCambiaValute("m1", "", "");

            Assert.True(m1.ToString!=null);
        }
    }
}