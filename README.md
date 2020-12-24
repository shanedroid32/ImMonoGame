# ImMonoGame
a small lightweight library for ImGui.Net and MonoGame, with a basic UI Entity/Object type system. Reccomended for use when debugging projects.

## documentation

- ImGui Entity: a simple object, with one virtual method that your UIObject is meant to inherit, add all UI code/methods in to that method.
- ImGui Component: abstracts ImGui rendering and handles update, drawing initialization and load content.
- Imgui Renderer & DrawVertDecleration: the main rendering code for ImMonoGame, generally best not to mess with it. From: https://github.com/mellinoe/ImGui.NET

## sample code and intergration
### ImGuiDemo Entity
```
using System;
using ImGuiNET;
using ImMonoGame.Thing;
using Num = System.Numerics;

namespace ImMonoGame
{
    public class ImGuiDemo : ImGuiEntity
    {
        private IntPtr _imGuiTexture;
        public ImGuiDemo(IntPtr imGuiTexture)
        {
            this._imGuiTexture = imGuiTexture;
        }
        private float f = 0.0f;
        private bool show_test_window = false;
        private bool show_another_window = false;
        private Num.Vector3 clear_color = new Num.Vector3(114f / 255f, 144f / 255f, 154f / 255f);
        private byte[] _textBuffer = new byte[100];
        public override void UI()
        {
            // 1.Show a simple window
            // Tip: if we don't call ImGui.Begin()/ImGui.End() the widgets appears in a window automatically called "Debug"
            {
                ImGui.Text("Hello, world!");
                ImGui.SliderFloat("float", ref f, 0.0f, 1.0f, string.Empty);
                ImGui.ColorEdit3("clear color", ref clear_color);
                if (ImGui.Button("Test Window")) show_test_window = !show_test_window;
                if (ImGui.Button("Another Window")) show_another_window = !show_another_window;
                ImGui.Text(string.Format("Application average {0:F3} ms/frame ({1:F1} FPS)", 1000f / ImGui.GetIO().Framerate, ImGui.GetIO().Framerate));

                ImGui.InputText("Text input", _textBuffer, 100);

                ImGui.Text("Texture sample");
                ImGui.Image(_imGuiTexture, new Num.Vector2(300, 150), Num.Vector2.Zero, Num.Vector2.One, Num.Vector4.One, Num.Vector4.One); // Here, the previously loaded texture is used
            }

            // 2. Show another simple window, this time using an explicit Begin/End pair
            if (show_another_window)
            {
                ImGui.SetNextWindowSize(new Num.Vector2(200, 100), ImGuiCond.FirstUseEver);
                ImGui.Begin("Another Window", ref show_another_window);
                ImGui.Text("Hello");
                ImGui.End();
            }

            // 3. Show the ImGui test window. Most of the sample code is in ImGui.ShowTestWindow()
            if (show_test_window)
            {
                ImGui.SetNextWindowPos(new Num.Vector2(650, 20), ImGuiCond.FirstUseEver);
                ImGui.ShowDemoWindow(ref show_test_window);
            }
        }
    }
}

```
### Game Class
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
         
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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
- ImGui created by https://github.com/ocornut/
- MonoGame created by https://github.com/MonoGame/
