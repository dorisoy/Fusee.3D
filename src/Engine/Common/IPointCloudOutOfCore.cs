﻿namespace Fusee.Engine.Common
{
    /// <summary>
    /// Implement this interface into wpf apps that use point cloud ooc rendering.
    /// </summary>
    public interface IPointCloudOutOfCore
    {
        /// <summary>
        /// Set to true if closing the app was requested from wpf.
        /// </summary>
        bool ClosingRequested { get; set; }

        /// <summary>
        /// Needed when using UI / WPF. Set to false on DeInit().
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Needed when using UI / WPF. Determines if a new file can be loaded. E.g. when 
        /// </summary>
        bool ReadyToLoadNewFile { get; }

        /// <summary>
        /// Set to true if the outlines of visible octants shall be rendered.
        /// </summary>
        bool DoShowOctants { get; set; }

        /// <summary>
        /// Allows different logic if you use WPF (or another UI).
        /// </summary>
        bool UseWPF { get; set; }

        /// <summary>
        /// Allows to check if the app has finished its Init() call.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// <see cref="RenderCanvas.CanvasImplementor"/>
        /// </summary>
        IRenderCanvasImp CanvasImplementor { get; set; }

        /// <summary>
        /// <see cref="RenderCanvas.ContextImplementor"/>
        /// </summary>
        IRenderContextImp ContextImplementor { get; set; }

        /// <summary>
        /// Method to reset the camera.
        /// </summary>
        void ResetCamera();

        /// <summary>
        /// <see cref="RenderCanvas.CloseGameWindow"/>
        /// </summary>
        void CloseGameWindow();

        /// <summary>
        /// <see cref="RenderCanvas.Run"/>
        /// </summary>
        void Run();

        /// <summary>
        /// Initializes the application and prepares it for the rendering loop.
        /// </summary>
        void InitApp();
    }
}