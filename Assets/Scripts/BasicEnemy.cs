using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public int health;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
           Debug.Log("Enemy should be destroyed");
            Destroy(gameObject);
        }
    }

 
}
