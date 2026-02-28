using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventoryManager;
    private InventoryManager im;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager");
        im = inventoryManager.GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            im.Acquire(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
