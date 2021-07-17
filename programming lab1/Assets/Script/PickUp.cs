using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PlayerInventory inventory;
    public GameObject itemButton;
    public enum CollectibleType
    {
        SpeedPotion,
        ColorPotion,
        SizePotion

    }
    private void Start()
    {
        inventory = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInventory>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    
    
}
