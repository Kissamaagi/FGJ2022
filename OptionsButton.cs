using Godot;
using System;

public class OptionsButton : Button
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_OptionsButton_pressed() {
        Console.WriteLine("Clicked");
        GetNode<PopupPanel>("/VBoxContainer/HBoxContainer/MenuOptions/Label/PopupPanel").Popup_();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
