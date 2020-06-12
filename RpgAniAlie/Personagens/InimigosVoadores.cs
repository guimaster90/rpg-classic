using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    public class InimigosVoadores : Inimigos
    {
        public InimigosVoadores(int nivel, string sprite, string nome) : base(nivel, sprite, nome)
        {

        }
        public override int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 101);
            if (!Esquivar(VeloAtk))//Caso o personagem esquive não recebera dano
            {
                if (AtaCrit)//Caso o atk for critico o personagem recebera o dobro de dano
                {
                    return Defender(AtaAtak) * 2;
                }
                else
                {
                    if (Defender(AtaAtak) == 1)//Caso a defesa for maior do que o ataque ele receberá 1 de dano

                        return 1;
                    else
                    {
                        float aux = randNum.Next(84, 121);//O ataque pode variar entre 85% a 120% do atk original

                        aux /= 100;

                        aux = (float)Defender(AtaAtak) * aux;
                        aux /= 2; //Irá receber metade do dano
                        return (int)aux;
                    }
                }
            }
            else
            {
                return 0;

            }

        }

    }
}
