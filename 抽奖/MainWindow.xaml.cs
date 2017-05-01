using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
   
namespace 抽奖
{
    /// <summary>
    /// 作用：号数随机抽取
    /// 时间：2017年4月30日 21:36:42
    /// 作者：连宗凯
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rand;   //随机数 
        private DispatcherTimer isPlaying; //定时变数字

        public MainWindow()
        {
            InitializeComponent();
            
            rand = new Random(); 
            isPlaying = new DispatcherTimer();
            isPlaying.Interval = TimeSpan.FromMilliseconds(25); //25毫秒变一次数字
            isPlaying.Tick += timer1_Tick; //开始滴答滴答
         

        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            NunShow.Text = (rand.Next(0, Convert.ToInt32(ClassNumberCountInPut.Text))+1).ToString();
        }
        

        private void StarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClassNumberCountInPut.Text == "")
            {
                NunShow.Text = "填人数";
                return;
            }
            
            isPlaying.IsEnabled = !isPlaying.IsEnabled; //核心句、启动或者停止定时器

            if (!isPlaying.IsEnabled)
            {
                StarButton.Content = "发车";
            }
            else
            {
                StarButton.Content = "刹车";
            }
        }

     

    }
}
