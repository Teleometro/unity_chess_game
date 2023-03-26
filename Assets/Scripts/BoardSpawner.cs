using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : Entity {


    public GameObject whiteTile;
    public GameObject blackTile;
    public GameObject pawn;
    public GameObject queen;
    public GameObject king;
    public GameObject rook;
    public GameObject bishop;
    public GameObject knight;

    private Vector2 shiftToOrigin = new Vector2(0.5f, 0.5f);

    void Start ()
    {
        CreateBoard();
        InstantiatePieces();
        whiteTurn = true;
        endGame = false;
        promotedPawnIndex = 100;
        winner = null;
    }
	
	void Update ()
    {
       
    }

    void CreateBoard()
    {
        bool black = false;
        for (int i = 0; i < 8; i++)
        {
            black = !black;
            for (int j = 0; j < 8; j++)
            {
                if (black == true)
                {
                    Instantiate(blackTile, new Vector2(i, j) + shiftToOrigin, new Quaternion(0, 0, 0, 0));
                }
                else
                {
                    Instantiate(whiteTile, new Vector2(i, j) + shiftToOrigin, new Quaternion(0, 0, 0, 0));
                }
                black = !black;

            }
        }
    }
    void InstantiatePieces()
    {
        
        for (int i = 0; i < 8; i++)
        {
            pieces[i] = Instantiate(pawn, new Vector2(i, 1) + shiftToOrigin, new Quaternion());
            pieces[i].name = "White Pawn " + i;
        }
        pieces[8] = Instantiate(rook, new Vector2(0, 0) + shiftToOrigin, new Quaternion());
        pieces[9] = Instantiate(rook, new Vector2(7, 0) + shiftToOrigin, new Quaternion());
        pieces[10] = Instantiate(knight, new Vector2(1, 0) + shiftToOrigin, new Quaternion());
        pieces[11] = Instantiate(knight, new Vector2(6, 0) + shiftToOrigin, new Quaternion());
        pieces[12] = Instantiate(bishop, new Vector2(2, 0) + shiftToOrigin, new Quaternion());
        pieces[13] = Instantiate(bishop, new Vector2(5, 0) + shiftToOrigin, new Quaternion());
        pieces[14] = Instantiate(queen, new Vector2(3, 0) + shiftToOrigin, new Quaternion());
        pieces[15] = Instantiate(king, new Vector2(4, 0) + shiftToOrigin, new Quaternion());

        for (int i = 16; i < 24; i++)
        {
            pieces[i] = Instantiate(pawn, new Vector2(i - 16, 6) + shiftToOrigin, new Quaternion());
            pieces[i].name = "Black Pawn " + (i - 16);
        }
        pieces[24] = Instantiate(rook, new Vector2(0, 7) + shiftToOrigin, new Quaternion());
        pieces[25] = Instantiate(rook, new Vector2(7, 7) + shiftToOrigin, new Quaternion());
        pieces[26] = Instantiate(knight, new Vector2(1, 7) + shiftToOrigin, new Quaternion());
        pieces[27] = Instantiate(knight, new Vector2(6, 7) + shiftToOrigin, new Quaternion());
        pieces[28] = Instantiate(bishop, new Vector2(2, 7) + shiftToOrigin, new Quaternion());
        pieces[29] = Instantiate(bishop, new Vector2(5, 7) + shiftToOrigin, new Quaternion());
        pieces[30] = Instantiate(queen, new Vector2(3, 7) + shiftToOrigin, new Quaternion());
        pieces[31] = Instantiate(king, new Vector2(4, 7) + shiftToOrigin, new Quaternion());
        for (int i = 16; i < 32; i++)
        {
            pieces[i].GetComponent<Piece>().SetPieceColour(false);
        }
        
    }
    
}
