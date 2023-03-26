using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    void Start()
    {
        specialCapture = true;
    }

    void Update()
    {
        UserInput();
        if (GetPieceColour() == true)
        {
            if (BoardPosition().y == 7)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (pieces[i] != null)
                    {
                        if (pieces[i].name == gameObject.name)
                        {
                            promotedPawnIndex = i;
                        }
                    }
                }
            }
        }
        else
        {
            if (BoardPosition().y == 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (pieces[i] != null)
                    {
                        if (pieces[i].name == gameObject.name)
                        {
                            promotedPawnIndex = i;
                        }
                    }
                }
            }
        }
    }

    public override void MovementPattern()
    {
        if (GetPieceColour() == true)
        {
            if (GetHasMoved() == false)
            {
                InstantiateMovementTiles(2, new Vector2(0, 1), gameObject.transform.position);
            }
            else InstantiateMovementTiles(1, new Vector2(0, 1), gameObject.transform.position);
            InstantiateSpecialCaptureTiles(new Vector2(1, 1));
            InstantiateSpecialCaptureTiles(new Vector2(-1, 1));
        }
        else
        {
            if (GetHasMoved() == false)
            {
                InstantiateMovementTiles(2, new Vector2(0, -1), gameObject.transform.position);
            }
            else InstantiateMovementTiles(1, new Vector2(0, -1), gameObject.transform.position);
            InstantiateSpecialCaptureTiles(new Vector2(1, -1));
            InstantiateSpecialCaptureTiles(new Vector2(-1, -1));
        }
    }

    public void InstantiateSpecialCaptureTiles(Vector2 direction)
    {
        Vector2 tilePosition = gameObject.transform.position;
        tilePosition += direction;
            for (int j = 0; j < 32; j++)
            {
                if (pieces[j] != null)
                {
                    if (pieces[j].GetComponent<Piece>().BoardPosition() == tilePosition - new Vector2(0.5f, 0.5f) && pieces[j].GetComponent<Piece>().GetPieceColour() != GetPieceColour())
                    {
                            movementTiles[tileIndex] = Instantiate(captureTile, tilePosition, new Quaternion());
                            tileIndex++;
                        return;
                    }
                }
            }
            tileIndex++;
    }

}
