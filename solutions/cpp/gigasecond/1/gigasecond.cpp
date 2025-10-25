#include "gigasecond.h"
using namespace boost::posix_time;
namespace gigasecond {
    ptime advance(ptime time){
        return time + seconds(1'000'000'000);
    }
}  // namespace gigasecond
