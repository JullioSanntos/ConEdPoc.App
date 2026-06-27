using System;
using System.Collections.Generic;
using System.Text;

namespace ConEd5.Models {
    public record UsageDataPoint(string Month, double Cost, double BarHeight, bool IsEstimated = false);
}
