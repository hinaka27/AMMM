using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlgorytmMrowkowyMinMax.ViewModel
{
    public class BezPrzeszkodViewModel
    {
        //tablica krawedzi
        static int x = 1000;
        Random losowaLiczba = new Random();
        double[,] feromon = new double[100, 100];
        public int[,] krawedzie = new int[100, 100]
           {

                {x,7,x,x,x,x,x,x,x,x,3,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//1
                {7,x,8,x,x,x,x,x,x,x,5,4,5,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//2
                {x,8,x,5,x,x,x,x,x,x,x,8,8,9,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//3
                {x,x,5,x,4,x,x,x,x,x,x,x,2,7,9,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//4
                {x,x,x,4,x,6,x,x,x,x,x,x,x,9,3,5,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//5
                {x,x,x,x,6,x,7,x,x,x,x,x,x,x,5,4,5,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//6
                {x,x,x,x,x,7,x,6,x,x,x,x,x,x,x,3,7,3,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//7
                {x,x,x,x,x,x,6,x,8,x,x,x,x,x,x,x,4,5,4,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//8
                {x,x,x,x,x,x,x,8,x,3,x,x,x,x,x,x,x,9,7,9,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//9
       /*10*/   {x,x,x,x,x,x,x,x,3,x,x,x,x,x,x,x,x,x,4,2,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//10
                {3,5,x,x,x,x,x,x,x,x,x,2,x,x,x,x,x,x,x,x,8,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//11
                {6,4,8,x,x,x,x,x,x,x,2,x,5,x,x,x,x,x,x,x,1,6,5,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//12
                {x,5,8,2,x,x,x,x,x,x,x,5,x,8,x,x,x,x,x,x,x,5,1,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//13
                {x,x,9,7,9,x,x,x,x,x,x,x,8,x,7,x,x,x,x,x,x,x,6,6,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//14
                {x,x,x,9,3,5,x,x,x,x,x,x,x,7,x,7,x,x,x,x,x,x,x,6,2,4,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//15
                {x,x,x,x,5,4,3,x,x,x,x,x,x,x,7,x,3,x,x,x,x,x,x,x,4,5,2,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//16
                {x,x,x,x,x,5,7,4,x,x,x,x,x,x,x,3,x,6,x,x,x,x,x,x,x,4,3,4,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//17
                {x,x,x,x,x,x,3,5,9,x,x,x,x,x,x,x,6,x,5,x,x,x,x,x,x,x,5,3,4,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//18
                {x,x,x,x,x,x,x,4,7,4,x,x,x,x,x,x,x,5,x,2,x,x,x,x,x,x,x,3,1,1,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//19
       /*20*/   {x,x,x,x,x,x,x,x,9,2,x,x,x,x,x,x,x,x,2,x,x,x,x,x,x,x,x,x,3,4,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//20
                {x,x,x,x,x,x,x,x,x,x,8,1,x,x,x,x,x,x,x,x,x,4,x,x,x,x,x,x,x,x,7,2,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//21
                {x,x,x,x,x,x,x,x,x,x,7,6,5,x,x,x,x,x,x,x,4,x,5,x,x,x,x,x,x,x,7,8,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//22
                {x,x,x,x,x,x,x,x,x,x,x,5,1,6,x,x,x,x,x,x,x,5,x,10,x,x,x,x,x,x,x,2,2,10,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//23
                {x,x,x,x,x,x,x,x,x,x,x,x,7,6,7,x,x,x,x,x,x,x,10,x,9,x,x,x,x,x,x,x,4,8,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//24
                {x,x,x,x,x,x,x,x,x,x,x,x,x,8,2,4,x,x,x,x,x,x,x,9,x,3,x,x,x,x,x,x,x,8,7,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//25
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,4,5,4,x,x,x,x,x,x,x,3,x,3,x,x,x,x,x,x,x,2,1,4,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//26
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,2,3,5,x,x,x,x,x,x,x,3,x,4,x,x,x,x,x,x,x,7,7,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//27
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,4,3,3,x,x,x,x,x,x,x,4,x,6,x,x,x,x,x,x,x,3,2,1,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//28
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,4,1,3,x,x,x,x,x,x,x,6,x,2,x,x,x,x,x,x,x,1,3,4,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//29
       /*30*/   {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,4,x,x,x,x,x,x,x,x,2,x,x,x,x,x,x,x,x,x,1,3,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//30
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,7,x,x,x,x,x,x,x,x,x,8,x,x,x,x,x,x,x,x,5,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//31
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,2,8,2,x,x,x,x,x,x,x,8,x,2,x,x,x,x,x,x,x,4,1,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//32
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,2,2,x,x,x,x,x,x,x,2,x,7,x,x,x,x,x,x,x,6,10,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//33
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,10,8,8,x,x,x,x,x,x,x,7,x,9,x,x,x,x,x,x,x,8,8,9,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//34
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,7,2,x,x,x,x,x,x,x,9,x,9,x,x,x,x,x,x,x,9,3,2,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//35
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,1,7,x,x,x,x,x,x,x,9,x,3,x,x,x,x,x,x,x,1,7,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//36
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,4,7,3,x,x,x,x,x,x,x,3,x,5,x,x,x,x,x,x,x,4,2,1,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//37
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,2,1,x,x,x,x,x,x,x,5,x,9,x,x,x,x,x,x,x,7,3,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//38
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,3,1,x,x,x,x,x,x,x,9,x,3,x,x,x,x,x,x,x,4,3,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//39
        /*40*/  {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,4,3,x,x,x,x,x,x,x,x,3,x,x,x,x,x,x,x,x,x,1,2,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//40
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,5,4,x,x,x,x,x,x,x,x,x,3,x,x,x,x,x,x,x,x,8,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//41
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,1,6,x,x,x,x,x,x,x,3,x,2,x,x,x,x,x,x,x,8,2,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//42
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,10,8,x,x,x,x,x,x,x,2,x,2,x,x,x,x,x,x,x,8,1,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//43
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,8,9,x,x,x,x,x,x,x,2,x,4,x,x,x,x,x,x,x,8,9,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//44
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,9,3,1,x,x,x,x,x,x,x,4,x,7,x,x,x,x,x,x,x,6,1,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//45
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,2,7,4,x,x,x,x,x,x,x,7,x,5,x,x,x,x,x,x,x,8,6,9,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//46
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,2,7,x,x,x,x,x,x,x,5,x,2,x,x,x,x,x,x,x,3,5,3,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//47
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,3,4,x,x,x,x,x,x,x,2,x,2,x,x,x,x,x,x,x,4,5,2,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//48
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,3,1,x,x,x,x,x,x,x,2,x,9,x,x,x,x,x,x,x,6,7,1,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//49
         /*50*/ {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,2,x,x,x,x,x,x,x,x,9,x,x,x,x,x,x,x,x,x,1,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//50
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,8,x,x,x,x,x,x,x,x,x,5,x,x,x,x,x,x,x,x,1,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//51
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,2,7,x,x,x,x,x,x,x,5,x,7,x,x,x,x,x,x,x,7,1,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//52
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,1,8,x,x,x,x,x,x,x,7,x,6,x,x,x,x,x,x,x,7,3,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//53
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,9,6,x,x,x,x,x,x,x,6,x,10,x,x,x,x,x,x,x,8,9,9,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//54
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,1,8,x,x,x,x,x,x,x,10,x,6,x,x,x,x,x,x,x,9,2,3,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//55
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,6,3,x,x,x,x,x,x,x,6,x,3,x,x,x,x,x,x,x,4,3,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//56
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,9,5,4,x,x,x,x,x,x,x,3,x,8,x,x,x,x,x,x,x,7,1,1,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//57
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,3,5,6,x,x,x,x,x,x,x,8,x,2,x,x,x,x,x,x,x,4,1,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//58
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,2,7,1,x,x,x,x,x,x,x,2,x,5,x,x,x,x,x,x,x,9,1,5,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//59
         /*60*/ {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,6,x,x,x,x,x,x,x,x,5,x,x,x,x,x,x,x,x,x,2,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//60
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,3,7,x,x,x,x,x,x,x,x,x,2,x,x,x,x,x,x,x,x,1,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//61
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,1,7,x,x,x,x,x,x,x,2,x,3,x,x,x,x,x,x,x,8,7,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//62
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,3,8,x,x,x,x,x,x,x,3,x,9,x,x,x,x,x,x,x,7,2,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//63
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,9,9,x,x,x,x,x,x,x,9,x,5,x,x,x,x,x,x,x,6,9,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//64
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,9,2,4,x,x,x,x,x,x,x,5,x,2,x,x,x,x,x,x,x,8,3,1,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//65
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,3,3,7,x,x,x,x,x,x,x,2,x,2,x,x,x,x,x,x,x,1,3,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//66
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,1,4,x,x,x,x,x,x,x,2,x,1,x,x,x,x,x,x,x,4,3,5,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//67
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,1,9,x,x,x,x,x,x,x,1,x,5,x,x,x,x,x,x,x,4,2,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//68
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,1,2,x,x,x,x,x,x,x,5,x,3,x,x,x,x,x,x,x,7,9,1,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//69
         /*70*/ {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,5,7,x,x,x,x,x,x,x,x,3,x,x,x,x,x,x,x,x,x,3,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//70
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,8,x,x,x,x,x,x,x,x,x,6,x,x,x,x,x,x,x,x,4,6,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//71
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,7,7,x,x,x,x,x,x,x,6,x,6,x,x,x,x,x,x,x,7,8,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//72
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,2,6,x,x,x,x,x,x,x,6,x,7,x,x,x,x,x,x,x,5,7,10,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//73
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,9,8,x,x,x,x,x,x,x,7,x,5,x,x,x,x,x,x,x,9,2,8,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//74
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,3,1,x,x,x,x,x,x,x,5,x,4,x,x,x,x,x,x,x,5,3,7,x,x,x,x,x,x,x,x,x,x,x,x,x,x},//75
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,3,4,x,x,x,x,x,x,x,4,x,1,x,x,x,x,x,x,x,8,5,10,x,x,x,x,x,x,x,x,x,x,x,x,x},//76
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,3,4,x,x,x,x,x,x,x,1,x,9,x,x,x,x,x,x,x,5,1,7,x,x,x,x,x,x,x,x,x,x,x,x},//77
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,5,2,7,x,x,x,x,x,x,x,9,x,5,x,x,x,x,x,x,x,2,3,2,x,x,x,x,x,x,x,x,x,x,x},//78
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,9,3,x,x,x,x,x,x,x,5,x,2,x,x,x,x,x,x,x,7,6,7,x,x,x,x,x,x,x,x,x,x},//79
         /*80*/ {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,8,x,x,x,x,x,x,x,x,2,x,x,x,x,x,x,x,x,x,6,1,x,x,x,x,x,x,x,x,x,x},//80
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,4,7,x,x,x,x,x,x,x,x,x,8,x,x,x,x,x,x,x,x,6,6,x,x,x,x,x,x,x,x},//81
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,8,5,x,x,x,x,x,x,x,8,x,6,x,x,x,x,x,x,x,7,8,7,x,x,x,x,x,x,x},//82
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,7,9,x,x,x,x,x,x,x,6,x,10,x,x,x,x,x,x,x,4,1,7,x,x,x,x,x,x},//83
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,10,5,2,x,x,x,x,x,x,x,10,x,8,x,x,x,x,x,x,x,6,6,9,x,x,x,x,x},//84
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,8,3,8,x,x,x,x,x,x,x,8,x,1,x,x,x,x,x,x,x,9,2,7,x,x,x,x},//85
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,5,5,x,x,x,x,x,x,x,1,x,5,x,x,x,x,x,x,x,9,6,2,x,x,x},//86
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,1,2,x,x,x,x,x,x,x,5,x,7,x,x,x,x,x,x,x,6,5,9,x,x},//87
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,3,7,x,x,x,x,x,x,x,7,x,3,x,x,x,x,x,x,x,1,2,1,x},//88
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,2,6,6,x,x,x,x,x,x,x,3,x,1,x,x,x,x,x,x,x,7,7,7},//89
         /*90*/ {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,1,x,x,x,x,x,x,x,x,1,x,x,x,x,x,x,x,x,x,3,2},//90
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,7,x,x,x,x,x,x,x,x,x,4,x,x,x,x,x,x,x,x},//91
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,6,8,4,x,x,x,x,x,x,x,4,x,8,x,x,x,x,x,x,x},//92
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,2,1,6,x,x,x,x,x,x,x,8,x,10,x,x,x,x,x,x},//93
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,6,9,x,x,x,x,x,x,x,10,x,5,x,x,x,x,x},//94
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,9,2,9,x,x,x,x,x,x,x,5,x,8,x,x,x,x},//95
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,6,6,x,x,x,x,x,x,x,8,x,6,x,x,x},//96
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,2,5,1,x,x,x,x,x,x,x,6,x,7,x,x},//97
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,9,2,7,x,x,x,x,x,x,x,7,x,6,x},//98
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,1,7,3,x,x,x,x,x,x,x,6,x,5},//99
       /*100*/  {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,7,2,x,x,x,x,x,x,x,x,5,x},//100
           };


        public Point[] WyznaczWspolrzedneWierzcholkow(int px, int py)
        {
            int x;
            int y;
            Point[] wspolrzedne_wierzcholkow = new Point[100];
            int i = 0;
            for (int n = 0; n < 10; n++)
            {
                y = py + n * 50;
                for (int m = 0; m < 10; m++)
                {
                    x = px + m * 50;
                    wspolrzedne_wierzcholkow[i] = new Point(x, y);
                    i++;
                }
            }
            return wspolrzedne_wierzcholkow;
        }

        public bool SprawdzWpisPoczatkuiKonca(bool flagaPoczatek, bool flagaKoniec, int poczatek, int koniec)
        {
            if (flagaPoczatek == true && flagaKoniec == true)
            {
                if (poczatek != koniec)
                {
                    return true;
                }

                else
                {
                    MessageBox.Show("Początek i koniec musi być różny");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Podaj początek i koniec");
                return false;
            }
        }

        public int[] GenerujTrase(int poczatek, int koniec, double alfa, double beta)
        {
            int[] trasa = new int[100];
            int[] sasiedzi = new int[8];
           
            int nowyWierzcholek;
            int k = 0;
            bool warunekZakonczenia = false;
            bool saSasiedzi = false;
            trasa[k] = poczatek;
            do
            {
                sasiedzi = ZnajdzSasiadow(trasa[k]);

                sasiedzi = UsunJuzOdwiedzonePunkty(trasa, sasiedzi);

                saSasiedzi = SprawdzCzySaSasiedzi(sasiedzi, koniec);
                
                if (!saSasiedzi)
                {
                    trasa = WyczyscTablice(trasa);
                    k = 0;
                    trasa[k] = poczatek;
                    sasiedzi = ZnajdzSasiadow(trasa[k]);
                    sasiedzi = UsunJuzOdwiedzonePunkty(trasa, sasiedzi);
                    
                }
                nowyWierzcholek = WybierzPunkt(sasiedzi, trasa[k], alfa, beta);
                k++;
                
                if (nowyWierzcholek != koniec)
                {
                    trasa[k] = nowyWierzcholek;
                }
                else
                {
                    trasa[k] = koniec;
                    warunekZakonczenia = true;
                }

            } while (warunekZakonczenia != true);
            return trasa;

        }

        public void UstawPoczatkowaWartoscFeromonu()
        {
            for(int i=0;i<100;i++)
            {
                for (int j = 0; j < 100; j++)
                { feromon[i,j] = 1; }
            }
            
        }
        


        public int[] WyczyscTablice(int[] tablica)
        {
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = 0;
            }
            return tablica;
        }

        public int[] ZnajdzSasiadow(int punkt)
        {
            int[] sasiedzi = new int[8];
            int liczbaWierzcholkow = 100;
            int k = 0;
            for (int i = 0; i < liczbaWierzcholkow; i++)
            {
                if (krawedzie[punkt, i] != 1000)
                {
                    sasiedzi[k] = i;
                    k++;
                }
            }
            return sasiedzi;
        }

        public int[] UsunJuzOdwiedzonePunkty(int[] trasa, int[] sasiedzi)
        {
            int[] nieOdwiedzone = new int[8];
            int k = 0;
            bool nieWystepuje = true;
            foreach (int punkt in sasiedzi)
            {
                for (int i = 0; i < trasa.Length; i++)
                {
                    if (trasa[i] == punkt)
                    {
                        nieWystepuje = false;
                    }
                }
                if (nieWystepuje)
                {
                    nieOdwiedzone[k] = punkt;
                    k++;
                    nieWystepuje = false;
                }

                nieWystepuje = true;


            }
            return nieOdwiedzone;
        }

        public bool SprawdzCzySaSasiedzi(int[] sasiedzi, int koniec)
        {
            foreach (int sasiad in sasiedzi)
            {
                if (sasiad != 0) { return true; }
            }

            if (koniec == 0)
            { return true; }
            else
            { return false; }


        }
    public int[] PobierzDlugosciKrawedzi (int[] sasiedzctwo, int punkt)
        {
            int[] odleglosci = new int[8];
            int liczbaSasiadow = 1;
            for (int i = 1; i < sasiedzctwo.Length; i++)
            {
                if (sasiedzctwo[i] != 0)
                { liczbaSasiadow++; }
            }

            for (int i=0; i<liczbaSasiadow;i++)
            {
                odleglosci[i] = krawedzie[punkt, sasiedzctwo[i]];
            }

            return odleglosci;
        }

        public double[] ObliczFunkcjeAtrakcyjnosci (double[] funkcjaAtrakcyjnosci, int[] odleglosci)
        {
            int k = 0;
            foreach(int dlugosc in odleglosci)
            {
                if (dlugosc != 0)
                {
                    funkcjaAtrakcyjnosci[k] = 1.0 / Convert.ToDouble( dlugosc);
                    
                }
                else
                {
                    funkcjaAtrakcyjnosci[k] = 0;
                }
                k++;
            }

            return funkcjaAtrakcyjnosci;
        }
    public double[] ObliczPrawdopodobienstwoWierzcholkow(double[] prawdopodobienstwo,int starPunkt, int[] sasiedzi,int[] odleglosci, double alfa, double beta)
        {
            double[] funkcjaAtrakcyjnosci = new double[8];
            double mianownik=0;
            funkcjaAtrakcyjnosci = ObliczFunkcjeAtrakcyjnosci(funkcjaAtrakcyjnosci, odleglosci);

            for (int i = 0; i < funkcjaAtrakcyjnosci.Length; i++)
            {
                if (funkcjaAtrakcyjnosci[i] != 0)
                { 
                mianownik = mianownik + (Math.Pow(feromon[starPunkt, sasiedzi[i]], alfa) * Math.Pow(funkcjaAtrakcyjnosci[i], beta));
                 }
            }

            for(int i=0; i<prawdopodobienstwo.Length;i++)
            {
                if (funkcjaAtrakcyjnosci[i] != 0)
                {
                    prawdopodobienstwo[i] = (Math.Pow(feromon[starPunkt, sasiedzi[i]], alfa) * Math.Pow(funkcjaAtrakcyjnosci[i], beta)) / mianownik;
                }
            }


            return prawdopodobienstwo;

        }
       
                   

         public int WybierzPunkt(int[] sasiedzi, int startPunkt, double alfa, double beta)
         {
             int punkt=0;
            int los = 0;
            int[] odleglosci = new int[8];
            int sumaPrawdopodobienstw = 0;
           
            double[] prawdopodobienstwo = new double[8];


            odleglosci=PobierzDlugosciKrawedzi(sasiedzi, startPunkt);
            prawdopodobienstwo = ObliczPrawdopodobienstwoWierzcholkow(prawdopodobienstwo,startPunkt,sasiedzi, odleglosci, alfa, beta);
            for (int i = 0; i < prawdopodobienstwo.Length; i++)
            {
                if (prawdopodobienstwo[i] != 0.0)
                {
                    sumaPrawdopodobienstw = sumaPrawdopodobienstw + Convert.ToInt32(prawdopodobienstwo[i] * 100);
                    
                }
            }
            los = losowaLiczba.Next(0,sumaPrawdopodobienstw);
            sumaPrawdopodobienstw = 0;
            for(int i=0;i<prawdopodobienstwo.Length;i++)
            {
                if (prawdopodobienstwo[i] != 0.0)
                {
                    sumaPrawdopodobienstw = sumaPrawdopodobienstw + Convert.ToInt32(prawdopodobienstwo[i]*100);
                    if(sumaPrawdopodobienstw>los)
                    {
                        punkt = sasiedzi[i];
                        break;
                    }
                }
            }

            
            return punkt;

   }

            public int ZliczDlugoscTrasy(int[] trasa, int koniec)
        {
            int dlugosc = 0;

            bool koniecTrasy = false;
            for (int k = 1; k < trasa.Length; k++)
            {

                if (!koniecTrasy)
                {
                    dlugosc = dlugosc + krawedzie[trasa[k - 1], trasa[k]];
                }
                if (trasa[k] == koniec)
                {
                    koniecTrasy = true;
                    break;
                }
            }
            return dlugosc;
        }


        
    }
}
