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

        public List<string> actions;
        public List<string> specialActions;

        public List<GameObject> spawningPrefabs;


        void Awake()
        {
            s_VoiceInstance = this;
        }

        public void Create(string transcript)
        {
            string[] words = transcript.Split(' ');
            foreach (var word in words)
            {
                if (actions.Contains(word.ToLower()))
                {
                    if (onVoiceCommand != null)
                    {
                        onVoiceCommand.Invoke(word.ToLower());
                    }
                    return;
                }
            }

            foreach (var word in words)
            {
                if (specialActions.Contains(word.ToLower()))
                {
                   if (word == "instantiate")
                   {
                       SpawnObject(words);
                   }
                   if (word == "music")
                   {
                       //
                   }
                }
                break;
            }
        }

        void SpawnObject(string[] words)
        {
            foreach (var word in words)
            {
                foreach (var prefab in spawningPrefabs)
                {
                    if (prefab.name == word.ToLower())
                    {
                        Instantiate(prefab, new Vector3(0f,1f,0f), Quaternion.identity);
                    }
                    break;
                }
            }
        }
    }
}