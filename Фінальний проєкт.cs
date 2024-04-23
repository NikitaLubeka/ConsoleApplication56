using System;
using System.Collections.Generic;
using System.IO;

class Personage
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public List<Item> Inventory { get; set; }

    public Personage(string name, int level, int health, int strength, int agility, int intelligence)
    {
        Name = name;
        Level = level;
        Health = health;
        Strength = strength;
        Agility = agility;
        Intelligence = intelligence;
        Inventory = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Inventory.Remove(item);
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Інвентар {Name}:");
        foreach (var item in Inventory)
        {
            Console.WriteLine("Назва: {item.Name}, Тип: {item.Type}, Вартість: {item.Value}, Вага: {item.Weight}");
        }
    }
}
class Item
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    public int Weight { get; set; }

    public Item(string name, string type, int value, int weight)
    {
        Name = name;
        Type = type;
        Value = value;
        Weight = weight;
    }
}

class Game
{
    public List<Personage> Characters { get; set; }
    public List<Item> Items { get; set; }

    public Game()
    {
        Characters = new List<Personage>();
        Items = new List<Item>();
    }

    public void CreateCharacter(string name, int level, int health, int strength, int agility, int intelligence)
    {
        var character = new Personage(name, level, health, strength, agility, intelligence);
        Characters.Add(character);
    }

    public void DeleteCharacter(string name)
    {
        var character = Characters.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (character != null)
        {
            Characters.Remove(character);
            Console.WriteLine("Персонаж {name} видален.");
        }
        else
        {
            Console.WriteLine("Персонаж {name} не знайден.");
        }
    }

    public void AddItemToCharacter(string charName, Item item)
    {
        var character = Characters.Find(c => c.Name.Equals(charName, StringComparison.OrdinalIgnoreCase));
        if (character != null)
        {
            character.AddItem(item);
            Console.WriteLine("Предмет {item.Name} додан до {charName} у інвентарь.");
        }
        else
        {
            Console.WriteLine("Character {charName} not found.");
        }
    }

    public void RemoveItemFromCharacter(string charName, Item item)
    {
        var character = Characters.Find(c => c.Name.Equals(charName, StringComparison.OrdinalIgnoreCase));
        if (character != null)
        {
            character.RemoveItem(item);
            Console.WriteLine("Предмет {item.Name} видален {charName} з  інвентаря");
        }
        else
        {
            Console.WriteLine("Персонажа {charName} не знайдено.");
        }
    }

    public void ChangeCharacterStats(string charName, int level, int health, int strength, int agility, int intelligence)
    {
        var character = Characters.Find(c => c.Name.Equals(charName, StringComparison.OrdinalIgnoreCase));
        if (character != null)
        {
            character.Level = level;
            character.Health = health;
            character.Strength = strength;
            character.Agility = agility;
            character.Intelligence = intelligence;
            Console.WriteLine("Характеристики змінено до персонажа {charName}.");
        }
        else
        {
            Console.WriteLine("Персонаж {charName} не знайдено.");
        }
    }

    public void DisplayCharacterInventory(string charName)
    {
        var character = Characters.Find(c => c.Name.Equals(charName, StringComparison.OrdinalIgnoreCase));
        if (character != null)
        {
            character.DisplayInventory();
        }
        else
        {
            Console.WriteLine("Персонаж {charName} не знайдено.");
        }
    }
}