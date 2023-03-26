using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    bool castlePossible = true;
    int castleTileAIndex;
    int castleTileBIndex;
    int castleRookAIndex = 100;
    int castleRookBIndex = 100;




    void Update()
    {
        CheckCastlePossible();
        Castle();
        UserInput();
    }

    public override void MovementPattern()
    {
        InstantiateMovementTiles(1, new Vector2(1, 1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(-1, 1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(1, -1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(-1, -1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(1, 0), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(-1, 0), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(0, 1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(0, -1), gameObject.transform.position);

        if (castlePossible == true)
        {
            movementTiles[tileIndex] = Instantiate(movementTile, BoardPosition() + new Vector2(2.5f, 0.5f), new Quaternion());
            movementTiles[tileIndex] = Instantiate(movementTile, BoardPosition() + new Vector2(-1.5f, 0.5f), new Quaternion());
        }
        
    }

    public void CheckCastlePossible()
    {
        if (castlePossible == true)
        {
            if (GetHasMoved() == false)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (pieces[i] != null)
                    {
                        if (pieces[i].GetComponent<Rook>() != null)
                        {
                            if (pieces[i].GetComponent<Rook>().GetHasMoved() == false && pieces[i].GetComponent<Rook>().GetPieceColour() == GetPieceColour())
                            {
                                if (pieces[i].GetComponent<Rook>().BoardPosition().x - BoardPosition().x == 3)
                                {
                                    for (int j = 0; j < 32; j++)
                                    {
                                        if (pieces[j] != null)
                                        {
                                            if (pieces[j].GetComponent<Piece>().BoardPosition() == new Vector2(5, BoardPosition().y) || pieces[j].GetComponent<Piece>().BoardPosition() == new Vector2(6, BoardPosition().y))
                                            {
                                                castlePossible = false;
                                                break;
                                            }
                                        }
                                    }
                                    if (castlePossible == true)
                                    {

                                        castleTileAIndex = tileIndex;
                                        tileIndex++;
                                        castleRookAIndex = i;
                                    }
                                }
                                else if (pieces[i].GetComponent<Rook>().BoardPosition().x - BoardPosition().x == -4)
                                {
                                    for (int j = 0; j < 32; j++)
                                    {
                                        if (pieces[j] != null)
                                        {
                                            if (pieces[j].GetComponent<Piece>().BoardPosition() == new Vector2(3, BoardPosition().y) || pieces[j].GetComponent<Piece>().BoardPosition() == new Vector2(2, BoardPosition().y))
                                            {
                                                castlePossible = false;
                                                break;
                                            }
                                        }
                                    }
                                    if (castlePossible == true)
                                    {
                                        castleTileBIndex = tileIndex;
                                        tileIndex++;
                                        castleRookBIndex = i;
                                    }
                                }
                                castlePossible = true;
                            }
                        }

                    }
                }
            }
            else castlePossible = false;
        }
    }
    public void Castle()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (active == true && castlePossible == true)
            {
                if (movementTiles[castleTileAIndex] != null)
                {
                    if (movementTiles[castleTileAIndex].GetComponent<movementTile>().BoardPosition() == MousePosition() && castleRookAIndex != 100)
                    {
                        pieces[castleRookAIndex].GetComponent<Rook>().Move(BoardPosition() + new Vector2(1.5f, 0.5f));
                        castlePossible = false;
                        whiteTurn = !whiteTurn;
                    }
                }

                if (movementTiles[castleTileBIndex] != null)
                {
                    if (movementTiles[castleTileBIndex].GetComponent<movementTile>().BoardPosition() == MousePosition() && castleRookAIndex != 100)
                    {
                        pieces[castleRookBIndex].GetComponent<Rook>().Move(BoardPosition() + new Vector2(-0.5f, 0.5f));
                        castlePossible = false;
                        whiteTurn = !whiteTurn;
                    }
                }

            }
    }
        }

}

