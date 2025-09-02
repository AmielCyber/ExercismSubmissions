#pragma once

namespace space_age {
class space_age {
public:
  space_age(int long);
  double seconds() const;
  double on_earth() const;
  double on_mercury() const;
  double on_venus() const;
  double on_mars() const;
  double on_jupiter() const;
  double on_saturn() const;
  double on_uranus() const;
  double on_neptune() const;

private:
  long earth_year_in_sec = 31557600;
  long age_in_seconds;
};

} // namespace space_age
