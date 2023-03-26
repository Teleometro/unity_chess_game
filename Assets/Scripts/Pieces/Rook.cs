using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{

    void Update()
    {
        UserInput();
    }

    public override void MovementPattern()
    {
        InstantiateMovementTiles(8, new Vector2(1, 0), gameObject.transform.position);
        InstantiateMovementTiles(8, new Vector2(-1, 0), gameObject.transform.position);
        InstantiateMovementTiles(8, new Vector2(0, 1), gameObject.transform.position);
        InstantiateMovementTiles(8, new Vector2(0, -1), gameObject.transform.position);
    }
}
