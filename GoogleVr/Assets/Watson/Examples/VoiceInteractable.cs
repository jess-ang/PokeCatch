using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watsson.Examples;

public class VoiceInteractable : MonoBehaviour
{
    private VoiceCommandProcessor commandProcessor;

    void Start()
    {
        commandProcessor = VoiceCommandProcessor.Instance;
        commandProcessor.onVoiceCommand += VoiceInteract;
    }

    public virtual void VoiceInteract(string action)
    {
        Debug.Log("Interactuando por voz, accion es " + action);
    }
}
