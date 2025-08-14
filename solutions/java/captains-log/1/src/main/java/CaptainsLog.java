import java.util.Random;

class CaptainsLog {

  private static final char[] PLANET_CLASSES = new char[] { 'D', 'H', 'J', 'K', 'L', 'M', 'N', 'R', 'T', 'Y' };
  private final int UPPER_LIMIT = PLANET_CLASSES.length;
  private static final int START_DATE_MIN = 41_000;
  private static final int START_DATE_UPPER_LIMIT = 42_000;
  private static final int REGISTRY_MIN = 1_000;
  private static final int REGISTRY_UPPER_LIMIT = 10_000;

  private Random random;

  CaptainsLog(Random random) {
    this.random = random;
  }

  char randomPlanetClass() {
    return PLANET_CLASSES[this.random.nextInt(UPPER_LIMIT)];
  }

  String randomShipRegistryNumber() {
    return String.format("NCC-%d", getRandomShipRegistryNumber());
  }

  double randomStardate() {
    return this.random.nextDouble(START_DATE_MIN, START_DATE_UPPER_LIMIT);
  }

  private int getRandomShipRegistryNumber() {
    return this.random.nextInt(REGISTRY_MIN, REGISTRY_UPPER_LIMIT);
  }
}
