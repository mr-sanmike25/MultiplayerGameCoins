using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    /// Date: 25/08/2024
    /// Author: Miguel Angel Garcia Elizalde.
    /// Brief: Código del comportamiento de la cámara, el cual sigue al jugador mediante un lerp o interpolación lineal.

    [SerializeField] Transform cameraPos;
    [SerializeField] float camSpeed;

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMov();
    }

    private void CameraMov()
    {
        Vector3 playerPos = new Vector3(cameraPos.transform.position.x, 
            cameraPos.transform.position.y, -1.0f);

        Vector3 interpolatePos = Vector3.Lerp(gameObject.transform.position,
playerPos, camSpeed * Time.deltaTime);

        transform.position = interpolatePos;
    }
}
