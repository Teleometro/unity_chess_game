using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour {

    public static GameObject[] pieces = new GameObject[32];
    public static bool whiteTurn = true;
    public static string winner;
    public static bool endGame = false;
    public static int promotedPawnIndex = 100;

    public Vector2 MousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return new Vector2(Mathf.Floor(ray.origin.x), Mathf.Floor(ray.origin.y));

    }

    public Vector2 BoardPosition()
    {
        return new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
    }


}
