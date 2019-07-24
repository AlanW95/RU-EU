using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingNews : MonoBehaviour {

    public BreakingNewsItem breakingNewsItemPrefab;
    [Range(1f, 10f)]
    public float itemDuration = 3.0f;
    public string[] fillerItems;

    float width;
    float pixelsPerSecond;
    BreakingNewsItem currentItem;

	// Use this for initialization
	void Start () {
        width = GetComponent<RectTransform>().rect.width;
        pixelsPerSecond = width / itemDuration;
        AddBreakingNewsItem(fillerItems[0]);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentItem.GetXPosition <= -currentItem.GetWidth) {

            AddBreakingNewsItem(fillerItems[Random.Range(0, fillerItems.Length)]);

            //leave the first element empty so it doesn't double in text

            //AddBreakingNewsItem(fillerItems[Random.Range(0, 1)]); //just saying Breaking News which is Element

            //AddBreakingNewsItem(fillerItems[Random.Range(0, fillerItems.Length)]);
            
            //AddBreakingNewsItem(fillerItems[Random.Range(0, fillerItems.Length)]); //don't want this to be random for final
        }
	}

    void AddBreakingNewsItem (string message) {
        currentItem = Instantiate(breakingNewsItemPrefab, transform);
        currentItem.Initialize(width, pixelsPerSecond, message);
    }
}
