#pragma once

#include <string>
#include <unordered_set>
#include <vector>
namespace robot_name {
class robot {
public:
  robot();
  std::string name() const;
  void reset();

private:
  static std::unordered_set<std::string> unique_names;
  std::string _name;
  std::string get_unique_name() const;
  std::string get_random_name() const;
  char get_random_letter() const;
  int get_random_digit() const;
};

} // namespace robot_name
