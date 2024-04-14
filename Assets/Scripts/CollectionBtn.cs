using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionBtn : MonoBehaviour
{
    public TextMeshProUGUI animalName;
    public Image animalIcon;
    public AnimalType fishType;

    public void SetToAnimal(AnimalType fishType)
    {
        this.fishType = fishType;
    }
}
