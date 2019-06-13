using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    enum guns
    {
        CubeGun,
        CircleGun,
        TriangleGun
    }

    public float bulletSpeed;

    private Camera mainCamera;

    [SerializeField] private float shootingRange;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private List<GameObject> gunList;
    [SerializeField] private List<GameObject> bulletList;
    [SerializeField] private List<Image> gunAimList;
    [SerializeField] private guns currentGun;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();

        DeactivateAllGuns();
        gunList[(int)currentGun].SetActive(true);
        gunAimList[(int)currentGun].gameObject.SetActive(true);

        SetShootingPoint();
    }

    private void DeactivateAllGuns()
    {
        for (int i = 0; i < gunList.Count; i++)
        {
            gunList[i].SetActive(false);
            gunAimList[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        ShootingInput();
        WeaponSwapInput();
    }

    private void ShootingInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    private void WeaponSwapInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetGunActive(guns.CubeGun);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetGunActive(guns.CircleGun);
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetGunActive(guns.TriangleGun);
        }

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0f)
        {
            switch (currentGun)
            {
                case guns.CubeGun:
                    SetGunActive(guns.CircleGun);
                    break;
                case guns.CircleGun:
                    SetGunActive(guns.TriangleGun);
                    break;
                case guns.TriangleGun:
                    SetGunActive(guns.CubeGun);
                    break;
                default:
                    break;
            }
        } else if(scrollWheel < 0f)
        {
            switch (currentGun)
            {
                case guns.CubeGun:
                    SetGunActive(guns.TriangleGun);
                    break;
                case guns.CircleGun:
                    SetGunActive(guns.CubeGun);
                    break;
                case guns.TriangleGun:
                    SetGunActive(guns.CircleGun);
                    break;
                default:
                    break;
            }
        }

    }

    private Vector3 ShootRay()
    {
        RaycastHit hit;
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(transform.position);
        Physics.Raycast(rayOrigin, transform.forward, out hit, shootingRange);
        return hit.point;

    }

    private void SetShootingPoint()
    {
        shootingPoint.LookAt(ShootRay());
    }

    private void ShootBullet()
    {
        GameObject shotBullet = Instantiate(bulletList[(int) currentGun]);
        shotBullet.transform.position = shootingPoint.position;
        shotBullet.transform.rotation = shootingPoint.rotation;
        shotBullet.GetComponent<Rigidbody>().AddForce(shotBullet.transform.forward * bulletSpeed, ForceMode.Impulse);
    }


    private void SetGunActive(guns gunToActivate)
    {
        if (currentGun != gunToActivate)
        {
            gunList[(int)currentGun].SetActive(false);
            gunAimList[(int)currentGun].gameObject.SetActive(false);
            currentGun = gunToActivate;
            gunList[(int)currentGun].SetActive(true);
            gunAimList[(int)currentGun].gameObject.SetActive(true);
        }
    }
}
