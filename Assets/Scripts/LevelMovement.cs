using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelMovement : MonoBehaviour
{
    public Transform _trans;

    public PlayerMovement player;

    int tester = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tester);
    }

    public void spinLeft(InputAction.CallbackContext context)
    {
        if (Keyboard.current[Key.Q].isPressed)
        {
            if (!player.GetIsGrounded())
            {
                tester -= 90;
                _trans.Rotate(_trans.rotation.x, _trans.rotation.y, tester);
            }
        }
    }
    
    public void spinRight(InputAction.CallbackContext context)
    {
        if (Keyboard.current[Key.E].isPressed)
        {
            if (!player.GetIsGrounded())
            {
                tester += 90;
                _trans.Rotate(_trans.rotation.x, _trans.rotation.y, tester);
            }
        }
    }
}
