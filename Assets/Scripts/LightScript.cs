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
        while (_currentState == LightState.On)
        {
            yield return null;

            if (Input.GetMouseButtonDown(0))
            {
                _currentState = LightState.Off;
            }
            //forces corountine to wait for end of frame
            //required for loop to not break
            //quirk of coroutines
            
        }

        //State termination/cleanup
        Debug.Log("On State: Exit");
        //Our _currentState var was just changed to off in the code, so we need to call ChangeState on our light
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
                var chance = Random.Range(0f, 100f);
                if (chance >= 50f) { _currentState = LightState.On; }
                else { _currentState = LightState.Flickering; }
                
            }
        }

        Debug.Log("Off State: Exit");
        ChangeState(_currentState);
    }

    IEnumerator FlickeringState()
    {
        Debug.Log("Flickering State: Enter");
        _lightComponent.intensity = 4f;

        //State loop
        while (_currentState == LightState.Flickering)
        {
            _lightComponent.enabled = true;

            yield return new WaitForSeconds(Random.Range(1f, 3f));

            _lightComponent.enabled = false;

            yield return new WaitForSeconds(0.1f);

            if (Input.GetMouseButtonDown(0))
            {
                _currentState = LightState.Off;
            }
        }

        Debug.Log("Flickering State: Exit");
        ChangeState(_currentState);
    }
}
