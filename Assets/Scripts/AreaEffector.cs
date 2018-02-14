using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector : MonoBehaviour
{
    // tiempo para activar y desactivar el effector
    public float toggleTime;

    // componente de effector que se desactiva y activa
    private AreaEffector2D effector;
    // utilizada para guardar el tiempo transcurrido
    private float ellapsedTime = 0f;

    private void Start()
    {
        effector = GetComponentInChildren<AreaEffector2D>();
    }

    private void Update()
    {
        // sumar el tiempo transcurrido y si es mayor al tiempo predefinido, se activa o desactiva el effector
        ellapsedTime += Time.deltaTime;
        if (ellapsedTime > toggleTime)
        {
            effector.gameObject.SetActive(!effector.gameObject.activeSelf);
            ellapsedTime = 0f;
        }
    }
}
