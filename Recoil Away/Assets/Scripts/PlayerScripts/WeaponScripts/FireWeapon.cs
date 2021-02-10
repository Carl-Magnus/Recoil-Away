using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject projectile;

    public Transform shotPoint;

    public float recoilForce;

    #region SMG Stats
    private float timeBetweenSMGShots;
    private float timeBetweenSMGShotsReset;

    private int SMGMagSize;
    #endregion

    #region Shotgun Stats
    private float timeBetweenShotgunShots;
    private float timeBetweenShotgunShotsReset;

    private int shotgunSpread;
    private int numberOfBullets;
    private int shotgunMagSize;

    private Quaternion shotgunNewRot;
    #endregion

    #region Player Weapons
    private int SMG = 0;
    private int shotgun = 1;
    #endregion

    void Start()
    {
        #region SMG Instantiates
        timeBetweenSMGShots = 0f;
        timeBetweenSMGShotsReset = 0.198f;
        #endregion

        #region Shotgun Instantiates
        timeBetweenShotgunShots = 0f;
        timeBetweenShotgunShotsReset = 0.75f;

        shotgunNewRot = shotPoint.rotation;

        numberOfBullets = 5;
        shotgunSpread = 2;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<WeaponSwitch>().selectedWeapon == SMG)
        {
            if (timeBetweenSMGShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                    RecoilKnockback();
                    timeBetweenSMGShots = timeBetweenSMGShotsReset;
                }
            }
            else
            {
                timeBetweenSMGShots -= Time.deltaTime;
            }
        }
        else if (gameObject.GetComponentInParent<WeaponSwitch>().selectedWeapon == shotgun)
        {
            if (timeBetweenShotgunShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                    RecoilKnockback();
                    timeBetweenShotgunShots = timeBetweenShotgunShotsReset;
                }
            }
            else
            {
                timeBetweenShotgunShots -= Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        if (gameObject.GetComponentInParent<WeaponSwitch>().selectedWeapon == SMG)
        {
            Instantiate(projectile, shotPoint.position, transform.rotation);
        }
        else if (gameObject.GetComponentInParent<WeaponSwitch>().selectedWeapon == shotgun)
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                float addOffset = (i - numberOfBullets / 2) * shotgunSpread;

                shotgunNewRot = Quaternion.Euler(shotPoint.transform.eulerAngles.x, shotPoint.transform.eulerAngles.y, shotPoint.transform.eulerAngles.z + addOffset);
                Instantiate(projectile, shotPoint.position, shotgunNewRot);
            }
        }

    }

    private void RecoilKnockback()
    {
        Rigidbody2D knockbackBody = gameObject.GetComponentInParent<Rigidbody2D>();

        knockbackBody.AddForce(recoilForce * (transform.right * -1));

    }
}

