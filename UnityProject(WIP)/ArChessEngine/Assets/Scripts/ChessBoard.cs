using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public Color lightColor;
    public Color darkColor;

    MeshRenderer[,] squareRenderers;

    [SerializeField]
    Material squareMaterial;



    //Every piece on the board is it's own object, required if we want AR Visual Representations of the full board
    //this could be an array but having each one seperate allows for more readable code

    public GameObject WhiteKing, WhiteQueen, WhiteBishopQ, WhiteKnightQ, WhiteRookQ; //King Queen and QueenSide Pieces
    public GameObject WhiteBishopK, WhiteKnightK, WhiteRookK; //white Kingside pieces
    public GameObject WhiteAPawn, WhiteBPawn, WhiteCPawn, WhiteDPawn, WhiteEPawn, WhiteFPawn, WhiteGPawn, WhiteHPawn; //white pawns

    public GameObject BlackKing, BlackQueen, BlackBishopQ, BlackKnightQ, BlackRookQ; //King Queen and QueenSide Pieces
    public GameObject BlackBishopK, BlackKnightK, BlackRookK; //Black Kingside pieces
    public GameObject BlackAPawn, BlackBPawn, BlackCPawn, BlackDPawn, BlackEPawn, BlackFPawn, BlackGPawn, BlackHPawn; //Black pawns

    //For all internal use, all gameobjects above are for AR
    private GameObject[,] boardRepresentation;

    // Start is called before the first frame update
    void Start()
    {
        boardRepresentation = new GameObject[8,8];

         for (int file = 0; file < 8; file++)
        {
            for (int rank = 0; rank < 8; rank++)
            {
                boardRepresentation[file, rank] = null;
            }
        }

        CreateBoard();

       

        Debug.Log(GetAllPiecePositions());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBoard()
    {
      
        squareRenderers = new MeshRenderer[8, 8];

        for (int file = 0; file < 8; file++)
        {
            for (int rank = 0; rank < 8; rank++)
            {
                bool isLightSquare = (file + rank) % 2 != 0;

                Transform square = GameObject.CreatePrimitive(PrimitiveType.Quad).transform;
                square.parent = transform;
                //square.name = (file, rank);
                square.position = PositionFromCoord(file, rank, 0);
                //square.position -= new Vector3(0,2.5f, 0);
               

                squareRenderers[file, rank] = square.gameObject.GetComponent<MeshRenderer>();
                squareRenderers[file, rank].material = squareMaterial;
                squareRenderers[file, rank].material.color = (isLightSquare) ? lightColor : darkColor;


                //Places pieces while initalizing position and piece type
                switch (file)
                {
                    case 0:
                        if (rank == 0)
                        {


                            int[,] pos = { { file }, { rank } };
                            //  WhiteRookQ.transform.parent = square;
                            WhiteRookQ.transform.position = square.transform.position;
                            WhiteRookQ.transform.localScale = Vector3.one * 1.5f;

                            WhiteRookQ.GetComponent<Piece>().position = pos;
                            WhiteRookQ.GetComponent<Piece>().pieceType = PieceTypes.Rook;

                            boardRepresentation[file, rank] = WhiteRookQ;
                            //    squarePieceRenderers[file, rank].sprite = WhiteRookQ.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //    WhiteAPawn.transform.parent = square;
                            WhiteAPawn.transform.position = square.transform.position;
                            WhiteAPawn.transform.localScale = Vector3.one * 1.5f;

                            WhiteAPawn.GetComponent<Piece>().position = pos;
                            WhiteAPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteAPawn;
                            //    squarePieceRenderers[file, rank].sprite = WhiteAPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };
                            //    BlackAPawn.transform.parent = square;
                            BlackAPawn.transform.position = square.transform.position;
                            BlackAPawn.transform.localScale = Vector3.one * 1.5f;

                            BlackAPawn.GetComponent<Piece>().position = pos;
                            BlackAPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackAPawn;
                            //   squarePieceRenderers[file, rank].sprite = BlackAPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };
                            //      BlackRookQ.transform.parent = square;
                            BlackRookQ.transform.position = square.transform.position;
                            BlackRookQ.transform.localScale = Vector3.one * 1.5f;


                            BlackRookQ.GetComponent<Piece>().position = pos;
                            BlackRookQ.GetComponent<Piece>().pieceType = PieceTypes.Rook;
                            boardRepresentation[file, rank] = BlackRookQ;
                            //  squarePieceRenderers[file, rank].sprite = BlackRookK.GetComponent<Piece>().pieceSprite;
                        }
                        break;

                    case 1:
                        if (rank == 0)
                        {
                            int[,] pos = { { file }, { rank } };
                            //   WhiteKnightQ.transform.parent = square;
                            WhiteKnightQ.transform.position = square.transform.position;
                            WhiteKnightQ.transform.localScale = Vector3.one * 1.5f;

                            WhiteKnightQ.GetComponent<Piece>().position = pos;
                            WhiteKnightQ.GetComponent<Piece>().pieceType = PieceTypes.Knight;
                            boardRepresentation[file, rank] = WhiteKnightQ;
                            //    squarePieceRenderers[file, rank].sprite = WhiteKnightQ.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //    WhiteBPawn.transform.parent = square;
                            WhiteBPawn.transform.position = square.transform.position;
                            WhiteBPawn.transform.localScale = Vector3.one * 1.5f;


                            WhiteBPawn.GetComponent<Piece>().position = pos;
                            WhiteBPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteBPawn;
                            //    squarePieceRenderers[file, rank].sprite = WhiteBPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };

                            //    BlackBPawn.transform.parent = square;
                            BlackBPawn.transform.position = square.transform.position;
                            BlackBPawn.transform.localScale = Vector3.one * 1.5f;

                            BlackBPawn.GetComponent<Piece>().position = pos;
                            BlackBPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackBPawn;
                            //    squarePieceRenderers[file, rank].sprite = BlackBPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };
                            //   BlackKnightQ.transform.parent = square;
                            BlackKnightQ.transform.position = square.transform.position;
                            BlackKnightQ.transform.localScale = Vector3.one * 1.5f;

                            BlackKnightQ.GetComponent<Piece>().position = pos;
                            BlackKnightQ.GetComponent<Piece>().pieceType = PieceTypes.Knight;
                            boardRepresentation[file, rank] = BlackKnightQ;
                            //      squarePieceRenderers[file, rank].sprite = BlackKnightK.GetComponent<Piece>().pieceSprite;
                        }
                        break;

                    case 2:
                        if (rank == 0)
                        {
                            int[,] pos = { { file }, { rank } };
                            //   WhiteBishopQ.transform.parent = square;
                            WhiteBishopQ.transform.position = square.transform.position;
                            WhiteBishopQ.transform.localScale = Vector3.one * 1.5f;

                            WhiteBishopQ.GetComponent<Piece>().position = pos;
                            WhiteBishopQ.GetComponent<Piece>().pieceType = PieceTypes.Bishop;
                            boardRepresentation[file, rank] = WhiteBishopQ;
                            //    squarePieceRenderers[file, rank].sprite = WhiteBishopQ.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //   WhiteCPawn.transform.parent = square;
                            WhiteCPawn.transform.position = square.transform.position;
                            WhiteCPawn.transform.localScale = Vector3.one * 1.5f;


                            WhiteCPawn.GetComponent<Piece>().position = pos;
                            WhiteCPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteCPawn;
                            //    squarePieceRenderers[file, rank].sprite = WhiteCPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };

                            //  BlackCPawn.transform.parent = square;
                            BlackCPawn.transform.position = square.transform.position;
                            BlackCPawn.transform.localScale = Vector3.one * 1.5f;

                            BlackCPawn.GetComponent<Piece>().position = pos;
                            BlackCPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackCPawn;
                            //    squarePieceRenderers[file, rank].sprite = BlackCPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };
                            //   BlackBishopQ.transform.parent = square;
                            BlackBishopQ.transform.position = square.transform.position;
                            BlackBishopQ.transform.localScale = Vector3.one * 1.5f;

                            BlackBishopQ.GetComponent<Piece>().position = pos;
                            BlackBishopQ.GetComponent<Piece>().pieceType = PieceTypes.Bishop;
                            boardRepresentation[file, rank] = BlackBishopQ;
                            //     squarePieceRenderers[file, rank].sprite = BlackBishopK.GetComponent<Piece>().pieceSprite;
                        }

                        break;

                    case 3:
                        if (rank == 0)
                        {
                            int[,] pos = { { file }, { rank } };
                            //     WhiteQueen.transform.parent = square;
                            WhiteQueen.transform.position = square.transform.position;
                            WhiteQueen.transform.localScale = Vector3.one * 1.5f;

                            WhiteQueen.GetComponent<Piece>().position = pos;
                            WhiteQueen.GetComponent<Piece>().pieceType = PieceTypes.Queen;
                            boardRepresentation[file, rank] = WhiteQueen;
                            //    squarePieceRenderers[file, rank].sprite = WhiteQueen.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //    WhiteDPawn.transform.parent = square;
                            WhiteDPawn.transform.position = square.transform.position;
                            WhiteDPawn.transform.localScale = Vector3.one * 1.5f;

                            WhiteDPawn.GetComponent<Piece>().position = pos;
                            WhiteDPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteDPawn;
                            //    squarePieceRenderers[file, rank].sprite = WhiteDPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };

                            // BlackDPawn.transform.parent = square;
                            BlackDPawn.transform.position = square.transform.position;
                            BlackDPawn.transform.localScale = Vector3.one * 1.5f;
                            BlackDPawn.GetComponent<Piece>().position = pos;
                            BlackDPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackDPawn;
                            //     squarePieceRenderers[file, rank].sprite = BlackDPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };
                            //  BlackQueen.transform.parent = square;
                            BlackQueen.transform.position = square.transform.position;
                            BlackQueen.transform.localScale = Vector3.one * 1.5f;

                            BlackQueen.GetComponent<Piece>().position = pos;
                            BlackQueen.GetComponent<Piece>().pieceType = PieceTypes.Queen;
                            boardRepresentation[file, rank] = BlackQueen;
                            //     squarePieceRenderers[file, rank].sprite = BlackQueen.GetComponent<Piece>().pieceSprite;
                        }

                        break;

                    case 4:
                        if (rank == 0)
                        {
                            int[,] pos = { { file }, { rank } };

                            //   WhiteKing.transform.parent = square;
                            WhiteKing.transform.position = square.transform.position;
                            WhiteKing.transform.localScale = Vector3.one * 1.5f;

                            WhiteKing.GetComponent<Piece>().position = pos;
                            WhiteKing.GetComponent<Piece>().pieceType = PieceTypes.King;
                            boardRepresentation[file, rank] = WhiteKing;
                            //  squarePieceRenderers[file, rank].sprite = WhiteKing.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //WhiteEPawn.transform.parent = square;
                            WhiteEPawn.transform.position = square.transform.position;
                            WhiteEPawn.transform.localScale = Vector3.one * 1.5f;

                            WhiteEPawn.GetComponent<Piece>().position = pos;
                            WhiteEPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteEPawn;
                            //  squarePieceRenderers[file, rank].sprite = WhiteEPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };
                            //  BlackEPawn.transform.parent = square;
                            BlackEPawn.transform.position = square.transform.position;
                            BlackEPawn.transform.localScale = Vector3.one * 1.5f;

                            BlackEPawn.GetComponent<Piece>().position = pos;
                            BlackEPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackEPawn;
                            //  squarePieceRenderers[file, rank].sprite = BlackEPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };
                            //  BlackKing.transform.parent = square;
                            BlackKing.transform.position = square.transform.position;
                            BlackKing.transform.localScale = Vector3.one * 1.5f;

                            BlackKing.GetComponent<Piece>().position = pos;
                            BlackKing.GetComponent<Piece>().pieceType = PieceTypes.King;
                            boardRepresentation[file, rank] = BlackKing;
                            //   squarePieceRenderers[file, rank].sprite = BlackKing.GetComponent<Piece>().pieceSprite;
                        }

                        break;

                    case 5:
                        if (rank == 0)
                        {
                            int[,] pos = { { file }, { rank } };
                            //  WhiteBishopK.transform.parent = square;
                            WhiteBishopK.transform.position = square.transform.position;
                            WhiteBishopK.transform.localScale = Vector3.one * 1.5f;

                            WhiteBishopK.GetComponent<Piece>().position = pos;
                            WhiteBishopK.GetComponent<Piece>().pieceType = PieceTypes.Bishop;
                            boardRepresentation[file, rank] = WhiteBishopK;
                            //   squarePieceRenderers[file, rank].sprite = WhiteBishopK.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //   WhiteFPawn.transform.parent = square;
                            WhiteFPawn.transform.position = square.transform.position;
                            WhiteFPawn.transform.localScale = Vector3.one * 1.5f;

                            WhiteFPawn.GetComponent<Piece>().position = pos;
                            WhiteFPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteFPawn;
                            //    squarePieceRenderers[file, rank].sprite = WhiteFPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };
                            //   BlackFPawn.transform.parent = square;
                            BlackFPawn.transform.position = square.transform.position;
                            BlackFPawn.transform.localScale = Vector3.one * 1.5f;

                            BlackFPawn.GetComponent<Piece>().position = pos;
                            BlackFPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackFPawn;
                            //    squarePieceRenderers[file, rank].sprite = BlackFPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };

                            //   BlackBishopK.transform.parent = square;
                            BlackBishopK.transform.position = square.transform.position;
                            BlackBishopK.transform.localScale = Vector3.one * 1.5f;

                            BlackBishopK.GetComponent<Piece>().position = pos;
                            BlackBishopK.GetComponent<Piece>().pieceType = PieceTypes.Bishop;
                            boardRepresentation[file, rank] = BlackBishopK;
                            //    squarePieceRenderers[file, rank].sprite = BlackBishopK.GetComponent<Piece>().pieceSprite;
                        }

                        break;

                    case 6:
                        if (rank == 0)
                        {
                            int[,] pos = { { file }, { rank } };
                            // WhiteKnightK.transform.parent = square;
                            WhiteKnightK.transform.position = square.transform.position;
                            WhiteKnightK.transform.localScale = Vector3.one * 1.5f;

                            WhiteKnightK.GetComponent<Piece>().position = pos;
                            WhiteKnightK.GetComponent<Piece>().pieceType = PieceTypes.Knight;
                            boardRepresentation[file, rank] = WhiteKnightK;
                            //    squarePieceRenderers[file, rank].sprite = WhiteKnightK.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //WhiteGPawn.transform.parent = square;
                            WhiteGPawn.transform.position = square.transform.position;
                            WhiteGPawn.transform.localScale = Vector3.one * 1.5f;

                            WhiteGPawn.GetComponent<Piece>().position = pos;
                            WhiteGPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteGPawn;
                            //   squarePieceRenderers[file, rank].sprite = WhiteGPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };

                            //BlackGPawn.transform.parent = square;
                            BlackGPawn.transform.position = square.transform.position;
                            BlackGPawn.transform.localScale = Vector3.one * 1.5f;

                            BlackGPawn.GetComponent<Piece>().position = pos;
                            BlackGPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackGPawn;
                            // squarePieceRenderers[file, rank].sprite = BlackGPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };

                            //        BlackKnightK.transform.parent = square;
                            BlackKnightK.transform.position = square.transform.position;
                            BlackKnightK.transform.localScale = Vector3.one * 1.5f;

                            BlackKnightK.GetComponent<Piece>().position = pos;
                            BlackKnightK.GetComponent<Piece>().pieceType = PieceTypes.Knight;
                            boardRepresentation[file, rank] = BlackKnightK;
                            //  squarePieceRenderers[file, rank].sprite = BlackKnightK.GetComponent<Piece>().pieceSprite;
                        }


                        break;

                    case 7:
                        if (rank == 0)
                        {
                            int[,] pos = { { file }, { rank } };
                            //      WhiteRookK.transform.parent = square;
                            WhiteRookK.transform.position = square.transform.position;
                            WhiteRookK.transform.localScale = Vector3.one * 1.5f;


                            WhiteRookK.GetComponent<Piece>().position = pos;
                            WhiteRookK.GetComponent<Piece>().pieceType = PieceTypes.Rook;
                            boardRepresentation[file, rank] = WhiteRookK;
                            //   squarePieceRenderers[file, rank].sprite = WhiteRookK.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 1)
                        {
                            int[,] pos = { { file }, { rank } };
                            //     WhiteHPawn.transform.parent = square;
                            WhiteHPawn.transform.position = square.transform.position;
                            WhiteHPawn.transform.localScale = Vector3.one * 1.5f;

                            WhiteHPawn.GetComponent<Piece>().position = pos;
                            WhiteHPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = WhiteHPawn;
                            //squarePieceRenderers[file, rank].sprite = WhiteHPawn.GetComponent<Piece>().pieceSprite;

                        }
                        else if (rank == 6)
                        {
                            int[,] pos = { { file }, { rank } };
                            //    BlackHPawn.transform.parent = square;
                            BlackHPawn.transform.position = square.transform.position;
                            BlackHPawn.transform.localScale = Vector3.one * 1.5f;


                            BlackHPawn.GetComponent<Piece>().position = pos;
                            BlackHPawn.GetComponent<Piece>().pieceType = PieceTypes.Pawn;
                            boardRepresentation[file, rank] = BlackHPawn;
                            //   squarePieceRenderers[file, rank].sprite = BlackHPawn.GetComponent<Piece>().pieceSprite;
                        }
                        else if (rank == 7)
                        {
                            int[,] pos = { { file }, { rank } };
                            // BlackRookK.transform.parent = square;
                            BlackRookK.transform.position = square.transform.position;
                            BlackRookK.transform.localScale = Vector3.one * 1.5f;

                            BlackRookK.GetComponent<Piece>().position = pos;
                            BlackRookK.GetComponent<Piece>().pieceType = PieceTypes.Rook;
                            boardRepresentation[file, rank] = BlackRookK;
                            //   squarePieceRenderers[file, rank].sprite = BlackRookK.GetComponent<Piece>().pieceSprite;
                        }

                        break;



                }


                Vector3 newPos = square.position;
                newPos.z += 0.1f;
                square.position = newPos;
            }

        }

    }

    //returns the full board in FEN notation
    public string GetAllPiecePositions()
    {
      //  Debug.Log(boardRepresentation[0,7].name);

        int freeCellCount = 0;
        string fen = "";
        Piece piece;
    for (int y = 7; y > -1; y--)
    {
        for (int x = 0; x < 8; x++)
        {
           

            if (boardRepresentation[x,y] == null)
            {
                freeCellCount += 1; //piece is empty
              //  Debug.Log("Empty Square");
                Debug.Log(x.ToString() + y.ToString());
            }
            else if (boardRepresentation[x,y] != null)
            {
              //  Debug.Log("Piece Found");
                piece = boardRepresentation[x,y].GetComponent<Piece>();

                if (freeCellCount != 0)
                {
                    fen += freeCellCount.ToString();
                    freeCellCount = 0;
                }
                if (piece.pieceType == PieceTypes.King)
                {
                    if (piece.color == false)
                        fen += "K";
                    else
                        fen += "k";
                }
                else if (piece.pieceType == PieceTypes.Queen)
                {
                    if (piece.color == false)
                        fen += "Q";
                    else
                        fen += "q";
                }
                else if (piece.pieceType == PieceTypes.Rook)
                {
                    if (piece.color == false)
                        fen += "R";
                    else
                        fen += "r";
                }
                else if (piece.pieceType == PieceTypes.Bishop)
                {
                    if (piece.color == false)
                        fen += "B";
                    else
                        fen += "b";
                }
                else if (piece.pieceType == PieceTypes.Knight)
                {
                    if (piece.color == false)
                        fen += "N";
                    else
                        fen += "n";
                }
                else if (piece.pieceType == PieceTypes.Pawn)
                {
                    if (piece.color == false)
                        fen += "P";
                    else
                        fen += "p";
                }

            }
        }
        if (freeCellCount != 0)
        {
            fen += freeCellCount.ToString();
        }
        freeCellCount = 0;
        if (y != 0)
            fen += '/';
    }

    fen += " ";


    //Defaults for Turn 1, change later when have more game info completed
    string turnChar = "w";
    fen += turnChar + " ";

    Piece kingWhite = WhiteKing.GetComponent<Piece>();
    Piece kingBlack = BlackKing.GetComponent<Piece>();

    fen += "K";
    fen += "Q";

    fen += "k";
    fen += "q";

    fen += " ";

    fen += "-";

    fen += " ";

    fen += "0";

    fen += " 1";

        return fen;
    }

    public Vector3 PositionFromCoord(int file, int rank, float depth = 0)
    {
        if (true)
        {
            return new Vector3(-3.5f + file, -3.5f + rank, depth);
        }

    }




}

