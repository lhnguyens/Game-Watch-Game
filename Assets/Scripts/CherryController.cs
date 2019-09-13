using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{

    [SerializeField]
    private List<Transform> positions = new List<Transform>();


    private int upperLimit = 0;
    private int currentPosition = 0;
    public float timer; 
    float moveDelay = 1.0f ;
    float deathDelay = 0.5f;
    public float startDelay;

    private int direction = 1;

    public LayerMask layerMask;

    public delegate void Cherry();
    public static event Cherry OnCherryDeath;
    public static event Cherry OnCherrySaved;
    private bool stop = false;

    private void Start()
    {

        UpdateCherry();
        timer = Time.time + startDelay;
    }

    private void Update()
    {
       
        if(Time.time > timer + moveDelay)
        {
          StartCoroutine (UpdateCherryToNextPosition());
            timer = Time.time;
        }
    }

    IEnumerator UpdateCherryToNextPosition()
    {
        currentPosition += direction;
        UpdateCherry();

        if (currentPosition == upperLimit )
        {
            ChangeDirection();
        }


        if (currentPosition == 4)
        {
            yield return new WaitForSeconds(0.5f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero,
                                         Mathf.Infinity, layerMask);
            
            if (hit.collider != null)
            {
                ChangeDirection();
                OnCherrySaved();
                upperLimit = RandomUpperLimit();
                Debug.Log("CATCHED");
            }
            else
            {
                OnCherryDeath();
               
                currentPosition = 0;
                UpdateCherry();

                Debug.Log("DEAD");
            }
        }
    }

    private int RandomUpperLimit()
    {
        int index = UnityEngine.Random.Range(0,2);
        return index;
    }

    private int RandomNumberGenerator()
    {
        int index = UnityEngine.Random.Range(0, 2);
            return index;
    }

    private void UpdateCherry()
    {
        transform.position = positions[currentPosition].position;
    }

    void ChangeDirection()
    {
        direction *= -1;
    }

    public void Stop()
    {
        stop = true;

        Application.Quit();
    }

}
