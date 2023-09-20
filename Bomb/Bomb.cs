using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float explosionForce;

    private Vector3 posBomb;
    private Collider[] colliders;
    private Rigidbody rb;
    
    void Start()
    {
        posBomb = transform.position; 
        colliders = Physics.OverlapSphere(posBomb, range);

        foreach(Collider hit in colliders)  { 
            
            rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, posBomb, range,2.0f,ForceMode.Impulse);
            }

        }

    }

    private void OnDrawGizmos()
    {
       Gizmos.color = new Color(0,1,0,0.3F);
       Gizmos.DrawSphere(transform.position, range);
    }


    void Update()
    {
        
    }
}
