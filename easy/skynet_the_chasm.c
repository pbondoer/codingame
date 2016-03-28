#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main()
{
	int road; // the length of the road before the gap.
	int gap; // the length of the gap.
	int platform; // the length of the landing platform.

	// read inputs
	scanf("%d", &road);
	scanf("%d", &gap);
	scanf("%d", &platform);

	// game loop
	while (42) {
		int speed; // the motorbike's speed.
		int coordX; // the position on the road of the motorbike.

		scanf("%d", &speed);
		scanf("%d", &coordX);

		// break if we have jumped
		if (road < 0)
		{
			printf("SLOW\n");
			speed--;
			continue;
		}

		// adjust speed
		if (speed > gap + 1)
		{
			printf("SLOW\n");
			speed--;
		}
		else if (speed < gap + 1)
		{
			printf("SPEED\n");
			speed++;
		}
		else
		{
			if (road == 1)
				printf("JUMP\n");
			else
				printf("WAIT\n");
		}
		road -= speed;
	}

	return (0);
}
