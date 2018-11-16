namespace chapter5_2
{
    class ray
    {
        public ray() { }
        public ray(vec3 ori, vec3 dir) { origin = ori; direction = dir; }
        public ray(ray r) { origin = r.Origin; direction = r.Direction; }
        public vec3 point_at_parameter(float t) { return origin + direction * t; }

        public vec3 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public vec3 Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        private vec3 origin;
        private vec3 direction;
    }
}
