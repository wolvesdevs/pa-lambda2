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
                      select new { product.Name, Price = $"{product.Price}‰~" };
        foreach (var product in result9)
        {
            Debug.WriteLine($"<result9>Id: Name: {product.Name} Price: {product.Price}"); 
        }
    }
}
