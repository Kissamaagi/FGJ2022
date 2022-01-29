using Godot;
using System;

public class PlayerCat : KinematicBody2D
{
    [Export] public int speed = 200;
    [Export] public int gravity = 10000;

    [Export] public int jumpSpeed = -3000;

    [Export] public float friction = 0.20F;

    public String leftKickSprite = "kickback";
    public String rightKickSprite = "kickfront";

    public Vector2 ScreenSize;
    public Vector2 velocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        ScreenSize = GetViewportRect().Size;
    }
    public void GetInput() {

        var catSprite = GetNode<AnimatedSprite>("CatSprite");



        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            catSprite.Animation = "walk";
            if (Input.IsActionPressed("move_right")) { 
                catSprite.FlipH = false;
                velocity.x += speed; 
                rightKickSprite = "kickfront";
                leftKickSprite = "kickback";

            }
            if (Input.IsActionPressed("move_left")) {
                catSprite.FlipH = true;
                velocity.x -= speed; 
                rightKickSprite = "kickback";
                leftKickSprite = "kickfront";
            }
            catSprite.Playing = true;
        }


        if (Input.IsActionJustPressed("jump") && IsOnFloor()) { 
            catSprite.Animation = "jump";
            velocity.y = jumpSpeed; 
        }



        if (Input.IsActionJustPressed("down") && IsOnFloor()) { 
            Position += new Vector2(0, 1);
        }

        
        if (Input.IsActionPressed("kick_right")) { HandleKick("right"); } else  GetNode<CollisionPolygon2D>("./KickAreaFront/KickCollision").Disabled = true;
        if (Input.IsActionPressed("kick_left")) { HandleKick("left"); } else  GetNode<CollisionPolygon2D>("./KickAreaBack/KickCollisionBack").Disabled = true;
        
        if  (!Input.IsActionPressed("kick_right") && !Input.IsActionPressed("kick_left")) {
            if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
                catSprite.Animation = "walk";
            }
            else catSprite.Animation = "stand";
        }
        
        if (!IsOnFloor()) {
            catSprite.Animation = "jump";
        }

        velocity.x = Mathf.Lerp(velocity.x, 0, friction);
    }

    public void HandleKick(String direction) {
        var catSprite = GetNode<AnimatedSprite>("CatSprite");


        if (direction == "right") {
            CollisionPolygon2D catKickHitbox = GetNode<CollisionPolygon2D>("./KickAreaFront/KickCollision");
            catKickHitbox.Disabled = false;
            catSprite.Animation = rightKickSprite;
        }
        if (direction == "left") {
            CollisionPolygon2D catKickHitbox = GetNode<CollisionPolygon2D>("./KickAreaBack/KickCollisionBack");
            catKickHitbox.Disabled = false;
            catSprite.Animation = leftKickSprite;
        }
        // catKickHitbox.Disabled = true;


    }

    public override void _PhysicsProcess(float delta) {
        GetInput();

        velocity.y += gravity * delta;

        

        Vector2 UP = new Vector2(0, -1);
        velocity = MoveAndSlide(velocity, UP);

        


    }

}
