using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace RpgTelas
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class FaseBatalha : Page
    {
        MediaPlayer tocador;
        public FaseBatalha()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tocador = (MediaPlayer)e.Parameter;
            
        }
        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void AtkCaco_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Curar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CurarCaco_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AtirarCaco_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Recarregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Perder_Click(object sender, RoutedEventArgs e)
        {
            tocador.Source = null;
            this.Frame.Navigate(typeof(GameOver));
            
        }
    }
}
