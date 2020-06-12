using NUnit.Framework;
using RpgAniAlieLib.Personagens;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TesteDanoDfIgualQAtk()
        {
            var inimigo = new Inimigos(1,"deslizando","inimig");
            inimigo.Vida = 23;
            inimigo.Velo = 0;
            inimigo.Def = 1000;
            inimigo.ReceberDano(1000, 100, false);

            Assert.AreEqual(inimigo.Vida, 22);
           
        }

        [Test]
        public void TesteDanoAtkMaiorQDf()
        {
            var inimigo = new Inimigos(1, "deslizando", "inimig");
            inimigo.Vida = 100;
            inimigo.Velo = 0;
            inimigo.Def = 100;
            inimigo.ReceberDano(125, 1, false);
            Assert.Greater(inimigo.Vida,68);
            Assert.Less(inimigo.Vida, 80);
         
        }

        [Test]
        public void TesteConseguiuEsquivarInimigo()
        {
            var inimigo = new Inimigos(1, "deslizando", "inimig");
            inimigo.Velo = 200;
            Assert.True(inimigo.Esquivar(100));
        }

        [Test]
        public void TesteNaoEsquivarInimigo()
        {
            var inimigo = new Inimigos(1, "deslizando", "inimig");
            inimigo.Velo = 0;
            Assert.False(inimigo.Esquivar(1));
        }

        [Test]
        public void TesteConseguiuCriticoInimigo()
        {
            var inimigo = new Inimigos(1, "deslizando", "inimig");
            inimigo.Sorte = 100;
            Assert.True(inimigo.Critico());
        }

        [Test]
        public void TesteNaoCriticoInimigo()
        {
            var inimigo = new Inimigos(1, "deslizando", "inimig");
            inimigo.Sorte = 0;
            Assert.False(inimigo.Critico());
        }

        [Test]
        public void AtaqueDeFuriaPadrao()
        {
            var inimigo = new Inimigos(1, "deslizando", "inimig");
            inimigo.Atk = 10;
            Assert.AreEqual(inimigo.AtaqueEspecial(), 15);
        }

        [Test]

        public void Ataques()
        {
            var inimigo = new Inimigos(1, "deslizando", "inimig");
            inimigo.Vida = 100;
            inimigo.Atk = 10;
            Assert.AreEqual(inimigo.Ataques(), 10);
        }
    }
}