﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.USYD.Board;
using Microsoft.MixedReality.USYD.ChessPiece;

public class VoiceHandler : MonoBehaviour
{
    [SerializeField]
    private BoardInformation bi;

    private int currentTurn;

    // [System.Serializable]
    // public class ChessPieces
    //{
    //    public GameObject whitePawns;
    //    public GameObject whiteRooks;
    //    public GameObject whiteKnights;
    //    public GameObject whiteBishops;
    //    public GameObject whiteQueen;
    //    public GameObject whiteKing;
    //    public GameObject blackPawns;
    //    public GameObject blackRooks;
    //    public GameObject blackKnights;
    //    public GameObject blackBishops;
    //    public GameObject blackQueen;
    //    public GameObject blackKing;
    //}
    //public ChessPieces chessPieces = new ChessPieces();

    // Start is called before the first frame update
    void Start()
    {
        currentTurn = bi.GetTurn();
    }


    //public void MovePiece(string chessPiece, char col, int row)
    //{
    //    Debug.Log("chesspice = " + chessPiece + ".   col = " + col + ".   row = " + row);

    //    //Get all pawn pieces of current turn
    //    GameObject currentPiece = null;
    //    switch (chessPiece)
    //    {
    //        case "pawn":
    //            if (currentTurn == 0) //white
    //                currentPiece = chessPieces.whitePawns;
    //            else
    //                currentPiece = chessPieces.blackPawns;
    //            break;
    //        case "rook":
    //            if (currentTurn == 0) //white
    //                currentPiece = chessPieces.whiteRooks;
    //            else
    //                currentPiece = chessPieces.blackRooks;
    //            break;
    //        case "bishop":
    //            if (currentTurn == 0) //white
    //                currentPiece = chessPieces.whiteBishops;
    //            else
    //                currentPiece = chessPieces.blackBishops;
    //            break;
    //        case "knight":
    //            if (currentTurn == 0) //white
    //                currentPiece = chessPieces.whiteKnights;
    //            else
    //                currentPiece = chessPieces.blackKnights;
    //            break;
    //        case "queen":
    //            if (currentTurn == 0) //white
    //                currentPiece = chessPieces.whiteQueen;
    //            else
    //                currentPiece = chessPieces.blackQueen;
    //            break;
    //        case "king":
    //            if (currentTurn == 0) //white
    //                currentPiece = chessPieces.whiteKing;
    //            else
    //                currentPiece = chessPieces.blackKing;
    //            break;
    //    }

    //    int validPieceCount = 0;
    //    //for all pieces check which one can move to the location
    //    foreach(Transform piece in currentPiece.transform)
    //    {
    //        var pi = piece.GetComponent<PieceInformation>();
    //        pi.ValidMoves();
    //        var possibleMoves = pi.GetPossibleMoves();

    //        foreach (string move in possibleMoves)
    //        {
    //            var x = char.GetNumericValue(move[0]);
    //            var z = char.GetNumericValue(move[2]);

    //        }

    //    }
    //}
    public void moveA1()
    {
        char col = '0';
        char row = '0';
        MovePiece(col, row);
    }

    public void moveB1()
    {
        char col = '1';
        char row = '0';
        MovePiece(col, row);
    }

    public void moveC1()
    {
        char col = '2';
        char row = '0';
        MovePiece(col, row);
    }

    public void moveD1()
    {
        char col = '3';
        char row = '0';
        MovePiece(col, row);
    }

    public void moveE1()
    {
        char col = '4';
        char row = '0';
        MovePiece(col, row);
    }

    public void moveF1()
    {
        char col = '5';
        char row = '0';
        MovePiece(col, row);
    }

    public void moveG1()
    {
        char col = '6';
        char row = '0';
        MovePiece(col, row);
    }

    public void moveH1()
    {
        char col = '7';
        char row = '0';
        MovePiece(col, row);
    }
    public void moveA2()
    {
        char col = '0';
        char row = '1';
        MovePiece(col, row);
    }

    public void moveB2()
    {
        char col = '1';
        char row = '1';
        MovePiece(col, row);
    }

    public void moveC2()
    {
        char col = '2';
        char row = '1';
        MovePiece(col, row);
    }

    public void moveD2()
    {
        char col = '3';
        char row = '1';
        MovePiece(col, row);
    }

    public void moveE2()
    {
        char col = '4';
        char row = '1';
        MovePiece(col, row);
    }

    public void moveF2()
    {
        char col = '5';
        char row = '1';
        MovePiece(col, row);
    }

    public void moveG2()
    {
        char col = '6';
        char row = '1';
        MovePiece(col, row);
    }

    public void moveH2()
    {
        char col = '7';
        char row = '1';
        MovePiece(col, row);
    }
    public void moveA3()
    {
        char col = '0';
        char row = '2';
        MovePiece(col, row);
    }

    public void moveB3()
    {
        char col = '1';
        char row = '2';
        MovePiece(col, row);
    }

    public void moveC3()
    {
        char col = '2';
        char row = '2';
        MovePiece(col, row);
    }

    public void moveD3()
    {
        char col = '3';
        char row = '2';
        MovePiece(col, row);
    }

    public void moveE3()
    {
        char col = '4';
        char row = '2';
        MovePiece(col, row);
    }

