﻿using Fusee.Math.Core;
using Fusee.PointCloud.Common;

namespace Fusee.PointCloud.Core
{
    /// <summary>
    /// <see cref="PointAccessor{TPoint}"/> for Point Clouds which position, color and classification values.
    /// </summary>
    public class PosD3ColF3InUsLblBAccessor : PointAccessor<PosD3ColF3InUsLblB>
    {
        public PosD3ColF3InUsLblBAccessor()
        {
            PositionType = PointPositionType.Double3;
            ColorType = PointColorType.Float;
            LabelType = PointLabelType.UInt_8;
            IntensityType = PointIntensityType.UInt_16;
        }

        /// <summary>
        /// Sets the color of a point cloud point if <see cref="HasColorFloat3_32"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        /// <param name="val">The new color.</param>
        public override void SetColorFloat3_32(ref PosD3ColF3InUsLblB point, float3 val)
        {
            point.Color = val;
        }
        /// <summary>
        /// Returns the normal color of a point cloud point if <see cref="HasColorFloat3_32"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        public override ref float3 GetColorFloat3_32(ref PosD3ColF3InUsLblB point)
        {
            return ref point.Color;
        }

        /// <summary>
        /// Sets the position of a point cloud point if <see cref="HasPositionFloat3_64"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        /// <param name="val">The new position value.</param>
        public override void SetPositionFloat3_64(ref PosD3ColF3InUsLblB point, double3 val)
        {
            point.Position = val;
        }
        /// <summary>
        /// Returns the position of a point cloud point if <see cref="HasPositionFloat3_64"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        public override ref double3 GetPositionFloat3_64(ref PosD3ColF3InUsLblB point)
        {
            return ref point.Position;
        }
        /// <summary>
        /// Sets the label of a point cloud point if <see cref="HasLabelUInt_8"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        /// <param name="val">The new label.</param>
        public override void SetLabelUInt_8(ref PosD3ColF3InUsLblB point, byte val)
        {
            point.Label = val;
        }
        /// <summary>
        /// Returns the label of a point cloud point if <see cref="HasLabelUInt_8"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        public override ref byte GetLabelUInt_8(ref PosD3ColF3InUsLblB point)
        {
            return ref point.Label;
        }

        /// <summary>
        /// Returns the intensity of a point cloud point if <see cref="PointIntensityType.UInt_8"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        public override ref ushort GetIntensityUInt_16(ref PosD3ColF3InUsLblB point)
        {
            return ref point.Intensity;
        }
        /// <summary>
        /// Sets the intensity of a point cloud point if <see cref="PointIntensityType.UInt_8"/> is true.
        /// </summary>
        /// <param name="point">The point cloud point.</param>
        /// <param name="val">The new intensity value.</param>
        public override void SetIntensityUInt_16(ref PosD3ColF3InUsLblB point, ushort val)
        {
            point.Intensity = val;
        }
    }
}