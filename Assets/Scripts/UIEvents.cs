using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvents : Entity
{
    public GameObject canvas;
    public GameObject endPanel;
    public GameObject queen;
    public GameObject bishop;
    public GameObject rook;
    public GameObject knight;
    public GameObject promotionPanel;

    void Update()
    {
        if (endGame == true)
        {
            EndGame();
        }

        else if (promotedPawnIndex != 100)
        {
            promotionPanel.gameObject.SetActive(true);
        }
    }

    public void EndGame()
    {

            endPanel.transform.GetChild(2).GetComponent<Text>().text = winner + " has won";
       
        endPanel.gameObject.SetActive(true);
    }

    public void PromoteToQueen()
    {
        bool colour = pieces[promotedPawnIndex].GetComponent<Piece>().GetPieceColour();
        Vector2 position = pieces[promotedPawnIndex].transform.position;
        Destroy(pieces[promotedPawnIndex]);
        pieces[promotedPawnIndex] = Instantiate(queen, position, new Quaternion());
        pieces[promotedPawnIndex].GetComponent<Piece>().SetPieceColour(colour);
        promotedPawnIndex = 100;
    }

    public void PromoteToBishop()
    {
        bool colour = pieces[promotedPawnIndex].GetComponent<Piece>().GetPieceColour();
        Vector2 position = pieces[promotedPawnIndex].transform.position;
        Destroy(pieces[promotedPawnIndex]);
        pieces[promotedPawnIndex] = Instantiate(bishop, position, new Quaternion());
        pieces[promotedPawnIndex].GetComponent<Piece>().SetPieceColour(colour);
        promotedPawnIndex = 100;
    }

    public void PromoteToRook()
    {
        bool colour = pieces[promotedPawnIndex].GetComponent<Piece>().GetPieceColour();
        Vector2 position = pieces[promotedPawnIndex].transform.position;
        Destroy(pieces[promotedPawnIndex]);
        pieces[promotedPawnIndex] = Instantiate(rook, position, new Quaternion());
        pieces[promotedPawnIndex].GetComponent<Piece>().SetPieceColour(colour);
        promotedPawnIndex = 100;
    }

    public void PromoteToKnight()
    {
        bool colour = pieces[promotedPawnIndex].GetComponent<Piece>().GetPieceColour();
        Vector2 position = pieces[promotedPawnIndex].transform.position;
        Destroy(pieces[promotedPawnIndex]);
        pieces[promotedPawnIndex] = Instantiate(knight, position, new Quaternion());
        pieces[promotedPawnIndex].GetComponent<Piece>().SetPieceColour(colour);
        promotedPawnIndex = 100;
    }

}
