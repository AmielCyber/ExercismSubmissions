const INNER_RADIUS = 1;
const INNER_POINTS = 10;
const MID_RADIUS = 5;
const MID_POINTS = 5;
const OUTER_RADIUS = 10;
const OUTER_POINTS = 1;

export function score(x: number, y: number): number {
  const radius = getRadius(x, y);
  if (isInnerCircle(radius))
    return INNER_POINTS;
  if (isMidCircle(radius))
    return MID_POINTS;
  if (isOuterCircle(radius))
    return OUTER_POINTS;
  return 0;
}

function isInnerCircle(radius: number): boolean {
  return radius <= INNER_RADIUS;
}
function isMidCircle(radius: number): boolean {
  return radius <= MID_RADIUS;
}
function isOuterCircle(radius: number): boolean {
  return radius <= OUTER_RADIUS;
}

function getRadius(x: number, y: number): number {
  return Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
}
