using UnityEngine;

public class BombThrower : MonoBehaviour
{
    public GameObject bombPrefab;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Bomb.bombCount > 0) // sağ tık
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Instantiate(bombPrefab, mousePos, Quaternion.identity);
            Bomb.bombCount -= 1;
        }
    }
}
