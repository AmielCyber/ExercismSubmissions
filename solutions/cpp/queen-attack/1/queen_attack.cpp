#include "queen_attack.h"
#include <cstdlib>
#include <stdexcept>
class chess_board {
public:
  chess_board(std::pair<int, int> white, std::pair<int, int> black);
  bool can_attack() const;
  std::pair<int, int> white() const;
  std::pair<int, int> black() const;

private:
  std::pair<int, int> white_location;
  std::pair<int, int> black_location;
};

namespace queen_attack {
chess_board::chess_board(std::pair<int, int> white, std::pair<int, int> black)
    : white_location(white), black_location(black) {
  assert_location_within_range(white);
  assert_location_within_range(black);
  assert_locations_are_unique(white, black);
}

bool chess_board::can_attack() const {
  return can_horizontal_attack() || can_vertical_attack() ||
         can_diagonal_attack();
}

std::pair<int, int> chess_board::white() const { return white_location; }

std::pair<int, int> chess_board::black() const { return black_location; }

bool chess_board::can_horizontal_attack() const {
  return white_location.first == black_location.first;
}
bool chess_board::can_vertical_attack() const {
  return white_location.second == black_location.second;
}
bool chess_board::can_diagonal_attack() const {
  return abs(white_location.first - black_location.first) ==
         abs(white_location.second - black_location.second);
}

void chess_board::assert_location_within_range(std::pair<int, int> location) {
  if (location.first < 0 || location.first > 7 || location.second < 0 ||
      location.second > 7) {
    throw std::domain_error("Values are out of range.");
  }
}
void chess_board::assert_locations_are_unique(std::pair<int, int> white,
                                              std::pair<int, int> black) {
  if (white.first == black.first && white.second == black.second) {
    throw std::domain_error("White and Black values must be unique.");
  }
}
} // namespace queen_attack
