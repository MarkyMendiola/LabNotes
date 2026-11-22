using System.Collections.Generic;

namespace LabPCTracker.Backend
{
    public static class Logic
    {
        // Set difference, A - B: every lab in A that is NOT in B.
        // Free labs = all labs - booked labs.
        public static List<Lab> Difference(List<Lab> allSet, List<Lab> bookedSet)
        {
            var result = new List<Lab>();

            foreach (var lab in allSet)
            {
                bool isInB = false;

                foreach (var other in bookedSet)
                {
                    if (other.id == lab.id)
                        isInB = true;
                }

                if (!isInB)
                    result.Add(lab);
            }

            return result;
        }
    }
}
