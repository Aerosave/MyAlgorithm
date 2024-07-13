using MyAlgorithm.BD;
using System.Runtime.ConstrainedExecution;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase users = new DataBase();

            while (true)
            {
                // Ввод логина и проверка премиум-статуса
                Console.WriteLine("Введите 'Login' от своей учетной записи. Пароль не нужен, мы вам и так верим:");
                string login = Console.ReadLine();
                User user = users.GetUserByLogin(login);

                if (user == null)
                {
                    ShowAds();
                    Console.WriteLine("Пользователь не найден. Попробуйте снова.");
                    continue; // Возвращаемся в начало цикла
                }

                switch (user)
                {
                    case User u when u.IsPremium:
                        Console.WriteLine($"Добрый день, {user.Name}");
                        break;
                    default:
                        ShowAds();
                        Console.WriteLine($"Добрый день, {user.Name}");
                        Thread.Sleep(1000);
                        Console.WriteLine("Хотите купить премиум? (да/нет)");
                        string response = Console.ReadLine();
                        if (response.ToLower() == "да")
                        {
                            BuyPremium(user);
                            Console.WriteLine("Премиум-статус успешно активирован!");
                        }
                        break;
                }
                while (true)
                {
                    Console.WriteLine("Хотите попробовать снова? (да/нет)");
                    string responsecontin = Console.ReadLine();
                    if (responsecontin.ToLower() == "да")
                    {
                        break; // Возвращаемся в начало цикла
                    }
                    else if (responsecontin.ToLower() == "нет")
                    {
                        Console.WriteLine("Прощайте!!!");
                        Thread.Sleep(3000);
                        return; // Выход из программы
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, введите 'да' или 'нет'.");
                    }
                }
            }

        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }

        static void BuyPremium(User user) 
        {

            user.IsPremium = true;

        }

        
    }
}
