using SolitarioMahjong;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfSolitarioMahjong
{
    /// <summary>
    /// Logica di interazione per Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int time = 5;
        private DispatcherTimer Timer;
        private Partita _partita;
        private Mazzetto _mazzettoPrimaCarta;
        private Mazzetto _mazzettoSecondaCarta;

        public Window1(Giocatore giocatore)
        {
            InitializeComponent();
            btnGiocaAncora.Visibility = Visibility.Hidden;
            btnSmettiDiGiocare.Visibility = Visibility.Hidden;
            btnPrimaCarta.Content = null;
            btnSecondaCarta.Content = null;
            btnPrimaCarta.IsEnabled = false;
            btnSecondaCarta.IsEnabled = false;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            _partita = new Partita(giocatore);
            SetTxtNCarte();
            ImpostaImmaginiCarte();
            txtFine.Visibility = Visibility.Hidden;
        }

        private void SetTxtNCarte()
        {
            txtNCarte1.Text = $"{_partita.Mazzetti[0, 0].ContaCarteMazzetto()} carte";
            txtNCarte2.Text = $"{_partita.Mazzetti[0, 1].ContaCarteMazzetto()} carte";
            txtNCarte3.Text = $"{_partita.Mazzetti[0, 2].ContaCarteMazzetto()} carte";
            txtNCarte4.Text = $"{_partita.Mazzetti[0, 3].ContaCarteMazzetto()} carte";

            txtNCarte5.Text = $"{_partita.Mazzetti[1, 0].ContaCarteMazzetto()} carte";
            txtNCarte6.Text = $"{_partita.Mazzetti[1, 1].ContaCarteMazzetto()} carte";
            txtNCarte7.Text = $"{_partita.Mazzetti[1, 2].ContaCarteMazzetto()} carte";
            txtNCarte8.Text = $"{_partita.Mazzetti[1, 3].ContaCarteMazzetto()} carte";

            txtNCarte9.Text = $"{_partita.Mazzetti[2, 0].ContaCarteMazzetto()} carte";
            txtNCarte10.Text = $"{_partita.Mazzetti[2, 1].ContaCarteMazzetto()} carte";
            txtNCarte11.Text = $"{_partita.Mazzetti[2, 2].ContaCarteMazzetto()} carte";
            txtNCarte12.Text = $"{_partita.Mazzetti[2, 3].ContaCarteMazzetto()} carte";

            txtNCarte13.Text = $"{_partita.Mazzetti[3, 0].ContaCarteMazzetto()} carte";
            txtNCarte14.Text = $"{_partita.Mazzetti[3, 1].ContaCarteMazzetto()} carte";
            txtNCarte15.Text = $"{_partita.Mazzetti[3, 2].ContaCarteMazzetto()} carte";
            txtNCarte16.Text = $"{_partita.Mazzetti[3, 3].ContaCarteMazzetto()} carte";
        }

        private void btnCarta_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            txtErr.Text = "";
            if (btnPrimaCarta.Content == null)
            {
                Image copia = button.Content as Image;
                Image image = new Image();
                image.Source = copia.Source;
                btnPrimaCarta.Content = image;
                switch (button.Name)
                {
                    case "btnCarta1":
                        _mazzettoPrimaCarta = _partita.Mazzetti[0, 0];
                        btnCarta1.IsEnabled = false;
                        break;
                    case "btnCarta2":
                        _mazzettoPrimaCarta = _partita.Mazzetti[0, 1];
                        btnCarta2.IsEnabled = false;
                        break;
                    case "btnCarta3":
                        _mazzettoPrimaCarta = _partita.Mazzetti[0, 2];
                        btnCarta3.IsEnabled = false;
                        break;
                    case "btnCarta4":
                        _mazzettoPrimaCarta = _partita.Mazzetti[0, 3];
                        btnCarta4.IsEnabled = false;
                        break;
                    case "btnCarta5":
                        _mazzettoPrimaCarta = _partita.Mazzetti[1, 0];
                        btnCarta5.IsEnabled = false;
                        break;
                    case "btnCarta6":
                        _mazzettoPrimaCarta = _partita.Mazzetti[1, 1];
                        btnCarta6.IsEnabled = false;
                        break;
                    case "btnCarta7":
                        _mazzettoPrimaCarta = _partita.Mazzetti[1, 2];
                        btnCarta7.IsEnabled = false;
                        break;
                    case "btnCarta8":
                        _mazzettoPrimaCarta = _partita.Mazzetti[1, 3];
                        btnCarta8.IsEnabled = false;
                        break;
                    case "btnCarta9":
                        _mazzettoPrimaCarta = _partita.Mazzetti[2, 0];
                        btnCarta9.IsEnabled = false;
                        break;
                    case "btnCarta10":
                        _mazzettoPrimaCarta = _partita.Mazzetti[2, 1];
                        btnCarta10.IsEnabled = false;
                        break;
                    case "btnCarta11":
                        _mazzettoPrimaCarta = _partita.Mazzetti[2, 2];
                        btnCarta11.IsEnabled = false;
                        break;
                    case "btnCarta12":
                        _mazzettoPrimaCarta = _partita.Mazzetti[2, 3];
                        btnCarta12.IsEnabled = false;
                        break;
                    case "btnCarta13":
                        _mazzettoPrimaCarta = _partita.Mazzetti[3, 0];
                        btnCarta13.IsEnabled = false;
                        break;
                    case "btnCarta14":
                        _mazzettoPrimaCarta = _partita.Mazzetti[3, 1];
                        btnCarta14.IsEnabled = false;
                        break;
                    case "btnCarta15":
                        _mazzettoPrimaCarta = _partita.Mazzetti[3, 2];
                        btnCarta15.IsEnabled = false;
                        break;
                    case "btnCarta16":
                        _mazzettoPrimaCarta = _partita.Mazzetti[3, 3];
                        btnCarta16.IsEnabled = false;
                        break;
                }
            }
            else
            {
                Image copia = button.Content as Image;
                Image image = new Image();
                image.Source = copia.Source;
                btnSecondaCarta.Content = image;
                BtnCarteDisattivate();
                switch (button.Name)
                {
                    case "btnCarta1":
                        _mazzettoSecondaCarta = _partita.Mazzetti[0, 0];
                        btnCarta1.IsEnabled = false;
                        break;
                    case "btnCarta2":
                        _mazzettoSecondaCarta = _partita.Mazzetti[0, 1];
                        btnCarta2.IsEnabled = false;
                        break;
                    case "btnCarta3":
                        _mazzettoSecondaCarta = _partita.Mazzetti[0, 2];
                        btnCarta3.IsEnabled = false;
                        break;
                    case "btnCarta4":
                        _mazzettoSecondaCarta = _partita.Mazzetti[0, 3];
                        btnCarta4.IsEnabled = false;
                        break;
                    case "btnCarta5":
                        _mazzettoSecondaCarta = _partita.Mazzetti[1, 0];
                        btnCarta5.IsEnabled = false;
                        break;
                    case "btnCarta6":
                        _mazzettoSecondaCarta = _partita.Mazzetti[1, 1];
                        btnCarta6.IsEnabled = false;
                        break;
                    case "btnCarta7":
                        _mazzettoSecondaCarta = _partita.Mazzetti[1, 2];
                        btnCarta7.IsEnabled = false;
                        break;
                    case "btnCarta8":
                        _mazzettoSecondaCarta = _partita.Mazzetti[1, 3];
                        btnCarta8.IsEnabled = false;
                        break;
                    case "btnCarta9":
                        _mazzettoSecondaCarta = _partita.Mazzetti[2, 0];
                        btnCarta9.IsEnabled = false;
                        break;
                    case "btnCarta10":
                        _mazzettoSecondaCarta = _partita.Mazzetti[2, 1];
                        btnCarta10.IsEnabled = false;
                        break;
                    case "btnCarta11":
                        _mazzettoSecondaCarta = _partita.Mazzetti[2, 2];
                        btnCarta11.IsEnabled = false;
                        break;
                    case "btnCarta12":
                        _mazzettoSecondaCarta = _partita.Mazzetti[2, 3];
                        btnCarta12.IsEnabled = false;
                        break;
                    case "btnCarta13":
                        _mazzettoSecondaCarta = _partita.Mazzetti[3, 0];
                        btnCarta13.IsEnabled = false;
                        break;
                    case "btnCarta14":
                        _mazzettoSecondaCarta = _partita.Mazzetti[3, 1];
                        btnCarta14.IsEnabled = false;
                        break;
                    case "btnCarta15":
                        _mazzettoSecondaCarta = _partita.Mazzetti[3, 2];
                        btnCarta15.IsEnabled = false;
                        break;
                    case "btnCarta16":
                        _mazzettoSecondaCarta = _partita.Mazzetti[3, 3];
                        btnCarta16.IsEnabled = false;
                        break;
                }
            }
            ImpostaImmaginiCarte();

        }

        private void btnSelezionaCarte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _partita.Gioca(_mazzettoPrimaCarta, _mazzettoSecondaCarta);
                if (_mazzettoPrimaCarta.ContaCarteMazzetto() == 0)
                {
                    if (_mazzettoPrimaCarta == _partita.Mazzetti[0, 0])
                    {
                        btnCarta1.Visibility = Visibility.Hidden;
                        txtNCarte1.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[0, 1])
                    {
                        btnCarta2.Visibility = Visibility.Hidden;
                        txtNCarte2.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[0, 2])
                    {
                        btnCarta3.Visibility = Visibility.Hidden;
                        txtNCarte3.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[0, 3])
                    {
                        btnCarta4.Visibility = Visibility.Hidden;
                        txtNCarte4.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[1, 0])
                    {
                        btnCarta5.Visibility = Visibility.Hidden;
                        txtNCarte5.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[1, 1])
                    {
                        btnCarta6.Visibility = Visibility.Hidden;
                        txtNCarte6.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[1, 2])
                    {
                        btnCarta7.Visibility = Visibility.Hidden;
                        txtNCarte7.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[1, 3])
                    {
                        btnCarta8.Visibility = Visibility.Hidden;
                        txtNCarte8.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[2, 0])
                    {
                        btnCarta9.Visibility = Visibility.Hidden;
                        txtNCarte9.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[2, 1])
                    {
                        btnCarta10.Visibility = Visibility.Hidden;
                        txtNCarte10.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[2, 2])
                    {
                        btnCarta11.Visibility = Visibility.Hidden;
                        txtNCarte11.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[2, 3])
                    {
                        btnCarta12.Visibility = Visibility.Hidden;
                        txtNCarte12.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[3, 0])
                    {
                        btnCarta13.Visibility = Visibility.Hidden;
                        txtNCarte13.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[3, 1])
                    {
                        btnCarta14.Visibility = Visibility.Hidden;
                        txtNCarte14.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[3, 2])
                    {
                        btnCarta15.Visibility = Visibility.Hidden;
                        txtNCarte15.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoPrimaCarta == _partita.Mazzetti[3, 3])
                    {
                        btnCarta16.Visibility = Visibility.Hidden;
                        txtNCarte16.Visibility = Visibility.Hidden;
                    }
                }
                if (_mazzettoSecondaCarta.ContaCarteMazzetto() == 0)
                {
                    if (_mazzettoSecondaCarta == _partita.Mazzetti[0, 0])
                    {
                        btnCarta1.Visibility = Visibility.Hidden;
                        txtNCarte1.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[0, 1])
                    {
                        btnCarta2.Visibility = Visibility.Hidden;
                        txtNCarte2.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[0, 2])
                    {
                        btnCarta3.Visibility = Visibility.Hidden;
                        txtNCarte3.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[0, 3])
                    {
                        btnCarta4.Visibility = Visibility.Hidden;
                        txtNCarte4.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[1, 0])
                    {
                        btnCarta5.Visibility = Visibility.Hidden;
                        txtNCarte5.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[1, 1])
                    {
                        btnCarta6.Visibility = Visibility.Hidden;
                        txtNCarte6.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[1, 2])
                    {
                        btnCarta7.Visibility = Visibility.Hidden;
                        txtNCarte7.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[1, 3])
                    {
                        btnCarta8.Visibility = Visibility.Hidden;
                        txtNCarte8.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[2, 0])
                    {
                        btnCarta9.Visibility = Visibility.Hidden;
                        txtNCarte9.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[2, 1])
                    {
                        btnCarta10.Visibility = Visibility.Hidden;
                        txtNCarte10.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[2, 2])
                    {
                        btnCarta11.Visibility = Visibility.Hidden;
                        txtNCarte11.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[2, 3])
                    {
                        btnCarta12.Visibility = Visibility.Hidden;
                        txtNCarte12.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[3, 0])
                    {
                        btnCarta13.Visibility = Visibility.Hidden;
                        txtNCarte13.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[3, 1])
                    {
                        btnCarta14.Visibility = Visibility.Hidden;
                        txtNCarte14.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[3, 2])
                    {
                        btnCarta15.Visibility = Visibility.Hidden;
                        txtNCarte15.Visibility = Visibility.Hidden;
                    }
                    else if (_mazzettoSecondaCarta == _partita.Mazzetti[3, 3])
                    {
                        btnCarta16.Visibility = Visibility.Hidden;
                        txtNCarte16.Visibility = Visibility.Hidden;
                    }
                }
                if (_partita.EsitoPartita == Esito.Vittoria || _partita.EsitoPartita == Esito.Sconfitta)
                {
                    BtnCarteNascoste();
                    TxtNCarteNascoste();
                    txtPrimaCarta.Visibility = Visibility.Hidden;
                    txtSecondaCarta.Visibility = Visibility.Hidden;
                    btnPrimaCarta.Visibility = Visibility.Hidden;
                    btnSecondaCarta.Visibility = Visibility.Hidden;
                    btnSelezionaCarte.Visibility = Visibility.Hidden;
                    btnGiocaAncora.Visibility = Visibility.Visible;
                    btnSmettiDiGiocare.Visibility = Visibility.Visible;
                    if (_partita.EsitoPartita == Esito.Vittoria)
                    {
                        txtEsito.Text = $"{_partita.Giocatore.Nome} hai vinto!";
                        txtEsito.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        txtEsito.Text = $"{_partita.Giocatore.Nome} hai perso!";
                        txtEsito.Visibility = Visibility.Visible;
                    }
                }
                SetTxtNCarte();
                BtnCarteAttivate();
                ImpostaImmaginiCarte();
                _mazzettoPrimaCarta = null;
                _mazzettoSecondaCarta = null;
                btnPrimaCarta.Content = null;
                btnSecondaCarta.Content = null;
            }
            catch (Exception ex)
            {
                txtErr.Text = ex.Message;
                BtnCarteAttivate();
                _mazzettoPrimaCarta = null;
                _mazzettoSecondaCarta = null;
                btnPrimaCarta.Content = null;
                btnSecondaCarta.Content = null;
            }
        }

        private void btnGiocaAncora_Click(object sender, RoutedEventArgs e)
        {
            btnGiocaAncora.Visibility = Visibility.Hidden;
            btnSmettiDiGiocare.Visibility = Visibility.Hidden;
            btnPrimaCarta.Visibility = Visibility.Visible;
            btnSecondaCarta.Visibility = Visibility.Visible;
            txtPrimaCarta.Visibility = Visibility.Visible;
            txtSecondaCarta.Visibility = Visibility.Visible;
            btnSelezionaCarte.Visibility = Visibility.Visible;
            txtEsito.Visibility = Visibility.Collapsed;

            Window1 window = new Window1(_partita.Giocatore);
            window.Show();
            this.Close();
        }

        private void btnSmettiDiGiocare_Click(object sender, RoutedEventArgs e)
        {
            btnGiocaAncora.Visibility = Visibility.Hidden;
            btnSmettiDiGiocare.Visibility = Visibility.Hidden;
            btnPrimaCarta.Visibility = Visibility.Hidden;
            btnSecondaCarta.Visibility = Visibility.Hidden;
            txtPrimaCarta.Visibility = Visibility.Hidden;
            txtSecondaCarta.Visibility = Visibility.Hidden;
            btnSelezionaCarte.Visibility = Visibility.Hidden;
            txtEsito.Visibility = Visibility.Collapsed;
            txtFine.Visibility = Visibility.Visible;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
            }
            else
            {
                Timer.Stop();
                Application.Current.Shutdown();
            }
        }

        private void ImpostaImmaginiCarte()
        {
            if (_partita.Mazzetti[0, 0].ContaCarteMazzetto() > 0) img1.Source = new BitmapImage(new Uri(_partita.Mazzetti[0, 0].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[0, 1].ContaCarteMazzetto() > 0) img2.Source = new BitmapImage(new Uri(_partita.Mazzetti[0, 1].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[0, 2].ContaCarteMazzetto() > 0) img3.Source = new BitmapImage(new Uri(_partita.Mazzetti[0, 2].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[0, 3].ContaCarteMazzetto() > 0) img4.Source = new BitmapImage(new Uri(_partita.Mazzetti[0, 3].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[1, 0].ContaCarteMazzetto() > 0) img5.Source = new BitmapImage(new Uri(_partita.Mazzetti[1, 0].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[1, 1].ContaCarteMazzetto() > 0) img6.Source = new BitmapImage(new Uri(_partita.Mazzetti[1, 1].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[1, 2].ContaCarteMazzetto() > 0) img7.Source = new BitmapImage(new Uri(_partita.Mazzetti[1, 2].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[1, 3].ContaCarteMazzetto() > 0) img8.Source = new BitmapImage(new Uri(_partita.Mazzetti[1, 3].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[2, 0].ContaCarteMazzetto() > 0) img9.Source = new BitmapImage(new Uri(_partita.Mazzetti[2, 0].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[2, 1].ContaCarteMazzetto() > 0) img10.Source = new BitmapImage(new Uri(_partita.Mazzetti[2, 1].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[2, 2].ContaCarteMazzetto() > 0) img11.Source = new BitmapImage(new Uri(_partita.Mazzetti[2, 2].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[2, 3].ContaCarteMazzetto() > 0) img12.Source = new BitmapImage(new Uri(_partita.Mazzetti[2, 3].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[3, 0].ContaCarteMazzetto() > 0) img13.Source = new BitmapImage(new Uri(_partita.Mazzetti[3, 0].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[3, 1].ContaCarteMazzetto() > 0) img14.Source = new BitmapImage(new Uri(_partita.Mazzetti[3, 1].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[3, 2].ContaCarteMazzetto() > 0) img15.Source = new BitmapImage(new Uri(_partita.Mazzetti[3, 2].UltimaCarta().IndirizzoFile));
            if (_partita.Mazzetti[3, 3].ContaCarteMazzetto() > 0) img16.Source = new BitmapImage(new Uri(_partita.Mazzetti[3, 3].UltimaCarta().IndirizzoFile));
        }

        private void BtnCarteNascoste()
        {
            btnCarta1.Visibility = Visibility.Hidden;
            btnCarta2.Visibility = Visibility.Hidden;
            btnCarta3.Visibility = Visibility.Hidden;
            btnCarta4.Visibility = Visibility.Hidden;
            btnCarta5.Visibility = Visibility.Hidden;
            btnCarta6.Visibility = Visibility.Hidden;
            btnCarta7.Visibility = Visibility.Hidden;
            btnCarta8.Visibility = Visibility.Hidden;
            btnCarta9.Visibility = Visibility.Hidden;
            btnCarta10.Visibility = Visibility.Hidden;
            btnCarta11.Visibility = Visibility.Hidden;
            btnCarta12.Visibility = Visibility.Hidden;
            btnCarta13.Visibility = Visibility.Hidden;
            btnCarta14.Visibility = Visibility.Hidden;
            btnCarta15.Visibility = Visibility.Hidden;
            btnCarta16.Visibility = Visibility.Hidden;
        }

        private void BtnCarteDisattivate()
        {
            btnCarta1.IsEnabled = false;
            btnCarta2.IsEnabled = false;
            btnCarta3.IsEnabled = false;
            btnCarta4.IsEnabled = false;
            btnCarta5.IsEnabled = false;
            btnCarta6.IsEnabled = false;
            btnCarta7.IsEnabled = false;
            btnCarta8.IsEnabled = false;
            btnCarta9.IsEnabled = false;
            btnCarta10.IsEnabled = false;
            btnCarta11.IsEnabled = false;
            btnCarta12.IsEnabled = false;
            btnCarta13.IsEnabled = false;
            btnCarta14.IsEnabled = false;
            btnCarta15.IsEnabled = false;
            btnCarta16.IsEnabled = false;
        }
        private void BtnCarteAttivate()
        {
            btnCarta1.IsEnabled = true;
            btnCarta2.IsEnabled = true;
            btnCarta3.IsEnabled = true;
            btnCarta4.IsEnabled = true;
            btnCarta5.IsEnabled = true;
            btnCarta6.IsEnabled = true;
            btnCarta7.IsEnabled = true;
            btnCarta8.IsEnabled = true;
            btnCarta9.IsEnabled = true;
            btnCarta10.IsEnabled = true;
            btnCarta11.IsEnabled = true;
            btnCarta12.IsEnabled = true;
            btnCarta13.IsEnabled = true;
            btnCarta14.IsEnabled = true;
            btnCarta15.IsEnabled = true;
            btnCarta16.IsEnabled = true;
        }

        private void BtnCarteVisibili()
        {
            btnCarta1.Visibility = Visibility.Visible;
            btnCarta2.Visibility = Visibility.Visible;
            btnCarta3.Visibility = Visibility.Visible;
            btnCarta4.Visibility = Visibility.Visible;
            btnCarta5.Visibility = Visibility.Visible;
            btnCarta6.Visibility = Visibility.Visible;
            btnCarta7.Visibility = Visibility.Visible;
            btnCarta8.Visibility = Visibility.Visible;
            btnCarta9.Visibility = Visibility.Visible;
            btnCarta10.Visibility = Visibility.Visible;
            btnCarta11.Visibility = Visibility.Visible;
            btnCarta12.Visibility = Visibility.Visible;
            btnCarta13.Visibility = Visibility.Visible;
            btnCarta14.Visibility = Visibility.Visible;
            btnCarta15.Visibility = Visibility.Visible;
            btnCarta16.Visibility = Visibility.Visible;
        }
        private void TxtNCarteNascoste()
        {
            txtNCarte1.Visibility = Visibility.Hidden;
            txtNCarte2.Visibility = Visibility.Hidden;
            txtNCarte3.Visibility = Visibility.Hidden;
            txtNCarte4.Visibility = Visibility.Hidden;
            txtNCarte5.Visibility = Visibility.Hidden;
            txtNCarte6.Visibility = Visibility.Hidden;
            txtNCarte7.Visibility = Visibility.Hidden;
            txtNCarte8.Visibility = Visibility.Hidden;
            txtNCarte9.Visibility = Visibility.Hidden;
            txtNCarte10.Visibility = Visibility.Hidden;
            txtNCarte11.Visibility = Visibility.Hidden;
            txtNCarte12.Visibility = Visibility.Hidden;
            txtNCarte13.Visibility = Visibility.Hidden;
            txtNCarte14.Visibility = Visibility.Hidden;
            txtNCarte15.Visibility = Visibility.Hidden;
            txtNCarte16.Visibility = Visibility.Hidden;
        }
        private void TxtNCarteVisibili()
        {
            txtNCarte1.Visibility = Visibility.Visible;
            txtNCarte2.Visibility = Visibility.Visible;
            txtNCarte3.Visibility = Visibility.Visible;
            txtNCarte4.Visibility = Visibility.Visible;
            txtNCarte5.Visibility = Visibility.Visible;
            txtNCarte6.Visibility = Visibility.Visible;
            txtNCarte7.Visibility = Visibility.Visible;
            txtNCarte8.Visibility = Visibility.Visible;
            txtNCarte9.Visibility = Visibility.Visible;
            txtNCarte10.Visibility = Visibility.Visible;
            txtNCarte11.Visibility = Visibility.Visible;
            txtNCarte12.Visibility = Visibility.Visible;
            txtNCarte13.Visibility = Visibility.Visible;
            txtNCarte14.Visibility = Visibility.Visible;
            txtNCarte15.Visibility = Visibility.Visible;
            txtNCarte16.Visibility = Visibility.Visible;
        }
    }
}
