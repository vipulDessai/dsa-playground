# [Cheapest Flights Within K Stops](https://leetcode.com/problems/cheapest-flights-within-k-stops/description/)

from typing import List


class Solution_Bellman_Ford:
    def findCheapestPrice(
        self, n: int, flights: List[List[int]], src: int, dst: int, k: int
    ) -> int:
        distance = [2**31] * n
        res = 2**31

        distance[src] = 0
        for _ in range(k + 1):
            cur = [2**31] * n

            for flight in flights:
                _from = flight[0]
                _to = flight[1]
                _cost = flight[2]

                if distance[_from] == 2**31:
                    continue

                cur[_to] = min(cur[_to], distance[_from] + _cost)

            distance = cur
            res = min(res, distance[dst])

        return -1 if res == 2**31 else res


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
