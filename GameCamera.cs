using Godot;
using System;

public class GameCamera : Camera2D
{

    public override void _Ready()
    {
        
    }


    public override void _Process(float delta)
    {
        Vector2 CatPosition = GetNode<KinematicBody2D>("/root/Level/PlayerCat").Position;


        GlobalPosition = new Vector2(CatPosition.x + 300, 200);
    }
}
