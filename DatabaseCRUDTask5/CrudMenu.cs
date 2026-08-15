using System;
using DatabaseCRUDTask5.Models;

namespace DatabaseCRUDTask5.EF_Core
{
    public class CrudMenu<T, TId> where T : class
    {
        private readonly string _entityName;
        private readonly IRepository<T, TId> _repository;
        private readonly Func<T> _createDelegate;
        private readonly Action<T> _updateDelegate;

        public CrudMenu( string entityName,IRepository<T, TId> repository, Func<T> createDelegate, Action<T> updateDelegate)
        {
            _entityName = entityName;
            _repository = repository;
            _createDelegate = createDelegate;
            _updateDelegate = updateDelegate;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{_entityName}");
                Console.WriteLine("1 показать все записи");
                Console.WriteLine("2 найти по ID");
                Console.WriteLine("3 добавить");
                Console.WriteLine("4 редактировать");
                Console.WriteLine("5 удалить");
                Console.WriteLine("0 назад");

                switch (Console.ReadLine())
                {
                    case "1": 
                        ShowAll();
                        break;
                    case "2": 
                        ShowById(); 
                        break;
                    case "3": 
                        Add(); 
                        break;
                    case "4": 
                        Update(); 
                        break;
                    case "5":
                        Delete(); 
                        break;
                    case "0": 
                        return;
                    default: 
                        Wait("Промах"); 
                        break;
                }
            }
        }

        private void ShowAll()
        {
            Console.Clear();
            Console.WriteLine($"Список: {_entityName}");
            var items = _repository.GetAll();

            foreach (var item in items) 
            {  
                Console.WriteLine(item); 
            }

            Wait();
        }

        private void ShowById()
        {
            Console.Clear();
            if (TryReadGuid("Введите id:", out Guid id))
            {
                var item = _repository.GetById((TId)(object)id);
                if (item != null)
                    Console.WriteLine($"\nНайден: {item}");
                else
                    Console.WriteLine("\nне найдено");
            }
            Wait();
        }

        private void Add()
        {
            Console.Clear();
            Console.WriteLine($"Добавление {_entityName}");
            T newItem = _createDelegate(); 
            _repository.Add(newItem);
            Console.WriteLine("\nДобавлено!");
            Wait();
        }

        private void Update()
        {
            Console.Clear();
            Console.WriteLine($"Обновлнеие для ({_entityName})");
            if (TryReadGuid("Введите его id: ", out Guid id))
            {
                var item = _repository.GetById((TId)(object)id);
                if (item == null)
                {
                    Console.WriteLine("не найдено");
                }
                else
                {
                    _updateDelegate(item); 
                    _repository.Update(item);
                    Console.WriteLine("\nНайден");
                }
            }
            Wait();
        }

        private void Delete()
        {
            Console.Clear();
            Console.WriteLine($"Удаление ({_entityName})");
            if (TryReadGuid("Введите id для удаления: ", out Guid id))
            {
                _repository.Delete((TId)(object)id);
                Console.WriteLine("\nУдалено");
            }
            Wait();
        }

        private bool TryReadGuid(string prompt, out Guid result)
        {
            Console.Write(prompt);
            return Guid.TryParse(Console.ReadLine(), out result);
        }

        private void Wait(string msg = "\n......жмяк......")
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }
    }
}