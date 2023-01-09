using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set
            {
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
                _tasse = value;
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
    }
}
