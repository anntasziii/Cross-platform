using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MyApp.Web.Models;

namespace MyApp.Web.Controllers
{
    public class Lab1Controller : Controller
    {
        public IActionResult Index()
        {
            var model = new Lab1ViewModel
            {
                TaskNumber = 1,
                TaskVariant = 32,
                TaskDescription = "Одного неформала вигнали з роботи, і тепер йому треба якось заробляти собі життя. Подумавши, він вирішив, що зможе мати дуже непогані гроші на продажі свого волосся. Відомо, що пункти прийому купують волосся довільної довжини вартістю C у. за кожний сантиметр. Так як волосяний ринок є дуже динамічним, то ціна одного сантиметра волосся змінюється щодня, як і курс валют. Неформал є дуже добрим бізнес-аналітиком. Він зміг обчислити, якою буде ціна одного сантиметра волосся в кожен із найближчих N днів (для зручності пронумеруємо дні у хронологічному порядку від 0 до N-1). Тепер він хоче визначити, які з цих днів йому слід продавати волосся, щоб після закінчення всіх N днів заробити максимальну кількість грошей.",
                InputDescription = "Вхідний файл INPUT.TXT містить два числа N та C[i] — кількість днів і ціни на волосся в ці дні відповідно.",
                OutputDescription = "Вихідний файл OUTPUT.TXT повинен містити максимальну суму, яку може заробити неформал за N днів.",
                TestCases = new List<TestCase1>
                {
                    new TestCase1 { Input = "3\n3 4 2", Output = "12" },
                    new TestCase1 { Input = "4\n1 1 1 1", Output = "4" }
                }
            };
            return View("Lab1", model);
        }

        [HttpPost]
        public IActionResult ProcessLab(Lab1ViewModel model)
        {
            string[] input = model.Input.Split();
            int N = int.Parse(input[0]);
            int[] C = new int[N];
            for (int i = 0; i < N; i++)
            {
                C[i] = int.Parse(input[i + 1]);
            }

            int maxSum = 0;
            int currentLength = 0;

            for (int i = 0; i < N; i++)
            {
                currentLength++;
                maxSum += currentLength * C[i];
            }

            model.Output = maxSum.ToString();
            return View(model);
        }
    }
}
