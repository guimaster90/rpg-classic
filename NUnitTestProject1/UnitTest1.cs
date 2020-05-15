using NUnit.Framework;
using RpgAniAlie.Personagens;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var inimigo = new Inimigos();
            inimigo.Vida = 100;
            inimigo.Velo = 0;
            inimigo.Def = 100;
            inimigo.ReceberDano(125, 1, false);

            Assert.Pass();
        }
    }
}