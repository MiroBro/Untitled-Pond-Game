using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject fishInfo;
    public TextMeshProUGUI fishNameText;
    public TextMeshProUGUI fishSellPriceText;
    public Image fishIcon;

    public GameObject shop;
    public TextMeshProUGUI moneyText;

    public GameObject inventoryUi;
    public GameObject inventoryBtnHolder;
    public GameObject inventoryBtnPrefab;

    public GameObject inspectorUi;
    public GameObject collectionUi;

    public void TurnOffFishInfo()
    {
        fishInfo.SetActive(false);
    }

    public void TurnOnFishInfo(System.Guid fishId)
    {
        var fish = References.Instance.animalsInSceneHandler.GetAnimal(fishId);
        var fishCategory = References.Instance.animalData.GetFishCategory(fish.AnimalType);

        fishNameText.text = fishCategory.Name;
        fishSellPriceText.text = fishCategory.SellPrice.ToString();
        fishIcon.sprite = References.Instance.animalData.animalSprites[(int)fish.AnimalType];

        fishInfo.SetActive(true);
    }

    public void RefreshMoney()
    {
        moneyText.text = Global.FormatNumber((long)StaticValues.money);
    }
    public void CloseShop()
    {
        shop.SetActive(false);
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }

    public void OpenInventory()
    {
        var inventory = AnimalsInSceneHandler.GetAllInventory();

        foreach (Transform btn in inventoryBtnHolder.transform)
        {
            Destroy(btn.gameObject);
        }

        foreach (var fish in inventory)
        {
            var inst = Instantiate(inventoryBtnPrefab,inventoryBtnHolder.transform);
            var i = inst.GetComponent<InventoryBtn>();

        }

        inventoryUi.SetActive(true);
    }

    public void OpenCollection()
    {
        collectionUi.SetActive(true);
    }

    public void CloseInventory()
    {
        inventoryUi.SetActive(false);
    }

    public void CloseAllOpenableUi()
    {
        inventoryUi.SetActive(false);
        shop.SetActive(false);
        collectionUi.SetActive(false);
        inspectorUi.SetActive(false);
    }
}
