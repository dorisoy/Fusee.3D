﻿using Fusee.Math.Core;
using Fusee.PointCloud.Common;
using Fusee.PointCloud.OoCReaderWriter;
using Fusee.PointCloud.Reader.LASReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Fusee.PointCloud.PointAccessorCollections
{
    /// <summary>
    /// Provides methods for the Pointcloud.Converter to create the ooc files according to the user-given point type.
    /// If a Point Type is added, ad the associated case to 'CreateFilesForPtType'.
    /// </summary>
    public static class OocFileCreator
    {
        /// <summary>
        /// Converts the point cloud and saves the files (meta.json, .hierarchy and .node files).
        /// </summary>
        /// <param name="ptType">The type of the point cloud points (<see cref="PointType"/>).</param>
        /// <param name="pathToFile">Path of the original point cloud file.</param>
        /// <param name="pathToFolder">Path where the new files will be saved.</param>
        /// <param name="maxNoOfPointsInBucket">Number of points that a bucket/octant can hold. If additional point would fall into it they fall into the next level instead.</param>
        /// <param name="doExchangeXZ">Bool that determines if the y and z coordinates of the points should be exchanged.</param>
        public static void CreateFilesForPtType(PointType ptType, string pathToFile, string pathToFolder, int maxNoOfPointsInBucket, bool doExchangeXZ)
        {
            switch (ptType)
            {
                case PointType.Pos64:
                    {
                        var ptAcc = new Pos64_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                case PointType.Pos64Col32IShort:
                    {
                        var ptAcc = new Pos64Col32IShort_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                case PointType.Pos64IShort:
                    {
                        var ptAcc = new Pos64IShort_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                case PointType.Pos64Col32:
                    {
                        var ptAcc = new Pos64Col32_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                case PointType.Pos64Label8:
                    {
                        var ptAcc = new Pos64Label8_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                case PointType.Pos64Nor32Col32IShort:
                    {
                        var ptAcc = new Pos64Nor32Col32IShort_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                case PointType.Pos64Nor32IShort:
                    {
                        var ptAcc = new Pos64Nor32IShort_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                case PointType.Pos64Nor32Col32:
                    {
                        var ptAcc = new Pos64Nor32Col32_Accessor();
                        CreateFiles(ptAcc, pathToFile, pathToFolder, maxNoOfPointsInBucket, doExchangeXZ);
                        break;
                    }
                default:
                    break;
            }
        }

        private static void CreateFiles<TPoint>(PointAccessor<TPoint> ptAcc, string pathToFile, string pathToFolder, int maxNoOfPointsInBucket, bool doExchangeYZ) where TPoint : new()
        {
            var points = FromLasToList(ptAcc, pathToFile, doExchangeYZ);

            AABBd aabb;
            var watch = new Stopwatch();
            if (ptAcc.HasPositionFloat3_64)
            {
                watch.Restart();
                var firstPt = points[0];
                var pos = ptAcc.GetPositionFloat3_64(ref firstPt);
                aabb = new AABBd(pos, pos);
                foreach (var pt in points)
                {
                    var thisPt = pt;
                    aabb |= ptAcc.GetPositionFloat3_64(ref thisPt);
                }
                Console.WriteLine("Get positions from accessor took: " + watch.ElapsedMilliseconds + "ms.");
            }
            else if (ptAcc.HasPositionFloat3_32)
            {
                watch.Restart();
                var firstPt = points[0];
                var pos = ptAcc.GetPositionFloat3_32(ref firstPt);
                var posD = new double3(pos.x, pos.y, pos.z);
                aabb = new AABBd(posD, posD);
                foreach (var pt in points)
                {
                    var thisPt = pt;
                    var thisPos = ptAcc.GetPositionFloat3_32(ref thisPt);
                    var thisPosD = new double3(pos.x, pos.y, pos.z);
                    aabb |= thisPosD;
                }
                Console.WriteLine("Get positions from accessor took: " + watch.ElapsedMilliseconds + "ms.");
            }
            else
            {
                throw new ArgumentException("Invalid Position type");
            }

            watch.Restart();

            var octree = new PtOctree<TPoint>(aabb, ptAcc, points, maxNoOfPointsInBucket);
            Console.WriteLine("Octree creation took: " + watch.ElapsedMilliseconds + "ms.");

            watch.Restart();
            var occFileWriter = new PtOctreeFileWriter<TPoint>(pathToFolder);
            occFileWriter.WriteCompleteData(octree, ptAcc);
            Console.WriteLine("Writing files took: " + watch.ElapsedMilliseconds + "ms.");
        }

        /// <summary>
        /// Reads a given las file into a List.
        /// </summary>
        /// <typeparam name="TPoint">The point type.</typeparam>
        /// <param name="ptAcc">The <see cref="PointAccessor{TPoint}"/></param>
        /// <param name="pathToPc">The path to the las file.</param>
        /// <param name="doExchangeYZ">Determines if the Y and Z components of each point position is exchaned.</param>
        /// <returns></returns>
        public static List<TPoint> FromLasToList<TPoint>(PointAccessor<TPoint> ptAcc, string pathToPc, bool doExchangeYZ) where TPoint : new()
        {
            var reader = new LASPointReader(pathToPc);
            var pointCnt = (MetaInfo)reader.MetaInfo;

            var points = new TPoint[(int)pointCnt.PointCnt];
            points = points.Select(pt => new TPoint()).ToArray();

            for (var i = 0; i < points.Length; i++)
                if (!reader.ReadNextPoint(ref points[i], ptAcc)) break;

            if (ptAcc.HasPositionFloat3_32)
            {
                var firstPoint = ptAcc.GetPositionFloat3_32(ref points[0]);

                for (int i = 0; i < points.Length; i++)
                {
                    var pt = points[i];

                    var pos = ptAcc.GetPositionFloat3_32(ref pt);
                    if (doExchangeYZ)
                        PointCloudHelper.ExchangeYZ(ref pos);
                    pos -= firstPoint;
                    ptAcc.SetPositionFloat3_32(ref pt, pos);

                    points[i] = pt;
                }
            }
            else if (ptAcc.HasPositionFloat3_64)
            {
                var firstPoint = ptAcc.GetPositionFloat3_64(ref points[0]);

                for (int i = 0; i < points.Length; i++)
                {
                    var pt = points[i];

                    var pos = ptAcc.GetPositionFloat3_64(ref pt);
                    if (doExchangeYZ)
                        PointCloudHelper.ExchangeYZ(ref pos);
                    pos -= firstPoint;
                    ptAcc.SetPositionFloat3_64(ref pt, pos);

                    points[i] = pt;
                }
            }
            else
            {
                throw new ArgumentException("Invalid Position type");
            }

            reader.Dispose();
            return points.ToList();
        }        
    }
}