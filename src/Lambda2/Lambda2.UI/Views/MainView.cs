using Lambda2.Domain.Helper;
using System.Diagnostics;

namespace Lambda2.UI;

public partial class MainView : Form
{
    public MainView()
    {
        InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        int[] nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        var result1 = from num in nums
                      where num >= 5
                      select num;
        Debug.WriteLine(string.Join(", ", result1));

        var result2 = from num in nums
                      where num >= 3
                      && num <= 5
                      || num == 7
                      select num;
        Debug.WriteLine(string.Join(", ", result2));

        var result3 = from num in nums
                      where num >= 3
                      && num <= 5
                      || num == 7
                      orderby num descending
                      select num;
        Debug.WriteLine(string.Join(", ", result3));
    }

    private void button2_Click(object sender, EventArgs e)
    {
        string[] values = ["A", "BB", "CCC", "DDDD", "EEEEE", "aBC"];

        var result1 = from value in values
                      select value;
        Debug.WriteLine($"result1: {string.Join(", ", result1)}");

        var result2 = from value in values
                      where value.Contains("a")
                      select value;
        Debug.WriteLine($"result2: {string.Join(", ", result2)}");

        var result3 = from value in values
                      where value.ToLower().Contains("a")
                      select value;
        Debug.WriteLine($"result3: {string.Join(", ", result3)}");

        var result4 = from value in values
                      where value.ToLower().Contains("a")
                      && value.Length >= 3
                      select value;
        Debug.WriteLine($"result4: {string.Join(", ", result4)}");

        var result5 = from value in values
                      where value.ToLower().Contains("a")
                      || value.Length >= 3
                      select value;
        Debug.WriteLine($"result5: {string.Join(", ", result5)}");
    }

