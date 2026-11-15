#pragma once

#include <array>
#include <string_view>
#include <tuple>
#include <vector>
namespace kindergarten_garden {
enum class Plants {
  grass,
  clover,
  radishes,
  violets,
};

size_t get_student_begining_column(std::string_view name);
std::vector<std::string_view> split(std::string_view str, char delimiter);
Plants get_plant_type(const char letter);
std::array<Plants, 4> plants(const std::string &cups, const std::string &name);

} // namespace kindergarten_garden
