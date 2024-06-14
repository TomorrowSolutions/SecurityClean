using Microsoft.EntityFrameworkCore;

namespace SecurityClean3
{
    public class PaginatedList<T>:List<T>
    {
        //Текущая страница
        public int PageIndex { get; set; }
        //Всего страниц
        public int TotalPages { get; set; }

        public PaginatedList(List<T> items,int count,int pageIndex,int pageSize)
        {
            //Устанавливается текущая страница
            PageIndex=pageIndex;
            //Количество страниц округляется в большую сторону
            TotalPages=(int)Math.Ceiling(count/(double)pageSize);
            //Добавляются все элементы
            this.AddRange(items);
        }
        //Проверка возможности перехода на предыдущую страницу
        public bool HasPreviousPage => PageIndex > 1;
        //Проверка возможности перехода на следующую страницу
        public bool HasNextPage => PageIndex<TotalPages;

        //Метод для создания нового экземпляра списка
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source,int pageIndex,int pageSize)
        {
            //подсчет количества элементов
            var count = await source.CountAsync();
            //проспуск элементов с предыдущих страниц и выборка элементов текущей страницы
            var items = await source.Skip((pageIndex-1)*pageSize).Take(pageSize).ToListAsync();
            //передача полученных параметров в конструктор
            return new PaginatedList<T>(items,count,pageIndex,pageSize);
        }
    }
}
