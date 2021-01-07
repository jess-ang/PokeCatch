using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void SetTextField(string word){
        // Debug.Log(word);
        wordPanel.GetComponentInChildren<Text>().text = word;
        
        // Debug.Log(wordPanel. GetComponent<UnityEngine.UI.Text>().text);
        // wordPanel.GetComponent<Text>().text = word;
    }

}