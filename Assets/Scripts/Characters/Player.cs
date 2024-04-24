using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public override void Start()
    {
        base.Start();
        speed = base.speed;
    }
    public override void Update()
    {
        base.Update();
        direction = Input.GetAxisRaw("Horizontal");
    }
    protected override void HandleMovement()
    {
        base.HandleMovement();
        anim.SetFloat("speed", Mathf.Abs(direction));
        TurnAround(direction);
    }

}