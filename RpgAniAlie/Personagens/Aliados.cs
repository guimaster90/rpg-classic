using System;
using System.Collections.Generic;
using System.Text;
using RpgAniAlie.Equipamento;

namespace RpgAniAlie.Personagens
{
    public class Aliados : Personagem
    {
        Equip Equips = new Equip();
        public bool Equipar(Equip Equips)
        {
            if (this.Equips.Equipado == false)
            {
                this.Equips.Equipado = true;
                this.Def += this.Equips.DefesaDoItem;
                this.Atk += this.Equips.AtaqueItem;
                this.Velo += this.Equips.VeloAtaqueDoItem;
                return true;
            }
            else
            {
                Console.WriteLine("O Item " + this.Equips.NomeDoItem + "já está equipado");
                return false;
            }
        }



        public override bool Critico()
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 100);//tem que ser balanceado quando tiver feito as armaduras
            if (x <= this.Sorte)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            return false;

        }

        public override int CalcularDano(int AtaAtak, int VeloAtk, bool AtaCrit)
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 101);
            if (Esquivar(VeloAtk))
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

    

