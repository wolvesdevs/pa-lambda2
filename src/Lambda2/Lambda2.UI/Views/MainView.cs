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
        }
    }
}
