using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Animals
    {
        public string Name { get; set; }
        //public int Weight { get; set; }
        public string Class { get; set; }
    }
    class Owner
    {
        public string Name { get; set; }
        public string Animal { get; set; }
    }
    class Collections
    {
        delegate int Test();
        public static void ArrayList()
        {
            Test _test;
            _test = Del;
            ArrayList list = new ArrayList() { 1, 3, "ssw", 1.2 };
            list.Add("sss");
            list.Add(_test());
            Print.prnt(list);
        }

        public static void List()
        {
            List<double> numbers = new List<double>() { 1.2, 2.0, 3.1, 4.5 };
            List<double> numberexample = new List<double>() { 2.0, 3.1 };
            numbers.Add(32.1);
            numbers.AddRange(new double[] { 7.1, 0.8, 9.3 });
            numbers.Sort();
            //Print.prnt(numbers);
            Console.WriteLine();
            var count = numbers.Where(t => t < 2);
            var countLet = from t in numbers
                           let dob = 1 + t                           //<<--------- действия до выборки
                           orderby dob descending               //<<---------  сортировка по убыванию                           
                           select dob;

            var except = numbers.Except(numberexample);             //<<---------  разность двух множеств
            var intersect = numbers.Intersect(numberexample);        //<<---------  Пересечение множеств
            var union = from t in numbers.Union(numberexample) orderby t descending select t; ;        //<<---------  Объединение  множеств по убыванию
            var aggregate = from t in numbers where t < 3 select t;                             //
            var z = aggregate.Aggregate((x, y) => x + y);                                      //<<---------  выполнение с каждым елементом                 
            int size = aggregate.Count();                                                     //<<--------- Кол-во элементов
            double sum = numbers.Sum();                     //<<--------- Сумма
            double min = numbers.Min();                     //<<--------- минимальное значение 
            double max = numbers.Max();                     //<<--------- максимальное значение 
            double average = numbers.Average();                     //<<--------- среднее значение 

            var takewhile = from t in numbers.TakeWhile(k => k < 5) select t;               //<<--------- выборка по условию
            var skipwhile = from t in numbers.SkipWhile(k => k < 5) select t;               //<<--------- пропуск пока не сработает условие

            Console.WriteLine("Все меньше 2 " + numbers.All(t => t < 2));                 //<<--------- Метод All
            Console.WriteLine("Хоть один да меньше 2 " + numbers.Any(t => t < 2));
            Console.WriteLine("А был ли 0.8? " + numbers.Contains(0.8));
            /*foreach (var item in skipwhile)
            {
                Console.WriteLine(item);
            }*/

        }
        public static void List1()
        {
            List<Animals> animals = new List<Animals>
                {
                    new Animals {Name="Жорик", Class="Dog" },
                    new Animals {Name="Куцык", Class="Cat" },
                    new Animals {Name="Антуан", Class="Dog" },
                    new Animals {Name="Нолик", Class="Rabbit" },
                    new Animals {Name="Килька", Class="Rat" },
                    new Animals {Name="Автобус", Class="Dog" },
                    new Animals {Name="Сарделя", Class="Bear" },
                    new Animals {Name="Язик", Class="Cat" }
                };

            List<Owner> owner = new List<Owner>
                {
                    new Owner {Name="Наташя", Animal="Bear" },
                    new Owner {Name="Ярослявя", Animal="Cat" },
                    new Owner {Name="Семен!", Animal="Dog" }
                };
            var animal = from t in animals
                         group t by t.Class;                                                                         //<<--------- Group

            var result = from a in animals
                         join o in owner on a.Class equals o.Animal                                         //<<--------- Join
                         select new { Nam = o.Name, Anima = a.Class };

            var ressult = owner.GroupJoin(                                                                  //<<--------- GroupJoin
                                animals,
                                t => t.Animal,
                                o => o.Class,
                                (ani, ow) => new
                                {
                                    Animalt = ani.Animal,
                                    Owners = ow.Select(z => z.Name)
                                }
                );
            var result3 = animals.Zip(owner,                                                             //<<--------- Zip
                          (a, o) => new
                          {
                              Name = a.Class,
                              Anim = o.Animal
                          });
            /*foreach (var item in result3)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.Anim);

                Console.WriteLine();
            }
            foreach (var item in ressult)
            {
                Console.WriteLine(item.Animal);
                foreach (string ow in item.Owners)
                {
                    Console.WriteLine(ow);
                }
                Console.WriteLine();
            }
            foreach (var item in result)
            {
                Console.WriteLine("{0} {1}", item.Nam, item.Anima);
            }            
            foreach (IGrouping<string, Animals> g in animal)
            {
                Console.WriteLine(g.Key);
                foreach (var item in g)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine();
            }*/

        }

        public static void LinkedListNode()
        {
            LinkedList<string> persons = new LinkedList<string>();
            persons.AddLast("Last");
            persons.AddFirst("First");
            persons.AddAfter(persons.First, "middle0");
            persons.AddAfter(persons.First, "middle1");
            persons.AddAfter(persons.First, "middle2");
            /*foreach (var item in persons)
            {

                Console.WriteLine(item);
            }
            Console.WriteLine(persons.Count());*/
            var take = persons.Take(3);                               //<<--------- выборка первых трех элементов
            var skip = persons.Skip(4).Take(3);                         //<<--------- выборка первых трех элементов после пропуска четырех
            foreach (var item in skip)
            {
                Console.WriteLine(item);
            }
        }
        public static void Queue()
        {
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("First");
            numbers.Enqueue("middle0");
            numbers.Enqueue("middle1");
            numbers.Enqueue("middle2");
            numbers.Enqueue("Last");
            numbers.Dequeue();
            numbers.Dequeue();
            numbers.Dequeue();
            foreach (var item in numbers)
            {

                Console.WriteLine(item);
            }
        }

        public static void Stack()
        {
            Stack<string> numbers = new Stack<string>();
            numbers.Push("First");
            numbers.Push("middle0");
            numbers.Push("middle1");
            numbers.Push("middle2");
            numbers.Push("Last");
            numbers.Pop();
            Console.WriteLine(numbers.Peek());
            Console.WriteLine(numbers.Peek());
            numbers.Pop();
            numbers.Pop();
            foreach (var item in numbers)
            {

                Console.WriteLine(item);
            }
        }

        public static void Dictionary()
        {
            Dictionary<string, string> names = new Dictionary<string, string>
            {
                ["Женщин0"] = "Андрей",
                ["Женщин1"] = "Василь",
                ["Женщин2"] = "Петро",
                ["Мущин1"] = "Роман",
                ["Мущин2"] = "Назар",
                ["Мущин3"] = "Рихат",
            };

            foreach (var item in names)
            {
                Console.WriteLine(item.Value);
            }
        }

        public static void ObservableCollection()
        {
            ObservableCollection<int> numb = new ObservableCollection<int>();
            numb.Add(1);
            numb.Add(2);
            numb.Add(3);
            numb.Add(4);
            numb.Add(5);
            numb.CollectionChanged += numb_CollectionChanged;
            numb.Add(63);
            numb.Remove(63);
            numb[0] = 3;
            foreach (var item in numb)
            {
                Console.WriteLine(item);
            }

            void numb_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        int z = e.NewStartingIndex;
                        Console.WriteLine("Добавлен новый объект: {0}", numb[z]);
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                                                               // numb[0] = e.OldItems[0] as User;

                        int k = e.OldStartingIndex;

                        Console.WriteLine("Удален объект: {0} ", k);
                        break;
                    case NotifyCollectionChangedAction.Replace: // если замена
                                                                // numb[0] = e.OldItems[0] as numb<int>;
                                                                // numb[1] = e.NewItems[0] as User;
                        int j = e.NewStartingIndex;
                        int o = e.OldStartingIndex;
                        Console.WriteLine("Объект {0} заменен значением {1}",
                                           j, numb[o]);
                        break;
                }
            }
        }

        public static void IEnumerable()
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                         "Friday", "Saturday", "Sunday" };
            foreach (var item in days)
            {
                Console.WriteLine(item);
            }
            /*public IEnumerator GetEnumerator()
            {
                return days.GetEnumerator();
            }*/
        }

        private static int Del()
        {
            Console.WriteLine("Delegat");
            return 1;
        }


    }
}
