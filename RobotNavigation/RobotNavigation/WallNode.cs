﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class WallNode : Node
    {
        public WallNode(Position pos) : base(pos)
        {

        }

        public override int NodeCost()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "X";
        }
    }
}
