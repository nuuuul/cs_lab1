using System;
using System.Globalization;
using static System.Collections.Specialized.BitVector32;

namespace Pr1.v18
{
    public abstract class Movie
    {
        protected string Name;                      //Имя
        protected string Country;                   //Страна производитель
        protected string Director;                  //Режиссер 
        protected int Time_Watched = 0;             //Просмотренно
        protected int Time { get; set; }            //Длительность

        public bool isGood { get; set; }            //Рейтинг
        public virtual void Start()
        {
            Console.WriteLine("Фильм запущен\n");
        }
        public override string ToString()           //Перегрузка метода ToString()
        {
            return String.Format("Название : {0}\nСтрана производитель: {1}\nРежиссер: {2}\nДлительность: " +
                "{3}\nХороший ли фильм : {4}", Name, Country, Director, Time, isGood ? "Да" : "Нет");
        }
        public void Rate()                          //Метод оценивания фильма
        {
            Console.WriteLine("Понравился ли вам фильм?\n\t1.Да\n\t2.Нет");
            int result = (int)Convert.ToInt32(Console.ReadLine());
            if (result == 1)
                isGood = true;
            else
                isGood = false;
        }
        public void Watch()                         //Метод просмотра
        {
            if(Time - Time_Watched <= 20)
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
        public virtual string ClassName()
        {

            return "Class Movie";
        }

    }


    public class Action_Movie : Movie
    {
        public bool Nicolas_Cage;
        public override void Start()
        {
            base.Start();
            Console.WriteLine("ВЗРЫВ\n");
        }
        public Action_Movie() { this.Name = "Snatch"; this.Country = "Britain";             //Конструктор по умолчанию
            this.Director = "Guy Ritchie"; this.Time = 103; this.isGood = true; }
        public Action_Movie(string name, string country, string director, int time, bool isOK)  //Конструктор с параметрами
        {
            Name = name;
            Country = country;
            Director = director;
            Time = time;
            isGood = isOK;
        }
        public Action_Movie(string name) { this.Name = name; }                          //Конструктор, принимающий string name
        public static void Distract()                                                   //Статический метод
        {
            Console.WriteLine("Не отвлекайтесь!\n");
        }
        public override string ClassName()
        {
            return "Class Action_Movie";
        }
    }


    public class Horror_Movie : Movie
    {
        private int Budget { get; set; }          //Бюджет
        public Horror_Movie()                     //Конструктор по умолчанию
        {
            Name = "Saw";
            Country = "USA";
            Director = "James Wan";
            Time = 103;
            Budget = 1200000;
            isGood=true;
        }
        public override void Start()
        {
            base.Start();
            Console.WriteLine("SCREAMER!!!!\n");
        }

        public void Screamer()
        {
            Random rand = new Random();
            int screamer = rand.Next(1, 2);
            if (screamer == 1)
                Console.WriteLine("Вас не так просто напугать.\nНе то, чтобы пытались");
            else
                Console.WriteLine("Вы сильно испугались");
        }

        public override string ClassName()
        {
            return "Class Horror_Movie";
        }
    }

    sealed public class Comedy_Movie : Movie
    {
        private bool PayBack { get; set; }
        public Comedy_Movie()
        {
            Name = "Don't Be a Menace to South Central While Drinking Your Juice in the Hood";
            Country = "USA";
            Director = "Paris K. C. Barclay";
            Time = 89;
            PayBack = true;
        }
        public override void Start()
        {
            base.Start();
            Console.WriteLine("Мммммм.... Озвучка Гоблина.....\n");
        }

        public void Titres()
        {
            if (Time_Watched < Time)
            {
                Console.WriteLine($"Титры будут в конце. Вы еще не досмотрели фильм\nДо конца : {Time - Time_Watched} минут");
                return;
            }
            Console.WriteLine("Будете смортеть титры?\n1.Да\n2.Нет");
            int answer = (int)Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
                Console.WriteLine(this.ToString());
        }

        public override string ClassName()
        {
            return "Class Comedy_Movie";
        }
    }

    public class Detective_Movie : Movie
    {
        private string Actor;
        public Detective_Movie()
        {
            Name = "7";
            Country = "USA";
            Director = "David Fincher";
            Time = 127;
            Actor = "Morgan Freeman";
        }
        public override void Start()
        {
            base.Start();
            Console.WriteLine("И почему детективы перестали снимать?\n");
        }
        public void Ugadayka()
        {
            Random rand = new Random();
            int answer = rand.Next(1, 3);
            Console.WriteLine("Поиграем в угадайку, раз у нас детектив.\nНапрягите интуицию и выберите число:\n\t1\t2\t3");
            int user_answer = (int)Convert.ToInt32(Console.ReadLine());
            if (answer == user_answer)
                Console.WriteLine("ВЕРНО\nВы действительно уникум, не думали на что тратите жизнь?\nЯ вот нет");
            else
                Console.WriteLine($"ОШИБКА\nОчень жаль это сообщать, но правильный ответ - {answer}\nВы в свою очередь поставили на {user_answer} и потеряли палец");
        }

