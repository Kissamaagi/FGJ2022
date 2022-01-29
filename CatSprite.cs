using Godot;
using System;

public class CatSprite : AnimatedSprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("kick_right")) {
            Animation = "kick";
            Offset = new Vector2(15, 20);
        }
        else {
            Animation = "walk";
            Offset = new Vector2(0, 0);

        }
    }
}
