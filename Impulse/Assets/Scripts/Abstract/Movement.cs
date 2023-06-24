using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] LayerMask barrierLayers;
    float circleOverlap = 0.2f;

    public void MoveAdjacent(Vector2 input)
    {
        if (!Physics2D.OverlapCircle(transform.position + new Vector3(input.x, input.y, 0), circleOverlap, barrierLayers))
        {
            transform.position += new Vector3(input.x, input.y, 0);
        }
    }

    public void MoveTo(Vector2 input)
    {
        //if (!Physics2D.OverlapCircle(new Vector3(input.x, input.y, 0), circleOverlap, barrierLayers))
        //{
            transform.position = new Vector3(input.x, input.y, 0);
        //}
    }
}
