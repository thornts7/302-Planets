using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class SolarMovement : MonoBehaviour
{

    public GameObject Planet1;
    public GameObject Planet2;
    public GameObject Planet3;
    public GameObject Planet4;
    public GameObject Planet5;

    public GameObject Moon1;
    public GameObject Moon2;
    public GameObject Moon3;
    public GameObject Moon4;
    public GameObject Moon5;
    public GameObject Moon6;
    public GameObject Moon7;
    public GameObject Moon8;

    public Slider timeSlider;
    public Button timeSliderButton;
    public Button Pause;
    public Button Play;

    Vector3 Loc;
    //Vector3 Rot;

    float Tim;
    [Range(-.2f, .2f)] public float TimCon = 0;
    float RoTim = 0;

    bool NotPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        timeSliderButton.onClick.AddListener(ResetTimeSlider);
        Pause.onClick.AddListener(PauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVar();
        UpdateEntities();
    }

    void UpdateVar()
    {
        TimCon = timeSlider.value;

        if (NotPaused)
        {
            Tim += 0.01f + TimCon;
            RoTim = 0.10f + TimCon;
        }

    }

    void UpdateEntities()
    {
        Planet1.transform.position = CalculatePlanetLocation(3, 1.2f);
        Planet2.transform.position = CalculatePlanetLocation(6, .8f);
        Planet3.transform.position = CalculatePlanetLocation(9, .50f);
        Planet4.transform.position = CalculatePlanetLocation(12, .3f);
        Planet5.transform.position = CalculatePlanetLocation(15, .2f);

        Moon1.transform.position = CalculateMoonLocation(Planet1.transform, 1f, 2f);
        Moon2.transform.position = CalculateMoonLocation(Planet2.transform, 1f, 2f);
        Moon3.transform.position = CalculateMoonLocation(Planet3.transform, 1f, 2f);
        Moon4.transform.position = CalculateMoonLocation(Planet4.transform, 1f, 2f);
        Moon5.transform.position = CalculateMoonLocation(Planet5.transform, 1f, 2f);
        Moon6.transform.position = CalculateMoonLocation(Planet3.transform, 1.5f, 1.7f);
        Moon7.transform.position = CalculateMoonLocation(Planet4.transform, 1.5f, 1.7f);
        Moon8.transform.position = CalculateMoonLocation(Planet5.transform, 1.5f, 1.7f);

        //First attempt at rotation.
        //Planet1.transform.rotation = CalculateRotation(10f, Planet1.transform.rotation);

        if (NotPaused)
        {
            gameObject.transform.Rotate(0, RoTim/2, 0);

            Planet1.transform.Rotate(0, RoTim, 0);
            Planet2.transform.Rotate(0, RoTim, 0);
            Planet3.transform.Rotate(0, RoTim, 0);
            Planet4.transform.Rotate(0, RoTim, 0);
            Planet5.transform.Rotate(0, RoTim, 0);

            Moon1.transform.Rotate(0, RoTim, 0);
            Moon2.transform.Rotate(0, RoTim, 0);
            Moon3.transform.Rotate(0, RoTim, 0);
            Moon4.transform.Rotate(0, RoTim, 0);
            Moon5.transform.Rotate(0, RoTim, 0);
            Moon6.transform.Rotate(0, RoTim, 0);
            Moon7.transform.Rotate(0, RoTim, 0);
            Moon8.transform.Rotate(0, RoTim, 0);
        }
    }

    Vector3 CalculatePlanetLocation(int type, float Speed) 
    {
        Loc.x = type * Mathf.Cos(Tim * Speed) + transform.position.x;
        Loc.z = type * Mathf.Sin(Tim * Speed) + transform.position.z;
        Loc.y = transform.position.y;
        return Loc;
    }

    Vector3 CalculateMoonLocation(Transform transform, float type, float Speed)
    {
        Loc.x = type * Mathf.Cos(Tim * Speed) + transform.position.x;
        Loc.z = type * Mathf.Sin(Tim * Speed) + transform.position.z;
        Loc.y = transform.position.y;
        return Loc;
    }

    //First attempt at rotation
    //Quaternion CalculateRotation(float r, Quaternion t)
    //{
    //    Quaternion rotation = t;
    //    float x = rotation.x;
    //    x += r;
    //    Debug.Log(x);
    //    if (x > 360) x = 0;
    //    return rotation = Quaternion.Euler(x, 0, 0);
    //}

    void ResetTimeSlider()
    {
        timeSlider.value = 0;
    }

    void PauseGame()
    {
        if (NotPaused)
        {
            NotPaused = false;
            return;
        }
        if (!NotPaused)
        {
            NotPaused = true;
            return;
        }
    }
}
