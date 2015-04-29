using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Interfaces
{
    public interface IStats
    {
        int Defence { get; set; }
        int HitPoints { get; set; }
        int Damage { get; set; }
    }
}
