using UnityEngine;
using Unity.VisualScripting;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    CinemachineInputAxisController axisController;
    GameObject cinemachineCamera;
    CinemachineCamera Camera;
    [SerializeField] Animator handsAnimator;
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
        if (reloadAmount > 0)
        {
            handsAnimator.SetTrigger("reloading");
        }
    }
    public void LockCamera()
    {
        cinemachineCamera.SetActive(false);
        
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Survivalist (3)")
            {
                foreach (Transform children in child)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }

    public void UnLockCamera()
    {
        cinemachineCamera.SetActive(true);
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Survivalist (3)")
            {
                foreach (Transform children in child)
                {
                    if (children.gameObject.name == "FPS_HANDS" || children.gameObject.name == "ROOT" || children.gameObject.name == "SK_Military_Boots3" || children.gameObject.name == "SK_Military_Head1" || children.gameObject.name == "SK_Military_Pants2" || children.gameObject.name == "SK_Military_Shirt3")
                    {
                       child.gameObject.SetActive(true);
                    }
                    
                }
            }
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Main");
    }
}
