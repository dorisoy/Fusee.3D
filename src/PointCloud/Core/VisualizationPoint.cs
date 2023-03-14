﻿using Fusee.Math.Core;

namespace Fusee.PointCloud.Potree.V2.Data
{
    /// <summary>
    /// This point is used for visualization purposes.
    /// It is read from a file and converted to mesh data.
    /// </summary>
    public struct VisualizationPoint
    {
        /// <summary>
        /// The position of a point.
        /// </summary>
        public float3 Position;

        /// <summary>
        /// The color (r,g,b,a) of a point.
        /// </summary>
        public float4 Color;

        /// <summary>
        /// Flags have to be interpreted manually or they will be ignored.
        /// </summary>
        public uint Flags;
    }

    /// <summary>
    /// This point is used for data handling purposes.
    /// It's read from a file and converted to either LAS or changed and updated in the original file.
    /// </summary>
    public struct PotreePoint
    {
        /// <summary>
        /// The position of a point.
        /// </summary>
        public float3 Position;

        /// <summary>
        /// The color (r,g,b,a) of a point.
        /// </summary>
        public float4 Color;


    }
}