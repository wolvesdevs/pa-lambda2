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
    }
}
