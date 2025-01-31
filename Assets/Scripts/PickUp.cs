using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{
    public static event Action OnPickupCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pickup collected by player!");
            OnPickupCollected?.Invoke();

            // Find the CubeMovement component and activate speed boost
            CubeMovement playerMovement = other.GetComponent<CubeMovement>();
            if (playerMovement != null)
            {
                playerMovement.ActivateSpeedBoost();
            }

            Destroy(gameObject);
        }
    }
}