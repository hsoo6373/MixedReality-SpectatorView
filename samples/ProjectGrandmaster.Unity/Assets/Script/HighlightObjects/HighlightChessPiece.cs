﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Contributed by USYD Team - Hrithvik (Jacob) Sood, John Tran, Tom Derrick, Aydin Ucan, Aayush Jindal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microsoft.MixedReality.SpectatorView.ProjectGrandmaster
{
    /// <summary>
    /// This script is attached to the chess pieces and is used to change their colour
    /// Used by Manipulation Handler script
    /// </summary>
    public class HighlightChessPiece : MonoBehaviour
    {
        private MeshRenderer mr;
        private Color startColor;
        private Color TouchHighlightColor; //purple
        private Color GrabHighlightColor; //green

        // Start is called before the first frame update
        void Awake()
        {
            mr = GetComponent<MeshRenderer>();
            if (!mr)
            {
                Debug.LogError("Mesh Renderer not found");
            }
            else
            {
                ChangeStartColour();
                //TouchHighlightColor = new Color(240f / 255f, 145f / 255f, 255f / 255f, 255f / 255f);
                TouchHighlightColor = new Color(195f / 255f, 156f / 255f, 200f / 255f, 50f / 255f);
                GrabHighlightColor = new Color(155f / 255f, 90f / 255f, 170f / 255f, 130f / 255f);
                //new Color(63/175f, 190/255f, 180/255f, 0.4f); //blue highlight
            }
        }

        public void TouchHighlightOn()
        {
            mr.material.color = TouchHighlightColor;
        }

        public void GrabHighlightOn()
        {
            mr.material.color = GrabHighlightColor;
        }

        public void HighlightOff()
        {
            mr.material.color = startColor;
        }

        public void HighlightColour(Color color)
        {
            mr.material.color = color;
        }

        public void ChangeStartColour()
        {
            startColor = mr.material.color;
        }
    }
}