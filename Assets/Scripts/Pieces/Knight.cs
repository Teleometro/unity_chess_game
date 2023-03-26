using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{

    void Update()
    {
        UserInput();
    }

    public override void MovementPattern()
    {
        InstantiateMovementTiles(1, new Vector2(1, 2), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(-1, 2), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(1, -2), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(-1, -2), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(2, 1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(-2, 1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(2, -1), gameObject.transform.position);
        InstantiateMovementTiles(1, new Vector2(-2, -1), gameObject.transform.position);
    }
}
