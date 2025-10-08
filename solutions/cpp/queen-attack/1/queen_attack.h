#pragma once

#include <utility>
namespace queen_attack {
class chess_board {
public:
  chess_board(std::pair<int, int> white, std::pair<int, int> black);
  bool can_attack() const;
  std::pair<int, int> white() const;
  std::pair<int, int> black() const;

private:
  std::pair<int, int> white_location;
  std::pair<int, int> black_location;
  bool can_horizontal_attack() const;
  bool can_vertical_attack() const;
  bool can_diagonal_attack() const;
  void assert_location_within_range(std::pair<int, int> location);
  void assert_locations_are_unique(std::pair<int, int> white,
                                   std::pair<int, int> black);
};
} // namespace queen_attack
