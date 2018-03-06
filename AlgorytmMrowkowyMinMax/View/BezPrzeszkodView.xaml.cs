using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlgorytmMrowkowyMinMax.ViewModel;
using AlgorytmMrowkowyMinMax.Model;

namespace AlgorytmMrowkowyMinMax.View
{
    /// <summary>
    /// Logika interakcji dla klasy BezPrzeszkodView.xaml
    /// </summary>
    public partial class BezPrzeszkodView : UserControl
    {
        public BezPrzeszkodView()
        {
            InitializeComponent();
            wspolrzedne_wierzcholkow = BPVM.WyznaczWspolrzedneWierzcholkow(0, 0);
            RysujGraf();

        }
        int liczbaMrowek = 10;
        int numerIteracji = 0;

       

        int[] trasa = new int[100];
        int[] najlepszaWIteracjiTrasa = new int[100];
        int[] najlepszaGlobalnieTrasa = new int[100];
        int dlugoscTrasy;
        int najlepszaMrowka;
        
        int dlugoscNajlepszejWIteracjiTrasy = 0;
        int dlugoscNajlepszeGlobalnieTrasy = 1000; 
        Graf graf = new Graf();
        BezPrzeszkodViewModel BPVM = new BezPrzeszkodViewModel();
        int poczatek = 0;
        int koniec = 0;
        int liczbaIteracji = 100;
        double alfa = 1;
        double beta = 1;
        double ρ = 1;
        double wspolczynnikModyfikacji = 0.8;
        bool flagaKoniec = false;
        bool flagaPoczatek = false;
        Point[] wspolrzedne_wierzcholkow = new Point[100];
       
      



        public void RysujGraf()
        {
            //rysuj krawedzie grafu
            for (int i = 0; i < wspolrzedne_wierzcholkow.Length; i++)
            {
                for (int j = 0; j < wspolrzedne_wierzcholkow.Length; j++)
                {
                    if (BPVM.krawedzie[i, j] != 1000)
                    {
                        polenagraf.Children.Add(graf.Rysuj_krawedz(0, wspolrzedne_wierzcholkow[j].X, wspolrzedne_wierzcholkow[j].Y, wspolrzedne_wierzcholkow[i].X, wspolrzedne_wierzcholkow[i].Y));
                    }
                }
            }
            //rysuj wierzcholki grafu
            for (int i = 0; i < 100; i++)
            {
                polenagraf.Children.Add(graf.Rysuj_wierzcholek(0, wspolrzedne_wierzcholkow[i].X, wspolrzedne_wierzcholkow[i].Y));
            }

        }



