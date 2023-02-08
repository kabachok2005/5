namespace prac_5_cakes
{
    internal class Program
    {
        private static int price = 0;
        private static string order = null;
        static void Main(string[] args)
        {
            
            Again();
        }
        static void Again()
        {
            Console.Clear();
            Console.WriteLine("Кондитерская. Добро пожаловать.");
            EachItem();
        }
        private static void ShowMenu(List<MainMenu> menuList)
        {
            int position = 0;
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();

                foreach (MainMenu each in menuList)
                {
                    Console.WriteLine("   " + each.Name);
                }
                Console.WriteLine("\n" + "Нажмите k для окончания заказа");

                Console.WriteLine("\n" + "Заказ: " + order);
                Console.WriteLine("Цена: " + price);

                position = Arrow(key, position, menuList);
                key = Console.ReadKey();
            }
            Console.Clear();
           
            ShowAddMenu(menuList[position], menuList);
        }
        static void ShowAddMenu(MainMenu OneMoreEach, List<MainMenu> menuList)
        {
            int position = 0;
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();

                foreach (MiniMenu each in OneMoreEach.MiniMenu)
                {
                    Console.WriteLine("   " + each.Title + " = " + each.Cost);
                }

                position = Arrow(key, position, menuList);
                key = Console.ReadKey();
            }
            Console.Clear();
            Order(OneMoreEach.MiniMenu[position]);
            
        }
        static int Arrow(ConsoleKeyInfo key, int position, List<MainMenu> menuList)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    position--;
                    break;
                case ConsoleKey.DownArrow:
                    position++;
                    break;
                case ConsoleKey.LeftArrow:
                    
                    ShowMenu(menuList);
                    break;
                case ConsoleKey.K:
                    Save();
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine("Вы вышли.");
                    Environment.Exit(Environment.ExitCode);
                    break;
            }
            Console.SetCursorPosition(0, position);
            Console.WriteLine(" → ");
            return position;
        }

        private static void Order(MiniMenu form)
        {
            price += form.Cost;
            order = order + form.Title + ", ";
        }

        private static void Save()
        {

            string Zakaz = "Заказ от " + DateTime.Now + "\n\t Заказ: " + Program.order + "\n\t Цена: " + Program.price + "\n";
            File.AppendAllText("C:\\Users\\klika\\OneDrive\\Рабочий стол\\cake.json", Zakaz);
            Console.WriteLine("Заказ сохранен. Чтобы оформить еще заказ нажмите esc");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                price = 0;
                order = null;
                Again();
            }
        }
        private static void EachItem()
        {
            while (true)
            {
                MiniMenu form1 = new("Куб", 100);
                MiniMenu form2 = new("Шар", 200);
                MiniMenu form3 = new("Треугольник", 300);
                MiniMenu amount1 = new("Один", 100);
                MiniMenu amount2 = new("Два", 200);
                MiniMenu amount3 = new("Три", 300);
                MiniMenu size1 = new("1 кг", 100);
                MiniMenu size2 = new("3 кг", 200);
                MiniMenu size3 = new("5 кг", 300);
                MiniMenu taste1 = new("Шоколадный", 100);
                MiniMenu taste2 = new("Ванильный", 200);
                MiniMenu taste3 = new("Фисташковый", 300);
                MiniMenu glazyr1 = new("Белая", 100);
                MiniMenu glazyr2 = new("Синяя", 200);
                MiniMenu glazyr3 = new("Красная", 300);
                MiniMenu decor1 = new("Крутой", 300);
                MiniMenu decor2 = new("АнтиКрутой", 300);
                MiniMenu decor3 = new("МегаКрутой", 300);
                MainMenu form = new("Форма", new List<MiniMenu>() { form1, form2, form3 });
                MainMenu amount = new("Количество коржей", new List<MiniMenu>() { amount1, amount2, amount3 });
                MainMenu size = new("Размер", new List<MiniMenu>() { size1, size2, size3 });
                MainMenu taste = new("Вкус", new List<MiniMenu>() { taste1, taste2, taste3 });
                MainMenu glaze = new("Глазурь", new List<MiniMenu>() { glazyr1, glazyr2, glazyr3 });
                MainMenu decor = new("Декор", new List<MiniMenu>() { decor1, decor2, decor3 });

                List<MainMenu> menuList = new() { form, size, taste, amount, glaze, decor };

                ShowMenu(menuList);
            }
        }
    }
}