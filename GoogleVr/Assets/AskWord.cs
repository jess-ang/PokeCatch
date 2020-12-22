using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskWord : MonoBehaviour
{
    public GameObject wordPanel;
    public Vector3 heightOffset;

    public void HideTextField()
    {
        wordPanel.SetActive(false);
    }

    public void ShowTextField(Vector3 newPosition)
    {
        wordPanel.transform.position = newPosition + heightOffset;
        wordPanel.SetActive(true);
    }

}