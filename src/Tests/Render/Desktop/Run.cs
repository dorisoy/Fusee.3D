using NUnitLite;

namespace Fusee.Tests.Render.Desktop
{
    internal static class Run
    {
        public static int Main(string[] args)
        {
            Program.Example = new Examples.AdvancedUI.Core.AdvancedUI() { rnd = new System.Random(12345) };
            Program.Init("AdvancedUI.png");

            Program.Example = new Examples.Camera.Core.CameraExample() { };
            Program.Init("Camera.png");

            Program.Example = new Examples.ComputeFractal.Core.ComputeFractal() { };
            Program.Init("Fractal.png");

            Program.Example = new Examples.Deferred.Core.Deferred() { };
            Program.Init("Deferred.png");

            Program.Example = new Examples.GeometryEditing.Core.GeometryEditing();
            Program.Init("GeometryEditing.png");

            Program.Example = new Examples.Labyrinth.Core.Labyrinth() { };
            Program.Init("Labyrinth.png");

            Program.Example = new Examples.Materials.Core.Materials { };
            Program.Init("Materials.png");

            Program.Example = new Examples.MeshingAround.Core.MeshingAround();
            Program.Init("MeshingAround.png");

            Program.Example = new Examples.Picking.Core.Picking();
            Program.Init("Picking.png");

            Program.Example = new Examples.PointCloudPotree2.Core.PointCloudPotree2();
            Program.Init("PointCloudPotree2.png");

            Program.Example = new Examples.RenderContextOnly.Core.RenderContextOnly();
            Program.Init("RenderContextOnly.png");

            Program.Example = new Examples.RenderLayerEx.Core.RenderLayerExample();
            Program.Init("RenderLayer.png");

            Program.Example = new Examples.Simple.Core.Simple();
            Program.Init("Simple.png");

            Program.Example = new Examples.UI.Core.UI();
            Program.Init("UI.png");

            return new AutoRun().Execute(args);
        }
    }
}