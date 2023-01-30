using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reycasting : MonoBehaviour
{
    [SerializeField]
    Transform raycastTop;

    [SerializeField]
    Transform raycastBottom;

    [SerializeField]
    Transform raycastLeft;

    [SerializeField]
    Transform raycastRight;

    public bool topRaycastActive;
    public bool bottomRaycastActive;
    public bool leftRaycastActive;
    public bool rightRaycastActive;
    public float rayLength;

    void Start()
    {
        Vector2 castPosTop = raycastTop.position;
        Vector2 castPosBottom = raycastBottom.position;
        Vector2 castPosLeft = raycastLeft.position;
        Vector2 castPosRight = raycastRight.position;
    }

    void Update()
    {

    }

    public void TopRaycastActive()
    {

    }
}
