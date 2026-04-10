using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private Camera targetCamera;
    [SerializeField] private LayerMask hitLayers = ~0; // Todo por defecto
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private bool debugDraw = true;

    public static ClickManager instance;

     private void Awake()
    {
        instance = this;
        // Si no asignamos cámara en el Inspector, usamos la principal
        if (targetCamera == null)
            targetCamera = Camera.main;
        
    }
     private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            DoRaycast();
    }

    private void DoRaycast()
    {
        // ScreenPointToRay maneja internamente perspectiva y ortográfica:
        //
        // - Perspectiva:  origin = posición de la cámara
        //                 direction = desde cámara hacia el punto en el near plane
        //
        // - Ortográfica:  origin = punto proyectado en el near plane (mundo 3D)
        //                 direction = forward de la cámara (rayos paralelos)
        //
        // En ambos casos, la posición del mouse se da en píxeles de pantalla.
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);

        if (debugDraw)
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.yellow, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, hitLayers))
        {
            Debug.Log($"Golpeó: {hit.collider.name} | Punto: {hit.point}");
            HandleHit(hit);
        }
    }

    private void HandleHit(RaycastHit hit)
    {
        // Punto exacto de impacto en el mundo 3D
        Vector3 worldPoint = hit.point;

        // Normal de la superficie golpeada
        Vector3 surfaceNormal = hit.normal;

        // El objeto golpeado
        GameObject hitObject = hit.collider.gameObject;

        if(hit.collider.GetComponent<IClickeable>() != null)
        {
            hit.collider.GetComponent<IClickeable>().OnClick();
        }

        // Ejemplo: mover un marcador al punto de impacto
        // marker.transform.position = worldPoint;
    }

}
