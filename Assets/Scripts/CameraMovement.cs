using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject Sun;
    public GameObject Planet1;
    public GameObject Planet2;
    public GameObject Planet3;
    public GameObject Planet4;
    public GameObject Planet5;

    [Range(0, 1)] public float percent;

    public float yaw = 0;
    public int target;

    public Dropdown dropdown;

    Vector3 NextPos;
    Vector3 CurrPos;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrPos.x = 15;
        CurrPos.y = 18;
        CurrPos.z = -16;
        dropdown.onValueChanged.AddListener(delegate
        {
            CurrPos = transform.position;
            percent = 0;
        });
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        CameraMove();
    }

    private void CameraMove()
    {
        if (target == 0)
        {
            NextPos.x = 15;
            NextPos.y = 18;
            NextPos.z = -16;
        }

        if (target == 1)
        {
            NextPos.x = Planet1.transform.position.x + 2f;
            NextPos.z = Planet1.transform.position.z - 2f;
            NextPos.y = Planet1.transform.position.y + 2f;
        }

        if (target == 2)
        {
            NextPos.x = Planet2.transform.position.x + 2f;
            NextPos.z = Planet2.transform.position.z - 2f;
            NextPos.y = Planet2.transform.position.y + 2f;
        }

        if (target == 3)
        {
            NextPos.x = Planet3.transform.position.x + 2f;
            NextPos.z = Planet3.transform.position.z - 2f;
            NextPos.y = Planet3.transform.position.y + 2f;
        }

        if (target == 4)
        {
            NextPos.x = Planet4.transform.position.x + 2f;
            NextPos.z = Planet4.transform.position.z - 2f;
            NextPos.y = Planet4.transform.position.y + 2f;
        }

        if (target == 5)
        {
            NextPos.x = Planet5.transform.position.x + 2f;
            NextPos.z = Planet5.transform.position.z - 2f;
            NextPos.y = Planet5.transform.position.y + 2f;
        }

        if (percent < 1)
        {
            percent += .002f;
        }

        transform.position = Lerp(CurrPos, NextPos, percent);
    }

    private void CameraRotation()
    {
        target = dropdown.value;
        Vector3 vectorToTarget = Vector3.zero;

        if (target == 0)
        {
            vectorToTarget = Sun.transform.position - transform.position;
        }
        if (target == 1)
        {
            vectorToTarget = Planet1.transform.position - transform.position;
        }
        if (target == 2)
        {
            vectorToTarget = Planet2.transform.position - transform.position;
        }
        if (target == 3)
        {
            vectorToTarget = Planet3.transform.position - transform.position;
        }
        if (target == 4)
        {
            vectorToTarget = Planet4.transform.position - transform.position;
        }
        if (target == 5)
        {
            vectorToTarget = Planet5.transform.position - transform.position;
        }


        yaw = Mathf.Atan2(vectorToTarget.z, vectorToTarget.x);
        Quaternion desiredRotation = Quaternion.LookRotation(vectorToTarget);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, 90 * Time.deltaTime);
    }

    float Lerp(float min, float max, float p)
    {
        return (max - min) * p + min;
    }

    Vector3 Lerp(Vector3 min, Vector3 max, float p)
    {
        float x = Lerp(min.x, max.x, p);
        float y = Lerp(min.y, max.y, p);
        float z = Lerp(min.z, max.z, p);
        return new Vector3(x, y, z);
    }
}
