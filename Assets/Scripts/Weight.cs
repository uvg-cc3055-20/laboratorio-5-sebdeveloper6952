using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    // para dibujar la linea que conecta el peso a la plataforma
    private LineRenderer line;
    // joint que une el peso a la plataforma
    private DistanceJoint2D joint;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        joint = GetComponent<DistanceJoint2D>();
    }

    private void Update()
    {
        // le decimos a la linea cuales son sus dos puntos extremos
        line.SetPosition(0, transform.position);
        line.SetPosition(1, joint.connectedBody.transform.position);
    }
}
