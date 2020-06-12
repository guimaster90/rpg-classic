using NUnit.Framework;
using RpgAniAlie.Personagens;

namespace Tests
{
    public class Tests3
    {
        [SetUp]
        public void Setup3()
        {

        }

        [Test]
        
        public void AtaqueNervoso()
        {
            var inimigo = new Boss(1, "deslizando", "inimig");
            inimigo.Atk = 10;
            Assert.AreEqual(inimigo.AtaqueNervoso(), 12);
        }

        [Test]

        public void ataque()
        {
            var inimigo = new Boss(1, "deslizando", "inimig");
            inimigo.Vida = 100;
            inimigo.Atk = 10;
            Assert.AreEqual(inimigo.Ataques(), 10);
        }

    }
}