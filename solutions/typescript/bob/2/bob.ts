export function hey(message: string): string {
  message = message.trim();
  if (isSilence(message))
    return SILENCE_REPLY;
  if (isYelling(message)) {
    if (isQuestion(message))
      return YELLING_QUESTION_REPLY;
    else
      return YELLING_REPLY;
  }
  if (isQuestion(message))
    return QUESTION_REPLY;
  return DEFAULT_REPLY;
}

const SILENCE_REPLY = "Fine. Be that way!";
const YELLING_QUESTION_REPLY = "Calm down, I know what I'm doing!";
const YELLING_REPLY = "Whoa, chill out!";
const QUESTION_REPLY = "Sure.";
const DEFAULT_REPLY = "Whatever.";

function isYelling(message: string): boolean {
  return /[A-Z]+/.test(message) && message.toUpperCase() === message;
}

function isQuestion(message: string): boolean {
  return message.endsWith('?');
}

function isSilence(message: string): boolean {
  return message === "";
}

