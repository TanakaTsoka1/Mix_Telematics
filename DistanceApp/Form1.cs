using System.Device.Location;
using System.Diagnostics;
using System.Drawing;

namespace DistanceApp
{
    public partial class frmDistanceCalc : Form
    {
        private List<VehiclePosition> vehicleData = new List<VehiclePosition>();

        public frmDistanceCalc()
        {
            InitializeComponent();
        }

        private static VehiclePosition ReadVehiclePosition(byte[] data, ref int offset) => VehiclePosition.FromBytes(data, ref offset);

        private void btnFileLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                byte[] data = File.ReadAllBytes(openFileDialog.FileName);
                
                int offset = 0;
                while (offset < data.Length)
                    vehicleData.Add(ReadVehiclePosition(data, ref offset));
                stopwatch.Stop();

                rtbOutput.Text += "File Loaded\r\n";
                rtbOutput.Text += string.Format("Load File Execution time: {0} ms\r\n\r\n", stopwatch.ElapsedMilliseconds);

                btnClassicExec.Enabled = true;
                btnPerfExec.Enabled = true;
            }
        }

        // This is your solution.
        private void btnClassicExec_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<GeoCoordinate> coords = new List<GeoCoordinate>() {
                new GeoCoordinate(34.544909, -102.100843),
                new GeoCoordinate(32.3455429, -99.12312),
                new GeoCoordinate(33.2342339, -100.214127),
                new GeoCoordinate(35.19574, -95.3489),
                new GeoCoordinate(31.89584, -97.78957),
                new GeoCoordinate(32.89584, -101.789574),
                new GeoCoordinate(34.1158371, -100.225731),
                new GeoCoordinate(32.33584, -99.99223),
                new GeoCoordinate(33.53534, -94.79223),
                new GeoCoordinate(32.2342339, -100.222221),
            };

            for (int i = 0; i < coords.Count; i++)
            {
                stopwatch.Restart();
                VehiclePosition nearest = null;
                double nearestDistance = double.MaxValue;
                foreach (VehiclePosition vehiclePosition in vehicleData)
                {
                    double num = DistanceBetween((float)coords[i].Latitude, (float)coords[i].Longitude, vehiclePosition.Latitude, vehiclePosition.Longitude);
                    if (num < nearestDistance)
                    {
                        nearest = vehiclePosition;
                        nearestDistance = num;
                    }
                }
                stopwatch.Stop();

                rtbOutput.Text += String.Format("Found Closest Match: {0}, {1} \r\n",
                    nearest.Latitude, nearest.Longitude);
                rtbOutput.Text += string.Format("Match Execution Time: {0} to  ms\r\n", stopwatch.ElapsedMilliseconds);
            }

            rtbOutput.Text += "\r\n";
        }

        // This is mine.
        // Take note that i could implement a solution using https://github.com/ericreg/Supercluster.KDTree it would be much faster.
        // Although that kind of implementation would take time that is beyond the purpose of this assessment.
        private void btnPerfExec_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<GeoCoordinate> coords = new List<GeoCoordinate>() {
                new GeoCoordinate(34.544909, -102.100843),
                new GeoCoordinate(32.3455429, -99.12312),
                new GeoCoordinate(33.2342339, -100.214127),
                new GeoCoordinate(35.19574, -95.3489),
                new GeoCoordinate(31.89584, -97.78957),
                new GeoCoordinate(32.89584, -101.789574),
                new GeoCoordinate(34.1158371, -100.225731),
                new GeoCoordinate(32.33584, -99.99223),
                new GeoCoordinate(33.53534, -94.79223),
                new GeoCoordinate(32.2342339, -100.222221),
            };

            for (int i = 0; i < coords.Count; i++)
            {
                stopwatch.Restart();
                var nearest = vehicleData.OrderBy(x =>
                    (coords[i].Longitude - x.Longitude) * (coords[i].Longitude - x.Longitude) + (coords[i].Latitude - x.Latitude) * (coords[i].Latitude - x.Latitude))
                    .First();
                stopwatch.Stop();

                rtbOutput.Text += String.Format("Found Closest Match: {0}, {1} to {2}, {3} \r\n",
                    nearest.Latitude, nearest.Longitude, coords[i].Latitude, coords[i].Longitude);
                rtbOutput.Text += string.Format("Match Execution Time: {0} to  ms\r\n", stopwatch.ElapsedMilliseconds);
            }

            rtbOutput.Text += "\r\n";
        }

        private double DistanceBetween(float latitude1, float longitude1, float latitude2, float longitude2)
        {
            return new GeoCoordinate((double)latitude1, (double)longitude1).GetDistanceTo(new GeoCoordinate((double)latitude2, (double)longitude2));
        }
    }
}