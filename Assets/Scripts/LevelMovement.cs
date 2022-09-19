using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelMovement : MonoBehaviour
{
    public Transform _trans;

    int tester = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Q].isPressed)
        {

            Debug.Log("sup");
        }
    }

    public void spinLeft(InputAction.CallbackContext context)
    {
        if (Keyboard.current[Key.Q].isPressed)
        {
            tester -= 90;
            _trans.Rotate(_trans.rotation.x, _trans.rotation.y, tester);
        }
    }
    
    public void spinRight(InputAction.CallbackContext context)
    {
        if (Keyboard.current[Key.E].isPressed)
        {
            tester += 90;
            _trans.Rotate(_trans.rotation.x, _trans.rotation.y, tester);
        }
    }
}
