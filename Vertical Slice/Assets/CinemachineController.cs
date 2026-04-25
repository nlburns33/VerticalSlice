using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    CinemachineInputAxisController axisController;
    
    // Start is called before the first frame update
    void Start()
    {
        axisController = GetComponent<CinemachineInputAxisController>();
        
    }

    public void LockCamera() 
    {
        foreach (var property in axisController.Controllers)
        {
            if (property.Name == "Look X(Pan)")
            {
                property.Input.Gain = 0;
                break;
            }
            if (property.Name == "Look Y(Tilt)")
            {
                property.Input.Gain = 0;
                break;
            }
        }
    }

    public void UnLockCamera()
    {
        foreach (var property in axisController.Controllers)
        {
            if (property.Name == "Look X(Pan)")
            {
                property.Input.Gain = 1;
                break;
            }
            if (property.Name == "Look Y(Tilt)")
            {
                property.Input.Gain = -1;
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
