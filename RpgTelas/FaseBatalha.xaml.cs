using RpgAniAlieLib.Personagens;
using RpgAniAlieLib.Player;
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
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace RpgTelas
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class FaseBatalha : Page
    {
        MediaPlayer tocador;
        Passar p;
        Macaco caco;
        Cobra co;
        Capivara capi;
        List<Inimigos> InimigosList = new List<Inimigos>();
        int qualInimigo;
        public FaseBatalha()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            p = (Passar)e.Parameter;
            tocador = p.RetornaTocador();
            caco = p.RetornaCaco();
            co = p.RetornaCo();
            capi = p.RetornaCapi();

            if(co == null)
            {
                ImgCo.Visibility = Visibility.Collapsed;
                AtkCo.Visibility = Visibility.Collapsed;
                Mordida.Visibility = Visibility.Collapsed;
                CurarCo.Visibility = Visibility.Collapsed;
                HpCo.Visibility = Visibility.Collapsed;
                Veneno.Visibility = Visibility.Collapsed;
            }

            if(capi == null)
            {
                ImgCapi.Visibility = Visibility.Collapsed;
                AtkCapi.Visibility = Visibility.Collapsed;
                Investida.Visibility = Visibility.Collapsed;
                CurarCapi.Visibility = Visibility.Collapsed;
                HpCapi.Visibility = Visibility.Collapsed;
                Estamina.Visibility = Visibility.Collapsed;
            }
            InventarioC.QtdBala = 4;
            if (p.QualInimigo == 'i')
            {
                InimigosRamdom();
                Random randNum = new Random();
                qualInimigo = randNum.Next(0, InimigosList.Count);
                ImgInimigo.Source = new BitmapImage(new Uri(base.BaseUri, @"" + InimigosList[qualInimigo].SpriteDeBatalha));
            }else if (p.QualInimigo == 'c')
            {
                InimigosList.Add(new Inimigos(caco.Nivel , "/Assets/Imagens/maxresdefault.jpg", "Capivara", "Investida"));
                qualInimigo = 0;
            }
            else if (p.QualInimigo == 'o')
            {
                InimigosList.Add(new Inimigos(caco.Nivel , "/Assets/Imagens/maxresdefault.jpg", "Cobra", "Mordida"));
                qualInimigo = 0;
            }
            else if (p.QualInimigo == 'a')
            {
                InimigosList.Add(new Inimigos(caco.Nivel, "/Assets/Imagens/maxresdefault.jpg", "Alien", "Laiser"));
                qualInimigo = 0;
            }
            AtualizarTxts();
        }
        public void InimigosRamdom()
        {
            Random randNum = new Random();

            int x = randNum.Next(caco.Nivel , caco.Nivel +2);
            InimigosList.Add(new Inimigos(caco.Nivel, "/Assets/Imagens/maxresdefault.jpg", "Urso","Garrada"));
            InimigosList.Add(new Inimigos(caco.Nivel, "/Assets/Imagens/roxo.jpg", "Furão", "Cabeçada"));
            InimigosList.Add(new Inimigos(caco.Nivel, "/Assets/Imagens/roxo.jpg", "Girafa", "Pescoçada"));
            InimigosList.Add(new Inimigos(caco.Nivel, "/Assets/Imagens/roxo.jpg", "Elefante", "Trombada"));
            InimigosList.Add(new InimigosVoadores(caco.Nivel, "/Assets/Imagens/maxresdefault.jpg", "Gavião", "Garrada"));
            InimigosList.Add(new InimigosVoadores(caco.Nivel, "/Assets/Imagens/maxresdefault.jpg", "Urubu", " Bicada"));
        }
        public void AtualizarTxts()
        {
            HpCaco.Text ="HP: " + caco.Vida.ToString() + "/" + caco.VidaMax.ToString();
            Carga.Text ="Munição: "+ caco.MedidorEspecial + "/3";
            PoteTxt.Text = ": " + InventarioC.qtdPocao.ToString();
            MuniTxt.Text = ": " + InventarioC.QtdBala.ToString();
           NomeInimigo.Text ="Nome: " + InimigosList[qualInimigo].Nome;
            HpInmigo.Text = "Hp: " + InimigosList[qualInimigo].Vida + "/" + InimigosList[qualInimigo].VidaMax;
            if(capi != null)
            {
                HpCapi.Text = "HP: " + capi.Vida.ToString() + "/" + capi.VidaMax;
                Estamina.Text = "Estamina: " + capi.MedidorEspecial + "/10"; 
            }

            if(co != null)
            {
                HpCo.Text = "HP: " + co.Vida.ToString() + "/" + co.VidaMax;
                Veneno.Text = "Veneno: " + co.MedidorEspecial + "/" + "10";
            }
        }
        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void AtkCaco_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
            if (0<caco.Vida)
            {


                int aux;
                aux = InimigosList[qualInimigo].ReceberDano(caco.AtaqueTotal(), caco.VelocidadeTotal(), caco.Critico());
                MensagemDoMeio.Text = "O macaco causou " + aux.ToString() + " de dano a(ao) " + InimigosList[qualInimigo].Nome + ". ";
                ReacaoInimigo();
                AtualizarTxts();
            }
            else
            {
                MensagemDoMeio.Text = "O macaco está desmaiado";
            }
        }

        private void CurarCaco_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
           

            
            if (caco.Curar() == 1)
            {
                MensagemDoMeio.Text = "O macaco se curou. ";
                ReacaoInimigo();
                AtualizarTxts();
                //Dar aviso em um txt
            }
            else
            {
                MensagemDoMeio.Text = "O macaco não conseguiu se curar. ";
                //Dar aviso em um txt
            }
           
        }

        private void AtirarCaco_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
            if (0 < caco.Vida)
            {
                int aux = caco.AtaqueEspecial();
                if (aux != 0)
                {
                    aux = InimigosList[qualInimigo].ReceberDano(aux, caco.VelocidadeTotal(), caco.Critico());
                    MensagemDoMeio.Text = "O macaco atirou  causando " + aux.ToString() + " de dano a(ao) " + InimigosList[qualInimigo].Nome + ". ";
                    ReacaoInimigo();
                }
                else
                {
                    MensagemDoMeio.Text = "O macaco não consegiu atirar.";
                }
                AtualizarTxts();
            }
            else
            {
                MensagemDoMeio.Text = "O macaco está desmaiado";
            }
        }

        private void Recarregar_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
            if (0<caco.Vida )
            {
                if (caco.Recarregar())
                {
                    MensagemDoMeio.Text = "Você recarregou. ";
                    ReacaoInimigo();
                }
                else
                {
                    MensagemDoMeio.Text = "Não é possível recarregar.";
                }

                AtualizarTxts();
            }
            else
            {
                MensagemDoMeio.Text = "O macaco está desmaiado";
            }
        }

        private void Perder_Click(object sender, RoutedEventArgs e)//Irá direcionar o jogador para a tela de GameOver
        {
            tocador.Source = null;//Irá parar a musica
            this.Frame.Navigate(typeof(GameOver));//Irá passar para a tela GameOver

        }

        private void AtkCapi_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
            if (0 < capi.Vida)
            {
                int aux;
                aux = InimigosList[qualInimigo].ReceberDano(capi.AtaqueTotal(), capi.VelocidadeTotal(), capi.Critico());
                MensagemDoMeio.Text = "A capivara causou " + aux.ToString() + " de dano a(ao) " + InimigosList[qualInimigo].Nome + ". ";
                capi.ReceberStamina();
                ReacaoInimigo();
                AtualizarTxts();
            }
            else
            {
                MensagemDoMeio.Text = "A capivara está desmaiada";
            }
        }

        private void Investida_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
            if (0 < capi.Vida)
            {
                int aux = capi.AtaqueEspecial();
                if (aux != 0)
                {
                    aux = InimigosList[qualInimigo].ReceberDano(aux, capi.VelocidadeTotal(), capi.Critico());
                    MensagemDoMeio.Text = "A investida da capivara causou " + aux.ToString() + " de dano a(ao) " + InimigosList[qualInimigo].Nome + ". ";
                    ReacaoInimigo();
                }
                else
                {
                    MensagemDoMeio.Text = "A capivara não conseguiu realizar uma investida. ";
                }
                AtualizarTxts();
            }
            else
            {
                MensagemDoMeio.Text = "A capivara está desmaiada";
            }
        }

        private void CurarCapi_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
                if (capi.Curar() == 1)
                {
                    MensagemDoMeio.Text = "A capivara se curou. ";
                    ReacaoInimigo();
                    AtualizarTxts();
                }
                else
                {
                    MensagemDoMeio.Text = "A capivara não conseguiu se curar. ";
                }
            
        }

        private void AtkCo_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
            if (0 < co.Vida )
            {


                int aux;
                aux = InimigosList[qualInimigo].ReceberDano(co.AtaqueTotal(), co.VelocidadeTotal(), co.Critico());
                MensagemDoMeio.Text = "A capivara causou " + aux.ToString() + " de dano a(ao) " + InimigosList[qualInimigo].Nome + ". ";
                ReacaoInimigo();
                AtualizarTxts();
            }
            else
            {
                MensagemDoMeio.Text = "A cobra está desmaiada";
            }
        }

        private void Mordida_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
            if (0 < co.Vida)
            {
                int aux = co.AtaqueEspecial();
                if (aux != 0)
                {
                    aux = InimigosList[qualInimigo].ReceberDano(aux, co.VelocidadeTotal(), co.Critico());
                    MensagemDoMeio.Text = "A mordida da causou " + aux.ToString() + " de dano a(ao) " + InimigosList[qualInimigo].Nome + ". ";
                    ReacaoInimigo();

                }
                else
                {
                    MensagemDoMeio.Text = "A cobra não conseguiu  morder o inimigo. ";
                }
                AtualizarTxts();
            }
            else
            {
                MensagemDoMeio.Text = "A cobra está desmaiada";
            }
        }

        private void CurarCo_Click(object sender, RoutedEventArgs e)
        {
            MensagemDoMeio.Text = "";
                if (co.Curar() == 1)
                {
                    MensagemDoMeio.Text = "A cobra se curou. ";
                    ReacaoInimigo();
                    AtualizarTxts();
                    //Dar aviso em um txt
                }
                else
                {
                    MensagemDoMeio.Text = "A cobra não conseguiu se curar. ";
                }
            
            
        }

        public async void ReacaoInimigo()
        {
            
            if (InimigosList[qualInimigo].Vida > 0)
            {
                int aux= 0;
                if (capi != null)
                {
                    aux++;
                }

                if(co != null)
                {
                    aux++;
                }
                Random randNum = new Random();

                
               int aleatorio = randNum.Next(0,aux+1);
                if (aleatorio == 0 && 0<caco.Vida )
                {
                    aux = caco.ReceberDano(InimigosList[qualInimigo].Ataques(), InimigosList[qualInimigo].Velo, InimigosList[qualInimigo].Critico());
                    string aux2;
                   if ( InimigosList[qualInimigo].Ataques() > InimigosList[qualInimigo].Atk )
                    {
                         aux2 = " com uma " + InimigosList[qualInimigo].NomeAtaqueDeFuria;
                    }
                    else
                    {
                        aux2 = "";
                    }
                    MensagemDoMeio.Text += "O " + InimigosList[qualInimigo].Nome + " causou " + aux.ToString() + " de dano " + aux2 + " ao  Macaco ";
                }
                else if (0 < capi.Vida && aleatorio == 1 || capi != null &&  caco.Vida < 0 && 0 < capi.Vida)
                {
                    string aux2;
                    if (InimigosList[qualInimigo].Ataques() > InimigosList[qualInimigo].Atk)
                    {
                        aux2 = " com uma " + InimigosList[qualInimigo].NomeAtaqueDeFuria;
                    }
                    else
                    {
                        aux2 = "";
                    }
                    capi.ReceberDano(InimigosList[qualInimigo].Ataques(), InimigosList[qualInimigo].Velo, InimigosList[qualInimigo].Critico());
                    MensagemDoMeio.Text += "O " + InimigosList[qualInimigo].Nome + " causou " + aux.ToString() + " de dano " + aux2 + " a " + "Capivara";
                }
                else if (aleatorio == 2 && 0 < co.Vida)
                {
                    string aux2;
                    if (InimigosList[qualInimigo].Ataques() > InimigosList[qualInimigo].Atk)
                    {
                        aux2 = " com uma " + InimigosList[qualInimigo].NomeAtaqueDeFuria;
                    }
                    else
                    {
                        aux2 = "";
                    }
                    co.ReceberDano(InimigosList[qualInimigo].Ataques(), InimigosList[qualInimigo].Velo, InimigosList[qualInimigo].Critico());
                    MensagemDoMeio.Text += "O " + InimigosList[qualInimigo].Nome + " causou " + aux.ToString() + " de dano " + aux2 + " a " + "Cobra";
                }

                if(caco.Vida <= 0  && capi == null && co == null)
                {
                    tocador.Source = null;//Irá parar a musica
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    this.Frame.Navigate(typeof(GameOver));//Irá passar para a tela GameOver
                }
                else if(caco.Vida <= 0 && capi.Vida <= 0 && co == null)
                {
                    tocador.Source = null;//Irá parar a musica
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    this.Frame.Navigate(typeof(GameOver));//Irá passar para a tela GameOver
                }else if(caco.Vida <= 0 && capi.Vida <= 0 && co.Vida < 0)
                {
                    tocador.Source = null;//Irá parar a musica
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    this.Frame.Navigate(typeof(GameOver));//Irá passar para a tela GameOver
                }
            }
            else
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                MensagemDoMeio.Text = "Você ganhou a batalha. Você recebeu uma moeda. Todos os seus aliados ganharão 10 de xp";
                InventarioC.QuantidadeMoeda++;
                caco.GanharXP(10);
                if(capi != null)
                {
                    capi.GanharXP(10);
                }

                if (co != null)
                {
                    co.GanharXP(10);
                    co.RecarregarVeneno();
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
                if(p.QualInimigo == 'i')
                {
                    this.Frame.GoBack();
                }else if(p.QualInimigo == 'c')
                {
                    tocador.Source = null;// Irá parar a musica
                    this.Frame.Navigate(typeof(Fase2), p);
                }
                else if (p.QualInimigo == 'o')
                {
                    tocador.Source = null;// Irá parar a musica
                    this.Frame.Navigate(typeof(Fase3), p);
                }
                else if (p.QualInimigo == 'a')
                {
                    tocador.Source = null;// Irá parar a musica
                    this.Frame.Navigate(typeof(TelaDeFim));
                }

            }
        }
    }
}
