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
                      select new { product.Name, Price = $"{product.Price}�~" };
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
}
