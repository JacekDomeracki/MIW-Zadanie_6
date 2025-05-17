using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_6
{
    internal class Siec_neuronowa           //warstwa nr 0 to wejścia sieci, waga nr 0 to bias neuronu
    {
        private List<Neuron>[] warstwy_neurony;

        public Siec_neuronowa(int[] licznosc_warstw)
        {
            warstwy_neurony = new List<Neuron>[licznosc_warstw.Length];
            for (int i = 0; i < licznosc_warstw.Length; i++)
            {
                warstwy_neurony[i] = new List<Neuron>();
                for (int j = 0; j < licznosc_warstw[i]; j++)
                {
                    warstwy_neurony[i].Add(new Neuron());
                    if (i == 0)
                        continue;
                    for (int k = 0; k < licznosc_warstw[i - 1] + 1; k++)        //tyle wag neuronu warstwy i, ile neuronów warstwy i-1, plus bias
                    {
                        warstwy_neurony[i][j].lista_wartosci_wag.Add(0);
                        warstwy_neurony[i][j].lista_korekt_wag.Add(0);
                        if (i == 1)
                            continue;
                        warstwy_neurony[i][j].lista_korekt_wejsc.Add(0);
                    }
                }
            }
        }

        public void Ustaw_losowe_wartosci_wag(double przedz_min, double przedz_max)
        {
            Random random = new Random();
            for (int i = 1; i < warstwy_neurony.Length; i++)
            {
                for (int j = 0; j < warstwy_neurony[i].Count; j++)
                {
                    for (int k = 0; k < warstwy_neurony[i][j].lista_wartosci_wag.Count; k++)
                    {
                        warstwy_neurony[i][j].lista_wartosci_wag[k] = random.NextDouble() * (przedz_max - przedz_min) + przedz_min;
                    }
                }
            }
        }

        private double Funkcja_aktywacji(double beta, double wartosc_bez_fa)
        {
            return 1 / (1 + Math.Exp(-beta * wartosc_bez_fa));
        }

        public void Oblicz_wyjscie_sieci_neuronowej(List<double> wej_probka, double beta, ref List<double> wartosc_wyjscia_sieci)
        {
            for (int i = 0; i < wej_probka.Count; i++)
            {
                warstwy_neurony[0][i].wartosc_wyjscia = wej_probka[i];
            }

            for (int i = 1; i < warstwy_neurony.Length; i++)
            {
                for (int j = 0; j < warstwy_neurony[i].Count; j++)
                {
                    double sum_wart_wyj = warstwy_neurony[i][j].lista_wartosci_wag[0];
                    for (int k = 1; k < warstwy_neurony[i][j].lista_wartosci_wag.Count; k++)
                    {
                        sum_wart_wyj += warstwy_neurony[i - 1][k - 1].wartosc_wyjscia * warstwy_neurony[i][j].lista_wartosci_wag[k];
                    }
                    warstwy_neurony[i][j].wartosc_wyjscia = Funkcja_aktywacji(beta, sum_wart_wyj);
                }
            }
            for (int i = 0; i < wartosc_wyjscia_sieci.Count; i++)
            {
                wartosc_wyjscia_sieci[i] = warstwy_neurony[warstwy_neurony.Length - 1][i].wartosc_wyjscia;

            }
        }

        public void Propaguj_wstecznie_korekty(List<double> wyj_probka, double beta, double mi)
        {
            for (int i = 0; i < wyj_probka.Count; i++)
            {
                warstwy_neurony[warstwy_neurony.Length - 1][i].korekta_wyjscia = mi * (wyj_probka[i] - warstwy_neurony[warstwy_neurony.Length - 1][i].wartosc_wyjscia);
            }

            for (int i = warstwy_neurony.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < warstwy_neurony[i].Count; j++)
                {
                    warstwy_neurony[i][j].korekta_sumy_wewa = warstwy_neurony[i][j].korekta_wyjscia
                                                    * beta * warstwy_neurony[i][j].wartosc_wyjscia * (1 - warstwy_neurony[i][j].wartosc_wyjscia);

                    warstwy_neurony[i][j].lista_korekt_wag[0] = warstwy_neurony[i][j].korekta_sumy_wewa * 1;
                    for (int k = 1; k < warstwy_neurony[i][j].lista_korekt_wag.Count; k++)
                    {
                        warstwy_neurony[i][j].lista_korekt_wag[k] = warstwy_neurony[i][j].korekta_sumy_wewa * warstwy_neurony[i - 1][k - 1].wartosc_wyjscia;
                    }
                    if (i == 1)
                        continue;
                    for (int k = 1; k < warstwy_neurony[i][j].lista_korekt_wejsc.Count; k++)
                    {
                        warstwy_neurony[i][j].lista_korekt_wejsc[k] = warstwy_neurony[i][j].korekta_sumy_wewa * warstwy_neurony[i][j].lista_wartosci_wag[k];
                    }
                }
                if (i == 1)
                    continue;
                for (int j = 0; j < warstwy_neurony[i - 1].Count; j++)
                {
                    warstwy_neurony[i - 1][j].korekta_wyjscia = 0;
                    for (int k = 0; k < warstwy_neurony[i].Count; k++)
                    {
                        warstwy_neurony[i - 1][j].korekta_wyjscia += warstwy_neurony[i][k].lista_korekt_wejsc[j + 1];
                    }
                }
            }
            for (int i = 1; i < warstwy_neurony.Length; i++)            //korekta wszystkich wag sieci
            {
                for (int j = 0; j < warstwy_neurony[i].Count; j++)
                {
                    for (int k = 0; k < warstwy_neurony[i][j].lista_korekt_wag.Count; k++)
                    {
                        warstwy_neurony[i][j].lista_wartosci_wag[k] += warstwy_neurony[i][j].lista_korekt_wag[k];
                    }
                }
            }
        }

        public void Wypisz_wagi_strukturalnie(ref TextBox textBox)
        {
            textBox.AppendText("--------------------------------------------------" + Environment.NewLine);
            for (int i = 1; i < warstwy_neurony.Length; i++)
            {
                textBox.AppendText(String.Format("WARSTWA NR : {0}", i) + Environment.NewLine);
                for (int j = 0; j < warstwy_neurony[i].Count; j++)
                {
                    textBox.AppendText(String.Format("      NEURON NR : {0}", j) + Environment.NewLine);
                    for (int k = 0; k < warstwy_neurony[i][j].lista_wartosci_wag.Count; k++)
                    {
                        textBox.AppendText(String.Format("            WAGA NR : {0}  |  WAGA : {1,10:F6}",
                            k, warstwy_neurony[i][j].lista_wartosci_wag[k]) + Environment.NewLine);
                    }
                }
            }
            textBox.AppendText("--------------------------------------------------" + Environment.NewLine);
        }
    }
}
