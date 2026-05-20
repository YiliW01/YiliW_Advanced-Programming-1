using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    [SerializeField]
    private PlayerScript player;
    [SerializeField]
    private float raycastDistance = 1000f;

    [SerializeField]
    LayerMask raycastMask;


    public void Awake()
    {
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 v = Input.mousePosition;

            Ray myRaycast;

            myRaycast = Camera.main.ScreenPointToRay(v);

            RaycastHit hit;

            if (Physics.Raycast(myRaycast, out hit, raycastDistance, raycastMask))
            {
                Debug.Log(hit.transform.name);

                Debug.Log(hit.point);

                player.Move(hit.point);
            }
        }
    }
}