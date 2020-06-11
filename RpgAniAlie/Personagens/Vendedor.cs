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
            
            string resposta = Console.ReadLine();
            if (resposta.Equals("Sim") || resposta.Equals("sim"))
            {
                
                string qtd = Console.ReadLine();
                int quantos = Int32.Parse(qtd);
                if (Moeda.QuantidadeMoeda < quantos)
                {
                    
                } else {
                    
                    Pocao.qtdPocao += quantos;
                }

            }
            
        }
    }
}