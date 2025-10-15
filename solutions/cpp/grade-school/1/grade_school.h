#pragma once
#include <map>
#include <string>
#include <vector>

namespace grade_school {
// TODO: add your solution here
class school {
public:
  school();
  const std::map<int, std::vector<std::string>> roster() const;
  void add(std::string name, int grade);
  std::vector<std::string> grade(int) const;

private:
  std::map<int, std::vector<std::string>> _roster;
};

} // namespace grade_school
