using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private int screenWight;                //ширина обзора камеры
    private int screenHeight;               //высота обзора камеры

    public float speed_y;
    public float max_Y, min_Y;

    public float max_X, min_X, max_Z, min_Z; //размеры карты по х и z
    public float speed;                      //скорость передвижения камеры
    public bool useCameraMove;               //фиксация камеры (ВКЛ/ВЫКЛ)


    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen.height;
        screenWight = Screen.width;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            useCameraMove = !useCameraMove;

        if (useCameraMove)
        {
            Vector3 camerPos = transform.position;

            if (Input.mousePosition.x <= 10)
            {
                camerPos.x -= Time.deltaTime * speed * 2;
            }
            else if (Input.mousePosition.x >= screenWight - 20)
            {
                camerPos.x += Time.deltaTime * speed * 2;
            }
            else if (Input.mousePosition.x <= 30)
            {
                camerPos.x -= Time.deltaTime * speed;
            }
            else if (Input.mousePosition.x >= screenWight - 40)
            {
                camerPos.x += Time.deltaTime * speed;
            }

            if (Input.mousePosition.y <= 5)
            {
                camerPos.z -= Time.deltaTime * speed * 4;
            }
            else if (Input.mousePosition.y >= screenHeight - 20)
            {
                camerPos.z += Time.deltaTime * speed * 4;
            }
            else if (Input.mousePosition.y <= 10)
            {
                camerPos.z -= Time.deltaTime * speed * 2;
            }
            else if (Input.mousePosition.y >= screenHeight - 40)
            {
                camerPos.z += Time.deltaTime * speed * 2;
            }
            camerPos.y -= Input.GetAxis("Mouse ScrollWheel") * speed_y * Time.deltaTime;
            float y = Mathf.Clamp(camerPos.y, min_Y, max_Y);
            float x = Mathf.Clamp(camerPos.x, min_X, max_X);
            float z = Mathf.Clamp(camerPos.z, min_Z, max_Z);

            transform.position = new Vector3(x, y, z);
        }
    }
}
