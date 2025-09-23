#include <string>
using std::string;

#include "doctor_data.h"
using heaven::Vessel;
using star_map::System;

Vessel::Vessel(string name, int generation)
    : generation(generation), name(name) {}

Vessel::Vessel(string name, int generation, System system)
    : generation(generation), current_system(system), name(name) {}

Vessel Vessel::replicate(string name) {
  return Vessel(name, this->generation + 1);
}

void Vessel::make_buster() { ++this->busters; }

bool Vessel::shoot_buster() {
  if (this->busters > 0) {
    --this->busters;
    return true;
  }
  return false;
}

std::string heaven::get_older_bob(Vessel vessel1, Vessel vessel2) {
  return vessel1.generation < vessel2.generation ? vessel1.get_name()
                                                 : vessel2.get_name();
}

bool heaven::in_the_same_system(Vessel vessel1, Vessel vessel2) {
  return vessel1.current_system == vessel2.current_system;
}
