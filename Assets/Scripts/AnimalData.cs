using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType
{
    Small,
    Medium,
    Big,
    Bigger,
    Biggest
}

public class AnimalData : MonoBehaviour
{
    public Sprite[] animalSprites;

    public class AnimalCategory
    {
        public AnimalType Type { get; set; }
        public string Name { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }


        //TODO: guess we need to add which animals are included in the category?

    }

    private Dictionary<AnimalType, AnimalCategory> allAnimalCategories = new Dictionary<AnimalType, AnimalCategory>()
    {
        {AnimalType.Small, new AnimalCategory{ Type = AnimalType.Small, Name = "Tiny animals", BuyPrice = 10, SellPrice = 20,} },
        {AnimalType.Medium, new AnimalCategory{ Type = AnimalType.Medium, Name = "Mid animals", BuyPrice = 1000 , SellPrice = 2000} },
        {AnimalType.Big, new AnimalCategory{ Type = AnimalType.Big, Name = "Big animals", BuyPrice = 2000000,SellPrice = 4000000 } },
        {AnimalType.Bigger, new AnimalCategory{ Type = AnimalType.Bigger, Name = "Bigger animals", BuyPrice = 50000000, SellPrice = 100000000} },
        {AnimalType.Biggest, new AnimalCategory{ Type = AnimalType.Biggest, Name = "Biggest animals", BuyPrice = 15000000000, SellPrice = 30000000000} },
    };

    public Dictionary<AnimalType, AnimalCategory> GetAllFishCategories() 
    { 
        return allAnimalCategories; 
    }

    public AnimalCategory GetFishCategory(AnimalType fishType) 
    {
        return allAnimalCategories[fishType]; 
    }

}
