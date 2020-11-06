using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender Defender { get; set; }

    public void SetSelectedDefender(Defender defender)
    {
        Defender = defender;
    }
    private void OnMouseDown()
    {
        AttempToPlaceDefenderAt();
    }
    
    private Vector2 GetSquareClicked()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
    private void SpawnDefender(Vector2 worldPos)
    {
        var newDefender = Instantiate(Defender, worldPos, Quaternion.identity) as Defender;
        Debug.Log(worldPos);
    }
    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        return new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
    }

    private void AttempToPlaceDefenderAt()
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        if (starDisplay.HaveEnoughStars(Defender.GetStarsCost()))
        {
            SpawnDefender(SnapToGrid(GetSquareClicked()));
            starDisplay.SpendStars(Defender.GetStarsCost());
        }
    }
}
