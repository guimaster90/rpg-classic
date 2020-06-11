using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    public class InimigosVoadores : InimigoComum
    {

        public override int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 101);
            if (!Esquivar(VeloAtk))
            {
                if (AtaCrit)
                {
                    return Defender(AtaAtak) * 2;
                }
                else
                {
                    float aux = randNum.Next(84, 121);

                    aux /= 100;

                    aux = (float)Defender(AtaAtak) * aux;
                    if (Defender(AtaAtak) == 1)

                        return 1;
                    else
                        aux /= 2;
                        return (int)aux;
                }
            }
            else
            {
                return 0;

            }

        }

    }
}
