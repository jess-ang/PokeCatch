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
    public class Potion2 : MonoBehaviour
    {
        
        private bool restoreHealth = false;
        private GameObject player;
        public int lifePoints = 10;
        private AudioSource source;


        public float triggerInteractionTime = 0.5f;
        public float interactionTimer = 0f;
        private bool timerRunning = false;

        void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        void Update ()
        {
            if(timerRunning)
            {
                interactionTimer += Time.deltaTime;
                Interact();
                if (interactionTimer > triggerInteractionTime)
                {
                    Destroy(gameObject,0.7f);
                }
            }
        }

        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        public void SetGazedAt(bool gazedAt)
        {
            if (gazedAt)
            {
                timerRunning = true;
            }
            else
            {
                timerRunning = false;
                interactionTimer = 0f;
            }
        }

        private void Start()
        {
            SetGazedAt(false);
            player = GameObject.Find("Player");        
        }

        public void Interact()
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
            Health health = player.GetComponent<Health>();
            if (health != null)
            {
                health.ModifyHealth(lifePoints*Time.deltaTime);
            }
            // Debug.Log("Drinking potion. Increasing life.");

        }
    }
}
