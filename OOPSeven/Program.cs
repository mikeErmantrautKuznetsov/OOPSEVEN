using System;

namespace OOPSeven
{
    //У вас есть программа, которая помогает пользователю составить план поезда.
    //Есть 4 основных шага в создании плана:
    //-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
    //-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
    //-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
    //-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
    //В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.

    class DataTrain
    {
        Random random = new Random();
        WayTrain wayTrain = new WayTrain();

        private int carriageHowManyPlace;
        private int carriageHowMany;

        public int CarriageHowMany { get { return carriageHowMany; } set { carriageHowMany = value; } }
        public int CarriageHowManyPlace { get { return carriageHowManyPlace; } set { carriageHowManyPlace = value; } }

        public void AddCarriage()
        {
            CarriageHowManyPlace = random.Next(25, 50);
            CarriageHowMany = wayTrain.People / CarriageHowManyPlace;
        }
    }

    class WayTrain
    {
        Random random = new Random();

        private string cityA;
        private string cityB;

        private int people;
        private int distance;

        public string CityA { get { return cityA; } set { cityA = value; } }
        public string CityB { get { return cityB; } set { cityB = value; } }

        public int People { get { return people; } set { people = value; } }
        public int Distance { get { return distance; } set { distance = value; } }

        public void WayCreate()
        {
            Console.WriteLine("Путь поезда. Пункт отправления");
            CityA = Console.ReadLine();
            Console.WriteLine("Путь поезда. Пункт прибытия");
            CityB = Console.ReadLine();

            Distance = random.Next(100, 2000);
        }

        public void AddPeople()
        {
            People = random.Next(200, 300);
        }
    }

    class AppointPrice
    {
        WayTrain wayTrain = new WayTrain();
        Random random = new Random();

        private int priceTicket;
        private int sum;

        public int PriceTicket { get { return priceTicket; } set { priceTicket = value; } }
        public int Sum { get { return sum; } set { sum = value; } }

        public void AddTicketPrice()
        {
            PriceTicket = random.Next(500, 5000);
            Sum = wayTrain.People * PriceTicket;
        }
    }

    class Train
    {
        DataTrain dataTrain = new DataTrain();
        WayTrain wayTrain = new WayTrain();
        AppointPrice appointPrice = new AppointPrice();
        Dictionary<WayTrain, DataTrain> trainList = new Dictionary<WayTrain, DataTrain>();
        public void DisplayTrain()
        {
            foreach (KeyValuePair<WayTrain, DataTrain> valueTrain in trainList)
            {
                Console.WriteLine($"Город отправления: {valueTrain.Key.CityA} - Город прибытия: {valueTrain.Key.CityB}. \n" +
                    $"Дистанция между городами: {valueTrain.Key.Distance}км. Цена на билет: {appointPrice.PriceTicket}руб. \n" +
                    $"Людей купившие билет: {valueTrain.Key.People}. Поезда принесла денег: {appointPrice.Sum}руб. \n" +
                    $"Количество вагонов задействованных в поезде {valueTrain.Value.CarriageHowMany}.");
                Console.WriteLine();
            }
        }

        public void CreateTrain()
        {
            dataTrain.AddCarriage();
            wayTrain.WayCreate();
            wayTrain.AddPeople();
            appointPrice.AddTicketPrice();
            trainList.Add(wayTrain, dataTrain);


            Console.WriteLine($"Город отправления: {wayTrain.CityA} - Город прибытия: {wayTrain.CityB}. \n" +
                $"Дистанция между городами: {wayTrain.Distance}км. Цена на билет: {appointPrice.PriceTicket}руб. \n" +
                $"Людей купившие билет: {wayTrain.People}. Поезда принесла денег: {appointPrice.Sum}руб. \n" +
                $"Количество вагонов задействованных в поезде {dataTrain.CarriageHowMany}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();

            while (true)
            {
                Console.WriteLine("Выберите команду. 1 - Вывести список. 2 - Добавить маршрут.");
                int command = Convert.ToInt32(Console.ReadLine());
                if (command == 1)
                {
                    train.DisplayTrain();
                }
                else if (command == 2)
                {
                    train.CreateTrain();
                }
            }

        }
    }
}