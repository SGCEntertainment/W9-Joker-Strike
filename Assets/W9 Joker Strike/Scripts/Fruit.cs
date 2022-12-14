using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D Rigidbody { get; set; }
    [SerializeField] GameObject sliced;

    public static Action OnCollided { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = new Vector2(0, -6.28f);

        Rigidbody.AddForce(Vector2.up * 25, ForceMode2D.Impulse);
        Rigidbody.angularVelocity = Random.Range(80, 180.0f);
    }

    public void Slice()
    {
        OnCollided?.Invoke();

        Instantiate(sliced, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
