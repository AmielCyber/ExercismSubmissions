#include "kindergarten_garden.h"
#include <cstddef>
#include <stdexcept>
#include <string_view>
#include <unordered_map>
#include <vector>

namespace kindergarten_garden {

// TODO: add your solution here

size_t get_student_begining_column(std::string_view name) {
  static const std::unordered_map<std::string_view, size_t> begining_column = {
      {"Alice", 0},   {"Bob", 2},     {"Charlie", 4},  {"David", 6},
      {"Eve", 8},     {"Fred", 10},   {"Ginny", 12},   {"Harriet", 14},
      {"Ileana", 16}, {"Joseph", 18}, {"Kincaid", 20}, {"Larry", 22},
  };
  return begining_column.at(name);
}
std::vector<std::string_view> split(std::string_view str,
                                    const char delimiter) {
  std::vector<std::string_view> result;
  size_t start = 0;
  size_t end = str.find(delimiter);
  while (end != std::string_view::npos) {
    result.emplace_back(str.substr(start, end - start));
    start = end + 1;
    end = str.find(delimiter, start);
  }
  if (start < str.length()) {
    result.emplace_back(str.substr(start));
  }

  return result;
}
Plants get_plant_type(const char letter) {
  switch (letter) {
  case 'G':
    return Plants::grass;
  case 'C':
    return Plants::clover;
  case 'R':
    return Plants::radishes;
  case 'V':
    return Plants::violets;
  default:
    throw std::invalid_argument("Only characters: G, C, R, V are accepted");
  }
}
std::array<Plants, 4> plants(const std::string &cups, const std::string &name) {
  std::array<Plants, 4> result{};

  std::vector<std::string_view> cups_vec = split(cups, '\n');
  size_t begining_column = get_student_begining_column(name);

  result[0] = get_plant_type(cups_vec.at(0).at(begining_column));
  result[1] = get_plant_type(cups_vec.at(0).at(begining_column + 1));
  result[2] = get_plant_type(cups_vec.at(1).at(begining_column));
  result[3] = get_plant_type(cups_vec.at(1).at(begining_column + 1));

  return result;
}
} // namespace kindergarten_garden
