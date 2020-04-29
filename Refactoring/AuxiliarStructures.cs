namespace Refactor.ValidateHierarchy
{
    public enum LineType
    {
        Header, Row
    }

    public class LineConfig
    {
        public LineType LineType { get; set; }
        public bool RepeatRegistry { get; set; }
        public int Order { get; set; }
        public bool Required { get; set; }
    }

    public class Line
    {
        public LineType LineType { get; set; }
        public bool RepeatRegistry { get; set; }
        public int Order { get; set; }
        public bool Required { get; set; }

    }
}