    public void moveF3()
    {
        char col = '5';
        char row = '2';
        MovePiece(col, row);
    }

    public void moveG3()
    {
        char col = '6';
        char row = '2';
        MovePiece(col, row);
    }

    public void moveH3()
    {
        char col = '7';
        char row = '2';
        MovePiece(col, row);
    }
    public void moveA4()
    {
        char col = '0';
        char row = '3';
        MovePiece(col, row);
    }

    public void moveB4()
    {
        char col = '1';
        char row = '3';
        MovePiece(col, row);
    }

    public void moveC4()
    {
        char col = '2';
        char row = '3';
        MovePiece(col, row);
    }

    public void moveD4()
    {
        char col = '3';
        char row = '3';
        MovePiece(col, row);
    }

    public void moveE4()
    {
        char col = '4';
        char row = '3';
        MovePiece(col, row);
    }

    public void moveF4()
    {
        char col = '5';
        char row = '3';
        MovePiece(col, row);
    }

    public void moveG4()
    {
        char col = '6';
        char row = '3';
        MovePiece(col, row);
    }

    public void moveH4()
    {
        char col = '7';
        char row = '3';
        MovePiece(col, row);
    }
    public void moveA5()
    {
        char col = '0';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveB5()
    {
        char col = '1';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveC5()
    {
        char col = '2';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveD5()
    {
        char col = '3';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveE5()
    {
        char col = '4';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveF5()
    {
        char col = '5';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveG5()
    {
        char col = '6';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveH5()
    {
        char col = '7';
        char row = '4';
        MovePiece(col, row);
    }

    public void moveA6()
    {
        char col = '0';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveB6()
    {
        char col = '1';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveC6()
    {
        char col = '2';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveD6()
    {
        char col = '3';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveE6()
    {
        char col = '4';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveF6()
    {
        char col = '5';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveG6()
    {
        char col = '6';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveH6()
    {
        char col = '7';
        char row = '5';
        MovePiece(col, row);
    }

    public void moveA7()
    {
        char col = '0';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveB7()
    {
        char col = '1';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveC7()
    {
        char col = '2';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveD7()
    {
        char col = '3';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveE7()
    {
        char col = '4';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveF7()
    {
        char col = '5';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveG7()
    {
        char col = '6';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveH7()
    {
        char col = '7';
        char row = '6';
        MovePiece(col, row);
    }

    public void moveA8()
    {
        char col = '0';
        char row = '7';
        MovePiece(col, row);
    }

    public void moveB8()
    {
        char col = '1';
        char row = '7';
        MovePiece(col, row);
    }

    public void moveC8()
    {
        char col = '2';
        char row = '7';
        MovePiece(col, row);
    }

    public void moveD8()
    {
        char col = '3';
        char row = '7';
        MovePiece(col, row);
    }

    public void moveE8()
    {
        char col = '4';
        char row = '7';
        MovePiece(col, row);
    }

    public void moveF8()
    {
        char col = '5';
        char row = '7';
        MovePiece(col, row);
    }

    public void moveG8()
    {
        char col = '6';
        char row = '7';
        MovePiece(col, row);
    }

    public void moveH8()
    {
        char col = '7';
        char row = '7';
        MovePiece(col, row);
    }

    private void MovePiece(char col, char row)
    {
        var pi = GetComponent<PieceInformation>();
        pi.GetMoves();
        var possibleMoves = pi.GetPossibleMoves();

        if (possibleMoves == null || (int)bi.GetTurn() != (int)pi.colour)
            return;

        var isKnight = false;
        if (pi.type == PieceInformation.Type.Knight)
            isKnight = true;

        foreach (string move in possibleMoves)
        {
            if (col == move[0] && row == move[2])
            {
                var pos = new Vector3((float)char.GetNumericValue(move[0]), 0f, (float)char.GetNumericValue(move[2]));
                StartCoroutine(AnimateMove(pos, isKnight));
            }
        }
    }

    private IEnumerator AnimateMove(Vector3 endPos, bool knight)
    {
        
        var startPos = transform.localPosition;
        GetComponent<Rigidbody>().detectCollisions = false;
        GetComponent<Rigidbody>().isKinematic = true;

        //TODO: make duration a function of distance between the positions
        var duration = 1f;
        var time = 0f;

        if (knight)
        {
            Vector3 transPosition;
            if (Mathf.Abs(startPos.x - endPos.x) < Mathf.Abs(startPos.z - endPos.z))
            {
                transPosition = new Vector3(startPos.x, 0, endPos.z);
            }
            else
            {
                transPosition = new Vector3(endPos.x, 0, startPos.z);
            }

            while (time <= duration)
            {
                time += Time.deltaTime;
                float blend = Mathf.Clamp01(time / duration);

                transform.localPosition = Vector3.Lerp(startPos, transPosition, blend);

                yield return null;
            }

            startPos = transPosition;

        }

        duration = 2f;
        time = 0f;

        while (time <= duration)
        {
            time += Time.deltaTime;
            float blend = Mathf.Clamp01(time / duration);

            transform.localPosition = Vector3.Lerp(startPos, endPos, blend);

            yield return null;
        }

        GetComponent<Rigidbody>().detectCollisions = true;
        GetComponent<Rigidbody>().isKinematic = false;

        //Add to moveset
        GetComponent<PieceInformation>().Moved();
    }

}
