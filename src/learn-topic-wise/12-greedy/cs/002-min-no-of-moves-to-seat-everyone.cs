// https://leetcode.com/problems/minimum-number-of-moves-to-seat-everyone
namespace learning_dsa_csharp._15_greedy._002_min_no_of_moves_to_seat_everyone
{
    internal class MySoln
    {
        public int MinMovesToSeat(int[] seats, int[] students)
        {
            int n = seats.Length;

            Array.Sort(seats);
            Array.Sort(students);

            int res = 0;
            for (int i = 0; i < n; ++i)
            {
                res += Math.Abs(seats[i] - students[i]);
            }

            return res;
        }
    }
}
