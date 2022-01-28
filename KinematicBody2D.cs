using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
    [Export] public int speed = 200;
    public Vector2 ScreenSize;
    public Vector2 velocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        ScreenSize = GetViewportRect().Size;
    }

    public override void _PhysicsProcess(float delta) {
        GetInput();

        velocity = MoveAndSlide(velocity);
    }

    public void GetInput() {
        velocity = new Vector2();

        if (Input.IsActionPressed("move_right")) { velocity.x += 1; }
        if (Input.IsActionPressed("move_left")) { velocity.x -= 1; }

        velocity = velocity.Normalized() * speed;
    }
}
