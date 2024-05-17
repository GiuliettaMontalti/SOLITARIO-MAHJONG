using SolitarioMahjong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSolitarioMahjong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Giocatore _giocatore;
        
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010; 
        public MainWindow()
        {
            InitializeComponent();
            lblRegoleGioco.Visibility = Visibility.Hidden;
            txtRegole.Visibility = Visibility.Hidden;
            SourceInitialized += MainWindow_SourceInitialized;
        }
        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            HwndSource source = HwndSource.FromHwnd(helper.Handle);
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            switch (msg)
            {
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        handled = true;
                    }
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        }

        private void btnRegole_Click(object sender, RoutedEventArgs e)
        {
            btnRegole.Visibility = Visibility.Collapsed;
            lblRegoleGioco.Visibility = Visibility.Visible;
            txtRegole.Visibility = Visibility.Visible;
        }

        private void boxNome_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxNome.Text == "Inserire nome") { boxNome.Text = ""; }
            boxNome.Foreground.Opacity = 100;
        }

        private void boxNome_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxNome.Text == "") { boxNome.Text = "Inserire nome"; }
            boxNome.Foreground.Opacity = 100;
        }

        private void btnInizio_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                string nome = boxNome.Text;
                _giocatore = new Giocatore($"{boxNome.Text}");
                Window1 window = new Window1(_giocatore);
                window.Show();
                this.Close();
            }
            catch (Exception ex) 
            { txtErr.Text = ex.Message; }           
        }
    }
}