    private void button3_Click(object sender, EventArgs e)
    {
        List<Product> products =
        [
            new Product(10, "p10A", 300),
            new Product(20, "p20", 300),
            new Product(30, "x301A", 200),
            new Product(40, "P40", 500),
        ];

        var result1 = from product in products
                      where product.Name[0] == 'p'
                      select product;
        foreach (var product in result1)
        {
            Debug.WriteLine($"<result1>Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var result2 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      select product;
        foreach (var product in result2)
        {
            Debug.WriteLine($"<result2>Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var result3 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      orderby product.Price
                      select product;
        foreach (var product in result3)
        {
            Debug.WriteLine($"<result3>Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var result4 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      orderby product.Price descending
                      select product;
        foreach (var product in result4)
        {
            Debug.WriteLine($"<result4>Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var result5 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      orderby product.Price descending, product.Id
                      select product;
        foreach (var product in result5)
        {
            Debug.WriteLine($"<result5>Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var result6 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      orderby product.Price descending, product.Id
                      select product.Name;
        foreach (var name in result6)
        {
            Debug.WriteLine($"<result6>Id: Name: {name}");
        }

        var result7 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      orderby product.Price descending, product.Id
                      select new { product.Name, product.Price };
        foreach (var product in result7)
        {
            Debug.WriteLine($"<result7>Id: Name: {product.Name} Price: {product.Price}");
        }

        var result8 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      orderby product.Price descending, product.Id
                      select new { product.Name, AAA = product.Price };
        foreach (var product in result8)
        {
            Debug.WriteLine($"<result8>Id: Name: {product.Name} Price: {product.AAA}");
        }

        var result9 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      orderby product.Price descending, product.Id
                      select new { product.Name, Price = $"{product.Price}â~" };
        foreach (var product in result9)
        {
            Debug.WriteLine($"<result9>Id: Name: {product.Name} Price: {product.Price}");
        }

        var result10 = from product in products
                       where product.Name.ToLower()[0] == 'p'
                       orderby product.Price descending, product.Id
                       select new ProductDto(product.Id.ToString(), product.Name);
        foreach (var product in result10)
        {
            Debug.WriteLine($"<result10>{product}");
        }

        var result11 = from product in products
                       where product.Name.ToLower()[0] == 'p'
                       orderby product.Price descending, product.Id
                       select new ProductDto(product);
        foreach (var product in result11)
        {
            Debug.WriteLine($"<result11>{product}");
        }

        var result12 = from product in products
                       where product.Name.ToLower()[0] == 'p'
                       orderby product.Price descending, product.Id
                       select new ProductEntity { Id = product.Id.ToString(), Name = product.Name };
        foreach (var product in result12)
        {
            Debug.WriteLine($"<result12>{product}");
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        List<Product> products =
        [
            new Product(10, "p10A", 300),
            new Product(20, "p20", 300),
            new Product(30, "x301A", 200),
            new Product(40, "P40", 500),
        ];

        var result2 = from product in products
                      where product.Name.ToLower()[0] == 'p'
                      select product;
        foreach (var product in result2)
        {
            Debug.WriteLine($"<result2>Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var result3 = from product in products
                      let name = product.Name.ToLower()
                      where name[0] == 'p'
                      select product;
        foreach (var product in result3)
        {
            Debug.WriteLine($"<result3>Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var result4 =
            from product in products
            let name = product.Name.ToLower()
            where name[0] == 'p'
            let MyPrice = (product.Price / 2 * 1.08)
            select new { product.Name, MyPrice };
        foreach (var product in result4)
        {
            Debug.WriteLine($"<result4>Name: {product.Name}, Price: {product.MyPrice}");
        }

        List<string> csvs = ["1,2,3", "4,5,6,7", "8,9"];
        var result5 =
            from csv in csvs
            let items = csv.Split(',')
            from item in items
            select item;
        foreach (var item in result5)
        {
            Debug.WriteLine($"<result5>item: {item}");
        }
    }

    private void button5_Click(object sender, EventArgs e)
    {
        List<Product> products =
        [
            new Product(10, "p10A", 300),
            new Product(20, "p20", 300),
            new Product(30, "x301A", 200),
            new Product(40, "P40", 500),
            new Product(50, "P50", 200),
        ];

        var result1 =
            from product in products
            group product by product.Price;
        foreach (var group in result1)
        {
            Debug.WriteLine($"Key: {group.Key}");

            foreach (var row in group)
            {
                Debug.WriteLine($" id: {row.Id} name: {row.Name} price: {row.Price}");
            }
        }

        Debug.WriteLine("----------------------------------------");

        var result2 =
            from product in products
            where product.Price > 250
            orderby product.Price descending
            group product by product.Price;
        foreach (var group in result2)
        {
            Debug.WriteLine($"Key: {group.Key}");

            foreach (var row in group)
            {
                Debug.WriteLine($" id: {row.Id} name: {row.Name} price: {row.Price}");
            }
        }
    }

    private void button6_Click(object sender, EventArgs e)
    {
        List<Product> products =
            [
                new Product(10, "p200", 200),
                new Product(20, "p200", 200),
                new Product(30, "p200", 220),
                new Product(40, "p200", 220),
                new Product(50, "p200", 300),
                new Product(60, "p300", 320),
                new Product(70, "p400", 320),
            ];

        var result1 =
            from product in products
            group product by new { product.Name, product.Price };
        foreach (var group in result1)
        {
            Debug.WriteLine($"Key: {group.Key}");

            foreach (var row in group)
            {
                Debug.WriteLine($" id: {row.Id} name: {row.Name} price: {row.Price}");
            }
        }
    }

    private void button7_Click(object sender, EventArgs e)
    {
        List<Sale> sales =
            [
                new Sale(10, 1, 100, Convert.ToDateTime("2020/12/12 12:12:12")),
                new Sale(11, 1, 100, Convert.ToDateTime("2020/12/13 12:12:12")),
                new Sale(12, 1, 101, Convert.ToDateTime("2020/12/12 12:12:12")),
            ];

        List<SaleItem> saleItems =
            [
                new SaleItem(10, 1, 1, 2),
                new SaleItem(10, 1, 2, 3),
                new SaleItem(11, 1, 1, 5),
                new SaleItem(12, 1, 1, 4),
                new SaleItem(12, 1, 3, 1),
            ];

        Debug.WriteLine("------------------- result1 ---------------------");

        var result1 =
            from sale in sales
            join saleItem in saleItems
            on sale.SaleId equals saleItem.SaleId
            select new
            {
                sale.SaleId,
                sale.CustomerId,
                sale.SaleDateTime,
                saleItem.ProductId,
                saleItem.SaleCount,
            };

        foreach (var row in result1)
        {
            Debug.WriteLine(row);
        }

        Debug.WriteLine("------------------- result2 ---------------------");

        var result2 =
            from s in sales
            join si in saleItems
            on s.SaleId equals si.SaleId
            where s.SaleId >= 11
            orderby si.SaleCount
            select new
            {
                s.SaleId,
                s.CustomerId,
                s.SaleDateTime,
                si.ProductId,
                si.SaleCount,
            };

        foreach (var row in result2)
        {
            Debug.WriteLine(row);
        }
    }

    private void button8_Click(object sender, EventArgs e)
    {
        List<Sale> sales =
            [
                new Sale(10, 1, 100, Convert.ToDateTime("2020/12/12 12:12:12")),
                new Sale(11, 1, 100, Convert.ToDateTime("2020/12/13 12:12:12")),
                new Sale(12, 1, 101, Convert.ToDateTime("2020/12/12 12:12:12")),
            ];

        List<SaleItem> saleItems =
            [
                new SaleItem(10, 1, 1, 2),
                new SaleItem(10, 99, 2, 3),
                new SaleItem(11, 1, 1, 5),
                new SaleItem(12, 1, 1, 4),
                new SaleItem(12, 1, 3, 1),
            ];

        Debug.WriteLine("------------------- result1 ---------------------");

        var result1 =
            from s in sales
            join si in saleItems
            on new { s.SaleId, s.No }
            equals new { si.SaleId, si.No }
            select new
            {
                s.SaleId,
                s.CustomerId,
                s.SaleDateTime,
                si.ProductId,
                si.SaleCount,
            };

        foreach (var row in result1)
        {
            Debug.WriteLine(row);
        }
    }

    private void button9_Click(object sender, EventArgs e)
    {
        List<Sale> sales =
            [
                new Sale(10, 1, 100, Convert.ToDateTime("2020/12/12 12:12:12")),
                new Sale(11, 1, 100, Convert.ToDateTime("2020/12/13 12:12:12")),
                new Sale(12, 1, 101, Convert.ToDateTime("2020/12/12 12:12:12")),
            ];

        List<SaleItem> saleItems =
            [
                new SaleItem(10, 1, 1, 2),
                new SaleItem(10, 1, 2, 3),
                //new SaleItem(11, 1, 1, 5),
                new SaleItem(12, 1, 1, 4),
                new SaleItem(12, 1, 3, 1),
            ];

        Debug.WriteLine("------------------- result1 ---------------------");

        var result1 =
            from s in sales
            join si in saleItems
            on s.SaleId equals si.SaleId into sis
            from si in sis.DefaultIfEmpty()
            select new
            {
                s.SaleId,
                s.CustomerId,
                s.SaleDateTime,
                ProductId = si?.ProductId ?? -1,
                SaleCount = si?.SaleCount ?? -1,
            };

        foreach (var row in result1)
        {
            Debug.WriteLine(row);
        }
    }

    private void button10_Click(object sender, EventArgs e)
    {
        List<int> nums = [1, 4, 8, 5, 10, 3, 2];

        var result1 = nums.Where(x => x >= 5);
        Debug.WriteLine($"<result1> {string.Join(", ", result1)}");

        var result2 = nums.Where(x => x >= 5);
        Debug.WriteLine($"<result2> {string.Join(", ", result2)}");

        // ïΩãœ
        var result3 = nums.Average();
        Debug.WriteLine($"<result3> {string.Join(", ", result3)}");

        // ç≈ëÂ, ç≈è¨, çáåv
        var result4 = nums.Max();
        Debug.WriteLine($"<result4> {string.Join(", ", result4)}");
        var result5 = nums.Min();
        Debug.WriteLine($"<result5> {string.Join(", ", result5)}");
        var result6 = nums.Sum();
        Debug.WriteLine($"<result6> {string.Join(", ", result6)}");

    }

    private void button11_Click(object sender, EventArgs e)
    {
        string[] values = ["A", "BB", "CCC", "DDDD", "EEEEE", "ABC"];

        var result1 = values.Average(x => x.Length);
        Debug.WriteLine($"<result1> {string.Join(", ", result1)}");

        var result2 = values.Max(x => x.Length);
        Debug.WriteLine($"<result2> {string.Join(", ", result2)}");

        var result3 = values.Min(x => x.Length);
        Debug.WriteLine($"<result3> {string.Join(", ", result3)}");

        var result4 = values.Sum(x => x.Length);
        Debug.WriteLine($"<result4> {string.Join(", ", result4)}");
    }

    private void button12_Click(object sender, EventArgs e)
    {
        List<int> ints = [10, 20];
        List<object> objects = [1, 2, 3, "AAA", "BB", ints];

        var result1 = objects.OfType<int>();
        Debug.WriteLine($"<result1> {string.Join(", ", result1)}");

        var result2 = objects.OfType<string>();
        Debug.WriteLine($"<result2> {string.Join(", ", result2)}");

        var result3 = objects.OfType<List<int>>();
        foreach (var val in result3)
        {
            Debug.WriteLine($"<result3> {string.Join(", ", val)}");
        }

        var result4 = objects.OfType<int>().Where(x => x >= 2);
        Debug.WriteLine($"<result4> {string.Join(", ", result4)}");
    }

    private void button13_Click(object sender, EventArgs e)
    {
        List<Product> products =
        [
            new Product(10, "p10A", 300),
            new Product(20, "p20", 300),
            new Product(30, "x301A", 200),
            new Product(40, "P40", 500),
            new Product(50, "P50", 200),
        ];

        var result1 = products.Where(x => x.Price == 200);
        foreach (var product in result1)
        {
            Debug.WriteLine($"<result1> Id: {product.Id} Name: {product.Name} Price: {product.Price}");
        }

        var result2 = products.Where(x => x.Price == 200)
                              .Select(x => x.Id);
        foreach (var product in result2)
        {
            Debug.WriteLine($"<result2> Id: {product}");
        }

        var result3 = products.Where(x => x.Price == 200)
                              .Select(x => new { x.Id, x.Name });
        foreach (var product in result3)
        {
            Debug.WriteLine($"<result3> Id: {product.Id} Name: {product.Name}");
        }
    }

    private void button14_Click(object sender, EventArgs e)
    {
        List<Product> products =
        [
            new Product(10, "p10A", 300),
            new Product(20, "p20", 300),
            new Product(30, "x301A", 200),
            new Product(40, "P40", 500),
            new Product(50, "P50", 200),
        ];

        var result1 = products.Where(x => x.Price == 200).ToList();
        result1.ForEach(x => Debug.WriteLine($"<result1> Id: {x.Id} Name: {x.Name} Price: {x.Price}"));
    }

    private void button15_Click(object sender, EventArgs e)
    {
        List<Product> products =
        [
            new Product(10, "p10A", 300),
            new Product(20, "p20", 300),
            new Product(30, "x301A", 200),
            new Product(40, "P40", 500),
            new Product(50, "P50", 200),
        ];

        var array = products.Where(x => x.Price == 200).ToArray();
        var list = products.Where(x => x.Price == 200).ToList();

        var dtos = products.ConvertAll(x => new ProductDto(x));

        var result1 =
            (from product in products
             where product.Price == 200
             select product).ToList();

        List<int> nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        List<string> strings = nums.ConvertAll(x => x.ToString());

        var result2 =
            (from num in nums
             select num.ToString()).ToList();
    }

    private void button16_Click(object sender, EventArgs e)
    {
        List<Product> products =
        [
            new Product(10, "p10A", 300),
            new Product(20, "p20", 300),
            new Product(30, "x301A", 200),
            new Product(40, "P40", 500),
            new Product(50, "P50", 200),
        ];

        var result1 = products.OrderBy(x => x.Price).ToList();
        result1.ForEach(x => Debug.WriteLine($"<result1> Id: {x.Id} Name: {x.Name} Price: {x.Price}"));

        var result2 = products.OrderByDescending(x => x.Price).ToList();
        result2.ForEach(x => Debug.WriteLine($"<result2> Id: {x.Id} Name: {x.Name} Price: {x.Price}"));

        var result3 = products.OrderBy(x => x.Price).ThenByDescending(x => x.Id).ToList();
        result3.ForEach(x => Debug.WriteLine($"<result3> Id: {x.Id} Name: {x.Name} Price: {x.Price}"));
    }
}
