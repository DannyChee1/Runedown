using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float x = 0;
    public float y = 0;
    public float z = -10;
    public GameObject Camera;
    public Vector2 WorldUnitsInCamera;
    public Vector2 WorldToPixelAmount;
    public float add;
    void Start() {
        WorldUnitsInCamera.y = Camera.GetComponent<Camera>().orthographicSize * 2;
        WorldUnitsInCamera.x = WorldUnitsInCamera.y * Screen.width / Screen.height;
        WorldToPixelAmount.x = Screen.width / WorldUnitsInCamera.x;
        WorldToPixelAmount.y = Screen.height / WorldUnitsInCamera.y;
        add = WorldUnitsInCamera.x;
        x = -add;
        InvokeRepeating("RotatePos", 0, 0.15f);
    }
    // public Vector2 ConvertToWorldUnits(Vector2 TouchLocation) {
    //     Vector2 returnVec2;
    //     returnVec2.x = ((TouchLocation.x / WorldToPixelAmount.x) - (WorldUnitsInCamera.x / 2)) + Camera.transform.position.x;
    //     returnVec2.y = ((TouchLocation.y / WorldToPixelAmount.y) - (WorldUnitsInCamera.y / 2)) + Camera.transform.position.y;
    //     return returnVec2;
    // }
    public float ConvertToWorldUnits(float x) {
        return x/WorldToPixelAmount.x - WorldUnitsInCamera.x/2 + Camera.transform.position.x;
    }
    void RotatePos() {
        //float add = WorldUnitsInCamera.x;
        //print(add);
        if(x +  add > 57.6f) x = -add;
        GameObject.Find("Main Camera").transform.position = new Vector3(x += add, y, z);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
