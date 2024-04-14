using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Global : MonoBehaviour
{
    private static Global _instance;
    public static Global Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public float maxDistToSwim;
    public float maxDistanceToFood;

    public GameObject left;
    public GameObject right;
    public GameObject upper;
    public GameObject bottom;

    //public Camera mainCam;

    public Material defaultMat;
    public Material highlightMat;

    public float fishRelaxSpeed;
    public float fishGetFoodSpeed;

    public Vector2 RandomPos(Vector3 currentPos)
    {
        var minX = (currentPos.x - maxDistToSwim) < left.transform.position.x ? left.transform.position.x : (currentPos.x - maxDistToSwim);
        var maxX = (currentPos.x + maxDistToSwim) > right.transform.position.x ? right.transform.position.x : (currentPos.x + maxDistToSwim);

        var minY = (currentPos.y - maxDistToSwim) < bottom.transform.position.y ? bottom.transform.position.y : (currentPos.y - maxDistToSwim);
        var maxY = (currentPos.y + maxDistToSwim) > bottom.transform.position.y ? upper.transform.position.y : (currentPos.y + maxDistToSwim);

        float moveToX = UnityEngine.Random.Range(minX, maxX);
        float moveToY = UnityEngine.Random.Range(minY, maxY);

        Vector2 randomPos = new Vector2(moveToX, moveToY);
        return randomPos;
    }

    public Vector2 GetRandomPosInScene()
    {
        float moveToX = UnityEngine.Random.Range(left.transform.position.x+1, right.transform.position.x-1);
        float moveToY = UnityEngine.Random.Range(bottom.transform.position.y+1, upper.transform.position.y -1);

        return new Vector2 (moveToX, moveToY);
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    public static string FormatNumber(long num)
    {
        /*
        // Ensure number has max 3 significant digits (no rounding up can happen)
        long i = (long)Mathf.Pow(10, (int)Mathf.Max(0, Mathf.Log10(num) - 2));
        num = num / (i <= 0 ? 1 : (i * i));

        if (num >= 1000000000)
            return (num / 1000000000D).ToString("0.##") + "B";
        if (num >= 1000000)
            return (num / 1000000D).ToString("0.##") + "M";
        if (num >= 1000)
            return (num / 1000D).ToString("0.##") + "K";

        return num.ToString("#,0");
        */
        return num.ToString();
    }
}
