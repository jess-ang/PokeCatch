using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenScore : MonoBehaviour
{
    public int henScore = 0;
    private int _minHenScore;
    public GameObject henScoreAware;
    void Start()
    {
        _minHenScore = 0;
        SetHenScore(_minHenScore);
    }

    private void SetHenScore(int newHenScore)
    {
        henScoreAware.SendMessage(nameof(SetHenScore), newHenScore, SendMessageOptions.DontRequireReceiver);
    }

    public void ModifyHenScore()
    {
        henScore++;
        SetHenScore(henScore);
    }   
}
