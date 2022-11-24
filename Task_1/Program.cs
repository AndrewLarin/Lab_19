using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PC> pc = new List<PC>()
            {
                new PC(){ID=1, Name="ACER 1", Processor="i8", Frequency=3.1, Storage=1024, RAM=8, Video=8192, Price=54985, Stock=41},
                new PC(){ID=2, Name="MSI 1", Processor="i9", Frequency=2.3, Storage=1024, RAM=16, Video=6144, Price=67468, Stock=24},
                new PC(){ID=3, Name="Apple 1", Processor="i10", Frequency=3.3, Storage=512, RAM=8, Video=4096, Price=89435, Stock=51},
                new PC(){ID=4, Name="ASUS 1", Processor="Ryzen 9", Frequency=3.2, Storage=512, RAM=16, Video=4096, Price=84384, Stock=43},
                new PC(){ID=5, Name="Dell 1", Processor="i5", Frequency=5.0, Storage=2048, RAM=8, Video=8192, Price=64361, Stock=32},
                new PC(){ID=6, Name="Xiaomi 1", Processor="i5", Frequency=3.2, Storage=512, RAM=16, Video=4096, Price=64386, Stock=53},
                new PC(){ID=7, Name="DELL 2", Processor="i9", Frequency=5.2, Storage=2048, RAM=8, Video=8192, Price=112548, Stock=64},
                new PC(){ID=8, Name="Apple 2", Processor="i7", Frequency=2.8, Storage=512, RAM=16, Video=4096, Price=99999, Stock=99},
                new PC(){ID=9, Name="MSI 3", Processor="i8", Frequency=3.2, Storage=2048, RAM=8, Video=6144, Price=55555, Stock=38}
            };

            Console.WriteLine("Введите процессор");
            string processor = Console.ReadLine();
            List<PC> pc1 = pc.Where(x => x.Processor == processor).ToList();
            Print(pc1);

            Console.WriteLine("Показать объем ОЗУ не ниже, чем указано");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<PC> pc2 = pc.Where(x => x.RAM >= ram).ToList();
            Print(pc2);

            Console.WriteLine("Вывести отсортированный по цене список");
            List<PC> pc3 = pc.OrderBy(x => x.Price).ToList();
            Print(pc3);

            IEnumerable<IGrouping<string, PC>> pc4 = pc.GroupBy(x => x.Processor);
            foreach (IGrouping<string, PC> gr in pc4)
            {
                Console.WriteLine(gr.Key);
                foreach (PC e in gr)
                {
                    Console.WriteLine($"{e.ID} {e.Name}, {e.Processor}, {e.Frequency} ГГц, {e.RAM} ГБ," +
                    $" {e.Storage} ГБ, {e.Video} ГБ, {e.Price} у.е.");
                }
            }

            PC pc5 = pc.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine("Самый дорогой ПК: ");
            Console.WriteLine($"{pc5.ID} {pc5.Name} {pc5.Processor} {pc5.Price} у.е.");

            PC pc6 = pc.OrderByDescending(x => x.Price).LastOrDefault();
            Console.WriteLine("Самый бюджетный ПК: ");
            Console.WriteLine($"{pc6.ID} {pc6.Name} {pc6.Processor} {pc6.Price} у.е.");


            Console.WriteLine("Есть ПК в количестве не менее 30 штук: " + pc.Any(x => x.Stock >= 30));

            Console.ReadKey();
        }

        static void Print(List<PC> pc)
        {
            foreach (PC e in pc)
            {
                Console.WriteLine($"{e.ID} {e.Name}, {e.Processor}, {e.Frequency} ГГц, {e.RAM} ГБ," +
                    $" {e.Storage} ГБ, {e.Video} ГБ, {e.Price} у.е. \nв наличии {e.Stock} шт.");
            }
            Console.WriteLine();
        }
    }
}
