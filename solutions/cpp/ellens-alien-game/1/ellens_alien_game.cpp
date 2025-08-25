namespace targets {
class Alien {
public:
  int x_coordinate;
  int y_coordinate;

  Alien(int x, int y) {
    x_coordinate = x;
    y_coordinate = y;
  }

  int get_health() { return health_level; }

  bool hit() {
    if (health_level > 0) {
      --health_level;
    }
    return true;
  }

  bool is_alive() { return health_level > 0; }

  bool teleport(int x_new, int y_new) {
    x_coordinate = x_new;
    y_coordinate = y_new;
    return true;
  }

  bool collision_detection(const Alien &alien) {
    return alien.x_coordinate == this->x_coordinate &&
           alien.y_coordinate == this->y_coordinate;
  }

private:
  int health_level = 3;
};

} // namespace targets
