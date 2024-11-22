using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace MyApp.Web.Controllers
{
    public class Lab1Controller : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RunLab1(string inputData)
        {
            // Парсинг вхідних даних
            var inputs = inputData.Split('\n');
            int N = int.Parse(inputs[0]);
            int[] prices = inputs[1].Split(' ').Select(int.Parse).ToArray();

            int[] maxPricesFromToday = new int[N];
            maxPricesFromToday[N - 1] = prices[N - 1];

            for (int i = N - 2; i >= 0; i--)
            {
                maxPricesFromToday[i] = Math.Max(prices[i], maxPricesFromToday[i + 1]);
            }

            int totalProfit = 0;
            int hairLength = 0;

            for (int i = 0; i < N; i++)
            {
                hairLength++;
                if (prices[i] == maxPricesFromToday[i])
                {
                    totalProfit += hairLength * prices[i];
                    hairLength = 0;
                }
            }

            // Відправка результату на вигляд
            ViewBag.Result = totalProfit;
            return View("Lab1");
        }
    }
}
