using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    float circleOverlap = 0.2f;

    public void Move(Vector2 input, LayerMask barrierLayers)
    {
        if (!Physics2D.OverlapCircle(transform.position + new Vector3(input.x, input.y, 0), circleOverlap, barrierLayers))
        {
            transform.position += new Vector3(input.x, input.y, 0);
        }
    }
}
