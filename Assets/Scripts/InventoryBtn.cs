using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBtn : MonoBehaviour
{
    public TextMeshProUGUI animalName;
    public TextMeshProUGUI animalValue;
    public Image animalIcon;
    public Slider slider;
    public AnimalType fishType;
    public DateTime birthDate;
    public double exp;
    public Guid animalId;

    public void SetExp(float exp)
    {

    }

    public void SetToFish(AnimalType fishType, Guid id, DateTime birthDate)
    {
        this.fishType = fishType;
        this.animalId = id;
        this.birthDate = birthDate;
    }
}
