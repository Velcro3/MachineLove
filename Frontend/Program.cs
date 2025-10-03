// Machine Love AMV
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Diagnostics;
using System.Drawing;
namespace OpenGLFrontend;

public class Program
{
    private static IWindow window;
    private static GL glcontext1;
    static readonly Stopwatch stopwatch = Stopwatch.StartNew();
    static bool StartedRender = false;
    static bool StartedUpdate = false;
    private static uint vao;
    private static uint vbo;
    static void LogGen(string message, string level = "INFO")
    {
        Console.WriteLine($"[{stopwatch.Elapsed.TotalSeconds:F7}] {level}: {message}");
    }
    public static void Main(string[] args) {
        Console.WriteLine("MACHINE LOVE\nSONG BY JAMIE PAIGE\nFEATURING KASANE TETO\nkasaneteto.jp\nOpenGL AMV by Viewer\nvelcro3.github.io");
        WindowOptions options = WindowOptions.Default with
        {
            Size = new Vector2D<int>(800, 600),
            Title = "Teto Territory"
        };
        Console.WriteLine("Press any key to start the AMV...");
        Console.ReadKey();
        Console.WriteLine("");
        stopwatch.Restart();
        LogGen("Starting target OpenGL Window...", "TASK START");
        window = Window.Create(options);
        window.Load += Startup;
        window.Update += Update;
        window.Render += Render;
        window.Run();
        LogGen("Window closed.", "FATAL");
        LogGen("Exiting...", "STATUS");
        Environment.Exit(0);
    }
    public static unsafe void Startup()
    {
        glcontext1 = window.CreateOpenGL();
        LogGen("Started target OpenGL Window.", "TASK SUCCESS");
        glcontext1.ClearColor(Color.FromArgb(0, 250, 255, 235));
        vao = glcontext1.GenVertexArray();
        vbo = glcontext1.GenBuffer();
        glcontext1.BindVertexArray(vao);
        glcontext1.BindBuffer(BufferTargetARB.ArrayBuffer, vbo);
        float[] vertices =
        {
           0.5f,  0.5f, 0.0f,
           0.5f, -0.5f, 0.0f,
           -0.5f, -0.5f, 0.0f,
           -0.5f,  0.5f, 0.0f
        };
        fixed (float* buf = vertices)
            glcontext1.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertices.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);
        LogGen("Starting target Update Cycle...", "TASK START");
    }
    public static void Update(double deltatime)
    {
        if (!StartedUpdate) {
            StartedUpdate = true;
            LogGen("Started target Update Cycle!", "TASK SUCCESS");
            LogGen("Starting target Render Cycle...", "TASK START");
        }
        LogGen("Updated logic.");
    }
    public static void Render(double deltatime)
    {
        if (!StartedRender)
        {
            StartedRender = true;
            LogGen("Started target Render Cycle!", "TASK START");
        }
        glcontext1.Clear(ClearBufferMask.ColorBufferBit);
        LogGen("Updated image.");
    }
}