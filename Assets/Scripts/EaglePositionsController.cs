using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglePositionsController : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();

    private int defaultPosition = 0;
    private float timer = 5.0f;
    private float timeLastMove;


    private void Start()
    {
        timeLastMove = Time.time;
        transform.position = positions[defaultPosition].position;
    }

    private void Update()
    {
        if (Time.time > timeLastMove + timer)
        {
            RandomEaglePositions();
            timeLastMove = Time.time;
        }
    }

    private void RandomEaglePositions()
    {
        int index = RandomNumberGenerator();
        if (index == defaultPosition)
        {
           index = RandomNumberGenerator();
        }
        else
        {
            transform.position = positions[index].position;
            defaultPosition = index;
            
        }
    }

    private int RandomNumberGenerator()
    {
        int index = Random.Range(0, positions.Count);
        return index;
    }
}
