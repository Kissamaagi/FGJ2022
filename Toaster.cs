using Godot;
using System;

public class Toaster : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Connect("body_entered", this, nameof(_on_enter));
    }

    public void _on_enter(Node body) {
        Console.WriteLine("Entered");
    }
}