#include "clock.h"
#include <iomanip>
#include <sstream>

namespace date_independent {
clock clock::at(int hours, int minutes) { return clock(hours, minutes); }

clock clock::plus(int minutes) const { return clock(_hour, _minute + minutes); }

clock::operator std::string() const {
  std::stringstream ss;
  ss << std::setw(2) << std::setfill('0') << _hour << ':';
  ss << std::setw(2) << std::setfill('0') << _minute;

  return ss.str();
}

bool clock::operator==(const clock &other) const {
  return _hour == other._hour && _minute == other._minute;
}

bool clock::operator!=(const clock &other) const {
  return _hour != other._hour || _minute != other._minute;
}

clock::clock(int hours, int minutes) {
  int total_minutes = hours * 60 + minutes;
  _hour = normalized_hours(total_minutes);
  _minute = normalized_minutes(total_minutes);
}

int clock::normalized_hours(int total_minutes) const {
  int hours = total_minutes / 60;
  if (total_minutes < 0) {
    hours = wrapped_hours(hours);
    if (total_minutes % 60 == 0) {
      // Don't start at 23 hours since minutes is 0.
      hours++;
    }
  }
  hours %= 24;
  return hours;
}

int clock::wrapped_hours(int negative_hours) const {
  return negative_hours % 24 + 23;
}

int clock::normalized_minutes(int total_minutes) const {
  int minutes = total_minutes % 60;
  if (minutes < 0) {
    minutes = 60 + minutes;
  }
  return minutes;
}

} // namespace date_independent
