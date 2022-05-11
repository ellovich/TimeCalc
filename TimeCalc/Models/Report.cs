using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TimeCalc.ViewModels;

namespace TimeCalc
{
    public class Report
    {
        private static readonly List<string> s_reports = new List<string>();

        /// <summary>
        /// Создание отчёта
        /// </summary>
        /// <param name="page">Страница этапа в методичке</param>
        /// <param name="html">HTML-код отчёта</param>
        public Report(int page, string html)
        {
           // _page = page;
            s_reports.Add(html);
        }

        private static string Generate()
        {
            return $@"
<!doctype html>

<html lang=""en-ru"">
    <head>
        <title>Проект {StepsManager.Instance.ProjName}</title>
        <link rel=""stylesheet"" href=""main.css""/>
    </head>
    <body>
        <h1>Пояснительная записка к расчёту трудоёмкости работ по проекту {StepsManager.Instance.ProjName}</h1>
        {string.Join("<hr>", s_reports)}
        <hr>
        <h2>Общая трудоёмкость проекта: {StepsManager.Instance.FullLabor.Out()}ч</h2>
    </body>
</html>
";
        }

        public static void Show()
        {
            s_reports.Clear();

            foreach (var step in StepsManager.Instance.DoneSteps)
                step.CreateReport();

            string path = @"..\report_beta.html";

            try
            {
                using (var sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    sw.Write(Generate());

                Debug.WriteLine($"Запись выполнена в {path}");
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }

            try
            {
                var process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = path;
                process.Start();
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
        }
    }
}
