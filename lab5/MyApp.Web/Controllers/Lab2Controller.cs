using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MyApp.Web.Models;

namespace MyApp.Web.Controllers
{
    public class Lab2Controller : Controller
    {
        public IActionResult Index()
        {
            var model = new Lab2ViewModel
            {
                TaskNumber = 2,
                TaskVariant = 32,
                TaskDescription = "Розглянемо нескінченну праворуч і вгору шахівницю, на якій стоїть ферзь. Двоє по черзі рухають цього ферзя. Дозволяється рухати ферзя тільки вниз, вліво або діагоналі вниз вліво на будь-яку позитивну кількість клітин у вибраному напрямку. Мета гри – засунути ферзя у кут, тобто клітину з координатами (1, 1). На малюнку показані дозволені рухи ферзя. Потрібно написати програму, яка знайде номер гравця, який виграє за правильної гри.",
                InputDescription = "Вхідний файл INPUT.TXT містить координати ферзя перед першим ходом - два числа M і N, записані через пропуск (1 ≤ M, N ≤ 250). Гарантується, що ферзь спочатку не знаходиться у клітині з координатами (1,1).",
                OutputDescription = "Вихідний файл OUTPUT.TXT повинен мати знайдений номер переможця.",
                TestCases = new List<TestCase2>
                {
                    new TestCase2 { Input = "3 3", Output = "1" },
                    new TestCase2 { Input = "2 4", Output = "2" }
                }
            };
            return View("Lab2", model);
        }

        [HttpPost]
        public IActionResult ProcessLab(Lab2ViewModel model)
        {
            string[] input = model.Input.Split();
            int M = int.Parse(input[0]);
            int N = int.Parse(input[1]);

            bool[,] dp = new bool[M + 1, N + 1];

            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (i == 1 && j == 1) continue;
                    bool hasLosingMove = false;

                    for (int k = 1; k < i; k++)
                    {
                        if (!dp[k, j])
                        {
                            hasLosingMove = true;
                            break;
                        }
                    }
                    if (!hasLosingMove)
                    {
                        for (int k = 1; k < j; k++)
                        {
                            if (!dp[i, k])
                            {
                                hasLosingMove = true;
                                break;
                            }
                        }
                    }
                    if (!hasLosingMove)
                    {
                        for (int k = 1; k < Math.Min(i, j); k++)
                        {
                            if (!dp[i - k, j - k])
                            {
                                hasLosingMove = true;
                                break;
                            }
                        }
                    }
                    dp[i, j] = hasLosingMove;
                }
            }
            int winner = dp[M, N] ? 1 : 2;
            model.Output = winner.ToString();
            return View(model);
        }
    }
}
