using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    class Inimigos : Personagem
    {
        public override int Atacar()
        {
            throw new NotImplementedException();
        }

        public override float Crítico()
        {
            throw new NotImplementedException();
        }

        public override int Defender(int AtaAtak)
        {
            if (this.Def > AtaAtak)
            {
                return 1;

            }
            else return (AtaAtak - this.Def); 

        }

        public override int Esquivar(int VeloAtk)
        {
            if (this.Velo > VeloAtk)
            {
                return (this.Velo - VeloAtk) ;
            }
            else
            {
                return 0;
            } 
        }

        public override int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 101);
            if (Esquivar(VeloAtk) <= x )
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
