class ProductionRemoteControlCar implements RemoteControlCar, Comparable<RemoteControlCar> {
    public int distanceTravelled = 0;
    public int numberOfVictories = 0;
    private final int SPEED;

    public ProductionRemoteControlCar() {
        this.SPEED = 10;
    }

    public ProductionRemoteControlCar(int speed) {
        this.SPEED = speed;
    }

    public void drive() {
        this.distanceTravelled += SPEED;
    }

    public int getDistanceTravelled() {
        return this.distanceTravelled;
    }

    public int getNumberOfVictories() {
        return this.numberOfVictories;
    }

    public void setNumberOfVictories(int numberOfVictories) {
        this.numberOfVictories = numberOfVictories;
    }

    public int compareTo(RemoteControlCar other) {
        return other.getNumberOfVictories() - this.getNumberOfVictories();
    }
}
