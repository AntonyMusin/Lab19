using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public int Code { get; set; }
        public string Brand { get; set; }
        public string CpuType { get; set; }
        public int CpuFrequency { get; set; }
        public int RamCapacity { get; set; }
        public int HddCapacity { get; set; }
        public int VideoCapacity { get; set; }
        public int Cost { get; set; }
        public int Availability { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> ListComputer = new List<Computer>()
            {
                new Computer(){Code=101,Brand="Dell",CpuType="Intel Core i3",CpuFrequency=2200,RamCapacity=8192,HddCapacity=128,VideoCapacity=2048,Cost=25000,Availability=15},
                new Computer(){Code=102,Brand="HP",CpuType="Intel Core i3",CpuFrequency=3600,RamCapacity=8192,HddCapacity=256,VideoCapacity=2048,Cost=29000,Availability=5},
                new Computer(){Code=103,Brand="HP",CpuType="Intel Core i5",CpuFrequency=4900,RamCapacity=12288,HddCapacity=256,VideoCapacity=4096,Cost=50000,Availability=12},
                new Computer(){Code=104,Brand="Dell",CpuType="AMD Ryzen 5",CpuFrequency=3900,RamCapacity=10240,HddCapacity=512,VideoCapacity=1024,Cost=21000,Availability=7},
                new Computer(){Code=105,Brand="ASUS",CpuType="AMD Rysen 5",CpuFrequency=3900,RamCapacity=8192,HddCapacity=512,VideoCapacity=1024,Cost=19000,Availability=3},
                new Computer(){Code=106,Brand="MSI",CpuType="Intel Core i7",CpuFrequency=5000,RamCapacity=16384,HddCapacity=1024,VideoCapacity=4096,Cost=70000,Availability=2},
                new Computer(){Code=107,Brand="Lenovo",CpuType="Intel Core i3",CpuFrequency=3600,RamCapacity=4096,HddCapacity=128,VideoCapacity=1024,Cost=17000,Availability=5},
                new Computer(){Code=108,Brand="ASUS",CpuType="AMD Ryzen 7",CpuFrequency=3600,RamCapacity=8192,HddCapacity=1024,VideoCapacity=2048,Cost=27000,Availability=11},
            };
            Console.WriteLine("Введите тип процессора:");
            string CpuTypeString = Console.ReadLine();
            List<Computer> computers1 = (from d in ListComputer
                                         where d.CpuType == CpuTypeString
                                         select d).ToList();
            foreach (var item in computers1)
            {
                Console.WriteLine($"{item.Code} {item.Brand} {item.CpuType} {item.CpuFrequency} {item.RamCapacity} {item.HddCapacity} {item.VideoCapacity} {item.Cost} {item.Availability}");
            }
            Console.ReadKey();

            Console.WriteLine("Введите объем ОЗУ:");
            int RamCapacityString = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = (from e in ListComputer
                                         where e.RamCapacity > RamCapacityString
                                         select e).ToList();
            foreach (var item in computers2)
            {
                Console.WriteLine($"{item.Code} {item.Brand} {item.CpuType} {item.CpuFrequency} {item.RamCapacity} {item.HddCapacity} {item.VideoCapacity} {item.Cost} {item.Availability}");
            }
            Console.ReadKey();

            Console.WriteLine("Отсортированный список по стоимости:");
            List<Computer> computers3 = (from f in ListComputer
                                         orderby f.Cost
                                         select f).ToList();
            foreach (var item in computers3)
            {
                Console.WriteLine($"{item.Code} {item.Brand} {item.CpuType} {item.CpuFrequency} {item.RamCapacity} {item.HddCapacity} {item.VideoCapacity} {item.Cost} {item.Availability}");
            }
            Console.ReadKey();

            Console.WriteLine("Группированный список по типу процессора:");
            var computers4 = from g in ListComputer
                              group g by g.CpuType;
            foreach (IGrouping<string, Computer> g in computers4)
            {
                foreach (var item in g)
                {
                    Console.WriteLine($"{item.Code} {item.Brand} {item.CpuType} {item.CpuFrequency} {item.RamCapacity} {item.HddCapacity} {item.VideoCapacity} {item.Cost} {item.Availability}");
                }
            }
            Console.ReadKey();

            Console.WriteLine("Находим самый дорогой и самый дешевый компьютер");
            int minCost = ListComputer.Min(n => n.Cost);
            Console.WriteLine(minCost);
            int maxCost = ListComputer.Max(n => n.Cost);
            Console.WriteLine(maxCost);
            List<Computer> computers5 = (from k in ListComputer
                                         where k.Cost == maxCost || k.Cost == minCost
                                         select k).ToList();
            foreach (var item in computers5)
            {
                Console.WriteLine($"{item.Code} {item.Brand} {item.CpuType} {item.CpuFrequency} {item.RamCapacity} {item.HddCapacity} {item.VideoCapacity} {item.Cost} {item.Availability}");
            }
            Console.ReadKey();

            Console.WriteLine("Проверяем наличие хотя бы одного компьтера в кличестве >= 30 шт.");
            var computer6 = (from i in ListComputer
                             where i.Availability > 29
                             select i).Count();
            Console.WriteLine("Количество компьтеров удовлетворяющих условию:{0}",computer6);
            Console.ReadKey();
        }
    }
}
