using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HenScoreUI : MonoBehaviour
{
    protected int currentHenScore;
    private Text _txtHenScore;
    
    private void Awake()
    {
        _txtHenScore = GetComponent<Text>();
    }

    public void InitializeHenScore(int henScore)
    {
        currentHenScore = henScore;
    }

    public void SetHenScore(int newHenScore)
    {
        currentHenScore = newHenScore;
        _txtHenScore.text = currentHenScore.ToString();
    }
}

