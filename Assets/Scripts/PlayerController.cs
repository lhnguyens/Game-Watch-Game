using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();

    private int startPositions = 1;

    private void OnEnable()
    {
        ButtonInputs.OnLeft += OnLeftPressed;
        ButtonInputs.OnRight += OnRightPressed;
    }

    private void OnDisable()
    {
        ButtonInputs.OnLeft -= OnLeftPressed;
        ButtonInputs.OnRight -= OnRightPressed;
    }

    private void Start()
    {
        UpdatePosition();
    }


    public void OnLeftPressed()
    {

        if (startPositions > 0)
        {
            startPositions--;
            UpdatePosition();
        }
    }

    public void OnRightPressed()
    {

        if (startPositions < positions.Count - 1)
        {
            startPositions++;
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = positions[startPositions].position;
    }
}
