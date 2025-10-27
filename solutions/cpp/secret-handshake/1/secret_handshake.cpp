#include "secret_handshake.h"
#include <string>
#include <vector>

namespace secret_handshake {
std::vector<std::string> commands(int code) {
  std::vector<std::string> commands{};
  if ((code & 0b0001) > 0) {
    commands.emplace_back("wink");
  }
  if ((code & 0b0010) > 0) {
    commands.emplace_back("double blink");
  }
  if ((code & 0b0100) > 0) {
    commands.emplace_back("close your eyes");
  }
  if ((code & 0b1000) > 0) {
    commands.emplace_back("jump");
  }
  if ((code & 0b0001'0000) > 0) {
    std::reverse(commands.begin(), commands.end());
  }
  return commands;
}
} // namespace secret_handshake
