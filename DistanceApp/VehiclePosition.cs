using System.Text;

namespace DistanceApp
{
    public class VehiclePosition
    {
        public int ID;
        public string Registration;
        public float Latitude;
        public float Longitude;
        public DateTime RecordedTimeUTC;

        internal static VehiclePosition FromBytes(byte[] buffer, ref int offset)
        {
            VehiclePosition vehiclePosition = new VehiclePosition();
            vehiclePosition.ID = BitConverter.ToInt32(buffer, offset);
            offset += 4;
            StringBuilder stringBuilder = new StringBuilder();
            while (buffer[offset] != (byte)0)
            {
                stringBuilder.Append((char)buffer[offset]);
                ++offset;
            }
            vehiclePosition.Registration = stringBuilder.ToString();
            ++offset;
            vehiclePosition.Latitude = BitConverter.ToSingle(buffer, offset);
            offset += 4;
            vehiclePosition.Longitude = BitConverter.ToSingle(buffer, offset);
            offset += 4;
            ulong uint64 = BitConverter.ToUInt64(buffer, offset);
            vehiclePosition.RecordedTimeUTC = FromCTime(uint64);
            offset += 8;
            return vehiclePosition;
        }

        internal static DateTime Epoch => new DateTime(1970, 1, 1, 0, 0, 0, 0);

        internal static ulong ToCTime(DateTime time) => Convert.ToUInt64((time - Epoch).TotalSeconds);

        internal static DateTime FromCTime(ulong cTime) => Epoch.AddSeconds((double)cTime);
    }
}
