using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RpgAniAlieLib.Equipamento;
using RpgAniAlieLib.Player;

namespace RpgAniAlieLib.Personagens
{
    public class Aliados : Personagem
    {

        public Aliados(string sprite, string nome)
        {
            this.Nivel = 1;
            this.Nome = nome;
            this.Atk = 10;
            this.Vida = 10;
            this.Velo = 10;
            this.Def = 10;
            this.Sorte = 10;
            this.VidaMax = this.Vida;
            this.XP = 0;
            this.XPProxNlv = 20;
        }
        /// <summary>
        /// Irá guardar a quantidade de vezes que uma habilidade pode ser usada 
        /// </summary>
        public int MedidorEspecial { get; set; }
        /// <summary>
        /// quantidade de experiência
        /// </summary>
        public int XP { get; set; } 
        /// <summary>
        /// quantidade de experiência utilizada para upar um nivel
        /// </summary>
        public double XPProxNlv { get; set; }

        public void UparStatus()//upa os status base dependendo do nível
        {
            this.VidaMax += 10*this.Nivel;
            this.Def += 10*this.Nivel;
            this.Atk += 10 * this.Nivel;
            this.Velo += 10 * this.Nivel;
            this.Sorte += 10 * this.Nivel;
            this.Vida = this.VidaMax;

        }
        public void GanharXP(int xp)//irá pegar o XP Adiquirido da batalha e se tiver uma quantidade suficiente irá upar de nivel
        {
            this.XP += xp;
            if(this.XP >= this.XPProxNlv)
            {
                this.XPProxNlv *= 1.5;
                this.Nivel++;
                UparStatus();
            }
        }
        
        public int DefesaTotal()//Irá pegar os status da armadura e incluir no status do personagem
        {
           int aux = (Peitoral.DefesaDoItem * InventarioC.NlvArmadura);
            aux += (Capacete.DefesaDoItem2 * InventarioC.NlvArmadura);
            return (aux + this.Def);
        }

        public int AtaqueTotal()//Irá pegar os status da armadura e incluir no status do personagem
        {
            int aux = (Luva.AtaqueDoItem * InventarioC.NlvArmadura);
            return (aux + this.Atk);
        }

        public int VelocidadeTotal()//Irá pegar os status da armadura e incluir no status do personagem
        {
            int aux = (Bota.VeloAtaqueDoItem* InventarioC.NlvArmadura);
            return (aux + this.Velo);
        }

        public int SorteTotal()//Irá pegar os status da armadura e incluir no status do personagem
        {
            int aux = (Colar.SorteDoItem * InventarioC.NlvArmadura);
            return (aux + this.Sorte);
        }

        public override bool Critico()
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 100);
            if (x <= this.SorteTotal())//Irá sortear para checar se o ataque foi critico ou não
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
            if (this.DefesaTotal() > AtaAtak)//Se a defesa do defensor for amior do que o ataque do atacante só sera causado 1 de dano
            {
                return 1;

            }
            else return (AtaAtak - this.DefesaTotal());
        }

        public override bool Esquivar(int VeloAtk)
        {

            if (this.VelocidadeTotal() > VeloAtk)//Verificando se a velociada do atacante é menor do que a sua
            {
                Random randNum = new Random();

                int x = randNum.Next(0, 101);

                if (this.VelocidadeTotal() - VeloAtk >= x)//Caso for maior ele irá sortear se o personagem conseguiu esquivar
                {
                    return true;//Conseguiu esquivar
                }
                else
                {
                    return false;//Não conseguiu esquivar
                }

            }
            else
            {
                return false;//Não conseguiu esquivar
            }
        }

        public override int CalcularDano(int AtaAtak, int VeloAtk, bool AtaCrit)
        {
            Random randNum = new Random();
            if (!Esquivar(VeloAtk))//Caso o personagem esquive não recebera dano
            {
                if (AtaCrit)//Caso o atk for critico o personagem recebera o dobro de dano
                {
                    return Defender(AtaAtak) * 2;
                }
                else
                {


                    if (Defender(AtaAtak) == 1)//Caso a defesa for maior do que o ataque ele receberá 1 de dano
                    {
                        return 1;
                    }
                    else
                    {
                        float aux = randNum.Next(84, 121);//O ataque pode variar entre 85% a 120% do atk original

                        aux /= 100;

                        aux = (float)Defender(AtaAtak) * aux;

                        return (int)aux;
                    }
                }
            }
            else
            {
                return 0;

            }

        }

        public int Curar()
        {
            if (InventarioC.qtdPocao > 0)
            {
                InventarioC.qtdPocao--;
                this.Vida += this.Nivel * 5;
                if(this.Vida > this.VidaMax)
                {
                    this.Vida = this.VidaMax;
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override int AtaqueEspecial()//Ataque especial é um ataque mais forte que utilizaza o MedidorDeEspecial
        {
            throw new NotImplementedException();
        }
    }
}

    

