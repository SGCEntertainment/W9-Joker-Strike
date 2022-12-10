using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Fruit>().Slice();
    }
}
