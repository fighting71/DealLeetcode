using System;
using System.Collections.Generic;
using System.Text;

namespace Command.CommonStruct
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/20/2021 5:28:56 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class ChildrenNode
    {

        public int val;
        public IList<ChildrenNode> children;

        public ChildrenNode() { }

        public ChildrenNode(int _val)
        {
            val = _val;
        }

        public ChildrenNode(int _val, IList<ChildrenNode> _children)
        {
            val = _val;
            children = _children;
        }


    }
}
