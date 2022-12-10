using UnityEngine;

public class Sliced : MonoBehaviour
{
    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Rigidbody2D rigidbody = transform.GetChild(i).GetComponent<Rigidbody2D>();
            rigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
    }
}
