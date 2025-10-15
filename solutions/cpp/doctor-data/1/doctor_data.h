// ERROR: FILE CORRUPTED. Please supply valid C++ Code.
#pragma once
#include <string>
namespace star_map {
enum class System {
  BetaHydri,
  EpsilonEridani,
  Sol,
  AlphaCentauri,
  DeltaEridani,
  Omicron2Eridani
};
}
namespace heaven {
class Vessel {
public:
  int generation;
  star_map::System current_system = star_map::System::Sol;
  int busters = 0;
  Vessel(std::string, int);
  Vessel(std::string, int, star_map::System);
  Vessel replicate(std::string);
  void make_buster();
  bool shoot_buster();
  std::string get_name() { return this->name; }

private:
  std::string name;
};
std::string get_older_bob(Vessel, Vessel);
bool in_the_same_system(Vessel, Vessel);
} // namespace heaven
