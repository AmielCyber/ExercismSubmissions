public class Lasagna {
  private final int EXPECTED_MINS_IN_OVEN = 40;
  private final int LAYER_PREPERATION_TIME = 2;

  public int expectedMinutesInOven() {
    return this.EXPECTED_MINS_IN_OVEN;
  }

  public int remainingMinutesInOven(int minLapse) {
    var remainingMins = this.EXPECTED_MINS_IN_OVEN - minLapse;
    return remainingMins > 0 ? remainingMins : 0;
  }

  public int preparationTimeInMinutes(int layers) {
    return layers < 1 ? 0 : LAYER_PREPERATION_TIME * layers;
  }

  public int totalTimeInMinutes(int layers, int minsInOven) {
    return minsInOven + this.preparationTimeInMinutes(layers);
  }
}
