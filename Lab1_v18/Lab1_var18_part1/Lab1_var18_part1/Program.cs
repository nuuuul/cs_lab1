using System;
using System.Globalization;

namespace Pr1.v18
{
    class Action_Movie
    {
        protected string Name;                      //Имя
        private readonly string zhanr = "ACTION";
        protected string Country;                   //Страна производитель
        protected string Director;                  //Режиссер 
        protected int Time { get; set; }            //Длительность
        private int Time_Watched = 0;             //Просмотрено пользователем
        public bool isGood { get; set; }            //Рейтинг

        public Action_Movie()
        {
            this.Name = "Snatch"; this.Country = "Britain";             //Конструктор по умолчанию
            this.Director = "Guy Ritchie"; this.Time = 103; this.isGood = true;
        }

        public Action_Movie(string name, string country, string director, int time, bool isOK)  //Конструктор с параметрами
        {
            Name = name;
            Country = country;
            Director = director;
            Time = time;
            isGood = isOK;
        }

        public Action_Movie(string name) { this.Name = name; }                          //Конструктор, принимающий string name

        public override string ToString()                                               //Перегрузка метода ToString()
        {
            return String.Format("Name : {0}\nCountry: {1}\nDirector: {2}\nTime: {3}\nIs it good : {4}", Name, Country, Director, Time, isGood ? "Yes" : "No");
        }

        public void Watch()                         //Метод просмотра
        {
            if (Time - Time_Watched <= 20)
            {
                Console.WriteLine($"Вы досмотрели последние {Time - Time_Watched} минут фильма." +
                    $"\nНе забудьте оценить!");
                Time_Watched = Time;
                return;
            }

            if (Time_Watched < Time)
            {
                Time_Watched += 20;
                Console.WriteLine($"Вы просмотрели {Time_Watched} минут фильма" +
                    $"\n{Time - Time_Watched} минут осталось\n");
                return;
            }

            if (Time_Watched == Time)
                Console.WriteLine("Вы уже просмотрели фильм до конца");
        }

        public void Rate()                                                              //Метод оценивания фильма
        {
            Console.WriteLine("Is this film good?\n\t1.Yes\n\t2.No");
            int result = (int)Convert.ToInt32(Console.ReadLine());
            if (result == 1)
                isGood = true;
            else
                isGood = false;
        }



        public static void Distract()                                                   //Статический метод
        {
            Console.WriteLine("Dont be distracted!\n");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string name = "Name";
            string counrty = "РОССИЯ РОССИЯ РОССИЯ";
            string director = "Director";
            int time = 100;
            bool isOK = true;
            int choosed = -1;

            Action_Movie Movie = new(name, counrty, director, time, isOK);
            while (choosed != 0)
            {
                Console.Clear();
                Console.WriteLine("1.Вывести информацию о фильме");
                Console.WriteLine("2.Смотреть фильм");
                Console.WriteLine("3.Оценить фильм");
                Console.WriteLine("4.Попробовать отвлечься");
                Console.WriteLine("0.Выйти");
                Int32.TryParse(Console.ReadLine(), out choosed);
                switch (choosed)
                {
                    case 1:
                        Console.WriteLine(Movie.ToString());
                        Console.ReadKey();
                        break;
                    case 2:
                        Movie.Watch();
                        Console.ReadKey();
                        break;
                    case 3:
                        Movie.Rate();
                        Console.ReadKey();
                        break;
                    case 4:
                        Action_Movie.Distract();
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("Выход");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }
    }
}
