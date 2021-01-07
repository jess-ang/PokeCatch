using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IBM.Watsson.Examples {

    public class VoiceCommandProcessor : MonoBehaviour
    {
        static protected VoiceCommandProcessor s_VoiceInstance;
        static public VoiceCommandProcessor Instance { get { return s_VoiceInstance; } }

        public delegate void OnVoiceCommand(string action);
        public OnVoiceCommand onVoiceCommand;

        public List<string> wordsToAsk;

        void Awake()
        {
            s_VoiceInstance = this;
        }

        public void Create(string transcript)
        {
            string[] words = transcript.Split(' ');
            foreach (var word in words)
            {
                if (wordsToAsk.Contains(word.ToLower()))
                {
                    if (onVoiceCommand != null)
                    {
                        onVoiceCommand.Invoke(word.ToLower());
                    }
                    return;
                }
            }
        }

    }
}