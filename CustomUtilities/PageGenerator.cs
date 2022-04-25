//using Microsoft.AspNetCore.Html;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using WebApplication1.Data.Products;

//namespace WebApplication1.CustomUtilities
//{
//    public static class PageGenerator
//    {
//        public static HtmlString CPUPage(this IHtmlHelper html, CPU cpu)
//        {
//            string result =
//                            $"<html>" +
//                            $"<body>" +
//                                $"<h1 class = \"text-center\" >Информация о {cpu.ModelName}</h1>" +
//                                $"<h2 class = \"text-center\">{cpu.Price} рублей</h1>" +
//                                $"<div class=\"form - inline\">" +
//                                    $"<p style = \" font-size: 150%\">Название модели:</p>" +
//                                    $"<b style = \" font-size: 200%\">{cpu.ModelName}</b>" +
//                                    $"<p></p>" +
//                                    $"<p style = \" font-size: 150%\">Сокет:</p>" +
//                                    $"<b style = \" font-size: 200%\">{cpu.Socket}</b>" +
//                                    $"<p></p>" +
//                                    $"<p style = \" font-size: 150%\">Колличество ядер:</p>" +
//                                    $"<b style = \" font-size: 200%\">{cpu.Cores}</b>" +
//                                    $"<p></p>" +
//                                    $"<p style = \" font-size: 150%\">Колличество потоков:</p>" +
//                                    $"<b style = \" font-size: 200%\">{cpu.Threads}</b>" +
//                                    $"<p></p>" +
//                                    $"<p style = \" font-size: 150%\">Частота:</p>" +
//                                    $"<b style = \" font-size: 200%\">{cpu.Speed}</b>" +
//                                    $"<p></p>" +
//                                    $"<p style = \" font-size: 150%\">TDP:</p>" +
//                                    $"<b style = \" font-size: 200%\">{cpu.PowerUsage}</b>" +
//                                    $"<p></p>";
//            if (cpu.Description != null && !string.IsNullOrEmpty(cpu.Description))
//            {
//                result += $"<p style = \" font-size: 150%\">Описание:</p>" +
//                          $"<b class = \"text-center\" style = \" font-size: 125%\">{cpu.Description}</b>";
//            }

//            result += $"<a class = \"btn btn-primary my-btn\" asp-controller = \"Home\" asp-action = \"Buy\">Купить</a>" +
//                         $"</div>" +
//                     $"</body>" +
//                 $"</html>";

//            return new HtmlString(result);
//        }

//        public static HtmlString FramePage(this IHtmlHelper html, ComputerFrame frame)
//        {
//        }
//    }
//}