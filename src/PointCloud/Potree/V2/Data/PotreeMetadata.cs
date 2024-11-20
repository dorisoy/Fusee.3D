using CommunityToolkit.Diagnostics;
using Fusee.Math.Core;
using Fusee.PointCloud.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#pragma warning disable CS1591

namespace Fusee.PointCloud.Potree.V2.Data
{
    public class PotreeSettingsHierarchy : IPointWriterHierarchy
    {
        public int FirstChunkSize { get; set; }
        public int StepSize { get; set; }
        public int Depth { get; set; }
    }

    public class PotreeSettingsBoundingBox
    {
        [JsonProperty(PropertyName = "min")]
        public List<double> MinList { get; set; }
        [JsonIgnore]
        public double3 Min => new(MinList[0], MinList[1], MinList[2]);

        [JsonProperty(PropertyName = "max")]
        public List<double> MaxList { get; set; }
        [JsonIgnore]
        public double3 Max => new(MaxList[0], MaxList[1], MaxList[2]);
    }

    public class PotreeSettingsAttribute
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Size { get; set; }
        public int NumElements { get; set; }
        public int ElementSize { get; set; }
        public string? Type { get; set; }

        [JsonProperty(PropertyName = "min")]
        public List<double> MinList { get; set; } = new List<double>();

        [JsonProperty(PropertyName = "max")]
        public List<double> MaxList { get; set; } = new List<double>();

        [JsonIgnore]
        public int AttributeOffset { get; set; }

        [JsonIgnore]
        public bool IsExtraByte { get; set; } = false;

        public PotreeSettingsAttribute(string name)
        {
            Name = name;
        }
    }


    public class PotreeMetadata : IPointWriterMetadata
    {
        public string Version { get; set; } = "2";
        public string? Name { get; set; }
        public string? Description { get; set; }
        [JsonProperty(PropertyName = "points")]
        public int PointCount { get; set; }
        public int OffsetToExtraBytes { get; set; } = -1;
        public string? Projection { get; set; }

        public IPointWriterHierarchy Hierarchy { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public List<double>? OffsetList { get; set; }
        [JsonIgnore]
        public double3 Offset { get { Guard.IsNotNull(OffsetList); return new double3(OffsetList[0], OffsetList[1], OffsetList[2]); } }

        [JsonProperty(PropertyName = "scale")]
        public List<double>? ScaleList { get; set; }
        [JsonIgnore]
        public double3 Scale { get { Guard.IsNotNull(ScaleList); return new double3(ScaleList[0], ScaleList[1], ScaleList[2]); } }

        public double Spacing { get; set; }
        public PotreeSettingsBoundingBox BoundingBox { get; set; }

        public AABBd AABB { get { Guard.IsNotNull(BoundingBox); return new AABBd(BoundingBox.Min, BoundingBox.Max); } }

        public string? Encoding { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        internal List<PotreeSettingsAttribute> AttributesList { get; set; }

        public Dictionary<string, PotreeSettingsAttribute> Attributes { get; set; }

        [JsonIgnore]
        public int PointSize { get; set; }

        [JsonIgnore]
        public string? FolderPath { get; set; }

        [JsonIgnore]
        public float4x4 PrincipalAxisRotation { get; set; }

        public PotreeMetadata(IPointWriterHierarchy hierarchy, List<PotreeSettingsAttribute>  attributesList)
        {
            Hierarchy = hierarchy;
            AttributesList = attributesList;
            Attributes = AttributesList.ToDictionary(x => x.Name, x => x);
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (AttributesList != null)
            {
                Attributes = AttributesList.ToDictionary(x => x.Name, x => x);
            }
        }

    }
}

#pragma warning restore CS1591