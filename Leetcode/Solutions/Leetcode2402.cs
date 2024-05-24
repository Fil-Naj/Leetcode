using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2402 : ISolution
    {
        public string Name => "Meeting Rooms III";
        public string Description => "You are given an integer n. There are n rooms numbered from 0 to n - 1.\r\n\r\nYou are given a 2D integer array meetings where meetings[i] = [starti, endi] means that a meeting will be held during the half-closed time interval [starti, endi). All the values of starti are unique.\r\n\r\nMeetings are allocated to rooms in the following manner:\r\n\r\n    Each meeting will take place in the unused room with the lowest number.\r\n    If there are no available rooms, the meeting will be delayed until a room becomes free. The delayed meeting should have the same duration as the original meeting.\r\n    When a room becomes unused, meetings that have an earlier original start time should be given the room.\r\n\r\nReturn the number of the room that held the most meetings. If there are multiple rooms, return the room with the lowest number.\r\n\r\nA half-closed interval [a, b) is the interval between a and b including a and not including b.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 2;
            int[][] meetings = [[0, 10], [1, 5], [2, 7], [3, 4]];
            var result = MostBooked(n, meetings);

            // Prettify
            Console.WriteLine($"Input: n = {n}, meetings = {meetings.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MostBooked(int n, int[][] meetings)
        {
            var roomBookings = new int[n];

            PriorityQueue<TimeSlot, TimeSlot> pq = new();

            // Set all rooms to be available at t = 0
            for (var i = 0; i < n; i++)
            {
                var timeSlot = new TimeSlot(i, 0);
                pq.Enqueue(timeSlot, timeSlot);
            }

            Array.Sort(meetings, (a, b) =>  a[0] - b[0]);

            foreach (var meeting in meetings)
            {
                var start = meeting[0]; 
                var end = meeting[1];

                // If some available times are earlier than what we need, ensure all rooms catchup to latest meeting
                // Not best way to do this, but since I chose to do this with a PQ, "this is the way"
                // Should have considered small constraint of rooms of 0 <= n <= 100
                // Using array faster than pq
                while (start > pq.Peek().Time)
                {
                    var roomToReadjust = pq.Dequeue().Room;
                    var newTimeSlot = new TimeSlot(roomToReadjust, start);
                    pq.Enqueue(newTimeSlot, newTimeSlot);
                }

                var nextAvailableRoom = pq.Dequeue();
                roomBookings[nextAvailableRoom.Room]++;

                var nextStartTime = nextAvailableRoom.Time + (end - start);
                var timeSlot = new TimeSlot(nextAvailableRoom.Room, nextStartTime);
                pq.Enqueue(timeSlot, timeSlot);
            }

            var maxBookings = 0;
            var maxRoomIndex = -1;

            for (var i = 0; i < n; i++)
            {
                if (roomBookings[i] > maxBookings)
                {
                    maxBookings = roomBookings[i];
                    maxRoomIndex = i;
                }
            }

            return maxRoomIndex;
        }

        public readonly record struct TimeSlot(int Room, long Time) : IComparable<TimeSlot>
        {
            public int CompareTo(TimeSlot other)
            {
                if (Time < other.Time) return -1;
                else if (Time > other.Time) return 1;
                else return Room > other.Room ? 1 : -1;
            }
        }
    }
}
