﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenTitan : MonoBehaviour
{
    public static int selectedTitan=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseTitan(int n)
    {
        selectedTitan = n;
    }
}