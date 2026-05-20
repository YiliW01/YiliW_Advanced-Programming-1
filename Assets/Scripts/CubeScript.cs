using Unity.VisualScripting;
using UnityEngine;

public class CubeScript : MonoBehaviour
{

    int[] xArray = {1, 2, 3};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string.Concat("hello", " world");

        int j = 0;
        while (j < xArray.Length)
        {
            Debug.Log(j);
            j++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