        public override string ClassName()
        {
            return "Detective_Movie";
        }
    }



    public class Program
    {
        static int Menu()
        {
            int choosed = -1;
            Console.Clear();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1.Показать список фильмов");
            Console.WriteLine("2.Выбрать Action");
            Console.WriteLine("3.Выбрать Horror");
            Console.WriteLine("4.Выбрать Comedy");
            Console.WriteLine("5.Выбрать Detective");
            Console.WriteLine("0 - выход");
            Int32.TryParse(Console.ReadLine(), out choosed);

            return choosed;
        }
        static int Deep_Menu(Movie obj)
        {
            int choosed = -1;
            Console.WriteLine("2.Вывести название класса");
            Console.WriteLine("3.Вывести информацию о фильме");
            Console.WriteLine("4.Оценить фильм");
            Console.WriteLine("5.Смотреть фильм");
            Console.WriteLine("0.Вернуться");
            Int32.TryParse(Console.ReadLine(), out choosed);
            switch (choosed)
            {
                case 1:
                    break;
                case 2:
                    Console.WriteLine(obj.ClassName());
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine(obj.ToString());
                    Console.ReadKey();
                    break;
                case 4:
                    obj.Rate();
                    Console.ReadKey();
                    break;
                case 5:
                    obj.Watch();
                    Console.ReadKey();
                    break;
                case 0:
                    Console.WriteLine("Возвращаемся.....");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            return choosed;
        }
        static void Main(string[] args)
        {
            Action_Movie action = new();
            Horror_Movie horror = new();
            Comedy_Movie comedy = new();
            Detective_Movie detective = new();

            int choosed = -1;
            int deep_choosed = -1;
            while(choosed!=0)
            {
                choosed = Menu();
                switch(choosed)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("--------------------------");
                        Console.WriteLine(action.ToString());
                        Console.WriteLine("--------------------------");
                        Console.WriteLine(horror.ToString());
                        Console.WriteLine("--------------------------");
                        Console.WriteLine(comedy.ToString());
                        Console.WriteLine("--------------------------");
                        Console.WriteLine(detective.ToString());
                        Console.WriteLine("--------------------------");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("-------Вы выбрали Action фильм-------");
                        Console.WriteLine(action.ToString());
                        Console.WriteLine("Начнем.......");
                        action.Start();

                        Console.ReadKey();
                        
                        while (deep_choosed != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Веберите действие");
                            Console.WriteLine("1.Что будет если отвлечься?");
                            deep_choosed = Deep_Menu(action);
                            if (deep_choosed == 1)
                            {
                                Action_Movie.Distract();
                                Console.ReadKey();
                            }
                        }
                        deep_choosed = -1;
                        break;

                    case 3:
                        Console.WriteLine("-------Вы выбрали Horror фильм-------");
                        Console.WriteLine(action.ToString());
                        Console.WriteLine("Начнем.......");
                        horror.Start();

                        Console.ReadKey();

                        while(deep_choosed!=0)
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите действие");
                            Console.WriteLine("1.Проверить свои нервы");
                            deep_choosed = Deep_Menu(horror);
                            if(deep_choosed == 1)
                            {
                                horror.Screamer();
                                Console.ReadKey();
                            }
                        }
                        deep_choosed = -1;
                        break;

                    case 4:
                        Console.WriteLine("-------Вы выбрали Comedy фильм-------");
                        Console.WriteLine(comedy.ToString());
                        Console.WriteLine("Начнем.......");
                        comedy.Start();

                        Console.ReadKey();

                        while(deep_choosed!=0)
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите действие");
                            Console.WriteLine("1.Выбрать остаться ли смотреть титры");
                            deep_choosed = Deep_Menu(comedy);
                            if(deep_choosed == 1)
                            {
                                comedy.Titres();
                                Console.ReadKey();
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("-------Вы выбрали Detective фильм-------");
                        Console.WriteLine(detective.ToString());
                        Console.WriteLine("Начнем........");
                        detective.Start();

                        Console.ReadKey();

                        while(deep_choosed!=0)
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите действие");
                            Console.WriteLine("1.Проверить свою интуицию");
                            deep_choosed = Deep_Menu(detective);

                            if(deep_choosed == 1)
                            {
                                detective.Ugadayka();
                                Console.ReadKey();
                            }
                        }
                        break;
                }
            }
        }
    }
}
