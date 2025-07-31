const Code = {
  WINK: 0b00001,
  DOUBLE_BLINK: 0b00010,
  CLOSE_EYES: 0b00100,
  JUMP: 0b01000,
  REVERSE: 0b10000,
}

const codes = [Code.WINK, Code.DOUBLE_BLINK, Code.CLOSE_EYES, Code.JUMP];

export function commands(num: number): string[] {
  const command: string[] = [];
  for (const code of codes) {
    if ((code & num) !== 0)
      command.push(getMessageCode(code));
  }
  if ((num & Code.REVERSE) !== 0)
    command.reverse();
  return command;
}

function getMessageCode(code: number): string {
  switch (code) {
    case Code.WINK:
      return "wink";
    case Code.DOUBLE_BLINK:
      return "double blink";
    case Code.CLOSE_EYES:
      return "close your eyes";
    case Code.JUMP:
      return "jump";
    default:
      throw new Error(`Invalid code number: ${code}`);
  }
}

