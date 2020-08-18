using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RasmusDohm.WPFGaming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int score = 0;
        int player1Choice = 0;
        int aiChoice = 0;
        Boolean userInput = true;
        Boolean player1chosen = false;
        Boolean player2chosen = false;
        BitmapImage thinkingPath = new BitmapImage(new Uri("C:/Users/rasm945b/source/repos/RasmusDohm.WPFGaming/RasmusDohm.WPFGaming/Thinking.png"));
        BitmapImage rockPath = new BitmapImage(new Uri("C:/Users/rasm945b/source/repos/RasmusDohm.WPFGaming/RasmusDohm.WPFGaming/Rock.png"));
        BitmapImage paperPath = new BitmapImage(new Uri("C:/Users/rasm945b/source/repos/RasmusDohm.WPFGaming/RasmusDohm.WPFGaming/Paper.png"));
        BitmapImage scissorsPath = new BitmapImage(new Uri("C:/Users/rasm945b/source/repos/RasmusDohm.WPFGaming/RasmusDohm.WPFGaming/Scissors.png"));
        public MainWindow()
        {
            InitializeComponent(); 
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if (userInput)
            {
                switch (e.Key)
                {
                    case Key.Escape:
                        Application.Current.Shutdown();
                        break;
                    case Key.Q:
                        player1Choice = 1;
                        PlayerImage.Source = rockPath;
                        aiChoice = rnd();
                        RNGimage();
                        scoreCalculate();
                        break;
                    case Key.W:
                        player1Choice = 2;
                        PlayerImage.Source = paperPath;
                        aiChoice = rnd();
                        RNGimage();
                        scoreCalculate();
                        break;
                    case Key.E:
                        player1Choice = 3;
                        PlayerImage.Source = scissorsPath;
                        aiChoice = rnd();
                        RNGimage();
                        scoreCalculate();
                        break;
                }
            }
        }

        private void Btn_rock_Click(object sender, RoutedEventArgs e)
        {
            player1Choice = 1;
            PlayerImage.Source = rockPath;
            aiChoice = rnd();
            RNGimage();
            scoreCalculate();
        }

        private void Btn_paper_Click(object sender, RoutedEventArgs e)
        {
            player1Choice = 2;
            PlayerImage.Source = paperPath;
            aiChoice = rnd();
            RNGimage();
            scoreCalculate();
        }

        private void Btn_scissors_Click(object sender, RoutedEventArgs e)
        {
            player1Choice = 3;
            PlayerImage.Source = scissorsPath;
            aiChoice = rnd();
            RNGimage();
            scoreCalculate();
        }
        private int rnd()
        {
            Random RNG = new Random();
            int randomChoice = RNG.Next(1, 4);
            return randomChoice;
        }
        private void RNGimage()
        {
            if (aiChoice == 1)
            {
                AiImage.Source = rockPath;
            }
            else if (aiChoice == 2)
            {
                AiImage.Source = paperPath;
            }
            else if (aiChoice == 3)
            {
                AiImage.Source = scissorsPath;
            }
        }
        async void wait()
        {
            await Task.Delay(2000);
            PlayerImage.Source = thinkingPath;
            AiImage.Source = thinkingPath;
            Btn_paper.IsEnabled = true;
            Btn_rock.IsEnabled = true;
            Btn_scissors.IsEnabled = true;
            userInput = true;
        }
        private void scoreCalculate()
        {
            Btn_paper.IsEnabled = false;
            Btn_rock.IsEnabled = false;
            Btn_scissors.IsEnabled = false;
            userInput = false;
            if (player1Choice - aiChoice ==  -1 || player1Choice - aiChoice == 2)
            {
                score = 0;
                scoreCounter.Text = score.ToString();
            }
            else if (aiChoice - player1Choice == -1 || aiChoice - player1Choice == 2)
            {
                score++;
                scoreCounter.Text = score.ToString();
            }
            wait();
        }
        private void bothInputs()
        {
            if (player1chosen && player2chosen)
            {
                if(player1Choice == 1)
                {
                    PlayerImage.Source = rockPath;
                }
                else if (player1Choice == 2)
                {
                    PlayerImage.Source = paperPath;
                }
                else if (player1Choice == 3)
                {
                    PlayerImage.Source = scissorsPath;
                }
                if (aiChoice == 1)
                {
                    AiImage.Source = rockPath;
                }
                else if (aiChoice == 2)
                {
                    AiImage.Source = paperPath;
                }
                else if (aiChoice == 3)
                {
                    AiImage.Source = scissorsPath;
                }
                scoreCalculate();
            }
        }
    }
}
