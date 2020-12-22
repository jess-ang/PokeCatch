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
        // Rigidbody rb;
        // public Vector3 kickDirection;
        // public float kickForce = 30f;
        
        private Inventory inventory;
        public Item item;

        private Vector3 startingPosition;
        private AskWord askWord;

        public float triggerInteractionTime = 0.1f;
        public float interactionTimer = 0f;
        private bool timerRunning = false;

        // void Awake()
        // {
        //     rb = GetComponent<Rigidbody>();
        // }

        // void FixedUpdate ()
        // {
        //     if(timerRunning)
        //     {
        //         interactionTimer += Time.deltaTime;
        //         if (interactionTimer > triggerInteractionTime)
        //         {
        //             Interact();
        //         }
        //     }
        // }
        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        public void SetGazedAt(bool gazedAt)
        {
            if (gazedAt)
            {
                timerRunning = true;
                 Interact();
            }
            else
            {
                timerRunning = false;
                interactionTimer = 0f;
                askWord.HideTextField();
            }
        }

        
        protected override void Start()
        {
            base.Start();
            startingPosition = transform.localPosition;
            askWord = FindObjectOfType<AskWord>();

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
            }
           
        }

        public override void VoiceInteract(string action)
        {
            base.VoiceInteract(action);
            Debug.Log("Pateando pelota...");
            if (action == "ataca" && timerRunning)
            {
                Debug.Log("Palabra "+action+" correcta, agregando a inventario");
                // rb.AddForce(kickDirection * kickForce, ForceMode.Force);
                inventory.Add(item);
                Destroy(gameObject,0.7f);
            }
            
        }
    }
}
