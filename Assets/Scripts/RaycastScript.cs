using System.Security.Cryptography;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    [SerializeField]
    private PlayerScript player;
    [SerializeField]
    private float raycastDistance = 1000f;

    public void Awake()
    {
        player = FindFirstObjectByType<PlayerScript>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 v = Input.mousePosition;
            Debug.Log(v);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(v), out hit, raycastDistance))
            {

            }
        }
    }
}
