using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesController : MonoBehaviour
{
    public float distance = 1;
    private List<GameObject> lives = new List<GameObject>();

    public void InitiateLives(int x)
    {
        GameObject firstLife = transform.GetChild(0).gameObject;
        lives.Add(firstLife);

        if (firstLife != null)
        {
            for (int i = 0; i < x - 1; i++)
            {
                GameObject life = Instantiate(firstLife);
                lives.Add(life);
                life.transform.parent = transform;
                Vector3 pos = life.transform.position;
                pos.x += distance * (i + 1);
                life.transform.position = pos;
            }
        }
    }

    public bool RemoveLife()
    {
        if(lives.Count < 1)
        {
            return false;
        }
        GameObject lastLife = lives[lives.Count - 1];
        lives.RemoveAt(lives.Count - 1);

        Destroy(lastLife);
        return true;
    }
}
