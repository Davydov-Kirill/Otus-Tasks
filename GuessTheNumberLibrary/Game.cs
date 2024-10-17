using GuessTheNumberLibrary.Interfaces;

namespace GuessTheNumberLibrary
{
    public class Game
    {
        private readonly IInputService _inputService;
        private readonly IOutputService _outputService;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IGameSettings _gameSettings;

        private int _targetNumber;

        public Game(IInputService inputService, IOutputService outputService,
            IRandomNumberGenerator randomNumberGenerator, IGameSettings gameSettings)
        {
            _inputService = inputService;
            _outputService = outputService;
            _randomNumberGenerator = randomNumberGenerator;
            _gameSettings = gameSettings;
        }

        public void Start()
        {
            _targetNumber = _randomNumberGenerator.Generate(_gameSettings.StartRange, _gameSettings.EndRange);

            while (_gameSettings.AttemptsCount > 0)
            {
                int guess = _inputService.GetGuess();

                if (guess < _targetNumber)
                {
                    _outputService.NumberLessMessage();
                }
                else if (guess > _targetNumber)
                {
                    _outputService.NumberGreaterMessage();
                }
                else
                {
                    _outputService.SuccessMessage();
                    break;
                }

                _gameSettings.ReduceAttemptsCount();

                if (_gameSettings.AttemptsCount == 0)
                {
                    _outputService.LoseMessage();
                }
            }
        }
    }
}
