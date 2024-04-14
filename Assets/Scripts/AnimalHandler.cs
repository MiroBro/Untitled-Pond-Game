using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class AnimalHandler : MonoBehaviour
{
    //public float speed;
    public GameObject animalHolder;

    public bool waiting = false;
    public Vector3 randomPosition;

    //public float relaxSwimSpeed = 0.8f;
    public float maxSwimSpeed = 1;

    private Vector2 worldPosition;

    private Rigidbody2D rb;

    public GameObject littleAnimal;
    public GameObject bigAnimal;

    public int experience;
    public TimeSpan timeToGrow;
    public System.DateTime startTime;

    public bool grown;

    public CircleCollider2D coll;
    public float smallCollRadius = 0.12f;
    public float bigCollRadius = 0.12f;

    private void Start()
    {
        startTime = DateTime.Now;
        timeToGrow = new TimeSpan(0, 0, UnityEngine.Random.Range(5, 30));//10);
        rb = transform.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = References.Instance.mainCam.nearClipPlane;
        worldPosition = References.Instance.mainCam.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButton(0) && Vector2.Distance(transform.position, worldPosition) < Global.Instance.maxDistanceToFood && !grown)
        {
            MoveFishToCursor();
        } else
        {
            SmoothRandomMovement();
        }

        Level();
    }

    public void Level()
    {
        if (!grown && (DateTime.Now - startTime) > timeToGrow)
        {
            grown = true;
            littleAnimal.SetActive(false);
            bigAnimal.SetActive(true);
            coll.radius = bigCollRadius;
        }
    }

    public void SmoothRandomMovement()
    {
        if (Vector2.Distance(transform.position,randomPosition) < 0.3)
        {
            randomPosition = Global.Instance.RandomPos(transform.position);
        }
        //transform.position = Vector3.Lerp(transform.position, randomPosition, Time.deltaTime * relaxSwimSpeed);

        Vector2 dir = (randomPosition - transform.position).normalized;

        rb.AddRelativeForce(dir * Global.Instance.fishRelaxSpeed);//relaxSwimSpeed);
        FlipToMovementDirection();
    }

    private void MoveFishToCursor()
    {

        {
            //this.transform.position = worldPosition;   

            var step = Global.Instance.fishGetFoodSpeed * Time.deltaTime;

            Vector2 pos = transform.position;
            Vector2 dir = (worldPosition - pos).normalized;

            if (rb.velocity.magnitude > maxSwimSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSwimSpeed;
                //rb.AddRelativeForce(-dir * speed);
            }
            else
            {
                rb.AddRelativeForce(dir * Global.Instance.fishGetFoodSpeed * (Vector3.Distance(transform.position, worldPosition) / 2));
            }
            FlipToMovementDirection();
        }
    }

    private void FlipToMovementDirection()
    {
        if (rb.velocity.x > 0)
        {
            animalHolder.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            animalHolder.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void HighlightFish()
    {
        littleAnimal.GetComponent<SpriteRenderer>().material = Global.Instance.highlightMat;
        bigAnimal.GetComponent<SpriteRenderer>().material = Global.Instance.highlightMat;
        References.Instance.uiHandler.TurnOnFishInfo(UserInput.clickedFish.GetComponent<AnimalInstanceData>().FishId);
    }

    public void UnHighlightFish()
    {
        if (!Global.IsPointerOverUIObject())
        {
            littleAnimal.GetComponent<SpriteRenderer>().material = Global.Instance.defaultMat;
            bigAnimal.GetComponent<SpriteRenderer>().material = Global.Instance.defaultMat;
            References.Instance.uiHandler.TurnOffFishInfo();
        }
    }
}




/*
private void SmoothMove()
{
    if (waiting == false)
    {
        StartCoroutine(LerpCube());//SendMessage("LerpCube");
    }
    else
    {
        transform.position = Vector3.Lerp(transform.position, randomPosition, Time.deltaTime * 1);
    }

}*/
/*


*/
/*
private IEnumerator LerpCube()
{
    randomPosition = new Vector3(Random.Range(6, -6), Random.Range(4, -4));
    waiting = true;
    yield return new WaitForSeconds(moveDelay);
    waiting = false;
    //Debug.Log ("waited");
}

*/
/*
private void JaggedMovement()
{
    //Get the vector
    Vector3 movementvector = RandomSmoothPointOnUnitSphere(Time.deltaTime, Time.deltaTime);//Time.time);
    Debug.Log(movementvector);
    //You can also use CharacterController.Move()
    transform.Translate(movementvector * Time.deltaTime);
}
*/

/*
//used methods to seperate just edit it then it's done
public float Speed = 5f;
private float x;
private float y;
private Vector2 NextPos;

void Gettingthenextposition()
{
    //the first number is included the last number is not in Random.Range
    x = Random.Range(3, 10);
    y = Random.Range(3, 10);
    NextPos = new Vector2(x, y);
}
*/

/*
void move()
{
    transform.position = Vector2.MoveTowards(transform.position, NextPos, Speed);
}
*/

/*
//There are probably better ways to do this.
Vector3 RandomSmoothPointOnUnitSphere(float time, float seed)
{


    //Get the y of the vector
    float y = Mathf.PerlinNoise(time, seed*10);

    int newNoise = Random.Range(0, 10000);
    int newNoise2 = Random.Range(0, 10000);

    float something = Mathf.PerlinNoise(transform.position.x + newNoise, transform.position.y + newNoise);
    if (something < 0.5) something = -something; 
    float something2 = Mathf.PerlinNoise(transform.position.x + newNoise2, transform.position.y + newNoise2);
    if (something2 < 0.5) something2 = -something2;


    //Create a vector3
    //Vector3 vector = new Vector3(x, y, 0);
    Vector3 vector = new Vector3(something, something2, 0);

    //Normalize the vector and return it
    return Vector3.Normalize(vector);

}
*/

/*

*/



/*
        if (Input.mousePosition.y >= (Screen.height * 0.95))
        {
            transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
        }
*/
//transform.position = Vector3.MoveTowards(transform.position, worldPosition, step);
//if (rb.velocity.magnitude < maxVelocity)


/*
 
         float spawnY = Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
 */