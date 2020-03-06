using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    public class Inimigos : Personagem
    {

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

        public override bool Esquivar(int VeloAtk)
        {
            if (this.Velo > VeloAtk)
            {
                Random randNum = new Random();
                int x = randNum.Next(0, 101);
                if (this.Velo - VeloAtk <= x) return (true);
                else return false;
            }
            else
            {
                return false;
            } 
        }

        public override int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
           
            if (Esquivar(VeloAtk))
            {
                if (AtaCrit)
                {
                    return Defender(AtaAtak) * 2;
                }
                else
                {
                    Random randNum = new Random();
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

        public Inimigos()
        {

        }
    }
}
