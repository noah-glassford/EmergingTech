using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
   public Sprite pieceSprite;
   public bool color; //0 white 1 black
   public bool CanCastle;
   public int [,] position;
   public PieceTypes pieceType; //0 pawn, 1 knight, 2 bishop, 3 rook, 4 queen, 5 king

   void Start()
   {
    GetComponent<SpriteRenderer>().sprite = pieceSprite;
   }

}

public enum PieceTypes
{
    Pawn,
    Knight,
    Bishop,
    Rook,
    Queen,
    King
}
