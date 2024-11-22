using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MyApp.Web.Models;

namespace MyApp.Web.Controllers
{
    public class Lab3Controller : Controller
    {
        public IActionResult Index()
        {
            var model = new Lab3ViewModel
            {
                TaskNumber = 2,
                TaskVariant = 32,
                TaskDescription = "Зовсім недавно Алі-Баба дізнався від свого брата Касіма про дивовижну гру Го. У Го грають на прямокутній дошці – гобані, розкресленому вертикальними та горизонтальними лініями. Усі лінії пронумеровані. У грі беруть участь два гравці, які по черзі виставляють на гобан каміння – спеціальні круглі фішки. Кожен камінь ставиться на незайняту точку перетину ліній дошки (перетину називають пунктами). У одного гравця – чорне каміння, у іншого – білі. Камені одного кольору, суміжні по вертикалі або по горизонталі (але не діагоналі), об'єднуються в групу. Поодинокий камінь також вважається групою.",
                InputDescription = "Вхідний файл INPUT.TXT містить ціле число N – розмірність ігрової дошки (6 ≤ N ≤ 19). Далі слідує N рядків по N символів кожен. Кожен символ визначає один пункт дошки. \"B\" означає чорний камінь, \"W\" - білий, \".\" означає порожній пункт. Усі групи на дошці мають хоча б одне даме.",
                OutputDescription = "Вихідний файл OUTPUT.TXT виводить одне число - кількість груп чорних каменів, що знаходяться в атарі.",
                TestCases = new List<TestCase3>
                {
                    new TestCase3 { Input = "9\n.........\n.........\n.........\n...WW....\n...BW.B..\nB..W.W...\nB...WBW..\n....WBW..\nW....BW..", Output = "2" }
                }
            };
            return View("Lab3", model);
        }

        [HttpPost]
        public IActionResult ProcessLab(Lab3ViewModel model)
        {
            string[] input = model.Input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int N = int.Parse(input[0]);
            char[,] board = new char[N, N];

            // Заповнення дошки
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = input[i + 1][j];
                }
            }

            // Логіка для пошуку груп чорних каменів, які знаходяться в атарі
            bool[,] visited = new bool[N, N];
            int atariCount = 0;

            // Операції на сусідів
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            void dfs(int x, int y, List<(int, int)> group, List<(int, int)> dame)
            {
                visited[x, y] = true;
                group.Add((x, y));

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx >= 0 && ny >= 0 && nx < N && ny < N)
                    {
                        if (board[nx, ny] == 'B' && !visited[nx, ny])
                        {
                            dfs(nx, ny, group, dame);
                        }
                        else if (board[nx, ny] == '.' && !dame.Contains((nx, ny)))
                        {
                            dame.Add((nx, ny));
                        }
                    }
                }
            }

            // Пошук всіх груп чорних каменів
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 'B' && !visited[i, j])
                    {
                        List<(int, int)> group = new List<(int, int)>();
                        List<(int, int)> dame = new List<(int, int)>();
                        dfs(i, j, group, dame);

                        // Якщо в групі тільки одне даме - вона в Атарі
                        if (dame.Count == 1)
                        {
                            atariCount++;
                        }
                    }
                }
            }

            model.Output = atariCount.ToString();
            return View(model);
        }
    }
}
