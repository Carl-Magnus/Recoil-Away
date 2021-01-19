using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    [Header("Offset aiming angle")]
    public float offSet;

    private bool facingRight = false;

    public Transform player;

    void Update()
    {
        Vector3 differance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offSet);

        if (rotZ < -90 || rotZ > 90)
        {
            if (player.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
            }
            else if (player.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
            }
        }
    }
}
