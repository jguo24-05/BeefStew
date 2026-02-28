using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotScript : MonoBehaviour
{
    public GameObject InventoryManager;
    private InventoryManager im;
    private ArrayList potStuff;
    [SerializeField] public int quota;   // TODO: maybe change to const later
    [SerializeField] public string nextLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryManager = GameObject.Find("Inventory Manager");
        im = InventoryManager.GetComponent<InventoryManager>();
        potStuff = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            ArrayList playerInventory = im.inventory;
            if (playerInventory.Count > 0)
            {
                foreach(GameObject g in playerInventory) {
                    potStuff.Add(g);
                }
                playerInventory.Clear();
            }

            if (potStuff.Count == quota)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
