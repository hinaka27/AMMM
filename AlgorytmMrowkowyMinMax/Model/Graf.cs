using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorytmMrowkowyMinMax.Model
{
    class Graf
    {
        public Ellipse Rysuj_wierzcholek(int maluj, double x, double y)
        {

            Ellipse punkt = new Ellipse();

            if (maluj == 0)
            {
                punkt.Fill = Brushes.LightGray;
                punkt.Stroke = Brushes.Black;
            }
            else
                if (maluj == 1)
            {
                punkt.Fill = Brushes.IndianRed;
                punkt.Stroke = Brushes.Red;
            }
            else
            {
                punkt.Fill = Brushes.Black;
                punkt.Stroke = Brushes.Black;
            }
            punkt.Width = 30;
            punkt.Height = 30;
            punkt.Margin = new Thickness(x, y, 0, 0);
            return punkt;

        }

        public Ellipse ZamalujPoczatek(double xp, double yp)
        {
            Ellipse poczatek = new Ellipse()
            {
                Fill = Brushes.LightGreen,
                Stroke = Brushes.Black,
                Width = 30,
                Height = 30,
                Margin = new Thickness(xp, yp, 0, 0)
            };
            return poczatek;


        }

        public Ellipse ZamalujKoniec(double xk, double yk)
        {
            Ellipse koniec = new Ellipse()
            {
                Fill = Brushes.IndianRed,
                Stroke = Brushes.Black,
                Width = 30,
                Height = 30,
                Margin = new Thickness(xk, yk, 0, 0)
            };
            return koniec;
        }

        public Line Rysuj_krawedz(int maluj, double xp, double yp, double xk, double yk)
        {
            Line krawedz = new Line()
            {
                StrokeThickness = 3
            };
            if (maluj == 0)
            {
                krawedz.Fill = Brushes.Gray;
                krawedz.Stroke = Brushes.Gray;
            }
            else
               if (maluj == 1)
            {
                krawedz.Fill = Brushes.Red;
                krawedz.Stroke = Brushes.Red;
            }
            else
                if (maluj == 2)
            {
                krawedz.Fill = Brushes.White;
                krawedz.Stroke = Brushes.White;
            }
            else
            {
                krawedz.Fill = Brushes.Black;
                krawedz.Stroke = Brushes.Black;
            }
            int srodek = 15;
            krawedz.X1 = xp + srodek;
            krawedz.Y1 = yp + srodek;
            krawedz.X2 = xk + srodek;
            krawedz.Y2 = yk + srodek;
            return krawedz;
        }
    }
}
