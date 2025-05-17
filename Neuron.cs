using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_6
{
    internal class Neuron
    {
        public List<double> lista_wartosci_wag = new List<double>();
        public double wartosc_wyjscia = 0;
        public double korekta_wyjscia = 0;
        public double korekta_sumy_wewa = 0;
        public List<double> lista_korekt_wag = new List<double>();
        public List<double> lista_korekt_wejsc = new List<double>();
    }
}
