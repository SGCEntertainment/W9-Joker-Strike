using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();

    private TrailRenderer TrailRenderer { get; set; }
    private EdgeCollider2D EdgeCollider2D { get; set; }

    private void Awake()
    {
        TrailRenderer = GetComponent<TrailRenderer>();
        EdgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(TrailRenderer.positionCount == 0)
        {
            return;
        }

        TrailRenderer.GetPositions(positions.ToArray());
        EdgeCollider2D.SetPoints(positions.Select((i) => new Vector2(i.x, i.y)).ToList());
    }
}
