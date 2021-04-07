using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : InputComponent
{

    public override void setInput(NormalInput inputs)
    {
        inputs.Map.Movement.performed += ctx =>
        {

            if (!Pauser.isPaused) {

                Vector3 v = transform.position;

                var aux = ctx.ReadValue<Vector2>();

                v.x += aux.x;
                v.y += aux.y;

                transform.position = v;
            }
            
        };



    }

}