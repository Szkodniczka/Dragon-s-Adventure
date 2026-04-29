using UnityEngine;


public class Collectible : MonoBehaviour
{
    public Sprite icon; // ikona do UI
    public string itemID = "default"; // unikalny identyfikator przedmiotu

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Powiadom menad¿er kolekcji
            CollectibleManager.Instance.CollectItem(itemID, icon);

            // Zniszcz znajdŸkê
            gameObject.SetActive(false);
        }
    }
}
