namespace tictactoe;

public class TicTacToeMonolith
{
	public void Start()
	{
		// Игровое поле
		char[,] board = new char[3, 3];

		// Инициализация поля
		for (int row = 0; row < 3; row++)
			for (int col = 0; col < 3; col++)
				board[row, col] = ' ';

		char currentPlayer = 'X';
		bool gameOver = false;
		int movesCount = 0;

		while (!gameOver)
		{
			// Отрисовка поля
			Console.Clear();
			Console.WriteLine("  0 1 2");
			for (int row = 0; row < 3; row++)
			{
				Console.Write(row + " ");
				for (var col = 0; col < 3; col++)
				{
					Console.Write(board[row, col]);
					if (col < 2) Console.Write("|");
				}

				Console.WriteLine();
				if (row < 2) Console.WriteLine("  -----");
			}

			// Ход игрока или ИИ
			if (currentPlayer == 'X')
			{
				// Ход игрока
				bool validMove = false;
				int row = -1, col = -1;

				while (!validMove)
				{
					Console.WriteLine($"Ход игрока {currentPlayer}. Введите строку и столбец через пробел (0 2):");
					string[] input = Console.ReadLine().Split(' ');

					if (input.Length == 2 &&
					    int.TryParse(input[0], out row) &&
					    int.TryParse(input[1], out col) &&
					    row >= 0 && row < 3 &&
					    col >= 0 && col < 3 &&
					    board[row, col] == ' ')
						validMove = true;
					else
						Console.WriteLine("Некорректный ход. Попробуйте снова.");
				}

				board[row, col] = currentPlayer;
			}
			else
			{
				// Ход ИИ (случайный)
				var rand = new Random();
				int row, col;

				do
				{
					row = rand.Next(0, 3);
					col = rand.Next(0, 3);
				} while (board[row, col] != ' ');

				Console.WriteLine($"ИИ делает ход: {row} {col}");
				Thread.Sleep(1000); // Задержка для "раздумий" ИИ

				board[row, col] = currentPlayer;
			}

			movesCount++;

			// Проверка победы
			bool win = false;

			// Проверка строк и столбцов
			for (int x = 0; x < 3; x++)
			{
				if (board[x, 0] == currentPlayer && board[x, 1] == currentPlayer && board[x, 2] == currentPlayer)
					win = true;
				if (board[0, x] == currentPlayer && board[1, x] == currentPlayer && board[2, x] == currentPlayer)
					win = true;
			}

			// Проверка диагоналей
			if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
				win = true;
			if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
				win = true;

			if (win)
			{
				Console.Clear();
				Console.WriteLine($"Игрок {currentPlayer} победил!");
				gameOver = true;
			}
			else if (movesCount == 9)
			{
				Console.Clear();
				Console.WriteLine("Ничья!");
				gameOver = true;
			}
			else
			{
				currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
			}
		}

		// Финальное отображение поля
		Console.WriteLine("  0 1 2");
		for (var row = 0; row < 3; row++)
		{
			Console.Write(row + " ");
			for (var col = 0; col < 3; col++)
			{
				Console.Write(board[row, col]);
				if (col < 2) Console.Write("|");
			}

			Console.WriteLine();
			if (row < 2) Console.WriteLine("  -----");
		}
	}
}