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
        List<UIElement> ColisoesLidar = new List<UIElement>();
        public Fase1()
        {
            this.InitializeComponent();
            this.KeyDown += Fase_KeyDown;
            this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            
        }



        public void handleCollisions(double x, double y)
        {
            List<UIElement> AllCollidables = Colidiveis.Children.ToList();
            Rect player = new Rect();
            player.X = Canvas.GetLeft(ImgCaco);
            player.Y = Canvas.GetTop(ImgCaco);
            player.Height = ImgCaco.Height;
            player.Width = ImgCaco.Width;


            foreach (Image item in AllCollidables)
            {
                if (item.Visibility == Visibility.Visible)
                {
                    Rect obj = new Rect();
                    obj.X = Canvas.GetLeft(item);
                    obj.Y = Canvas.GetTop(item);
                    obj.Height = item.Height;
                    obj.Width = item.Width;

                    obj.Intersect(player);

                    if (!obj.IsEmpty)
                    {
                        ColisoesLidar.Add(item);
                    }
                }
            }
            foreach (Image item in ColisoesLidar)
            {

                if (item.Name.ToLower().Contains("bloco"))
                {
                    //item.Visibility = Visibility.Collapsed;
                    if (y != 0)
                    {
                        Canvas.SetTop(ImgCaco, Canvas.GetTop(ImgCaco) + y );
                    }else if (x != 0){
                        Canvas.SetLeft(ImgCaco, Canvas.GetLeft(ImgCaco) + x);
                    }

                }
                if (item.Name.ToLower().Contains("inimigo"))
                {
                    item.Visibility = Visibility.Collapsed;
                    this.Frame.Navigate(typeof(FaseBatalha));
                }
                if (item.Name.ToLower().Contains("chefe"))
                {
                    item.Visibility = Visibility.Collapsed;
                    this.Frame.Navigate(typeof(Fase2));
                }
            }
            
            ColisoesLidar.Clear();
        }
        private async void Fase_KeyDown(object sender, KeyRoutedEventArgs e)
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

        public async void Down()
        {
            int x = 0;
            // Manipular o componente de Interface
            while (x < 1)
            {
                Canvas.SetTop(ImgCaco, Canvas.GetTop(ImgCaco) + 5);
                handleCollisions(0,-5);
                await Task.Delay(50);
                x++;
            }
        }

        public async void Up()
        {
            int cont = 0;
            // Manipular o componente de Interface
            while (cont < 1)
            {
                
                Canvas.SetTop(ImgCaco, Canvas.GetTop(ImgCaco) - 5);
                handleCollisions(0, 5);
                await Task.Delay(100);
                cont++;
            }
        }

        public async void Right()
        {
            int x = 0;
            // Manipular o componente de Interface
            while (x < 1)
            {
                
                Canvas.SetLeft(ImgCaco, Canvas.GetLeft(ImgCaco) + 5);
                handleCollisions(-5, 0);
                await Task.Delay(50);
                x++;
            }
        }

        public async void Left()
        {
            int x = 0;
            // Manipular o componente de Interface
            while (x < 1)
            {
                
                Canvas.SetLeft(ImgCaco, Canvas.GetLeft(ImgCaco) - 5);
                handleCollisions(5, 0);
                await Task.Delay(50);
                x++;
            }
        }

        /*
            private async void Fase1_KeyDown(object sender, KeyRoutedEventArgs e)
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

        public async void Movimentacao(double x, double y)
        {
            //double aux = Canvas.GetLeft(ImgCaco);
            //double aux2 = Canvas.GetTop(ImgCaco);
            while (true)
            {
                
                if (x == Canvas.GetLeft(ImgCaco))
                {
                    break;
                }
                if (x < Canvas.GetLeft(ImgCaco))
                {

                    Canvas.SetLeft(ImgCaco, Canvas.GetLeft(ImgCaco) - 1); 
                    await Task.Delay(1);
                }
                else if (x > Canvas.GetLeft(ImgCaco)) {
                    Canvas.SetLeft(ImgCaco, Canvas.GetLeft(ImgCaco) + 1);
                    await Task.Delay(1);
                }
                
            }

            while (y != Canvas.GetTop(ImgCaco))
            {
                if (y < Canvas.GetTop(ImgCaco))
                {
                    Canvas.SetTop(ImgCaco, Canvas.GetTop(ImgCaco) - 1); 
                    await Task.Delay(1);
                }
                else if (y > Canvas.GetTop(ImgCaco))
                {
                    Canvas.SetTop(ImgCaco, Canvas.GetTop(ImgCaco) + 1);
                    await Task.Delay(1);
                }

            }
        }

        private void BtnInv_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Inventario));
        }
    }
}

