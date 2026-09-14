using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShoot : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject waterbullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; //Pozisyon farkındaki değeri açıya çevirir ordan radyanı derece yapar

        transform.rotation = Quaternion.Euler(0, 0, rotZ);//Z ekseninde döndürür


        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }


        if (Input.GetMouseButton(0) && canFire)
        {
            //Sol tuşa basılırsa ve ateş özelliği açıksa mermi oluşturur
            //Quaternion.identity açıyı sabit tutturur
            canFire = false;
            GameObject bullet = Instantiate(waterbullet, bulletTransform.position, Quaternion.identity);
            Destroy(bullet, 3f); // 3 saniye sonra mermiyi siler    

        }
    }
}
