#include "robot_name.h"
#include <cstdlib>
#include <string>
#include <unordered_set>

namespace robot_name {

std::unordered_set<std::string> robot::unique_names{};

robot::robot() {
  _name = get_unique_name();
  unique_names.insert(_name);
}

std::string robot::name() const { return _name; }

void robot::reset() {
  unique_names.erase(_name);
  _name = get_unique_name();
  unique_names.insert(_name);
}

std::string robot::get_unique_name() const {
  std::string candidate = get_random_name();
  while (unique_names.find(candidate) != unique_names.end()) {
    candidate = get_random_name();
  }
  return candidate;
}

std::string robot::get_random_name() const {
  std::string name{};
  name += get_random_letter();
  name += get_random_letter();
  name += std::to_string(get_random_digit());
  name += std::to_string(get_random_digit());
  name += std::to_string(get_random_digit());
  return name;
}

char robot::get_random_letter() const {
  const int random_int = std::rand() % 26;
  return static_cast<char>('A' + random_int);
}

int robot::get_random_digit() const { return std::rand() % 10; }
} // namespace robot_name
