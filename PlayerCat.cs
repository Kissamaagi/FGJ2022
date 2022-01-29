using Godot;
using System;

public class PlayerCat : KinematicBody2D
{
    [Export] public int speed = 200;
    [Export] public int gravity = 10000;

    [Export] public int jumpSpeed = -3000;

    [Export] public float friction = 0.20F;


    public Vector2 ScreenSize;
    public Vector2 velocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        ScreenSize = GetViewportRect().Size;
    }
    public void GetInput() {
        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            if (Input.IsActionPressed("move_right")) { velocity.x += speed; }
            if (Input.IsActionPressed("move_left")) { velocity.x -= speed; }
            GetNode<AnimatedSprite>("CatSprite").Playing = true;
        }

        else {
            GetNode<AnimatedSprite>("CatSprite").Playing = false;
        }

        if (Input.IsActionJustPressed("jump") && IsOnFloor()) { velocity.y = jumpSpeed; }
        if (Input.IsActionJustPressed("down") && IsOnFloor()) { 
            Position += new Vector2(0, 1);
        }

        if (Input.IsActionJustPressed("kick_right")) { HandleCollision("right"); }

        velocity.x = Mathf.Lerp(velocity.x, 0, friction);
    }

    public void HandleCollision(String direction) {
        CollisionPolygon2D catKickHitbox = GetNode<CollisionPolygon2D>("KickCollision");
        catKickHitbox.Disabled = false;


    }

    public override void _PhysicsProcess(float delta) {
        GetInput();

        velocity.y += gravity * delta;

        

        Vector2 UP = new Vector2(0, -1);
        velocity = MoveAndSlide(velocity, UP);

        


    }

}
