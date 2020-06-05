using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
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

    public sealed partial class Fase1 : Page
    {


        public Fase1()
        {
            this.InitializeComponent();


        }
       
        protected override async void OnKeyUp(KeyRoutedEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == Windows.System.VirtualKey.Down)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Down // O Método a ser chamado
                );
            }
            else if (e.Key == Windows.System.VirtualKey.Up)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Up // O Método a ser chamado
                );
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Right // O Método a ser chamado
                );
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Left // O Método a ser chamado
                );
            }
        }

        /*
       private async void Page_KeyDown(object sender, KeyRoutedEventArgs e)
       {
           if (e.Key == Windows.System.VirtualKey.Down)
           {
               await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Down // O Método a ser chamado
               );
           }
           else if (e.Key == Windows.System.VirtualKey.Up)
           {
               await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Up // O Método a ser chamado
               );
           }
           else if (e.Key == Windows.System.VirtualKey.Right)
           {
               await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                   CoreDispatcherPriority.Normal,
                   Right // O Método a ser chamado
              );
           }
           else if (e.Key == Windows.System.VirtualKey.Left)
           {
               await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                   Left // O Método a ser chamado
              );
           }
       }
       */
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Set the input focus to ensure that keyboard events are raised.
            this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
            Debug.WriteLine("NavigatedTo!");
        }

        public async void Down()
        {
            int x = 0;
            // Manipular o componente de Interface
            while (x < 20)
            {
                ImgCacoTranslateTransform.Y += 5;
                //Canvas.SetTop(ImgBestFriend, Canvas.GetTop(ImgBestFriend) + 5);
                await Task.Delay(50);
                x++;
            }
        }

        public async void Up()
        {
            int cont = 0;
            // Manipular o componente de Interface
            while (cont < 20)
            {
                ImgCacoTranslateTransform.Y = cont < 10 ? ImgCacoTranslateTransform.Y - 5 : ImgCacoTranslateTransform.Y + 5;
                // Canvas.SetTop(ImgBestFriend, Canvas.GetTop(ImgBestFriend) - 5);
                await Task.Delay(100);
                cont++;
            }
        }

        public async void Right()
        {
            int x = 0;
            // Manipular o componente de Interface
            while (x < 10)
            {
                ImgCacoTranslateTransform.X += 5;
                //Canvas.SetLeft(ImgBestFriend, Canvas.GetLeft(ImgBestFriend) + 5);
                await Task.Delay(50);
                x++;
            }
        }

        public async void Left()
        {
            int x = 0;
            // Manipular o componente de Interface
            while (x < 10)
            {
                ImgCacoTranslateTransform.X -= 5;
                //Canvas.SetLeft(ImgBestFriend, Canvas.GetLeft(ImgBestFriend) - 5);
                await Task.Delay(50);
                x++;
            }
        }

       

    }
}

