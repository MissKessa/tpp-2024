using System;

namespace PTP_HW_5
{
    public class Angle
    {
        public double Radians { get; private set; }

        public float Degrees
        {
            get { return (float)(this.Radians / Math.PI * 180); }
        }
        
        public Angle(double radians)
        {
            this.Radians = radians;
        }
        
        public Angle(float degrees)
        {
            this.Radians = degrees / 180.0 * Math.PI;
        }
        
        public double Sine()
        {
            return Math.Sin(this.Radians);
        }
        
        public double Cosine()
        {
            return Math.Cos(this.Radians);
        }
        
        public double Tangent()
        {
            return Sine() / Cosine();
        }
    }
}
