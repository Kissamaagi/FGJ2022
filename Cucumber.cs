using Godot;
using System;

public class Cucumber : Area2D
{
    int DeathTimer = -1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Connect("area_entered", this, nameof(_on_enter));
    }

    public void _on_enter(Node body) {
        Console.WriteLine(body);

        CPUParticles2D explosion1 = GetNode<CPUParticles2D>("Part1");
        explosion1.Emitting = true;
        CPUParticles2D explosion2 = GetNode<CPUParticles2D>("Part2");
        explosion2.Emitting = true;

        DeathTimer = 600;
        GetNode<Sprite>("Sprite").Visible = false; 
        Disconnect("area_entered", this, nameof(_on_enter));
    }


    public override void _Process(float delta){
        if (DeathTimer != -1) {

            if (DeathTimer > 0) {
                DeathTimer--;
            }
            else {
                QueueFree();
            }
        } 
    }
}
