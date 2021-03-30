using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : InputComponent
{

    bool playerIsMoving;
    public override void setInput(NormalInput inputs)
    {
        inputs.Map.Movement.performed += ctx =>
        {

            playerIsMoving = true;

            if (!Pauser.isPaused) {

                Vector3 v = transform.position;

                var aux = ctx.ReadValue<Vector2>();

                v.x += aux.x;
                v.y += aux.y;

                transform.position = v;
            }
            
        };


        inputs.Map.Movement.canceled += ctx =>
        {
            playerIsMoving = false;
            
        };



    }

}