using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;

    private bool targetHit;


    
    
    // Start is called before the first frame update
    private void Start()
    {
        rb=GetComponent<Rigidbody>();
 
    }
    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Projectile collided with: " + collision.gameObject.name);

        if(targetHit)
        return;
        else 
            targetHit=true;

        if(collision.gameObject.GetComponent<BasicEnemy>()!=null)
           {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
           }
        
        rb.isKinematic=true;
        transform.SetParent(collision.transform);
    }
  
}
