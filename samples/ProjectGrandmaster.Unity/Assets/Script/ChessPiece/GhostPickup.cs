﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Contributed by USYD Team - Hrithvik (Jacob) Sood, John Tran, Tom Derrick, Aydin Ucan, Aayush Jindal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.SpectatorView.ProjectGrandmaster;

namespace Microsoft.MixedReality.SpectatorView.ProjectGrandmaster
{
    /// <summary>
    /// Game mode that creates a duplicate of a chess piece when picked up.
    /// The piece automatically moves to the new chosen position.
    /// </summary>
    public class GhostPickup : MonoBehaviour
    {
        private GameObject clonePiece;
        public PieceAction gameManagerPieceAction;
        public BoardInformation bi;
        private Vector3 origPos, finalPos;

        /// <summary>
        /// Called by Manipulation script when a piece is picked up and creates a clone. 
        /// The original is the piece being moved whereas the clone is a placeholder in the original spot.
        /// </summary>
        public void DuplicatePiece()
        {
            //Create clone and change colours of clone
            clonePiece = Instantiate(gameObject, gameObject.transform.parent.transform);
            if ((int)GetComponent<PieceInformation>().colour == 0)
                clonePiece.GetComponent<HighlightChessPiece>().HighlightColour(new Color(1f, 0.888f, 0.439f, 1f));
            else
                clonePiece.GetComponent<HighlightChessPiece>().HighlightColour(new Color(0.331f, 0.331f, 0.331f, 1f));

            //The clone's rigidbody does not interact with any object including the "ghost" being moved around
            clonePiece.GetComponent<Rigidbody>().isKinematic = true;
            clonePiece.GetComponent<Rigidbody>().detectCollisions = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().detectCollisions = false;

        }

        /// <summary>
        /// Called by Manipulation script when a piece is dropped.
        /// </summary>
        public void EndManipulation()
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().detectCollisions = true;
            StartCoroutine(DestroyCloneDelayed());
        }

        IEnumerator ResetRigidBody()
        {
            yield return new WaitForSeconds(1f);

            foreach (GameObject piece in bi.GetPieceAvailable())
            {
                piece.GetComponent<Rigidbody>().isKinematic = false;
                piece.GetComponent<Rigidbody>().detectCollisions = true;
            }
        }

        public void DestroyClone()
        {
            Destroy(clonePiece);
        }

        IEnumerator DestroyCloneDelayed()
        {
            yield return new WaitForSeconds(4f);
            GetComponent<MeshRenderer>().enabled = true;
            if (clonePiece)
                Destroy(clonePiece);
        }
    }
}