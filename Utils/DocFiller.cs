using NPOI.XWPF.UserModel;
using SecurityClean3.Models;
using System.Text;

namespace SecurityClean3.Utils
{
    public class DocFiller
    {
        public static string FillTemplate(Customer customer, Contract contract, List<Service> services, List<SecuredItem> securedItems, IWebHostEnvironment env)
        {
            var priceIntAndFract = GetIntegerAndFractionalParts(services.Sum(x => x.Price));
            using (var rs = File.OpenRead(GetTemplatePath(env, "template.docx")))
            {
                var fileName = $"contract_{Guid.NewGuid()}.docx";
                using (var doc = new XWPFDocument(rs))
                {
                    foreach (var p in doc.Paragraphs)
                    {
                        doc.FindAndReplaceText("{dogovor_number}", contract.Id.ToString());
                        doc.FindAndReplaceText("{signDate}", contract.SignDate.ToShortDateString());
                        doc.FindAndReplaceText("{customer_info}", customer.ToString());
                        doc.FindAndReplaceText("{customer_pred}", customer.ContactPerson);
                        doc.FindAndReplaceText("{price_int}", priceIntAndFract[0].ToString());
                        doc.FindAndReplaceText("{price_fract}", priceIntAndFract[1].ToString());
                        doc.FindAndReplaceText("{startDate}", contract.StartDate.ToShortDateString());
                        doc.FindAndReplaceText("{endDate}", contract.EndDate.ToShortDateString());
                        doc.FindAndReplaceText("{customer_company}", customer.CompanyName);
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
                    using (var ws = File.Create(GetOutputPath(env, fileName)))
                    {
                        doc.Write(ws);
                        return fileName;
                    }
                }
            }
        }
        private static double[] GetIntegerAndFractionalParts(double number)
        {
            double[] parts = new double[2];

            // Получаем целую часть числа
            parts[0] = Math.Truncate(number);

            // Получаем дробную часть числа
            parts[1] = Math.Abs(number - parts[0]); // Берем модуль для отрицательных чисел

            return parts;
        }
        public static string GetOutputPath(IWebHostEnvironment env,string fileName) => Path.Combine(env.WebRootPath,GetOutputRelativePath(fileName));
        public static string GetOutputRelativePath(string fileName) =>  Path.Combine("docs", "output", fileName);
        private static string GetTemplatePath(IWebHostEnvironment env,string fileName) => Path.Combine(env.WebRootPath, Path.Combine("docs", "templates", fileName));
    }
}
