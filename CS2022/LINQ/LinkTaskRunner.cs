using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.LINQ
{
    public class LinkTaskRunner
    {
        /// <summary>
        /// Товар 
        /// </summary>
        private class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Product(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        /// <summary>
        /// Сделка
        /// </summary>
        private class Deal
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public double Price { get; set; }
            public int Count { get; set; }
            public Deal(int id, int productid, int price, int count)
            {
                Id = id;
                ProductId = productid;
                Price = price;
                Count = count;
            }
        }
        public void Run()
        {
            //Создать перечень продуктов из 10 товаров
            var listProduct = new List<Product>()
            {
                new Product(1, "Milk"),
                new Product(2, "Cheese"),
                new Product(3, "Eggs"),
                new Product(4, "Tomato"),
                new Product(5, "Cake"),
                new Product(6, "Potato"),
                new Product(7, "Carrot"),
                new Product(8, "Apple"),
                new Product(9, "Wine"),
                new Product(10, "Butter"),
            };

            //Создать перечень сделок 20 шт
            var listDeal = new List<Deal>()
            {
                new Deal(1, 1, 12, 1),
                new Deal(2, 2, 30, 1),
                new Deal(3, 3, 13, 1),
                new Deal(4, 4, 14, 1),
                new Deal(5, 5, 22, 2),
                new Deal(6, 6, 8, 12),
                new Deal(7, 7, 9, 2),
                new Deal(8, 8, 15, 1),
                new Deal(9, 9, 60, 1),
                new Deal(10, 10, 25, 1),
                new Deal(11, 1, 12, 1),
                new Deal(12, 2, 30, 2),
                new Deal(13, 3, 13, 1),
                new Deal(14, 4, 14, 5),
                new Deal(15, 5, 22, 1),
                new Deal(16, 6, 8, 3),
                new Deal(17, 7, 9, 1),
                new Deal(18, 8, 15, 4),
                new Deal(19, 9, 60, 1),
                new Deal(20, 10, 25, 1),

            };
            //Выбрать все сделки, которые были дороже 50
            var result1 = listDeal.Where(x => (x.Price * x.Count) > 50).ToList();
            //var result1 = listDeal.All(x => (x.Price * x.Count) > 50); 

            //Вывести первые 10 сделок, отсортированных по коду товара и цене
            var result2 = (listDeal
                .OrderBy(x => x.ProductId)
                .ThenBy(x => x.Price))
                .Take(10);

            //Вывести первые 3 сделки, цена которых между 30 и 70
            var result3 = listDeal
                .Where(x =>
                {
                    var price = x.Price * x.Count;
                    return price > 29 && price < 71;
                })
                .Take(3)
                .ToList();

            //Создать второй список сделок 10 шт
            var listDeal2 = new List<Deal>()
            {
                new Deal(1, 1, 12, 2),
                new Deal(2, 2, 30, 1),
                new Deal(3, 3, 13, 1),
                new Deal(4, 4, 14, 0),
                new Deal(5, 5, 22, 2),
                new Deal(6, 6, 8, 0),
                new Deal(7, 7, 9, 2),
                new Deal(8, 8, 15, 1),
                new Deal(9, 9, 60, 2),
                new Deal(10, 10, 25, 1),
            };
            //Найти пересечение продуктов из двух списков сделок
            var res1 = listDeal
                .Select(x => x.ProductId)
                .Distinct() //удаляем дубликаты
                .Intersect(listDeal2
                            .Select(x => x.ProductId)
                            .Distinct());
            //разницу
            var res2 = listDeal
                .Select(x => x.ProductId)
                .Distinct() //удаляем дубликаты
                .Except(listDeal2
                            .Select(x => x.ProductId)
                            .Distinct());
            //объединение
            var res3 = listDeal
                .Select(x => x.ProductId)
                .Distinct() //удаляем дубликаты
                .Union(listDeal2
                            .Select(x => x.ProductId)
                            .Distinct());

            //Вывести самую дорогую сделку
            var res4 = listDeal2.Max(x => x.Price * x.Count);

            //Вывести среднюю стоимость сделки
            var res5 = listDeal.Average(x => x.Price * x.Count);

            //Посчитать количество сделок с суммой 50
            var res6 = listDeal.Count(x => (x.Price * x.Count) == 50);

            //Сгруппировать сделки по продуктам и вывести 
            var res7 = listDeal
                .GroupBy(x => x.ProductId);

            //код продукта, количество сделок, среднюю стоимость
            var res8 = listDeal
                .GroupBy(x => x.ProductId)
                .Select(x => new
                {
                    x.Key,
                    dealCount = x.Count(),
                    AveragePrice = x.Average(y => y.Price * y.Count)
                });

            //Вывести сделки, соединив со справочником продуктов:
            //Наименование продукта, цена


            //Проверить наличие продукта с кодом 4

            //Проверить, все ли сделки дороже 20
        }
    }
}
