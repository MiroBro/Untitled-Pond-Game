using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public GameObject shopButtonParent;
    public GameObject shopButton;


    private void Start()
    {
        var fishes = References.Instance.animalData.GetAllFishCategories();

        foreach (var fish in fishes) 
        {
            var inst = Instantiate(shopButton, shopButtonParent.transform);   
            inst.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{fish.Value.Name}\n{Global.FormatNumber((long)fish.Value.BuyPrice)}";
            inst.GetComponent<Button>().onClick.AddListener( () => BuyFish(fish.Value.Type));
        }
    }

    public void BuyFish(AnimalType fishType)
    {
        References.Instance.moneyHandler.AddMoney(-References.Instance.animalData.GetFishCategory(fishType).BuyPrice);
        References.Instance.animalsInSceneHandler.AddAnimalToHabitat(fishType);
    }

    public void SellFish()
    {
        var fishId = UserInput.clickedFish.gameObject.GetComponent<AnimalInstanceData>().FishId;
        var fish = References.Instance.animalsInSceneHandler.GetAnimal(fishId);

        References.Instance.animalsInSceneHandler.DeleteAnimalFromHabitat(fishId);
        Debug.Log("Adding " + fish.SellPrice);
        References.Instance.moneyHandler.AddMoney(fish.SellPrice);

        References.Instance.uiHandler.TurnOffFishInfo();
    }
}
