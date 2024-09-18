using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Since serialized yung DropSystem script, accessible siya dito

    public List<DropSystem> itemDrops = new List<DropSystem>(); // List for multiple item drops, better than array for transferring

    //Go to enemy (Spider) gameobject Inspector, drag the script and click plus dun sa item drops

    public void DropLoot()
    {
        float chance = Random.Range(0f, 100f); //Generate random num between 0-100
        for(int i = 0; i < itemDrops.Count; i++)
        {
            if(chance <= itemDrops[i].DropChance)
            {
                //Amount of loot that will drop
                int amountToDrop = Random.Range(itemDrops[i].min, itemDrops[i].max);

                //Instantiating the item
                for (int j = 0; j < amountToDrop; j++)
                {
                    //Spawn Item Drops
                    GameObject itemSpawn = Instantiate(itemDrops[i].ItemPrefab, transform.position, Quaternion.identity); // transform.position, Quaternion.identity is for the item to drop where the enemy is
                    Rigidbody rb = itemSpawn.AddComponent<Rigidbody>();
                    rb.AddForce(transform.up * 5);
                    itemSpawn.AddComponent<BoxCollider>();
                    //NOTE, avoid using add component, its better to add manually since using it is heavy, this is only for testing purposes
                    Destroy(itemSpawn, itemDrops[i].duration);
                }
                Debug.Log($"{amountToDrop} {itemDrops[i].ItemName}s dropped."); //To check on console
            }
        }
    }

    private void OnDestroy()
    {
        DropLoot();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
