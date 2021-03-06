﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Contributed by USYD Team - Hrithvik (Jacob) Sood, John Tran, Tom Derrick, Aydin Ucan, Aayush Jindal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Microsoft.MixedReality.SpectatorView.ProjectGrandmaster
{
    /// <summary>
    /// Remove/Add Piece From Board When Eliminated/Undo/Reset
    /// </summary>
    public class PieceAction : MonoBehaviour
    {
        private float blackMatallic;
        private float blackGloss;
        private float whiteMetallic;
        private float whiteGloss;
        private float duration = 1f;

        void Awake()
        {
            this.blackGloss = 0.511f;
            this.whiteGloss = 1f;
            this.blackMatallic = 0.045f;
            this.whiteMetallic = 0.185f;
        }

        public void SetMaterialValues(float blackMat, float whiteMat, float whiteGloss, float blackGloss) 
        {
            this.blackGloss = blackGloss;
            this.whiteGloss = whiteGloss;
            this.blackMatallic = blackMat;
            this.whiteMetallic = whiteMat;
        }

        /// <summary>
        /// Removes the piece from board in a fade-out motion
        /// </summary>
        public void Eliminate(GameObject piece)
        {
            piece.GetComponent<Rigidbody>().isKinematic = true;
            piece.GetComponent<Rigidbody>().detectCollisions = false;
            Material material = piece.GetComponent<Renderer>().material;
            ChangeRendModeTransparent(material);
            StartCoroutine(Fade(piece, material, 0f, 0f, 0f, duration));
        }

        /// <summary>
        /// Brings back eliminated piece onto the chess board.
        /// Used when resetting or undoing last move
        /// </summary>
        public void FadeIn(GameObject piece)
        {
            piece.SetActive(true);
            Material material = piece.GetComponent<Renderer>().material;
            if (piece.name.Contains("Dark"))
            {
                StartCoroutine(Fade(piece, material, 1f, blackMatallic, blackGloss, duration));
            }
            else
            {
                StartCoroutine(Fade(piece, material, 1f, whiteMetallic, whiteGloss, duration));
            }
        }

        /// <summary>
        /// Fades the piece over 1 seconds through coroutine
        /// </summary>
        IEnumerator Fade(GameObject piece, Material material, float targetOpacity, float targetMet, float targetGloss, float duration)
        {
            Color color = material.color;
            float startOpacity = color.a;
            float startOpacityMetallic = material.GetFloat("_Metallic");
            float startOpacityGloss = material.GetFloat("_Glossiness");
            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime;
                float blend = Mathf.Clamp01(time / duration);

                color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);
                material.SetFloat("_Glossiness", Mathf.Lerp(startOpacityGloss, targetGloss, blend));
                material.SetFloat("_Metallic", Mathf.Lerp(startOpacityMetallic, targetMet, blend));
                material.color = color;
                yield return null;
            }
            if (targetOpacity == 0)
            {
                piece.SetActive(false);
            }
            else
            {
                ChangeRendModeOpaque(material);
                piece.GetComponent<Rigidbody>().detectCollisions = true;
                piece.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        void ChangeRendModeTransparent(Material material)
        {
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.DisableKeyword("_ALPHABLEND_ON");
            material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;
        }

        void ChangeRendModeOpaque(Material material)
        {
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            material.SetInt("_ZWrite", 1);
            material.DisableKeyword("_ALPHATEST_ON");
            material.DisableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = -1;
        }

        /// <summary>
        /// Change Position of Pieces 
        /// </summary>
        public void ChangePosition(GameObject piece, Vector3 endPosition, int colour, bool slide = false)
        {
            StartCoroutine(Pos(piece, endPosition, colour, slide));
        }

        IEnumerator Rotate(float duration, GameObject piece, int colour)
        {
            float time = 0;

            Quaternion startRotation = piece.transform.localRotation;
            Quaternion endRotation;
            if (colour == 0)
            {
                endRotation = Quaternion.Euler(-90, 180, 0);
            }
            else
            {
                endRotation = Quaternion.Euler(-90, 0, 0);
            }

            while (time <= duration)
            {
                time += Time.deltaTime;
                float blend = Mathf.Clamp01(time / duration);

                piece.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, blend);
                yield return null;
            }
        }

        IEnumerator Pos(GameObject piece, Vector3 endPosition, int colour, bool slide)
        {
            // Piece resets over x seconds
            float time = 0;
            float duration = 0.75f;
            piece.GetComponent<Rigidbody>().isKinematic = true;
            piece.GetComponent<Rigidbody>().detectCollisions = false;

            Vector3 startPosition = piece.transform.localPosition;
            Vector3 up = new Vector3(startPosition.x, 2, startPosition.z);
            Vector3 aboveOriginalPosition = new Vector3(endPosition.x, 2, endPosition.z);

            bool skip = false;
            if ((Math.Abs(startPosition.x - endPosition.x) <= 1 && Math.Abs(startPosition.z - endPosition.z) <= 1) || slide)
            {
                aboveOriginalPosition = startPosition;
                skip = true;
                duration *= 1.5f;
            }

            // Fix the rotation of the piece
            StartCoroutine(Rotate(duration, piece, colour));

            if (!skip)
            {
                while (time <= duration)
                {
                    time += Time.deltaTime;
                    float blend = Mathf.Clamp01(time / duration);
                    piece.transform.localPosition = Vector3.Lerp(startPosition, up, blend);
                    yield return null;
                }

                time = 0;

                while (time <= duration)
                {
                    time += Time.deltaTime;
                    float blend = Mathf.Clamp01(time / duration);
                    piece.transform.localPosition = Vector3.Lerp(up, aboveOriginalPosition, blend);
                    yield return null;
                }
            }

            time = 0;

            while (time <= duration)
            {
                time += Time.deltaTime;
                float blend = Mathf.Clamp01(time / duration);
                piece.transform.localPosition = Vector3.Lerp(aboveOriginalPosition, endPosition, blend);

                yield return null;
            }

            piece.GetComponent<Rigidbody>().detectCollisions = true;
            piece.GetComponent<Rigidbody>().isKinematic = false;
        }

        /// <summary>
        /// Player forfeit piece animation 
        /// </summary>
        public IEnumerator FallDown(GameObject piece)
        {
            int fallDirection = UnityEngine.Random.Range(0, 359);
            var quatStart = transform.rotation;

            var quatEnd = Quaternion.Euler(-90, fallDirection, 90);

            var timeStart = Time.time;
            float timePassed;

            do
            {
                yield return null;
                timePassed = Time.time - timeStart;
                piece.transform.rotation = Quaternion.Slerp(quatStart, quatEnd, timePassed);
            }
            while (timePassed < 1f);

        }
    }
}