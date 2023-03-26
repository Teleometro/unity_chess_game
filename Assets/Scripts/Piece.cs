using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : Entity
{

    bool hasMoved = false;
    protected bool specialCapture = false;
    public GameObject movementTile;
    public GameObject captureTile;

    protected bool active = false;
    public bool isWhite = true;
    public GameObject[] movementTiles = new GameObject[32];
    public Sprite blackSprite;
    protected int tileIndex = 0;
   
    void Update ()
    {
        UserInput();
	}

    public void InstantiateMovementTiles(int amount, Vector2 direction, Vector2 origin)
    {
        if (amount > 0)
        {
            Vector2 tilePosition = origin;
            tilePosition += direction;
            if ((int)tilePosition.x >= 0 && (int)tilePosition.x < 8 && (int)tilePosition.y >= 0 && (int)tilePosition.y < 8)
            {

                for (int j = 0; j < 32; j++)
                {
                    if (pieces[j] != null)
                    {
                            if (pieces[j].GetComponent<Piece>().BoardPosition() == tilePosition - new Vector2(0.5f, 0.5f))
                            {
                                if (specialCapture == false && pieces[j].GetComponent<Piece>().GetPieceColour() != GetPieceColour())
                                {
                                    movementTiles[tileIndex] = Instantiate(captureTile, tilePosition, new Quaternion());
                                    tileIndex++;
                                }
                                return;
                            }
                    }
                }
                if (movementTiles[tileIndex] == null)
                {
                    movementTiles[tileIndex] = Instantiate(movementTile, tilePosition, new Quaternion());
                }

                tileIndex++;
            }
            InstantiateMovementTiles(amount - 1, direction, tilePosition);
        }
    }

    public virtual void MovementPattern()
    {
        InstantiateMovementTiles(8, new Vector2(1,1), gameObject.transform.position);
    }

    public void DeleteMovementTiles()
    {
        for (int i = 0; i < 32; i++)
        {
            if (movementTiles[i] != null)
            {
                Destroy(movementTiles[i]);
                movementTiles[i] = null;
            }
        }
        tileIndex = 0;
    }

  

    
    public void Move(Vector2 newPosition)
    {
        gameObject.transform.position = newPosition;
        hasMoved = true;
    }  

    public void UserInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (whiteTurn == GetPieceColour())
            {
                if (BoardPosition() == MousePosition())
                {
                    if (active == false) MovementPattern();
                    active = true;
                }
                else
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (movementTiles[i] != null)
                        {
                            if (movementTiles[i].GetComponent<movementTile>().BoardPosition() == MousePosition())
                            {
                                for (int j = 0; j < 32; j++)
                                {
                                    if (pieces[j] != null)
                                    {
                                        if (pieces[j].GetComponent<Piece>().BoardPosition() == MousePosition())
                                        {
                                            if (pieces[j].GetComponent<King>() != null)
                                            {
                                                    if (pieces[j].GetComponent<King>().GetPieceColour() == true)
                                                    {
                                                        winner = "Black";
                                                    }
                                                    else if (pieces[j].GetComponent<King>().GetPieceColour() == false)
                                                    {
                                                        winner = "White";
                                                    }
                                                endGame = true;
                                            }
                                            Destroy(pieces[j]);
                                            pieces[j] = null;
                                        }
                                    }
                                }
                                Move(movementTiles[i].transform.position);
                                whiteTurn = !whiteTurn;
                            }
                        }
                    }
                    DeleteMovementTiles();
                    active = false;
                }
            }
            
        }
        if (isWhite == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = blackSprite;
        }
    }
    public bool GetHasMoved()
    {
        return hasMoved;
    }
    public void SetHasMoved(bool newValue)
    {
        hasMoved = newValue;
    }
    public bool GetPieceColour()
    {
        return isWhite;
    }
    public void SetPieceColour(bool newValue)
    {
        isWhite = newValue;
    }

}
