using DatabaseCRUDTask5.EF_Core;
using DatabaseCRUDTask5.Models;
using System;

namespace DatabaseCRUDTask5
{
    public class MainMenu
    {
        private readonly IRepository<Plane, Guid> _planeRepo;
        private readonly IRepository<Passenger, Guid> _passengerRepo;
        private readonly IRepository<Company, Guid> _companyRepo;
        private readonly IRepository<Trip, Guid> _tripRepo;
        private readonly IRepository<PassInTrip, Guid> _passInTripRepo;

        public MainMenu(
            IRepository<Plane, Guid> planeRepo,
            IRepository<Passenger, Guid> passengerRepo,
            IRepository<Company, Guid> companyRepo,
            IRepository<Trip, Guid> tripRepo,
            IRepository<PassInTrip, Guid> passInTripRepo)
        {
            _planeRepo = planeRepo;
            _passengerRepo = passengerRepo;
            _companyRepo = companyRepo;
            _tripRepo = tripRepo;
            _passInTripRepo = passInTripRepo;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Plane");
                Console.WriteLine("2. Passenger");
                Console.WriteLine("3. Company");
                Console.WriteLine("4. Trip");
                Console.WriteLine("5. PassInTrip");
                Console.WriteLine("0. Выход");

                switch (Console.ReadLine())
                {
                    case "1": 
                        ManagePlanes(); 
                        break;
                    case "2": 
                        ManagePassengers(); 
                        break;
                    case "3": 
                        ManageCompanies(); 
                        break;
                    case "4":
                        ManageTrips(); 
                        break;
                    case "5": 
                        ManagePassInTrips(); 
                        break;
                    case "0": 
                        return;
                    default:
                        Console.WriteLine("Промах");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ManagePlanes()
        {
            var menu = new CrudMenu<Plane, Guid>(
                entityName: "Самолет",
                repository: _planeRepo,
                createDelegate: () =>
                {
                    Console.Write("Введите модель самолета: ");
                    string model = Console.ReadLine();

                    return new Plane
                    {
                        Id = Guid.NewGuid(),
                        Model = model
                    };
                },
                updateDelegate: (plane) =>
                {
                    Console.Write($"Новая модель (текущая: '{plane.Model}'): ");
                    string input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        plane.Model = input;
                    }
                }
            );

            menu.Run();
        }

        private void ManagePassengers()
        {
            var menu = new CrudMenu<Passenger, Guid>(
                entityName: "Пассажир",
                repository: _passengerRepo,
                createDelegate: () =>
                {
                    Console.Write("Введите имя пассажира: ");
                    string name = Console.ReadLine();

                    return new Passenger
                    {
                        Id = Guid.NewGuid(),
                        Name = name
                    };
                },
                updateDelegate: (passenger) =>
                {
                    Console.Write($"Новое имя (текущее: '{passenger.Name}'): ");
                    string input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        passenger.Name = input;
                    }
                }
            );

            menu.Run();
        }

        private void ManageCompanies()
        {
            var menu = new CrudMenu<Company, Guid>(
                entityName: "Компания",
                repository: _companyRepo,
                createDelegate: () =>
                {
                    Console.Write("Введите название компании: ");
                    string name = Console.ReadLine();

                    return new Company
                    {
                        Id = Guid.NewGuid(),
                        Name = name
                    };
                },
                updateDelegate: (company) =>
                {
                    Console.Write($"Новое название (текущее: '{company.Name}'): ");
                    string input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        company.Name = input;
                    }
                }
            );

            menu.Run();
        }

        private void ManageTrips()
        {
            var menu = new CrudMenu<Trip, Guid>(
                entityName: "Рейс",
                repository: _tripRepo,
                createDelegate: () =>
                {
                    var trip = new Trip
                    {
                        Id = Guid.NewGuid()
                    };

                    Console.Write("Введите id Компании (Guid): ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid companyId))
                    {
                        trip.CompanyId = companyId;
                    }

                    Console.Write("Id самолета: ");
                    trip.PlaneId = Console.ReadLine();

                    Console.Write("Город вылета: ");
                    trip.TownFrom = Console.ReadLine();

                    Console.Write("Город прилета: ");
                    trip.TownTo = Console.ReadLine();

                    trip.TimeOut = DateTime.Now;
                    trip.TimeIn = DateTime.Now.AddHours(2);

                    return trip;
                },
                updateDelegate: (trip) =>
                {
                    Console.Write($"Город вылета (текущий: '{trip.TownFrom}'): ");
                    string from = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(from))
                    {
                        trip.TownFrom = from;
                    }

                    Console.Write($"Город прилета (текущий: '{trip.TownTo}'): ");
                    string to = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(to))
                    {
                        trip.TownTo = to;
                    }
                }
            );

            menu.Run();
        }

        private void ManagePassInTrips()
        {
            var menu = new CrudMenu<PassInTrip, Guid>(
                entityName: "Билет / Посадка",
                repository: _passInTripRepo,
                createDelegate: () =>
                {
                    Console.Write("Введите id Пассажира (Guid): ");
                    Guid.TryParse(Console.ReadLine(), out Guid passengerId);

                    Console.Write("Введите id Рейса (Guid): ");
                    Guid.TryParse(Console.ReadLine(), out Guid tripId);

                    Console.Write("Место: ");
                    string place = Console.ReadLine();

                    return new PassInTrip
                    {
                        Id = Guid.NewGuid(),
                        PassengerId = passengerId,
                        TripId = tripId,
                        Place = place
                    };
                },
                updateDelegate: (passInTrip) =>
                {
                    Console.Write($"Новое место (текущее: '{passInTrip.Place}'): ");
                    string place = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(place))
                    {
                        passInTrip.Place = place;
                    }
                }
            );

            menu.Run();
        }
    }
}
    