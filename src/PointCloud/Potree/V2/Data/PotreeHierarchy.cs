using System.Collections.Generic;

#pragma warning disable CS1591

namespace Fusee.PointCloud.Potree.V2.Data
{
    public class PotreeHierarchy
    {
        public PotreeNode Root;
        public List<PotreeNode> Nodes;

        public PotreeHierarchy(PotreeNode root)
        {
            Root = root;
            Nodes = new();
        }
    }
}

#pragma warning restore CS1591