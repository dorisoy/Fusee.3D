﻿using System;
using System.Collections.Generic;

namespace Fusee.Engine.Core.Effects
{
    /// <summary>
    /// Class that contains information on how to build a compute shader program.
    /// </summary>
    public class ComputeEffect : Effect, IDisposable
    {
        /// <summary>
        /// The Compute Shader code.
        /// </summary>
        public string ComputeShaderSrc { get; protected set; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="shaderCode">The compute shader code.</param>
        /// <param name="effectParameters">The uniform parameters as collections of <see cref="IFxParamDeclaration"/>.</param>
        public ComputeEffect(string shaderCode, IEnumerable<IFxParamDeclaration> effectParameters)
        {
            UniformParameters = new Dictionary<int, IFxParamDeclaration>();
            ComputeShaderSrc = shaderCode;

            if (effectParameters != null)
            {
                foreach (var param in effectParameters)
                    UniformParameters.Add(param.Hash, param);
            }

            RendererStates = RenderStateSet.Default;
            EffectManagerEventArgs = new EffectManagerEventArgs(UniformChangedEnum.Unchanged);
        }

        /// <summary>
        /// Destructor calls <see cref="Dispose"/> in order to fire MeshChanged event.
        /// </summary>
        ~ComputeEffect()
        {
            Dispose();
        }

        /// <summary>
        /// Is called when GC of this shader effect kicks in
        /// </summary>
        public void Dispose()
        {
            EffectChanged?.Invoke(this, new EffectManagerEventArgs(UniformChangedEnum.Dispose));
        }
    }
}