using Godot;
using System;

public class MainMenu : MarginContainer
{
    public Vector2 ScreenSize;
    public int timer = 0;

    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        ScreenSize = GetViewportRect().Size;
    }

    public void HandleBlink() {
        AnimatedSprite blinkCat = GetNode<AnimatedSprite>("VBoxContainer/HBoxContainer/BlinkCat");
        Console.WriteLine("blinking...");
        blinkCat.Animation = "blink";
    }


    public override void _Process(float delta){   

        timer++;

        if (timer == 300) {
            HandleBlink();
            timer = 0;
        }
    }
}
