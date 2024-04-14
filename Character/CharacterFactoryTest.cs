using CharacterFactory.Models;
using CharacterFactory.Services;
using GameLib.CharacterFactory.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLibUnitTest.Character
{
    [TestClass]
    public class CharacterFactoryTest
    {
        [TestMethod]
        public void TestPlayerCreation()
        {
            // Arrange
            string playerName = "Hero";
            int playerHealth = 100;
            int playerAttackDamage = 20;
            int playerDefense = 10;
            int playerX = 0;
            int playerY = 0;
            ICharacterFactory playerFactory = new PlayerFactory();

            // Act
            CharacterBase player = playerFactory.CreateCharacter(playerName, playerHealth, playerAttackDamage, playerDefense, playerX, playerY);

            // Assert
            Assert.IsNotNull(player);
            Assert.IsInstanceOfType(player, typeof(Player));
            Assert.AreEqual(playerName, player.Name);
            Assert.AreEqual(playerHealth, player.Health);
            Assert.AreEqual(playerAttackDamage, player.AttackDamage);
            Assert.AreEqual(playerDefense, player.Defense);
            Assert.AreEqual(playerX, player.X);
            Assert.AreEqual(playerY, player.Y);
        }

        [TestMethod]
        public void TestNPCCreation()
        {
            // Arrange
            string npcName = "Monster";
            int npcHealth = 50;
            int npcAttackDamage = 15;
            int npcDefense = 5;
            int npcX = 10;
            int npcY = 10;
            ICharacterFactory npcFactory = new NpcFactory();

            // Act
            CharacterBase npc = npcFactory.CreateCharacter(npcName, npcHealth, npcAttackDamage, npcDefense, npcX, npcY);

            // Assert
            Assert.IsNotNull(npc);
            Assert.IsInstanceOfType(npc, typeof(NPC));
            Assert.AreEqual(npcName, npc.Name);
            Assert.AreEqual(npcHealth, npc.Health);
            Assert.AreEqual(npcAttackDamage, npc.AttackDamage);
            Assert.AreEqual(npcDefense, npc.Defense);
            Assert.AreEqual(npcX, npc.X);
            Assert.AreEqual(npcY, npc.Y);
        }
    }
}

