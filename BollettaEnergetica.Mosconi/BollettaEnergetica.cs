using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BollettaEnergetica.Mosconi
{
    public class BollettaEnergetica
    {
        //attributi
        private string _id;
        private double _prezunita;
        private double _prezdistribuzione;
        private double _consumo;
        private double _tasse;
        private double _perctassa;

        //costruttori
        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                //controllo 6 cifre
                if (value.Length==6&& !String.IsNullOrWhiteSpace(value))
                    _id = value;
            }
        }
        public double Prezunita
        {
            get
            {
                return _prezunita;
            }
            set
            {
                _prezunita = value;
            }
        }
        public double Prezdistribuzione
        {
            get
            {
                return _prezdistribuzione;
            }
            set
            {
                _prezdistribuzione = value;
            }
        }
        public double Consumo
        {
            get
            {
                return _consumo;
            }
            set
            {
                _consumo = value;
            }
        }
        public double Tasse
        {
            get
            {
                return _tasse;
            }
            set
            {
                try
                {
                    _tasse = ((Prezdistribuzione+Prezunita)*Consumo) * Perctassa / 100;
                }
                catch
                {
                    throw new Exception("Invalid parameters");
                }
                
            }
        }
        public double Perctassa
        {
            get
            {
                return _perctassa;
            }
            set
            {
                _perctassa = value;
            }
        }

        //metodi
        public BollettaEnergetica(string id, double prezzounita, double prezzodistribuzione, double consumo, double percentualetassa)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new Exception("Invalid id");
            }
            Id = id;
            Prezunita = prezzounita;
            Prezdistribuzione = prezzodistribuzione;
            Consumo = consumo;
            Perctassa = percentualetassa;
        }

        public BollettaEnergetica(string id, double prezzounita, double prezzodistribuzione, double consumo) : this(id, prezzounita, prezzodistribuzione, consumo, -1)
        {
        }
        public BollettaEnergetica(string id, double prezzounita, double prezzodistribuzione) : this(id, prezzounita, prezzodistribuzione, -1, -1)
        {
        }
        public BollettaEnergetica() : this("vuoto1", -1, -1, -1, -1)
        {
        }

        protected BollettaEnergetica(BollettaEnergetica other) : this(other.Id, other.Prezunita, other.Prezdistribuzione, other.Consumo, other.Perctassa)
        {
        }
        public BollettaEnergetica Clone()
        {
            return new BollettaEnergetica(this);
        }

        public bool Equals(BollettaEnergetica p)
        {
            if (p == null) return false;

            if (this == p) return true;

            return (this.Id == p.Id);
        }

        public override string ToString()
        {
            return "Bolletta:" + Id + ";" + Prezunita + ";" + Prezdistribuzione + ";" + Consumo + ";" + Tasse + ";" + Perctassa;
        }

        public string CodiceGenerale()
        {
            string code = "";

            Random q = new Random(0-2);
            Random r = new Random(48-58);
            Random t = new Random(97 - 123);

            for (int i=0; i<6; i++)
            {
                char a;
                int n = q.Next();
                if (n == 0)
                {
                    int o = r.Next();
                    a = (char)o;
                }
                else
                {
                    int o = t.Next();
                    a = (char)o;
                }

                code += a;
            }

            return code;
        }

        public void Modifica(string id, double prezzounita, double prezzodistribuzione, double consumo, double percentualetassa)
        {
            Id = id;
            Prezunita = prezzounita;
            Prezdistribuzione = prezzodistribuzione;
            Consumo = consumo;
            Perctassa = percentualetassa;
        }

        public double PrezzoTot()
        {
            if (Prezdistribuzione!=-1 && Prezunita != -1 && Consumo != -1 && Tasse != -1)
                return ((Prezdistribuzione + Prezunita) * Consumo) + Tasse;
            else
                throw new Exception("Invalid parameters");
        }

        public string Confronto(BollettaEnergetica b1)
        {
            if (!this.Equals(b1))
            {
                double be1 = b1.Prezdistribuzione + b1.Prezunita + b1.Tasse;
                double be2 = this.Prezdistribuzione + this.Prezunita + this.Tasse;

                if (be1 > be2)
                    return this.ToString();
                else if (be2 < be1)
                    return b1.ToString();
                else
                    return "Uguali";
            }
            else
                throw new Exception("Invalid parameters");
        }

        public void IncrementaUnitaEnergetica(double Percentuale)
        {
            if (Percentuale>0)
                Prezunita = (Prezunita * Percentuale / 100) + Prezunita;
        }

        public void IncrementaUnitaDistribuzione(double Percentuale)
        {
            if (Percentuale > 0)
                Prezdistribuzione = (Prezdistribuzione * Percentuale / 100) + Prezdistribuzione;
        }

        public void DecrementaUnitaEnergetica(double Percentuale)
        {
            if (Percentuale < 0)
                Prezunita = Prezunita - (Prezunita * Percentuale / 100);
        }

        public void DecrementaUnitaDistribuzione(double Percentuale)
        {
            if (Percentuale < 0)
                Prezdistribuzione = Prezdistribuzione - (Prezdistribuzione * Percentuale / 100);
        }
    }
}
