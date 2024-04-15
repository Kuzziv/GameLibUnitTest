using System;
using System.Collections.Generic;
using GameLib.Lootsystem.Models;
using GameLib.Lootsystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLibUnitTest.Lootsystem
{
    [TestClass]
    public class LootSystemTest
    {
        [TestMethod]
        public void TestOpenBag()
        {
            // Arrange
            Bag bag = new Bag();
            IItem sword = new Weapon("Sword", 50);
            IItem potion = new Consumable("Health Potion", 20);

            bag.AddItem(sword);
            bag.AddItem(potion);

            LootSystem lootSystem = new LootSystem();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => lootSystem.OpenBag(null));

            // This test cannot be fully automated due to the Console.WriteLine output,
            // but you could redirect Console output and assert it.
        }

        [TestMethod]
        public void TestGetBagsContainingItemType()
        {
            // Arrange
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            IItem sword = new Weapon("Sword", 50);
            IItem potion = new Consumable("Health Potion", 20);

            bag1.AddItem(sword);
            bag2.AddItem(potion);

            List<Bag> bags = new List<Bag> { bag1, bag2 };

            LootSystem lootSystem = new LootSystem();

            // Act
            var bagsWithWeapons = lootSystem.GetBagsContainingItemType(bags, typeof(Weapon));

            // Assert
            Assert.IsNotNull(bagsWithWeapons, "The list of bags containing weapons should not be null.");
            Assert.AreEqual(1, bagsWithWeapons.Count(), "Expected one bag containing weapons.");
            Assert.AreEqual(bag1, bagsWithWeapons.First(), "The first bag should contain a weapon.");
        }



        [TestMethod]
        public void TestGetBagWithHighestValue()
        {
            // Arrange
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            IItem sword = new Weapon("Sword", 50);
            IItem potion = new Consumable("Health Potion", 20);

            bag1.AddItem(sword);
            bag2.AddItem(potion);

            List<Bag> bags = new List<Bag> { bag1, bag2 };

            LootSystem lootSystem = new LootSystem();

            // Act
            var bagWithHighestValue = lootSystem.GetBagWithHighestValue(bags);

            // Assert
            Assert.AreEqual(bag1, bagWithHighestValue);
        }

        [TestMethod]
        public void TestGetBagWithMostItems()
        {
            // Arrange
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            IItem sword = new Weapon("Sword", 50);
            IItem potion = new Consumable("Health Potion", 20);

            bag1.AddItem(sword);
            bag1.AddItem(potion);
            bag2.AddItem(sword);

            List<Bag> bags = new List<Bag> { bag1, bag2 };

            LootSystem lootSystem = new LootSystem();

            // Act
            var bagWithMostItems = lootSystem.GetBagWithMostItems(bags);

            // Assert
            Assert.AreEqual(bag1, bagWithMostItems);
        }

        [TestMethod]
        public void TestRemoveItemFromBag()
        {
            // Arrange
            Bag bag = new Bag();
            IItem sword = new Weapon("Sword", 50);
            IItem potion = new Consumable("Health Potion", 20);

            bag.AddItem(sword);
            bag.AddItem(potion);

            LootSystem lootSystem = new LootSystem();

            // Act
            lootSystem.RemoveItemFromBag(bag, potion);

            // Assert
            Assert.IsFalse(bag.GetItems().Contains(potion), "The potion should have been removed from the bag.");
        }

    }
}
