using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MoneyUI : MonoBehaviour
{
    protected int currentMoney;
    private Text _txtMoney;
    
    private void Awake()
    {
        _txtMoney = GetComponent<Text>();
    }

    public void InitializeMoney(int money)
    {
        currentMoney = money;
    }

    public void SetMoney(int newMoney)
    {
        currentMoney = newMoney;
        _txtMoney.text = currentMoney.ToString();
    }
}

