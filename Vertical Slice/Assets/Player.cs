using UnityEngine;
using Unity.VisualScripting;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    CinemachineInputAxisController axisController;
    GameObject cinemachineCamera;
    CinemachineCamera Camera;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineCamera = GameObject.Find("First Person Camera");
        axisController = cinemachineCamera.GetComponent<CinemachineInputAxisController>();
        Debug.Log(axisController);
        Camera = cinemachineCamera.GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reload()
    {
        
        int currentAmmo = (int)Variables.Object(gameObject).Get("ammo");
        int ammoReserves = (int)Variables.Object(gameObject).Get("ammoReserve");
        int ammoDifference = 5 - currentAmmo;
        int reloadAmount = Mathf.Min(ammoReserves, ammoDifference);
        Variables.Object(gameObject).Set("ammo", currentAmmo + reloadAmount);
        Variables.Object(gameObject).Set("ammoReserve", ammoReserves - reloadAmount); 
    }
    public void LockCamera()
    {
        GameObject cameraLocator = (GameObject)Variables.Object(gameObject).Get("cameraLocator");
        Vector3 cameraLocatorPos = cameraLocator.transform.position;
        Quaternion lockerFacing = (Quaternion)Variables.Object(gameObject).Get("lockerFacing");
        /*
        foreach (var c in axisController.Controllers)
        {
            Debug.Log(c);
            if (c.Name == "Look X (Pan)")
            {
                c.Input.Gain = 0;  
            }
            if (c.Name == "Look Y (Tilt)")
            {
                c.Input.Gain = 0;
            }
        }
        */
        cinemachineCamera.SetActive(false);
        Camera.ForceCameraPosition(cameraLocatorPos, lockerFacing);
    }

    public void UnLockCamera()
    {
        foreach (var c in axisController.Controllers)
        {
            if (c.Name == "Look X (Pan)")
            {
                c.Input.Gain = 1;
            }
            if (c.Name == "Look Y (Tilt)")
            {
                c.Input.Gain = -1;
            }
        }
    }
}
