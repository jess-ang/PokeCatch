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
    public class GoldCoin : MonoBehaviour
    {
        
        public float triggerInteractionTime = 0.1f;
        public float interactionTimer = 0f;
        private bool timerRunning = false;
        private bool interact = true;

        Rigidbody rb;
        private float speed;
        private GameObject player;
        public int points = 10;
        private AudioSource source;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            source = GetComponent<AudioSource>();
            speed = 300;
        }

        void FixedUpdate ()
        {
            if(timerRunning)
            {
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
                interactionTimer += Time.deltaTime;
                if (interactionTimer > triggerInteractionTime && interact)
                {
                    Interact();
                    interact = false;
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
            Money money = player.GetComponent<Money>();
            if (money != null)
            {
                money.ModifyMoney(points);
            }
            Destroy(gameObject,0.7f);

        }
    }
}
