using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInstanceData : MonoBehaviour
{
    public Guid FishId { get; set; }
    public AnimalType AnimalType { get; set; }

    public SpriteRenderer[] animalSprites;

    public void ChangeFishSprite(AnimalType animalType) 
    {
        AnimalType = animalType;
        foreach (var animal in animalSprites)
        {
            animal.sprite = References.Instance.animalData.animalSprites[(int)animalType];
        }
    }
}
