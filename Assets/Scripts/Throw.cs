using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    //[Header("References")]
    public Camera cam;
    public Transform attackPoint;
    public GameObject objectToThrow;


    //[Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    //[Header("Throwing")]
    public KeyCode throwKey=KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;


    // Start is called before the first frame update
    private void Start()
    {
        readyToThrow=true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows>0)
        {
            Throwing();
        }
    }
    private void Throwing()
    {
        readyToThrow=false;
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.transform.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        
        Vector3 forceDirection=cam.transform.forward;
            
            RaycastHit hit;

         Ray ray = cam.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit, 500f))
        {
         forceDirection = (hit.point - attackPoint.position).normalized;
         }
        
        Vector3 forceToAdd =forceDirection *throwForce +transform.up*throwUpwardForce;
        
        projectileRb.AddForce(forceToAdd,ForceMode.Impulse);
        totalThrows--;
        Invoke(nameof(ResetThrow),throwCooldown);
   }
    private void ResetThrow()
    {
        readyToThrow=true;
    }

     
}
