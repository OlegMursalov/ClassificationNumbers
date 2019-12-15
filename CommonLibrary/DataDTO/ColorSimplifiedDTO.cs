using System.Runtime.Serialization;

namespace CommonLibrary.DataDTO
{
    [DataContract]
    public class ColorSimplifiedDTO
    {
        [DataMember]
        public int R { get; set; }

        [DataMember]
        public int G { get; set; }

        [DataMember]
        public int B { get; set; }

        [DataMember]
        public int A { get; set; }
    }
}