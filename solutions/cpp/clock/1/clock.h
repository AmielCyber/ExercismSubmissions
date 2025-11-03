#pragma once

#include <ostream>
#include <string>
namespace date_independent {
class clock {
public:
  static clock at(int hours, int minutes);
  clock plus(int minutes) const;
  operator std::string() const;
  bool operator==(const clock &other) const;
  bool operator!=(const clock &other) const;

protected:
  int _hour;
  int _minute;

private:
  clock(int hour, int minute);
  int wrapped_hours(int negative_hours) const;
  int normalized_hours(int total_minutes) const;
  int normalized_minutes(int total_minutes) const;
};
} // namespace date_independent
