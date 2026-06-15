# [Cheapest Flights Within K Stops](https://leetcode.com/problems/cheapest-flights-within-k-stops/description/)

from typing import List


class Solution_Bellman_Ford:
    def findCheapestPrice(
        self, n: int, flights: List[List[int]], src: int, dst: int, k: int
    ) -> int:
        next = [2**31] * n

        next[src] = 0
        for _ in range(k + 1):
            # snapshot of previous values is needed
            # as there Edge-count constraint of k stops
            # this ensures vertices distance value is 
            # updated only once per pass, and we DO NOT take the 
            # next pass, that will exceed at most k stops
            prev = next[:]
            for flight in flights:
                _from = flight[0]
                _to = flight[1]
                _cost = flight[2]

                next[_to] = min(next[_to], prev[_from] + _cost)

        return next[dst] if next[dst] != 2**31 else -1


def Main():
    n = 4
    flights = [[0, 1, 100], [1, 2, 100], [2, 0, 100], [1, 3, 600], [2, 3, 200]]
    src = 0
    dst = 3
    k = 1

    s = Solution_Bellman_Ford()
    out = s.findCheapestPrice(n, flights, src, dst, k)

    print(out)


if __name__ == "__main__":
    Main()
