# ImMonoGame
A small lightiwght library for ImGui.Net with MonoGame Intergration, and a basic UI Entity/Object type system.

## documentation

ImGui Entity: a simple object, with one virtual method that your UIObject is meant to inherit, add all UI code/methods in to that method.
ImGui Component: abstracts ImGui rendering and handles update, drawing initialization and load content.
Imgui Renderer & DrawVertDecleration: the main rendering code for ImMonoGame, generally best not to mess with it. From: https://github.com/mellinoe/ImGui.NET

## Credits
ImGui.Net created by https://github.com/mellinoe/
ImGui created by https://github.com/ocornut/imgui/
MonoGame created by MonoGame (big suprise)
