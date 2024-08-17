def print_board(board):
    for row in board:
        print("|".join(row))
        print("-" * 5)

def get_player_input(player):
    while True:
        try:
            position = int(input(f"Spieler {player}, wähle eine Position (1-9): ")) - 1
            if position in range(9):
                return position
            else:
                print("Bitte eine Zahl zwischen 1 und 9 eingeben.")
        except ValueError:
            print("Ungültige Eingabe. Bitte eine Zahl eingeben.")

def make_move(player, position, board):
    row, col = divmod(position, 3)
    if board[row][col] == ' ':
        board[row][col] = player
    else:
        print("Diese Position ist bereits besetzt. Bitte wähle eine andere.")
        new_position = get_player_input(player)
        make_move(player, new_position, board)

def check_winner(board):
    # Horizontale Linien überprüfen
    for row in board:
        if row[0] == row[1] == row[2] != ' ':
            return row[0]

    # Vertikale Linien überprüfen
    for col in range(3):
        if board[0][col] == board[1][col] == board[2][col] != ' ':
            return board[0][col]

    # Diagonale Linien überprüfen
    if board[0][0] == board[1][1] == board[2][2] != ' ':
        return board[0][0]
    if board[0][2] == board[1][1] == board[2][0] != ' ':
        return board[0][2]

    return None

def play_game():
    board = [
        [' ', ' ', ' '],
        [' ', ' ', ' '],
        [' ', ' ', ' ']
    ]
    current_player = 'X'

    while True:
        print_board(board)
        position = get_player_input(current_player)
        make_move(current_player, position, board)

        winner = check_winner(board)
        if winner:
            print_board(board)
            print(f"Spieler {winner} hat gewonnen!")
            break

        if all(cell != ' ' for row in board for cell in row):
            print_board(board)
            print("Unentschieden!")
            break

        current_player = 'O' if current_player == 'X' else 'X'

play_game()
