using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Vector3 start;
    private Vector3 dest;

    // takes a transform (the spot where the bullet will leave the gun), and sends
    // a raycast in it's forward direction.
    public void ShootGun( Transform bulletStart ){
        start = bulletStart.position;
        dest = start + (bulletStart.forward * 100);
        // Debug.DrawRay(start, dest, Color.blue, 5.0f);
        Debug.Log("Shooting");
        
         // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(start, dest, out hit, Mathf.Infinity, layerMask))
        {   
            Debug.Log(hit.transform.root.tag);
            if (hit.transform.root.tag == "NPC" || hit.transform.root.tag == "Player"){
                Debug.Log("Hit something that can die, lol");
                //Do some call to do a damage calculation here.
            }
            Debug.DrawRay(start, bulletStart.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(start, bulletStart.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
    
}
