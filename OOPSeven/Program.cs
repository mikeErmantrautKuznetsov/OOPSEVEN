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

        private int carriageHowManyPlace;
        private int carriageHowMany;
        private int people;
        private int priceTicket;
        private int sum;
        private int distance;

        private string cityA;
        private string cityB;

        public string CityA { get { return cityA; } set { cityA = value; } }
        public string CityB { get { return cityB; } set { cityB = value; } }

        public int Distance { get { return distance; } set { distance = value; } }
        public int CarriageHowMany { get { return carriageHowMany; } set { carriageHowMany = value; } }
        public int CarriageHowManyPlace { get { return carriageHowManyPlace; } set { carriageHowManyPlace = value; } }
        public int People { get { return people; } set { people = value; } }
        public int PriceTicket { get { return priceTicket; } set { priceTicket = value; } }
        public int Sum { get { return sum; } set { sum = value; } }

        public void AddCarriage()
        {
            People = random.Next(200, 300);
            CarriageHowManyPlace = random.Next(25, 50);
            CarriageHowMany = People / CarriageHowManyPlace;
        }

        public void AddTicketPrice()
        {
            PriceTicket = random.Next(500, 5000);
            Sum = People * PriceTicket;
        }

        public void WayCreate()
        {
            Console.WriteLine("Путь поезда. Пункт отправления");
            CityA = Console.ReadLine();
            Console.WriteLine("Путь поезда. Пункт прибытия");
            CityB = Console.ReadLine();

            Distance = random.Next(100, 2000);
        }
    }

    class Train
    {
        DataTrain dataTrain = new DataTrain(); 
        List<DataTrain> trainList = new List<DataTrain>();
        public void DisplayTrain()
        {
            foreach (DataTrain valueTrain in trainList)
            {
                Console.WriteLine($"Город отправления: {valueTrain.CityA} - Город прибытия: {valueTrain.CityB}. \n" +
                    $"Дистанция между городами: {valueTrain.Distance}км. Цена на билет: {dataTrain.PriceTicket}руб. \n" +
                    $"Людей купившие билет: {valueTrain.People}. Поезда принесла денег: {dataTrain.Sum}руб. \n" +
                    $"Количество вагонов задействованных в поезде {valueTrain.CarriageHowMany}.");
                Console.WriteLine();
            }
        }

        public void CreateTrain()
        {
            dataTrain.AddCarriage();
            dataTrain.WayCreate();
            dataTrain.AddTicketPrice();
            trainList.Add(dataTrain);

            Console.WriteLine($"Город отправления: {dataTrain.CityA} - Город прибытия: {dataTrain.CityB}. \n" +
                $"Дистанция между городами: {dataTrain.Distance}км. Цена на билет: {dataTrain.PriceTicket}руб. \n" +
                $"Людей купившие билет: {dataTrain.People}. Поезда принесла денег: {dataTrain.Sum}руб. \n" +
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
                if (command == (int)ChoiceInput.DisplayList)
                {
                    train.DisplayTrain();
                }
                else if (command == (int)ChoiceInput.AddWay)
                {
                    train.CreateTrain();
                }
            }

        }
    }
}

enum ChoiceInput
{
    DisplayList = 1,
    AddWay
}