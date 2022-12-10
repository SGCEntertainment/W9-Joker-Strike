using UnityEngine;

public class Sliced : MonoBehaviour
{
    private const float force = 6;
    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Rigidbody2D rigidbody = transform.GetChild(i).GetComponent<Rigidbody2D>();

            rigidbody.AddForce(i > 0 ? Vector2.right * force : Vector2.left * force, ForceMode2D.Impulse);
            rigidbody.angularVelocity = Random.Range(120, 180);
        }
    }
}
