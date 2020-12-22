# ImMonoGame
A small lightiwght library for ImGui.Net with MonoGame Intergration, and a basic UI Entity/Object type system.

## documentation

- ImGui Entity: a simple object, with one virtual method that your UIObject is meant to inherit, add all UI code/methods in to that method.
- ImGui Component: abstracts ImGui rendering and handles update, drawing initialization and load content.
- Imgui Renderer & DrawVertDecleration: the main rendering code for ImMonoGame, generally best not to mess with it. From: https://github.com/mellinoe/ImGui.NET

## sample code and intergration
```using ImGuiNET;
using ImMonoGame.Thing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Num = System.Numerics;

namespace ImMonoGame
{
    public class SampleProject : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ImguiComponent ImGui;
        private List<ImGuiEntity> UIEntity = new List<ImGuiEntity>();
  
        public SampleProject()
        {
            _graphics = new GraphicsDeviceManager(this);
            ImGui = new ImguiComponent(_graphics, this, UIEntity);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            ImGui.Initialize();
            ImGui.LoadContent();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            UIEntity.Add(new ImGuiDemo(this.ImGui._imGuiTexture));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ImGui.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
```
## credits
- ImGui.Net created by https://github.com/mellinoe/
- ImGui created by https://github.com/ocornut/imgui/
- MonoGame created by MonoGame (big suprise)
