using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    internal static class BezierSurfaceReader
    {
        private static int PointsPerSurface = Constants.MaxControlSurfacePoints;

        public static List<List<Point<double>>> Read(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("A file path is required.", nameof(path));

            var surfaces = new List<List<Point<double>>>();
            var current = new List<Point<double>>(PointsPerSurface);

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    throw new FormatException(
                        $"Line {i + 1}: expected 'x y z', found '{line}'.");
                }

                if (!double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x) ||
                    !double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y) ||
                    !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double z))
                {
                    throw new FormatException(
                        $"Line {i + 1}: invalid real number in '{line}'.");
                }

                current.Add(new Point<double>(x, y, z));

                if (current.Count == PointsPerSurface)
                {
                    surfaces.Add(current);
                    current = new List<Point<double>>(PointsPerSurface);
                }
            }

            if (current.Count > 0)
            {
                throw new FormatException(
                    $"File ended with {current.Count} extra point(s); " +
                    $"each surface must contain exactly {PointsPerSurface} points.");
            }

            if (surfaces.Count < 2)
            {
                throw new FormatException(
                    $"File must contain at least 2 surfaces; found {surfaces.Count}.");
            }

            return surfaces;
        }
    }
}
