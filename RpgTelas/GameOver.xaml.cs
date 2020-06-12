using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
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
    public sealed partial class GameOver : Page
    {
        MediaPlayer tocador;
        public GameOver()
        {
            this.InitializeComponent();
            tocador = new MediaPlayer();
            Musica();
        }
        public async void Musica()
        {

            Windows.Storage.StorageFolder pasta = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile arquivo = await pasta.GetFileAsync("Caixao.mp3");

            tocador.AutoPlay = true;
            tocador.Source = MediaSource.CreateFromStorageFile(arquivo);
            tocador.IsLoopingEnabled = true;
        }
        private void ResetPageCache()
        {
            var cacheSize = ((Frame)Parent).CacheSize;
            ((Frame)Parent).CacheSize = 0;
            ((Frame)Parent).CacheSize = cacheSize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tocador.Source = null;
            ResetPageCache();
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
