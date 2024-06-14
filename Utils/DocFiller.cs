using NPOI.XWPF.UserModel;
using SecurityClean3.Models;
using System.Text;

namespace SecurityClean3.Utils
{
    public class DocFiller
    {
        public static string FillTemplate(Customer customer, Contract contract, List<Service> services, List<SecuredItem> securedItems, IWebHostEnvironment env)
        {
            //Цена с числами после запятой
            var priceDouble = services.Sum(x => x.Price);
            //Целая часть цены
            var priceInt = Math.Truncate(priceDouble);
            //Дробная часть цены
            var priceFract = Math.Abs(priceDouble - priceInt);
            //Открытие файла на чтение 
            using (var rs = File.OpenRead(GetTemplatePath(env, "template.docx")))
            {
                //Создание имени нового файла 
                //Для исключения повторов используется класс GUID
                var fileName = $"contract_{Guid.NewGuid()}.docx";
                //Файловый поток загружается в документ NPOI
                using (var doc = new XWPFDocument(rs))
                {
                    //Идет цикл по всем параграфам
                    foreach (var p in doc.Paragraphs)
                    {
                        //При нахождении специальной строки она заменяется значением, которое идет вторым параметром
                        doc.FindAndReplaceText("{dogovor_number}", contract.Id.ToString());
                        doc.FindAndReplaceText("{signDate}", contract.SignDate.ToShortDateString());
                        doc.FindAndReplaceText("{customer_info}", customer.ToString());
                        doc.FindAndReplaceText("{customer_pred}", customer.ContactPerson);
                        doc.FindAndReplaceText("{price_int}", priceInt.ToString());
                        doc.FindAndReplaceText("{price_fract}", priceFract.ToString());
                        doc.FindAndReplaceText("{startDate}", contract.StartDate.ToShortDateString());
                        doc.FindAndReplaceText("{endDate}", contract.EndDate.ToShortDateString());
                        doc.FindAndReplaceText("{customer_company}", customer.CompanyName);
                        doc.FindAndReplaceText("{customer_pred_cut}", customer.getShortFio());
                        //Для записи списка используется вспомогательный класс
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < securedItems.Count; i++)
                        {
                            sb.AppendLine($"{i + 1} Название: {securedItems[i].Name} Адрес: {securedItems[i].Address}; ");
                        }
                        doc.FindAndReplaceText("{objects_list}", sb.ToString());
                        sb.Clear();
                        for (int i = 0; i < services.Count; i++)
                        {
                            sb.AppendLine($"{i + 1} Название: {services[i].Name} Стоимость: {services[i].Price}; ");
                        }
                        doc.FindAndReplaceText("{services_list}", sb.ToString());
                    }
                    //Здесь происходит запись изменений в новый документ
                    using (var ws = File.Create(GetOutputPath(env, fileName)))
                    {
                        doc.Write(ws);
                        //Идет возврат имени файла
                        return fileName;
                    }
                }
            }
        }
        //Свойство для получения пути файла из выходного каталога с готовыми документами
        public static string GetOutputPath(IWebHostEnvironment env,string fileName) => Path.Combine(env.WebRootPath,GetOutputRelativePath(fileName));
        //Свойство для получения относительного пути файла из  выходного каталога с готовыми документами
        public static string GetOutputRelativePath(string fileName) =>  Path.Combine("docs", "output", fileName);
        //Свойство для получения пути файла из  каталога с шаблонами
        private static string GetTemplatePath(IWebHostEnvironment env,string fileName) => Path.Combine(env.WebRootPath, Path.Combine("docs", "templates", fileName));
    }
}
