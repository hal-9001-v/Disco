using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : CombatInputComponent 
{

    public ButtonScript RightButton;
    public ButtonScript LeftButton;
    public ButtonScript UpButton;
    public ButtonScript DownButton;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public override void setInput(CombatInput inputs)
    {
        //RhythmButtons Controller
        inputs.Combat.RhythmDown.performed += ctx =>
        {

            DownButton.Push();

        };

        inputs.Combat.RythmUp.performed += ctx =>
        {

            UpButton.Push();

        };
        
        inputs.Combat.RhythmLeft.performed += ctx =>
        {

            LeftButton.Push();

        };
        
        inputs.Combat.RhythmRight.performed += ctx =>
        {

            RightButton.Push();

        };

        //CANCELS
        inputs.Combat.RhythmDown.canceled += ctx =>
        {

            DownButton.Release();

        };

        inputs.Combat.RythmUp.canceled += ctx =>
        {

            UpButton.Release();

        };

        inputs.Combat.RhythmLeft.canceled += ctx =>
        {

            LeftButton.Release();

        };

        inputs.Combat.RhythmRight.canceled += ctx =>
        {

            RightButton.Release();

        };

        //Card Combat Input Controller
        inputs.Combat.CardLeft.performed += ctx =>
        {



        }; inputs.Combat.CardRight.performed += ctx =>
        {



        }; inputs.Combat.CardSend.performed += ctx =>
        {



        };


    }
}
