﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlieLib.Player
{
    public class InventarioC
    {
        /// <summary>
        /// Quantidade de munição que tem para rearregar o medidor especial do macaco
        /// </summary>
        public static int QtdBala { get; set; }
        /// <summary>
        /// quantidade de moeda que é usada no vendedor
        /// </summary>
        public static int QuantidadeMoeda { get; set; }
        /// <summary>
        /// Quantidade de poções que tem,pocção é usada para recuperar a vida
        /// </summary>
        public static int qtdPocao { get; set; }
        /// <summary>
        /// O Nivel que sua armadura está,quanto maior o nivel,maior o status que ela dará ao personagem
        /// </summary>
        public static int NlvArmadura { get; set; }


    }
}
