using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static GameObject clickedFish;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Global.IsPointerOverUIObject())
        {
            // Cast a ray straight down.
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0,0,1));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // If it hits something...
            if (hit.collider != null && hit.collider.CompareTag("Animal"))
            {
                if (clickedFish != null)
                {
                    clickedFish.GetComponent<AnimalHandler>().UnHighlightFish();
                }
                clickedFish = hit.collider.gameObject;
                clickedFish.GetComponent<AnimalHandler>().HighlightFish();
            } 
            else
            {
                if (clickedFish != null)
                {
                    clickedFish.GetComponent<AnimalHandler>().UnHighlightFish();
                    clickedFish = null;
                }
            }
        }
    }
}
