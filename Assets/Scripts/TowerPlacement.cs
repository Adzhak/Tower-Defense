using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Tower _placedTower;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tower tower = collision.GetComponent<Tower>();
        if (tower != null)
        {
            // If there is already a tower placed, destroy it
            if (_placedTower != null)
            {
                Debug.Log("Destroying previous tower.");
                Destroy(_placedTower.gameObject);
            }
            // Place the new tower
            tower.SetPlacePosition(transform.position);
            _placedTower = tower;
            Debug.Log("Placed new tower.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Tower tower = collision.GetComponent<Tower>();
        if (tower != null && tower == _placedTower)
        {
            _placedTower.SetPlacePosition(null);
            _placedTower = null;
            Debug.Log("Removed tower placement.");
        }
    }
}
