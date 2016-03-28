#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main()
{
	int lightX; // the X position of the light of power
	int lightY; // the Y position of the light of power
	int thorX; // Thor's starting X position
	int thorY; // Thor's starting Y position
	scanf("%d%d%d%d", &lightX, &lightY, &thorX, &thorY);

	// game loop
	while (42) {
		int remainingTurns;
		scanf("%d", &remainingTurns);

		// Y movement
		if (thorY > lightY)
		{
			printf("N");
			thorY--;
		}
		else if(thorY < lightY)
		{
			printf("S");
			thorY++;
		}

		// X movement
		if (thorX > lightX)
		{
			printf("W");
			thorX--;
		}
		else if(thorX < lightX)
		{
			printf("E");
			thorX++;
		} 
		printf("\n");
	}
	return (0);
}
