//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google Inc.">
// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleVR.HelloVR
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>Controls interactable teleporting objects in the Demo scene.</summary>
    [RequireComponent(typeof(Collider))]
    public class PokemonController : VoiceInteractable
    {
        public string wordToAsk = "pregunta";
        public string japanese = "さかな";
        private Inventory inventory;
        public Item item;
        private AudioSource source;

        private Vector3 startingPosition;
        private AskWord askWord;

        private bool targetGazed = false;

        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        public void SetGazedAt(bool gazedAt)
        {
            if (gazedAt)
            {
                targetGazed = true;
                 Interact();
            }
            else
            {
                targetGazed = false;
                askWord.HideTextField();
            }
        }

        
        protected override void Start()
        {
            base.Start();
            startingPosition = transform.localPosition;
            askWord = FindObjectOfType<AskWord>();
source = GetComponent<AudioSource>();
            SetGazedAt(false);
        
            inventory = FindObjectOfType<Inventory>();
            if(inventory == null)
            {
                Debug.LogWarning("No se encontró el inventario");
            }  
        }

        public void Interact()
        {
        //    Debug.Log("Mostrando pregunta");
            if (askWord != null)
            {
                askWord.ShowTextField(transform.position);
                askWord.SetTextField(japanese);
            }
           
        }

        public override void VoiceInteract(string action)
        {
            base.VoiceInteract(action);
            Debug.Log("Pateando pelota...");
            Debug.Log("Ask: "+wordToAsk);
            Debug.Log("User says: "+action);
            if (action == wordToAsk && targetGazed)
            {
                if (!source.isPlaying)
            {
                source.Play();
            }
                Debug.Log("Palabra "+action+" correcta, agregando a inventario");
                askWord.HideTextField();
                inventory.Add(item);
                Destroy(gameObject,0.5f);
            }
            
        }
    }
}
