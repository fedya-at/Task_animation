using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace atelierTask
{

    public partial class MainWindow : Window
    {
        CancellationTokenSource tokenSource;
        CancellationToken token;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wResult.Text = "";
            Wfin.Visibility = Visibility.Collapsed;

            rectangle.Visibility = System.Windows.Visibility.Visible;
            LongRun lr = new LongRun();
            wResult.Text = lr.count().ToString();
            rectangle.Visibility = System.Windows.Visibility.Collapsed;
            Wfin.Visibility = Visibility.Visible;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                tokenSource.Cancel();
                rectangle.Visibility = System.Windows.Visibility.Visible;
                Wfin.Visibility = Visibility.Collapsed;
                wResult.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("An Error d'annulation");
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            wResult.Text = "";
            Wfin.Visibility = Visibility.Collapsed;

            rectangle.Visibility = System.Windows.Visibility.Visible;
            LongRun lr = new LongRun();
            long i = await lr.CountAsync3();
            wResult.Text = i.ToString();
            rectangle.Visibility = System.Windows.Visibility.Collapsed;

            Wfin.Visibility = Visibility.Visible;
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            wResult.Text = "";
            Wfin.Visibility = Visibility.Collapsed;
            rectangle.Visibility = System.Windows.Visibility.Visible;
            tokenSource = new CancellationTokenSource();
            try
            {
                LongRun lr = new LongRun();
                long i = await lr.CountAsync4(token);
                wResult.Text = i.ToString();
            }catch (TaskCanceledException)
            {
                MessageBox.Show("Canceled");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("canceled");
            }
            finally
            {
                tokenSource.Dispose();
                rectangle.Visibility = System.Windows.Visibility.Visible;
                Wfin.Visibility = Visibility.Visible;
            }

        }

        private void btnGreeting_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello , it works !!");
        }

       
    }
}
