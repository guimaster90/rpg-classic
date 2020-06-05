using System;
using System.Collections.Generic;
using System.Text;
using RpgAniAlie.Itens;

namespace RpgAniAlie.Personagens
{
    class Vendedor
    {

        public void VenderPocao()
        {
            Console.WriteLine("Você quer comprar poção?");
            string resposta = Console.ReadLine();
            if (resposta.Equals("Sim") || resposta.Equals("sim"))
            {
                Console.WriteLine("Você quer quantas poções?");
                string qtd = Console.ReadLine();
                int quantos = Int32.Parse(qtd);
                if (Moeda.QuantidadeMoeda < quantos)
                {
                    Console.WriteLine("Você n tem moedas pra comprar poção");
                } else {
                    Console.WriteLine("Compra efetuada com sucesso");
                    Pocao.qtdPocao += quantos;
                }

            }
            
        }
    }
}