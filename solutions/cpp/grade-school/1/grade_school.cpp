#include "grade_school.h"
#include <algorithm>
#include <vector>

namespace grade_school {
school::school() : _roster() {}

const std::map<int, std::vector<std::string>> school::roster() const {
  return _roster;
}

void school::add(std::string name, int grade) {
  if (_roster.count(grade) > 0) {
    _roster[grade].push_back(name);
    std::sort(_roster.at(grade).begin(), _roster.at(grade).end());
  } else {
    _roster.insert({grade, std::vector<std::string>{name}});
  }
}
std::vector<std::string> school::grade(int grade) const {
  if (_roster.count(grade) > 0) {
    return _roster.at(grade);
  }
  return std::vector<std::string>{};
}

} // namespace grade_school
