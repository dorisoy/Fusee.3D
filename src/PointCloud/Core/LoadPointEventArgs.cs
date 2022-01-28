using Fusee.Base.Core;
using Fusee.PointCloud.Common;
using System;

namespace Fusee.PointCloud.Core
{
    /// <summary>
    /// Used in a <see cref="PointCloudLoader"/> for caching loaded points using the <see cref="MemoryCache{TItem}.AddItemAsync"/> event.
    /// </summary>
    public class LoadPointEventArgs : EventArgs
    {
        /// <summary>
        /// The path to the potree file
        /// </summary>
        public string PathToFile;

        public IPointAccessor PtAccessor;

        public string Guid;

        /// <summary>
        /// Creates a new instance of type <see cref="LoadPointEventArgs"/>.
        /// </summary>
        /// <param name="octant">The octant we want to read the points for.</param>
        /// <param name="pathToFile">The path to the potree file.</param>
        /// <param name="ptAccessor">The <see cref="PointAccessor{TPoint}"/>.</param>
        public LoadPointEventArgs(string guid, string pathToFile, IPointAccessor ptAccessor)
        {
            Guid = guid;
            PathToFile = pathToFile;
            PtAccessor = ptAccessor;
        }
    }
}