#include "difference_of_squares.h"
#include <cmath>

namespace difference_of_squares {

// TODO: add your solution here
int square_of_sum(int num) {
  int sum = 0;
  while (num > 0) {
    sum += num;
    --num;
  }
  sum = std::pow(sum, 2);
  return sum;
}
int sum_of_squares(int num) {
  int sum = 0;
  while (num > 0) {
    sum += std::pow(num, 2);
    --num;
  }
  return sum;
}
int difference(int num) { return square_of_sum(num) - sum_of_squares(num); }
} // namespace difference_of_squares
