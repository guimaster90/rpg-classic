using RpgAniAlie.Personagens;
using System;

namespace RpgAniAlie
{
    class Program
    {
        static void Main(string[] args)
        {
            Inimigos inimigo = new Inimigos();
            inimigo.Velo = 150;
            inimigo.Def = 100;
            inimigo.Vida = 100;
            inimigo.Sorte = 100;
            inimigo.ReceberDano(120,100, false);
            Console.WriteLine(inimigo.Vida);
            Console.ReadKey();
        }
    }
}
