using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    

    public InventoryManager InventoryManager;
    public float raycastDistance = 5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition - (Vector2)transform.position, raycastDistance);

            Debug.DrawRay(transform.position, (mousePosition - (Vector2)transform.position).normalized * raycastDistance, Color.red, 1);


            if (hit.collider != null)
            {
                Debug.Log("Objet touché : " + hit.collider.name);

                InventoryManager.AddItem(hit.transform.gameObject.GetComponent<Item>().item);
                hit.collider.GetComponent<SpriteRenderer>().color = Color.red;
            }

            

        }
    }




}
