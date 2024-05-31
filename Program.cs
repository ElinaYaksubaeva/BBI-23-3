using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7_1
{
    using System;
    using System.Text.RegularExpressions;

    abstract class Cross
    {
        protected string lastname_;
        protected int group_;
        protected string trener_;
        protected double rez_;
        public double rez => rez_;

        protected double distance_;
        public double distance => distance_;

        public Cross(string lastname, int group, string trener, double rez, double distance)
        {
            lastname_ = lastname;
            group_ = group;
            trener_ = trener;
            rez_ = rez;
            distance_ = distance;
        }
        public virtual void Print()
        {
            Console.WriteLine(
            "Фамилия: {0} \t Группа: {1} \t Тренер: {2} \t Результат: {3:f2} \t Дистанция: {4:f2}",
            lastname_, group_, trener_, rez_, distance_);
        }
    }
    class Sto : Cross
    {
        protected string material_;
        public string material => material_;

        public Sto(string lastname, int group, string trener, double rez, double distance, string material) : base(lastname, group, trener, rez, distance)
        {
            material_ = material;
        }
        public override void Print()
        {
            Console.WriteLine(
            "Фамилия: {0} \t Группа: {1} \t Тренер: {2} \t Результат: {3:f2} \t Дистанция: {4:f2} \t Материал дорожки: {5}",
            lastname_, group_, trener_, rez_, distance_, material_);
        }
    }
    class Five : Cross
    {
        protected int running_laps_;
        public int running_laps => running_laps_;

        public Five(string lastname, int group, string trener, double rez, double distance, int laps) : base(lastname, group, trener, rez, distance)
        {
            running_laps_ = laps;
        }
        public override void Print()
        {
            Console.WriteLine(
            "Фамилия: {0} \t Группа: {1} \t Тренер: {2} \t Результат: {3:f2} \t Дистанция: {4:f2} \t Количество кругов: {5}",
            lastname_, group_, trener_, rez_, distance_, running_laps_);
        }
    }

    class Program
    {
        static void Main()
        {
            Five[] five = new Five[5]
            {
                new Five("Леденцова", 5, "Симочкина", 54.3, 500, 5),
                new Five("Лидова\t", 1, "Ситко\t", 61.3, 500, 6),
                new Five("Архипова", 4, "Метелкина", 55.9, 500, 7),
                new Five("Любвина ", 6, "Носова\t", 53.5, 500, 8),
                new Five("Рыкина\t", 2, "Калинина", 60.1, 500, 9)

            };
            Sto[] sto = new Sto[5]
           {
                new Sto("Леденцова", 5, "Симочкина", 22.4, 100, "Резина"),
                new Sto("Лидова\t", 1, "Ситко\t", 19.3, 100, "Асфальт"),
                new Sto("Архипова", 4, "Метелкина", 19.9, 100, "Бетон"),
                new Sto("Любвина ", 6, "Носова\t", 18.2, 100, "Резина"),
                new Sto("Рыкина\t", 2, "Калинина", 25.7, 100, "Бетон")
           };


            static void SortByNorm1(Cross[] arrA, Cross[] arrB, Cross[] arrC)
            {
                int i = 0;
                int j = 0;
                int k = 0;

                while (i < arrA.Length && j < arrB.Length)
                {
                    if (arrA[i].rez / arrA[i].distance > arrB[j].rez / arrB[j].distance)
                    {
                        arrC[k] = arrA[i];
                        i++;
                    }
                    else
                    {
                        arrC[k] = arrB[j];
                        j++;
                    }
                    k++;
                }

                while (i < arrA.Length)
                {
                    arrC[k] = arrA[i];
                    i++;
                    k++;
                }

                while (j < arrB.Length)
                {
                    arrC[k] = arrB[j];
                    j++;
                    k++;
                }
            }

            Cross[] runners = new Cross[10];
            SortByNorm1(five, sto, runners);

            Console.WriteLine("\nОбъединенный отсортированный массив:");
            for (int l = 0; l < 10; l++)
            {
                runners[l].Print();
            }
        }
    }
}
