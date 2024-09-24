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

namespace lab_4_PiOGI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        BitmapImage mine = new BitmapImage(new Uri(@"pack://application:,,,/imgs/Minee.png", UriKind.Absolute));

        int N = 10;
        int K = 5;
        int J = 15;
        int size = 30;
        int wincheck = 0;
       
        cGen gen;
     

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
           
        
            Image img = new Image();
            img.Source = mine;
            StackPanel stackPnl = new StackPanel();
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);
            ((Button)sender).Content = stackPnl;

            int i = (int)((Button)sender).Tag;
            ((Button)sender).Background = Brushes.White;
            ((Button)sender).Foreground = Brushes.Pink;
            ((Button)sender).FontSize = 18;

            if (gen.getCell(i % N, i / N) == 9)
            {
                img.Source = mine;
                MessageBox.Show("MEOW!!! YOU DIED!!! MEOW!!! TRY AGAIN!!!");
                ugr.Children.Clear();
                wincheck = 0;
            }
            else
            {
                wincheck = wincheck + 1;
                ((Button)sender).Content = gen.getCell(i % N, i / N);
                
            }
            if (wincheck == 84)
            {
                MessageBox.Show("MEOW!!! YOU WIN!!! MEOW!!!");
                ugr.Children.Clear();
                wincheck = 0;
            }


        }


        private void Btn1_Click(object sender, RoutedEventArgs e)
        {

            Image img = new Image();
            img.Source = mine;
            StackPanel stackPnl = new StackPanel();
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);
            ((Button)sender).Content = stackPnl;

            int i = (int)((Button)sender).Tag;
            ((Button)sender).Background = Brushes.White;
            ((Button)sender).Foreground = Brushes.Pink;
            ((Button)sender).FontSize = 18;

            if (gen.getCell(i % K, i / K) == 9)
            {
                img.Source = mine;
                MessageBox.Show("MEOW!!! YOU DIED!!! MEOW!!!");
                ugr.Children.Clear();
                wincheck = 0;
            }
            else
            {
                wincheck = wincheck + 1;
                ((Button)sender).Content = gen.getCell(i % K, i / K);
               
            }
            if (wincheck == 21)
            {
                MessageBox.Show("MEOW!!! YOU WIN!!! MEOW!!!");
                ugr.Children.Clear();
                wincheck = 0;
            }



        }

        private void Large_Click(object sender, RoutedEventArgs e)
        {

            gen = new cGen(J);
            gen.generate();


            ugr.Rows = J;
            ugr.Columns = J;

            ugr.Width = J * (size + 4);
            ugr.Height = J * (size + 4);

            ugr.Margin = new Thickness(5, 5, 5, 5);

            ugr.Children.Clear();

            for (int i = 0; i < J * J; i++)
            {
                Button btn = new Button();

                btn.Tag = i;
                btn.Width = size;
                btn.Height = size;

                btn.Margin = new Thickness(2);

                btn.Click += Btn2_Click;

                ugr.Children.Add(btn);
            }
        }

            private void Btn2_Click(object sender, RoutedEventArgs e)
            {
                Image img = new Image();
                img.Source = mine;
                StackPanel stackPnl = new StackPanel();
                stackPnl.Margin = new Thickness(1);
                stackPnl.Children.Add(img);
                ((Button)sender).Content = stackPnl;

                int i = (int)((Button)sender).Tag;
                ((Button)sender).Background = Brushes.White;
                ((Button)sender).Foreground = Brushes.Pink;
                ((Button)sender).FontSize = 18;

                if (gen.getCell(i % J, i / J) == 9)
                {
                    img.Source = mine;
                    MessageBox.Show("MEOW!!! YOU DIED!!! MEOW!!!");
                    ugr.Children.Clear();
                    wincheck = 0;
            }
            else
            {
                wincheck = wincheck + 1;
                ((Button)sender).Content = gen.getCell(i % J, i / J);
            }
            if (wincheck == 188)
            {
                MessageBox.Show("MEOW!!! YOU WIN!!! MEOW!!!");
                ugr.Children.Clear();
                wincheck = 0;
            }
            
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gen = new cGen(K);
            gen.generate();

            ugr.Rows = K;
            ugr.Columns = K;

            ugr.Width = K * (size + 4);
            ugr.Height = K * (size + 4);

            ugr.Margin = new Thickness(5, 5, 5, 5);

            ugr.Children.Clear();

            for (int i = 0; i < K * K; i++)
            {
                Button btn = new Button();

                btn.Tag = i;
                btn.Width = size;
                btn.Height = size;

                btn.Margin = new Thickness(2);

                btn.Click += Btn1_Click;

                ugr.Children.Add(btn);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gen = new cGen(N);
            gen.generate();


            ugr.Rows = N;
            ugr.Columns = N;

            ugr.Width = N * (size + 4);
            ugr.Height = N * (size + 4);

            ugr.Margin = new Thickness(5, 5, 5, 5);

            ugr.Children.Clear();

            for (int i = 0; i < N * N; i++)
            {
                Button btn = new Button();

                btn.Tag = i;
                btn.Width = size;
                btn.Height = size;

                btn.Margin = new Thickness(2);

                btn.Click += Btn_Click;

                ugr.Children.Add(btn);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gen = new cGen(J);
            gen.generate();


            ugr.Rows = J;
            ugr.Columns = J;

            ugr.Width = J * (size + 4);
            ugr.Height = J * (size + 4);

            ugr.Margin = new Thickness(5, 5, 5, 5);

            ugr.Children.Clear();

            for (int i = 0; i < J * J; i++)
            {
                Button btn = new Button();

                btn.Tag = i;
                btn.Width = size;
                btn.Height = size;

                btn.Margin = new Thickness(2);

                btn.Click += Btn2_Click;

                ugr.Children.Add(btn);
            }
        }
    }
    }


    

