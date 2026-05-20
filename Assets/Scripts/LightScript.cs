using System.Collections;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    // light component var
    private Light _lightComponent;

    //define enum for discrete(moving vs stopped/standing vs crouched) light states
    private enum LightState
    {
        On, //0
        Off, //1
        Flickering //2
    }

    [SerializeField]
    private LightState _currentState;
    [SerializeField]
    private LightState _defaultState;

    private void Start()
    {
        _lightComponent = GetComponent<Light>();
        _currentState = _defaultState;

        //start state machine
        ChangeState(_currentState);
    }

    // Setting up state machine

    //Change state takes a var of type Lightstate (enum)
    //then change light currentstate to the newstate
    private void ChangeState(LightState newState)
    {
        Debug.Log("Change State to: " + newState.ToString());

        //check status of newState var, run code to change to corresponding state
        switch (newState)
        {
            case LightState.On:
                //swap to On state coroutine
                StartCoroutine(OnState());
                break;
            case LightState.Off:
                StartCoroutine(OffState());
                //swap to Off state coroutine
                break;
            case LightState.Flickering:
                StartCoroutine(FlickeringState());
                //swap to Flickering state coroutine
                break;
        }
    }

    IEnumerator OnState()
    {
        //State initialization
        //turn on light, set brightness
        Debug.Log("On State: Enter");
        _lightComponent.enabled = true;
        _lightComponent.intensity = 4f;

        //State loop
        while(_currentState == LightState.On)
        {
            //forces corountine to wait for end of frame
            //required for loop to not break
            //quirk of coroutines
            yield return null;
            if (Input.GetMouseButton(0))
            {
                _currentState = LightState.Off;
            }
        }

        //State termination/cleanup
        Debug.Log("On State: Exit");
        //Our _currentState var was just changed to ff in the code, so we need to call ChangeState on our light
        //this will move us to the OFF State
        ChangeState(_currentState);
        //Corountine ends
    }

    IEnumerator OffState()
    {
        //State initialization
        //turn off light
        Debug.Log("Off State: Enter");
        _lightComponent.enabled = false;

        //State Loop
        while (_currentState == LightState.Off)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0))
            {
                //Change state to On
                _currentState = LightState.On;
            }
        }

        Debug.Log("Off State Exit");
        ChangeState(_currentState);
    }

    IEnumerator FlickeringState()
    {
        yield return null;
    }
}
