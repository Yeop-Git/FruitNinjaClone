using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        MoveBladeToMouse();
    }

    void MoveBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint((mousePos));
        rb.MovePosition(worldMousePos);
    }
}
