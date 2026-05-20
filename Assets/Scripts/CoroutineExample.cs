using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{

    IEnumerator SampleCorountine(float f, string s)
    {

        yield return new WaitForSeconds(f);

        Debug.Log("Coroutine Finished" + s);
    }

    private void Start()
    {
        StartCoroutine(SampleCorountine(2f, "#1"));

        StartCoroutine(SampleCorountine(1f, "#2"));
    }

}
