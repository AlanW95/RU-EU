using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreakingNewsItem : MonoBehaviour {

    float breakingNewsWidth;
    float pixelsPerSecond;
    RectTransform rt;

    public float GetXPosition { get { return rt.anchoredPosition.x; } }
    public float GetWidth { get { return rt.rect.width; } }

    public void Initialize(float breakingNewsWidth, float pixelsPerSecond, string message) {
        this.breakingNewsWidth = breakingNewsWidth;
        this.pixelsPerSecond = pixelsPerSecond;
        rt = GetComponent<RectTransform>();
        GetComponent<Text>().text = message + "   •   ";
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rt.position += Vector3.left * pixelsPerSecond * Time.deltaTime;

        if (GetXPosition <= 0 - breakingNewsWidth - GetWidth) {
            Destroy(gameObject);
        }
	}
}
