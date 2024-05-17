using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _LABA_6_3
{

using System;

struct FootBall
    {
        private string team_;
        private int points_;

        public int Points => points_;

        public FootBall(string team, int points)
        {
            team_ = team;
            points_ = points;
        }

        public void Printinf()
        {
            Console.WriteLine("команда {0} \t\t очки {1}", team_, points_);
        }

        public static void ShellSort(FootBall[] array)
        {
            int n = array.Length;
            int d = n / 2;

            while (d > 0)
            {
                for (int i = d; i < n; i++)
                {
                    int j = i;
                    FootBall temp = array[i];

                    while (j >= d && array[j - d].Points < temp.Points)
                    {
                        array[j] = array[j - d];
                        j -= d;
                    }

                    array[j] = temp;
                }

                d /= 2;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FootBall[] group1 = new FootBall[]
            {
            new FootBall("Динамо\t", 11),
            new FootBall("Ростов\t", 17),
            new FootBall("ЦСКА\t", 9),
            new FootBall("Спартак", 10),
            new FootBall("Анжи\t", 15),
            new FootBall("Локомотив", 6),
            new FootBall("Волгарь", 13),
            new FootBall("Реал Мадрид", 12),
            new FootBall("Зенит\t", 8),
            new FootBall("Барселона", 14),
            new FootBall("Ливерпуль", 7),
            new FootBall("Челси\t", 6)
            };

            FootBall[] group2 = new FootBall[]
            {
            new FootBall("Факел\t", 9),
            new FootBall("Крылья Советов", 13),
            new FootBall("Манчестер Сити", 11),
            new FootBall("Ювентус", 18),
            new FootBall("Торпедо", 17),
            new FootBall("Бавария", 6),
            new FootBall("Краснодар", 10),
            new FootBall("Галатасарай", 7),
            new FootBall("Ротор\t", 8),
            new FootBall("Арсенал", 14),
            new FootBall("Фенербахче", 12),
            new FootBall("Милан\t", 6)
            };

            
            FootBall.ShellSort(group1);
            FootBall.ShellSort(group2);

            Console.WriteLine("Результаты группы 1:");
            for (int i = 0; i < group1.Length; i++)
            {
                group1[i].Printinf();
            }

            Console.WriteLine();

            Console.WriteLine("Результаты группы 2:");
            for (int i = 0; i < group2.Length; i++)
            {
                group2[i].Printinf();
            }

            FootBall[] rez = new FootBall[12];

            Array.Copy(group1, rez, 6);
            Array.Copy(group2, 0, rez, 6, 6);

            FootBall.ShellSort(rez);

            Console.WriteLine();

            Console.WriteLine("Окончательный список команд:");
            for (int i = 0; i < rez.Length; i++)
            {
                rez[i].Printinf();
            }
        }
    }
    
}
