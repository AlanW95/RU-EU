using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingTextController : MonoBehaviour
{
    private static FloatingText popUpTextPrefab;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("PopUpTextCanvas");
        popUpTextPrefab = Resources.Load<FloatingText>("Prefabs/PopUpTextParent");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popUpTextPrefab);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f, .5f), location.position.y + Random.Range(-.5f, .5f)));

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}
