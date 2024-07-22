using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface IMedible
    {
        double? Size();
    }
    public static class Medible
    {
        public static IMedible HighestSize(IMedible a, IMedible b)
        {
            return a.Size() > b.Size()?a:b;
        }
    }
}