        private void TextBoxPoczatek_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxPoczatek.Text != String.Empty)
            {
                try
                {
                    poczatek = Int32.Parse(TextBoxPoczatek.Text) - 1; //zmniejszenie o 1 by wyszukiwać odpowiedni indeks w tablicy

                    if (poczatek >= 0 && poczatek <= 100)
                    {
                        flagaPoczatek = true;
                    }
                    else
                    {
                        MessageBox.Show("Wartość musi być w zakresie 1-100.");
                        TextBoxPoczatek.Text = String.Empty;
                    }
                }
                catch
                {
                    MessageBox.Show("Zły typ. Początek musi być liczbą.");
                    TextBoxPoczatek.Text = String.Empty;
                }
            }
        }

        private void TextBoxKoniec_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxKoniec.Text != String.Empty)
            {
                try
                {
                    koniec = Int32.Parse(TextBoxKoniec.Text) - 1; //zmniejszenie o 1 by wyszukiwać odpowiedni indeks w tablicy
                    if (koniec >= 0 && koniec <= 100)
                    {
                        flagaKoniec = true;
                    }
                    else
                    {
                        MessageBox.Show("Wartość musi być w zakresie 1-100.");
                        TextBoxKoniec.Text = String.Empty;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bład. Koniec musi być liczbą.");
                    TextBoxKoniec.Text = String.Empty;
                }
            }
        }

        public bool CzyWpisanoParametry
        {
            get
            {
                bool wpisano = false;


                if ((TextBoxLiczbaIteracji.Text != String.Empty) && (TextBoxWspolczynnikρ.Text != String.Empty) && (TextBoxWspolczynnikAlfa.Text != String.Empty) && (TextBoxWspolczynnikBeta.Text != String.Empty) && (TextBoxKoniec.Text != String.Empty) && (TextBoxPoczatek.Text != String.Empty))
                {
                    wpisano = true;
                }

                if (wpisano == false)
                {
                    MessageBox.Show("Musisz uzupełnić wszystkie parametry");
                }
                return wpisano;
            }
        }

        private void TextBoxLiczbaIteracji_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxLiczbaIteracji.Text != String.Empty)
            {
                try
                {
                    liczbaIteracji = Int32.Parse(TextBoxLiczbaIteracji.Text);
                    if (liczbaIteracji == 0)
                    {
                        MessageBox.Show("Liczba iteracji musi być dodatnia i większa od 0");
                        TextBoxLiczbaIteracji.Text = String.Empty;
                    }

                }
                catch
                {
                    MessageBox.Show("Liczba iteracji musi być liczbą dodatnią");
                    TextBoxLiczbaIteracji.Text = String.Empty;
                }

            }
        }

        

        public void ZaznaczPoczatekiKoniec()
        {
            polenagraf.Children.Add(graf.ZamalujPoczatek(wspolrzedne_wierzcholkow[poczatek].X, wspolrzedne_wierzcholkow[poczatek].Y));
            polenagraf.Children.Add(graf.ZamalujKoniec(wspolrzedne_wierzcholkow[koniec].X, wspolrzedne_wierzcholkow[koniec].Y));
        }

        public void ZaznaczTrase(int[] trasa)
        {
            RysujGraf();
            int k = 1;
            do
            {
                polenagraf.Children.Add(graf.Rysuj_krawedz(1, wspolrzedne_wierzcholkow[trasa[k - 1]].X, wspolrzedne_wierzcholkow[trasa[k - 1]].Y, wspolrzedne_wierzcholkow[trasa[k]].X, wspolrzedne_wierzcholkow[trasa[k]].Y));
                k++;
            }
            while (trasa[k - 1] != koniec);



            for (k = 1; k < trasa.Length; k++)
            {
                if (trasa[k] != koniec)
                { polenagraf.Children.Add(graf.Rysuj_wierzcholek(1, wspolrzedne_wierzcholkow[trasa[k]].X, wspolrzedne_wierzcholkow[trasa[k]].Y)); }
                else
                {
                    break;
                }
            }
            ZaznaczPoczatekiKoniec();
        }

        public void ZaktualizujTrase(int[] Trasa, int dlugosc)
        {
            
            ZaznaczTrase(Trasa);
            MessageBox.Show("długosc:" + dlugosc + "  iteracja:" + numerIteracji);

        }
        public int ZnajdzNajlepszaTrase (int[] dlugosci)
        {

            int indeks = 0;
            int i=0;
            int najlepszaDlugosc = dlugosci[0];
            foreach(int dlugosc in dlugosci)
            {
                if(dlugosc<=najlepszaDlugosc)
                {
                    najlepszaDlugosc = dlugosc;
                    indeks = i;
                }
                i++;
            }

            return indeks;
        }

        public int[,] dodajDoTras(int[,] trasy, int[] Trasa, int numerMrowki)
        {
            int k = 0;
            foreach(int punkt in Trasa)
            {
                trasy[numerMrowki, k] = punkt;
                k++;
            }
            return trasy;

        }
        public int[] dodajDoDlugosci(int[] dlugosci, int dlugosc, int numerMrowki)
        {
            dlugosci[numerMrowki] = dlugosc;
            return dlugosci;
        }

        public int[] ZczytajTablice (int[,] trasy, int numerMrowki)
        {
            int[] trasa = new int[100];

            for(int i =0; i<100;i++)
            {
                trasa[i] = trasy[numerMrowki, i];
            }

            return trasa;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int[,] trasy = new int[liczbaMrowek, 100];
            int[] dlugosciTras = new int[liczbaMrowek];
            RysujGraf();
            BPVM.UstawPoczatkowaWartoscFeromonu();
  
            Random wylosuj = new Random();
            if (BPVM.SprawdzWpisPoczatkuiKonca(flagaPoczatek, flagaKoniec, poczatek, koniec) && CzyWpisanoParametry)
            {


                for (numerIteracji = 0; numerIteracji < liczbaIteracji; numerIteracji++)
                {
                    for (int i = 0; i < liczbaMrowek; i++)
                    {
                        trasa = BPVM.GenerujTrase(poczatek, koniec, alfa, beta);                        
                        trasy=dodajDoTras(trasy, trasa, i);
                        dlugoscTrasy = BPVM.ZliczDlugoscTrasy(trasa, koniec);
                        dlugosciTras=dodajDoDlugosci(dlugosciTras, dlugoscTrasy, i);
                        
                    }
                    najlepszaMrowka = ZnajdzNajlepszaTrase(dlugosciTras);
                    dlugoscNajlepszejWIteracjiTrasy = dlugosciTras[najlepszaMrowka];
                    najlepszaWIteracjiTrasa = ZczytajTablice(trasy, najlepszaMrowka);
                    ZaktualizujTrase(najlepszaWIteracjiTrasa, dlugoscNajlepszejWIteracjiTrasy);
                    if (dlugoscNajlepszejWIteracjiTrasy < dlugoscNajlepszeGlobalnieTrasy)
                    { najlepszaGlobalnieTrasa = najlepszaWIteracjiTrasa;
                        dlugoscNajlepszeGlobalnieTrasy = dlugoscNajlepszejWIteracjiTrasy;
                    }
                    

                }
            }
        }

        private void TextBoxWspolczynnik_TextChangedρ(object sender, TextChangedEventArgs e)
        {
            if (TextBoxWspolczynnikρ.Text != String.Empty)
            {
                try
                {
                    ρ = Convert.ToDouble(TextBoxWspolczynnikρ.Text);
                    if (wspolczynnikModyfikacji >= 1)
                    {
                        MessageBox.Show("Współczynnik ρ nie może być równy 1, musi być liczbą z zakresu 0-1");
                        TextBoxWspolczynnikρ.Text = String.Empty;
                    }

                }
                catch
                {
                    MessageBox.Show("Współczynnik  ρ musi być liczbą z zakresu 0-1");
                    TextBoxWspolczynnikρ.Text = String.Empty;
                }

            }
        }

        private void TextBoxWspolczynnikBeta_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxWspolczynnikBeta.Text != String.Empty)
            {
                try
                {
                    beta = Convert.ToDouble(TextBoxWspolczynnikBeta.Text);
                    if (wspolczynnikModyfikacji >= 1)
                    {
                        MessageBox.Show("Współczynnik nie może być równy 1, musi być liczbą z zakresu 0-1");
                        TextBoxWspolczynnikBeta.Text = String.Empty;
                    }

                }
                catch
                {
                    MessageBox.Show("Współczynnik musi być liczbą z zakresu 0-1");
                    TextBoxWspolczynnikBeta.Text = String.Empty;
                }

            }
        }

        private void TextBoxWspolczynnikAlfa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxWspolczynnikAlfa.Text != String.Empty)
            {
                try
                {
                    alfa = Convert.ToDouble(TextBoxWspolczynnikAlfa.Text);
                    if (wspolczynnikModyfikacji >= 1)
                    {
                        MessageBox.Show("Współczynnik nie może być równy 1, musi być liczbą z zakresu 0-1");
                        TextBoxWspolczynnikAlfa.Text = String.Empty;
                    }

                }
                catch
                {
                    MessageBox.Show("Współczynnik musi być liczbą z zakresu 0-1");
                    TextBoxWspolczynnikAlfa.Text = String.Empty;
                }

            }
        }
    }
}
