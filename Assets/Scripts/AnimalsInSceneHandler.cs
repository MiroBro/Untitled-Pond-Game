using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AnimalsInSceneHandler : MonoBehaviour
{
    public GameObject animalPrefab;
    public Transform animalParent;
    public int numberOfAnimalsAtStart;
    // Start is called before the first frame update

    public class AnimalInstance 
    {
        public Guid AnimalId  { get; set; }
        public AnimalType AnimalType { get; set; }
        public double SellPrice { get; set; }
        public GameObject WorldObj { get; set; }
        public bool IsAdult { get; set; }
    }

    private static Dictionary<Guid, AnimalInstance> animalInstances = new Dictionary<Guid, AnimalInstance>();

    public static Dictionary<Guid, AnimalInstance> GetAllInventory()
    {
        return animalInstances;
    }

    void Start()
    {

    }

    private Vector2 RandomPos()
    {
        float spawnY = UnityEngine.Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = UnityEngine.Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        return new Vector2(spawnX, spawnY);
    }

    public void DeleteAnimalFromHabitat(Guid id) 
    {
        var inst = animalInstances[id];
        animalInstances.Remove(id);

        Destroy(inst.WorldObj);
    }

    public void AddAnimalToHabitat(AnimalType fishType) 
    {
        var inst = Instantiate(animalPrefab, Global.Instance.GetRandomPosInScene(), animalPrefab.transform.rotation, animalParent);
        Guid newId = Guid.NewGuid();
        inst.GetComponent<AnimalInstanceData>().FishId = newId;
        inst.GetComponent<AnimalInstanceData>().ChangeFishSprite(fishType);
        AnimalInstance fishInstance = new AnimalInstance() { AnimalId = newId, SellPrice = References.Instance.animalData.GetFishCategory(fishType).SellPrice, WorldObj = inst, AnimalType = fishType };

        animalInstances.Add(newId, fishInstance);
    }

    public AnimalInstance GetAnimal(Guid id) 
    {
        return animalInstances[id];
    }

}
