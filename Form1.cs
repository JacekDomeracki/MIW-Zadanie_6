///algorytm wstecznej propagacji 3 (Sumator) | Jacek Domeracki | numer albumu: 173518

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadanie_6
{
    public partial class Form1 : Form
    {
        static readonly int[] SCHEMAT_SIECI_NEURONOWEJ = { 3, 3, 2, 2 };
        const double PRZEDZ_MIN = -5;
        const double PRZEDZ_MAX = 5;
        const int ILE_WID_GD = 200;         //ile widocznych iteracji z góry i z do³u
        const int CO_ILE_LICZ = 10000;      //co ile iteracji pokazywaæ licznik

        //wartoœci domyœlne
        int ILE_ITERACJE = 50000;
        double BETA = 1;
        double MI = 0.3;
        double MARGINES_BLEDU = 0.4;

        List<Tuple<List<double>, List<double>>> Probki_funkcji_wejwyj = new List<Tuple<List<double>, List<double>>>
            {
                new Tuple<List<double>, List<double>> ( new List<double> { 0, 0, 0 }, new List<double> { 0, 0 } ),
                new Tuple<List<double>, List<double>> ( new List<double> { 0, 1, 0 }, new List<double> { 1, 0 } ),
                new Tuple<List<double>, List<double>> ( new List<double> { 1, 0, 0 }, new List<double> { 1, 0 } ),
                new Tuple<List<double>, List<double>> ( new List<double> { 1, 1, 0 }, new List<double> { 0, 1 } ),
                new Tuple<List<double>, List<double>> ( new List<double> { 0, 0, 1 }, new List<double> { 1, 0 } ),
                new Tuple<List<double>, List<double>> ( new List<double> { 0, 1, 1 }, new List<double> { 0, 1 } ),
                new Tuple<List<double>, List<double>> ( new List<double> { 1, 0, 1 }, new List<double> { 0, 1 } ),
                new Tuple<List<double>, List<double>> ( new List<double> { 1, 1, 1 }, new List<double> { 1, 1 } )
            };
        Tuple<List<double>, List<double>> probka_rob;

        Siec_neuronowa SN = new Siec_neuronowa(SCHEMAT_SIECI_NEURONOWEJ);

        Random random = new Random();
        List<int> indeksy_probek = new List<int>();
        int n_pr;

        List<double> wartosc_wyjscia_SN;
        List<double> nowa_wartosc_wyjscia_SN;
        List<double> blizej_do_probki_wyj;

        StringBuilder buforTekstu = new StringBuilder();

        public Form1()
        {
            InitializeComponent();

            probka_rob = Probki_funkcji_wejwyj[0];
            wartosc_wyjscia_SN = new List<double>(Probki_funkcji_wejwyj[0].Item2);             //musz¹ byæ zainicjowane
            nowa_wartosc_wyjscia_SN = new List<double>(Probki_funkcji_wejwyj[0].Item2);
            blizej_do_probki_wyj = new List<double>(Probki_funkcji_wejwyj[0].Item2);

            textBoxParBeta.Text = BETA.ToString();
            textBoxParMi.Text = MI.ToString();
            textBoxLiczEpok.Text = ILE_ITERACJE.ToString();
            textBoxMarBledu.Text = MARGINES_BLEDU.ToString();

            ButtonReset_Click(null, null);
        }

        private void ButtonReset_Click(object? sender, EventArgs? e)
        {
            buttonReset.Visible = false;

            textBoxEkran.Text = "ALGORYTM WSTECZNEJ PROPAGACJI ( ZADANIE 3 : SUMATOR )" + Environment.NewLine + Environment.NewLine;
            textBoxLicznik.Text = 0.ToString();

            textBoxParBeta.Enabled = true;
            textBoxParMi.Enabled = true;
            textBoxLiczEpok.Enabled = true;
            textBoxMarBledu.Enabled = true;

            buttonStart.Enabled = true;
            buttonStart.Focus();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;

            textBoxParBeta.Enabled = false;
            textBoxParMi.Enabled = false;
            textBoxLiczEpok.Enabled = false;
            textBoxMarBledu.Enabled = false;

            BETA = double.Parse(textBoxParBeta.Text);
            MI = double.Parse(textBoxParMi.Text);
            ILE_ITERACJE = int.Parse(textBoxLiczEpok.Text);
            MARGINES_BLEDU = double.Parse(textBoxMarBledu.Text);

            SN.Ustaw_losowe_wartosci_wag(PRZEDZ_MIN, PRZEDZ_MAX);

            textBoxEkran.AppendText("-->  START" + Environment.NewLine + Environment.NewLine);
            buforTekstu.Clear();

            for (int i = 0; i < ILE_ITERACJE; i++)
            {
                if (i < ILE_WID_GD || i >= ILE_ITERACJE - ILE_WID_GD)
                    buforTekstu.AppendLine(String.Format("-->  EPOKA NR : {0}", i + 1));

                for (int j = 0; j < Probki_funkcji_wejwyj.Count; j++)
                {
                    indeksy_probek.Add(j);
                }
                for (int j = 0; j < Probki_funkcji_wejwyj.Count; j++)
                {
                    n_pr = indeksy_probek[random.Next(indeksy_probek.Count)];
                    indeksy_probek.Remove(n_pr);

                    probka_rob = Probki_funkcji_wejwyj[n_pr];
                    SN.Oblicz_wyjscie_sieci_neuronowej(probka_rob.Item1, BETA, ref wartosc_wyjscia_SN);

                    SN.Propaguj_wstecznie_korekty(probka_rob.Item2, BETA, MI);
                    SN.Oblicz_wyjscie_sieci_neuronowej(probka_rob.Item1, BETA, ref nowa_wartosc_wyjscia_SN);

                    for (int k = 0; k < probka_rob.Item2.Count; k++)
                    {
                        blizej_do_probki_wyj[k] = Math.Abs(probka_rob.Item2[k] - wartosc_wyjscia_SN[k]) - Math.Abs(probka_rob.Item2[k] - nowa_wartosc_wyjscia_SN[k]);
                    }

                    if (i < ILE_WID_GD || i >= ILE_ITERACJE - ILE_WID_GD)
                    {
                        for (int k = 0; k < probka_rob.Item2.Count; k++)
                        {
                            buforTekstu.AppendLine(String.Format("------>  PRÓBKA NR : {0}  |  NOWE WYJŒCIE : {1,8:F6}  |  UBYTEK B£ÊDU : {2,12:F10}  |  NOWY B£¥D: {3,9:F6}",
                            n_pr + 1, nowa_wartosc_wyjscia_SN[k], blizej_do_probki_wyj[k], probka_rob.Item2[k] - nowa_wartosc_wyjscia_SN[k]));
                        }
                    }
                }
                if (i < ILE_WID_GD || i >= ILE_ITERACJE - ILE_WID_GD) buforTekstu.AppendLine();

                if ((i + 1) % CO_ILE_LICZ == 0)
                {
                    textBoxLicznik.Text = (i + 1).ToString("#,##0");
                    Application.DoEvents();
                }
            }
            textBoxEkran.AppendText(buforTekstu.ToString());

            n_pr = 0;
            foreach (var probka in Probki_funkcji_wejwyj)
            {
                SN.Oblicz_wyjscie_sieci_neuronowej(probka.Item1, BETA, ref wartosc_wyjscia_SN);

                for (int i = 0; i < probka.Item2.Count; i++)
                {
                    if (Math.Abs(probka.Item2[i] - wartosc_wyjscia_SN[i]) >= MARGINES_BLEDU)
                    {
                        n_pr++;
                    }
                }
            }
            textBoxEkran.AppendText(String.Format("---------->  MARGINES B£ÊDU : {0,6:F4}", MARGINES_BLEDU) + Environment.NewLine);
            if (n_pr == 0)
            {
                textBoxEkran.AppendText("---------->  SPE£NIONY" + Environment.NewLine);
                SN.Wypisz_wagi_strukturalnie(ref textBoxEkran);
            }
            else
            {
                textBoxEkran.AppendText(String.Format("/\\/\\------>  NIESPE£NIONY : {0} -KROTNIE", n_pr) + Environment.NewLine);
            }

            textBoxEkran.AppendText(Environment.NewLine + "-->  KONIEC" + Environment.NewLine);
            textBoxLicznik.Text = ILE_ITERACJE.ToString("#,##0");

            buttonReset.Visible = true;
            buttonReset.Focus();
        }

        private void textBoxParBeta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!double.TryParse(textBoxParBeta.Text, out double liczba) || liczba <= 0)
            {
                MessageBox.Show("Wpisz liczbê rzeczywist¹ > 0");
                e.Cancel = true;
            }
        }

        private void textBoxParMi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!double.TryParse(textBoxParMi.Text, out double liczba) || liczba <= 0 || liczba >= 1)
            {
                MessageBox.Show("Wpisz liczbê rzeczywist¹ > 0 oraz < 1");
                e.Cancel = true;
            }
        }

        private void textBoxLiczEpok_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(textBoxLiczEpok.Text, out int liczba) || liczba < 1 || liczba > 2000000)
            {
                MessageBox.Show("Wpisz liczbê ca³kowit¹ >= 1 oraz <= 2000000");
                e.Cancel = true;
            }
        }

        private void textBoxMarBledu_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!double.TryParse(textBoxMarBledu.Text, out double liczba) || liczba <= 0 || liczba >= 1)
            {
                MessageBox.Show("Wpisz liczbê rzeczywist¹ > 0 oraz < 1");
                e.Cancel = true;
            }
        }
    }
}
