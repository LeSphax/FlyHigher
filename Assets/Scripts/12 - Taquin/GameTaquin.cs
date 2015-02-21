//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
namespace AssemblyCSharp
{
		public class GameTaquin : MonoBehaviour
		{

				enum State
				{
						Active,
						Pressed,
						Inactive
				}
				State state;
				public Tile[] board;
				private Tile[,] matrix;
				public int height;
				public int width;
				public GameObject gamesUI;

				Boolean won;
				private Tile currentTile;

				void Start ()
				{
						state = State.Inactive;
						StartCoroutine (InitMatrix ());
				}

				IEnumerator InitMatrix ()
				{
						int i;
						matrix = new Tile[height, width];
						for (i = 0; i < board.Length; i++) {
								board [i].line = i / width;
								board [i].column = i % width;
								matrix [i / width, i % width] = board [i];
						}
						yield return new WaitForSeconds (1);
						StartCoroutine (MixGame ());
				}

				IEnumerator MixGame ()
				{

						int i, numberOfSwaps = 50;
						Vector2 coordinates;
						for (i = 0; i < numberOfSwaps; i++) {
								coordinates = GetRandomEmptyTile ();
								yield return new WaitForSeconds (0.1f);
								SwapWithRandomNonEmptyTile (coordinates);
						}
						state = State.Active;
				}

				private Vector2 GetRandomEmptyTile ()
				{
						System.Random rand = new System.Random ();
						int line = -1, column = 0;
						while (line == -1 || !matrix[line, column].isEmpty) {
								line = rand.Next (0, height);
								column = rand.Next (0, width);
						}
						return new Vector2 (line, column);
				}


				/* Should be given the coordinates of a non Empty Tile as coordinates, it will swap its position with a nearby non empty Tile if possible*/

				private void SwapWithRandomNonEmptyTile (Vector2 coordinates)
				{
						_SwapWithRandomNonEmptyTile (coordinates, 0);
				}

				private void _SwapWithRandomNonEmptyTile (Vector2 coordinates, int times)
				{
						int i;
						times++;
						Vector2 coordinatesOther;
						float lineOrColumn = UnityEngine.Random.Range (0, 2);
						if (lineOrColumn > 0.5f) {
								i = Delta ((int)coordinates.x);
								coordinatesOther.x = coordinates.x + i;
								coordinatesOther.y = coordinates.y;
						} else {
								i = Delta ((int)coordinates.y);
								coordinatesOther.x = coordinates.x;
								coordinatesOther.y = coordinates.y + i;
						}
						if (matrix [(int)coordinatesOther.x, (int)coordinatesOther.y].isEmpty && times < 5) {
								_SwapWithRandomNonEmptyTile (coordinates, times);
						} else {
								SwapTiles (matrix [(int)coordinates.x, (int)coordinates.y], matrix [(int)coordinatesOther.x, (int)coordinatesOther.y]);
						}
				}

				private int Delta (int value)
				{
						int delta;
						if (value == 0)
								delta = 1;
						else if (value == width - 1)
								delta = -1;
						else {
								int rand = UnityEngine.Random.Range (0, 2);
								if (rand <= 0.5f)
										delta = -1;
								else
										delta = 1;
						}
						return delta;
				}

				/* Exchange positions of the Tiles given as parameters */
				public bool SwapTiles (Tile Origin, Tile Arrival)
				{
						int x = Math.Abs (Origin.line - Arrival.line);
						int y = Math.Abs (Origin.column - Arrival.column);
						bool areAdjacent = (x == 1 && y == 0) || (x == 0 && y == 1);
						bool noEmptyTile = !Origin.isEmpty && !Arrival.isEmpty;
						if (!areAdjacent || noEmptyTile) {
								return false;
						} else {
								int line = Origin.line;
								int column = Origin.column;
								Origin.line = Arrival.line;
								Origin.column = Arrival.column;
								Arrival.line = line;
								Arrival.column = column;

								matrix [Arrival.line, Arrival.column] = Arrival;
								matrix [Origin.line, Origin.column] = Origin;
								return true;
						}
				}



				public void PressedOnTile (Tile sender, EventArgs e)
				{
						switch (state) {
						case State.Active:
								state = State.Pressed;
								currentTile = sender;
								currentTile.gameObject.BroadcastMessage ("DisableRenderer", SendMessageOptions.DontRequireReceiver);
								break;
						case State.Pressed:
                    //Impossible
								break;
						case State.Inactive:
								state = State.Inactive;
								break;
						}
				}

				public void ReleasedOnTile (Tile sender, EventArgs e)
				{
						switch (state) {
						case State.Active:
                    //Impossible
								break;
						case State.Pressed:
								state = State.Active;
								currentTile.gameObject.BroadcastMessage ("EnableRenderer", SendMessageOptions.DontRequireReceiver);
								break;
						case State.Inactive:
								state = State.Inactive;
								break;
						}
				}

				public void EnteredTile (Tile sender, EventArgs e)
				{
						switch (state) {
						case State.Active:
								state = State.Active;
								break;
						case State.Pressed:
								state = State.Pressed;
								SwapTiles (currentTile, sender);
								if (won = GameIsWon ()) {
										state = State.Inactive;
										gamesUI.BroadcastMessage ("GameEnded", 2);
								}
								break;
						case State.Inactive:
								state = State.Inactive;
								break;
						}
				}

				bool GameIsWon ()
				{
						int i;
						for (i = 0; i < board.Length; i++) {
								if (matrix [i / width, i % width] != board [i] && board [i].isEmpty == false) {
										return false;
								}
						}
						return true;
				}
		}
}

