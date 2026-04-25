using UnityEngine;
using Unity.VisualScripting;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
