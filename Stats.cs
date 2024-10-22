﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Stats 
{   [SerializeField]
    private BarScript bar;
    [SerializeField]
    private float currentVal;
    [SerializeField]
    private float maxVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            this.currentVal = Mathf.Clamp(value,0,MaxVal);
            bar.Value = currentVal;
        }

    }
    public float MaxVal
    {
        get
        {
            return maxVal;
        }
        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }
    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
