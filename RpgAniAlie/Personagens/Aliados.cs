using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RpgAniAlie.Equipamento;

namespace RpgAniAlie.Personagens
{
    public class Aliados : Personagem
    {

        ArrayList inventario = new ArrayList ();
        ArrayList CapaceteEquipado = new ArrayList ();
        ArrayList PeitoralEquipado = new ArrayList ();
        ArrayList BotasEquipado = new ArrayList ();
        ArrayList LuvaEquipado = new ArrayList ();
        ArrayList ColarEquipado = new ArrayList ();
        
        public Aliados()
        {
            Capacete CapaceteBasico = new Capacete();
            CapaceteBasico.NomeDoItem = "Capacete Lixo";
            CapaceteBasico.DefesaDoItem = 20;
            CapaceteBasico.AtaqueItem = 5;
            CapaceteBasico.VeloAtaqueDoItem = 5;

            Capacete CapaceteDefesa = new Capacete();
            CapaceteDefesa.NomeDoItem = "Capacete Blindão";
            CapaceteDefesa.DefesaDoItem = 20;
            CapaceteDefesa.AtaqueItem = 5;
            CapaceteDefesa.VeloAtaqueDoItem = 5;

            Capacete CapaceteAtaque = new Capacete();
            CapaceteAtaque.NomeDoItem = "Capacete da Cabeçada";
            CapaceteAtaque.DefesaDoItem = 5;
            CapaceteAtaque.AtaqueItem = 20;
            CapaceteAtaque.VeloAtaqueDoItem = 5;

            Capacete CapaceteRapido = new Capacete();
            CapaceteAtaque.NomeDoItem = "Capacete Ligeirinho";
            CapaceteAtaque.DefesaDoItem = 5;
            CapaceteAtaque.AtaqueItem = 5;
            CapaceteAtaque.VeloAtaqueDoItem = 20;

            Peitoral PeitoralBasico = new Peitoral();
            PeitoralBasico.NomeDoItem = "Peitoral Lixo";
            PeitoralBasico.DefesaDoItem = 20;
            PeitoralBasico.AtaqueItem = 5;
            PeitoralBasico.VeloAtaqueDoItem = 5;

            Peitoral PeitoralDefesa = new Peitoral();
            PeitoralDefesa.NomeDoItem = "Peitoral Blindão";
            PeitoralDefesa.DefesaDoItem = 20;
            PeitoralDefesa.AtaqueItem = 5;
            PeitoralDefesa.VeloAtaqueDoItem = 5;

            Peitoral PeitoralAtaque = new Peitoral();
            PeitoralAtaque.NomeDoItem = "Peitoral da Peitada";
            PeitoralAtaque.DefesaDoItem = 5;
            PeitoralAtaque.AtaqueItem = 20;
            PeitoralAtaque.VeloAtaqueDoItem = 5;

            Peitoral PeitoralRapido = new Peitoral();
            PeitoralRapido.NomeDoItem = "Peitoral Ligeirinho";
            PeitoralRapido.DefesaDoItem = 5;
            PeitoralRapido.AtaqueItem = 5;
            PeitoralRapido.VeloAtaqueDoItem = 20;

            Luva LuvaBasico = new Luva();
            LuvaBasico.NomeDoItem = "Luva Lixo";
            LuvaBasico.DefesaDoItem = 20;
            LuvaBasico.AtaqueItem = 5;
            LuvaBasico.VeloAtaqueDoItem = 5;

            Luva LuvaDefesa = new Luva();
            PeitoralDefesa.NomeDoItem = "Luva Blindão";
            PeitoralDefesa.DefesaDoItem = 20;
            PeitoralDefesa.AtaqueItem = 5;
            PeitoralDefesa.VeloAtaqueDoItem = 5;

            Luva LuvaAtaque = new Luva();
            LuvaAtaque.NomeDoItem = "Luva Porradeira";
            LuvaAtaque.DefesaDoItem = 5;
            LuvaAtaque.AtaqueItem = 20;
            LuvaAtaque.VeloAtaqueDoItem = 5;

            Luva LuvaRapido = new Luva();
            LuvaRapido.NomeDoItem = "Luva Ligeirinho";
            LuvaRapido.DefesaDoItem = 5;
            LuvaRapido.AtaqueItem = 5;
            LuvaRapido.VeloAtaqueDoItem = 20;

            Bota BotaBasico = new Bota();
            BotaBasico.NomeDoItem = "Bota Lixo";
            BotaBasico.DefesaDoItem = 20;
            BotaBasico.AtaqueItem = 5;
            BotaBasico.VeloAtaqueDoItem = 5;

            Bota BotaDefesa = new Bota();
            BotaDefesa.NomeDoItem = "Bota Blindão";
            BotaDefesa.DefesaDoItem = 20;
            BotaDefesa.AtaqueItem = 5;
            BotaDefesa.VeloAtaqueDoItem = 5;

            Bota BotaAtaque = new Bota();
            BotaAtaque.NomeDoItem = "Bota da Rasteira";
            BotaAtaque.DefesaDoItem = 5;
            BotaAtaque.AtaqueItem = 20;
            BotaAtaque.VeloAtaqueDoItem = 5;

            Bota BotaRapido = new Bota();
            BotaRapido.NomeDoItem = "Bota Ligeirinho";
            BotaRapido.DefesaDoItem = 5;
            BotaRapido.AtaqueItem = 5;
            BotaRapido.VeloAtaqueDoItem = 20;

            Colar ColarDePoucaSorte = new Colar();
            ColarDePoucaSorte.NomeDoItem = "Quaze Azarado";
            ColarDePoucaSorte.Sorte = 10;

            Colar ColarComSorte = new Colar();
            ColarComSorte.NomeDoItem = "Sortizinha";
            ColarComSorte.Sorte = 20;

            Colar ColarDeMuitaSorte = new Colar();
            ColarDeMuitaSorte.NomeDoItem = "Agr ja da pra ganhar na Loteria";
            ColarDeMuitaSorte.Sorte = 30;

        }

        /*
        public bool Equipar()
        {
            if (CapaceteEquipado.Capacity == 0)
            {
                Console.WriteLine("Qual qual a peça de armadura que você quer equipar ");
                Console.WriteLine("Digite para /n 1-Capacete /n 2-Peitoral /n 3-Botas /n 4-Luvas /n 5-Colar");
                int escolha = int.Parse(Console.ReadLine());
                if (escolha == 1)
                {


                }
            }
            else
            {
                return false;
            }
        }
        */

        /*
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
        */


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

    

