using System.Diagnostics;

namespace Lambda2.UI
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

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
            // �z��v�f��6�B���g��"A"�`"FFFFFF"�܂ŁB��������1���������₵�Ă����B�ၨ"A", "BB", "CCC", "DDDD", "EEEEE", "FFFFFF"
            string[] values = { "A", "BB", "CCC", "DDDD", "EEEEE", "aBC" };

            // ���ׂĎ擾�B�N�G���\���ŁB
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
    }
}
