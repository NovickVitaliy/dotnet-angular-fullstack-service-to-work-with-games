export enum GameStatus{
  Started = 'Started',
  InProgress = "InProgress",
  Finished = "Finished",
  Abandoned = "Abandoned",
  Desired = "Desired"
}

export const GameStatusToLabelMapping: Record<GameStatus, string> = {
  [GameStatus.Started]: "Started",
  [GameStatus.InProgress]: "InProgress",
  [GameStatus.Finished]: "Finished",
  [GameStatus.Abandoned]: "Abandoned",
  [GameStatus.Desired]: "Desired"
};
