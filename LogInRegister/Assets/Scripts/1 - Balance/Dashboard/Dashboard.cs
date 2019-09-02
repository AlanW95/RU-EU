﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dashboard : MonoBehaviour
{

    public TextMeshProUGUI topTheme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        topTheme.text = PlayerPrefs.GetString("TopTheme");
    }
}
